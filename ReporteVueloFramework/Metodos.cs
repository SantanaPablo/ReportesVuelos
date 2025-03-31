using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfiumViewer;

namespace ReporteVueloFramework
{
    public class Metodos
    {
        // Propiedades comunes reutilizables
        private BaseFont fuenteBase;
        private BaseFont fuenteTripulantes;
        private float tripulacionYInicial = 652;
        private float tripulacionXInicial = 111;
        private int maxLineasPorColumna = 6;
        private float tamanoFuenteBase = 12;
        private float tamanoFuenteTripulantes = 8;

        // Constructor para inicializar las propiedades
        public Metodos()
        {
            // Establecer la fuente una sola vez
            fuenteBase = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            fuenteTripulantes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        }

        // Función para cargar un vuelo en el visor PDF
        public void CargarPdfConVuelo(Vuelo vuelo, string existingPdfPath, PdfViewer pdfViewer)
        {
            if (vuelo != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (PdfReader pdfReader = new PdfReader(existingPdfPath))
                    {
                        using (PdfStamper pdfStamper = new PdfStamper(pdfReader, ms))
                        {
                            PdfContentByte pdfContentByte = pdfStamper.GetOverContent(1);
                            pdfContentByte.SetFontAndSize(fuenteBase, tamanoFuenteBase);

                            // Colocar datos del vuelo
                            AgregarDatosVuelo(pdfContentByte, vuelo);
                            pdfContentByte.SetFontAndSize(fuenteBase, tamanoFuenteTripulantes);
                            // Colocar tripulación
                            AgregarTripulacion(pdfContentByte, vuelo);

                            pdfContentByte.EndText();
                        }
                    }

                    // Recargar PDF modificado en el visor
                    CargarPdfEnVisor(pdfViewer, ms);
                }
            }
        }

        // Función para imprimir todos los vuelos en un PDF
        public void PrintAll(List<Vuelo> listaVuelos, PdfViewer pdfViewer)
        {
            if (listaVuelos.Count > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document document = new Document())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(document, ms);
                        document.Open();

                        foreach (var vuelo in listaVuelos)
                        {
                            PdfContentByte pdfContentByte = writer.DirectContent;
                            document.NewPage();
                            pdfContentByte.SetFontAndSize(fuenteBase, tamanoFuenteBase);

                            // Colocar datos del vuelo
                            AgregarDatosVuelo(pdfContentByte, vuelo);
                            pdfContentByte.SetFontAndSize(fuenteBase, tamanoFuenteTripulantes);
                            // Colocar tripulación
                            AgregarTripulacion(pdfContentByte, vuelo);

                            pdfContentByte.EndText();
                        }

                        document.Close();
                    }

                    // Cargar el PDF en el visor
                    CargarPdfEnVisor(pdfViewer, ms);
                }
            }
            else
            {
                MessageBox.Show("No hay vuelos cargados para imprimir.");
            }
        }

        // Función para imprimir un solo vuelo
        public void PrintOne(List<Vuelo> listaVuelos, PdfViewer pdfViewer, int currentFlightIndex)
        {
            if (listaVuelos.Count > 0 && currentFlightIndex >= 0 && currentFlightIndex < listaVuelos.Count)
            {
                Vuelo vueloSeleccionado = listaVuelos[currentFlightIndex];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document document = new Document())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(document, ms);
                        document.Open();
                        PdfContentByte pdfContentByte = writer.DirectContent;
                        document.NewPage();
                        pdfContentByte.SetFontAndSize(fuenteBase, tamanoFuenteBase);

                        // Colocar datos del vuelo
                        AgregarDatosVuelo(pdfContentByte, vueloSeleccionado);
                        pdfContentByte.SetFontAndSize(fuenteBase, tamanoFuenteTripulantes);
                        // Colocar tripulación
                        AgregarTripulacion(pdfContentByte, vueloSeleccionado);

                        pdfContentByte.EndText();
                        document.Close();
                    }

                    CargarPdfEnVisor(pdfViewer, ms);
                }

            }
            else
            {
                MessageBox.Show("No hay vuelos cargados para imprimir.");
            }
        }

        // Función reutilizada para agregar los datos del vuelo
        private void AgregarDatosVuelo(PdfContentByte pdfContentByte, Vuelo vuelo)
        {
            pdfContentByte.BeginText();
            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.CodigoVuelo, 237, 753, 0); // Número de vuelo
            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Origen, 84, 725, 0); // Origen
            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Destino, 443, 725, 0); // Destino
            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Matricula, 444, 753, 0); // Matrícula
            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.FechaVuelo.ToString(), 320, 753, 0); // Fecha de vuelo
        }

        // Función reutilizada para agregar la tripulación
        private void AgregarTripulacion(PdfContentByte pdfContentByte, Vuelo vuelo)
        {
            float tripulacionY = tripulacionYInicial;
            float tripulacionX = tripulacionXInicial;
            int currentLine = 0;

            // Procesar roles prioritarios
            var rolesPrioritarios = new[] { "CP", "FO", "CM" };
            var restantes = new List<Tripulante>();

            foreach (var rol in rolesPrioritarios)
            {
                var tripulantesRol = vuelo.Tripulacion.Where(t => t.Rol == rol).ToList();

                if (tripulantesRol.Count > 0)
                {
                    // Imprimir el primer tripulante
                    var tripulante = tripulantesRol[0];
                    pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{tripulante.Legajo}", tripulacionX, tripulacionY, 0);
                    pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{tripulante.Nombre}", tripulacionX + 45, tripulacionY, 0);
                }
                else
                {
                    // Reservar la línea en blanco si el rol prioritario no está presente
                    pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", tripulacionX, tripulacionY, 0);
                    pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", tripulacionX + 45, tripulacionY, 0);
                }

                // Mover hacia abajo para la siguiente posición reservada
                tripulacionY -= 14;
                currentLine++;

                // Manejo de líneas y columnas
                if (currentLine >= maxLineasPorColumna)
                {
                    tripulacionY = tripulacionYInicial - (14 * 3);
                    tripulacionX += 100;
                    currentLine = 3;
                }

                // Imprimir tripulantes adicionales del mismo rol
                float extraTripulanteX = 323;
                for (int i = 1; i < tripulantesRol.Count; i++)
                {
                    var tripulante = tripulantesRol[i];
                    pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{tripulante.Legajo}", extraTripulanteX, tripulacionY + 14, 0);
                    pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{tripulante.Nombre}", extraTripulanteX + 48, tripulacionY + 14, 0);
                }
            }

            // Procesar otros roles
            var otrosTripulantes = vuelo.Tripulacion.Where(t => !rolesPrioritarios.Contains(t.Rol)).ToList();
            restantes.AddRange(otrosTripulantes);

            foreach (var tripulante in restantes)
            {
                pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{tripulante.Legajo}", tripulacionX, tripulacionY, 0);
                pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{tripulante.Nombre}", tripulacionX + 48, tripulacionY, 0);

                tripulacionY -= 14;
                currentLine++;

                if (currentLine >= maxLineasPorColumna)
                {

                    if (currentLine >= maxLineasPorColumna)
                    {
                        // Cambia `tripulacionY` para que empiece en la cuarta línea
                        tripulacionY = tripulacionYInicial - (14 * 3);
                        tripulacionX = 323;  // Mueve a la segunda columna
                        currentLine = 2; // Empezar desde la posición en la cuarta línea
                    }
                }
            }
        }

        // Función para cargar un PDF en el visor
        private void CargarPdfEnVisor(PdfViewer pdfViewer, MemoryStream ms)
        {
            byte[] pdfBytes = ms.ToArray();
            var stream = new MemoryStream(pdfBytes);
            PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(stream);
            pdfViewer.Document = pdfDocument;
        }

    }


    public class FlightManager
    {
        private List<Vuelo> vuelos = new List<Vuelo>();

        public List<Vuelo> CargarVuelos(string filePath)
        {
            // Validate if the file is a CSV file
            if (Path.GetExtension(filePath).ToLower() != ".csv")
            {
                MessageBox.Show("El archivo seleccionado no es un archivo CSV.");
                return vuelos;
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ",",
                BadDataFound = null,
            }))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    var recordDict = (IDictionary<string, object>)record;
                    var values = recordDict.Values.Select(v => v.ToString()).ToArray();

                    // Validate the format of the flight string
                    if (!values[8].StartsWith("LV"))
                    {
                        MessageBox.Show($"Formato de fila incorrecto: {values[8]}. El dato debe empezar con la matrícula.");
                        return vuelos;
                    }

                    if (values[8][5] != ' ')
                    {
                        MessageBox.Show($"Formato de fila incorrecto: {values[8]}. Revisar el formato de los datos.");
                        return vuelos;
                    }

                    try
                    {
                        // Split the flight details by spaces
                        var flightDetails = values[8].Split(' ');

                        if (flightDetails.Length < 6)
                        {
                            MessageBox.Show("Error: Formato de datos insuficiente.");
                            return vuelos;
                        }

                        // Process flight details
                        string matricula = flightDetails[0].Substring(2); // Eliminar "LV"
                        string codigoVuelo = flightDetails[1]; // Código de vuelo
                        string origen = flightDetails[2]; // Origen
                        string fecha = flightDetails[3]; // Fecha
                        string horaSalida = flightDetails[4]; // Hora de salida
                        string destino = flightDetails[5]; // Destino

                        // Check if flight already exists
                        Vuelo vuelo = vuelos.FirstOrDefault(v => v.CodigoVuelo == codigoVuelo);
                        if (vuelo == null)
                        {
                            // Create a new flight
                            vuelo = new Vuelo
                            {
                                CodigoVuelo = codigoVuelo,
                                FechaVuelo = fecha,
                                Origen = origen,
                                HoraSalida = horaSalida,
                                Destino = destino,
                                Matricula = matricula
                            };

                            vuelos.Add(vuelo);
                        }

                        // Process crew details
                        string rol = values[11];
                        string tipo = (rol == "CP" || rol == "FO") ? "F" : "C";
                        string operacion = values[12];
                        string nombre = values[13];
                        string legajo = values[14];

                        // Check if the crew member already exists for this flight
                        bool crewExists = vuelo.Tripulacion.Any(t => t.Legajo == legajo && t.Rol == rol);
                        if (!crewExists)
                        {
                            // Add the crew member only if they don't already exist
                            Tripulante tripulante = new Tripulante(tipo, legajo, operacion, rol, nombre);
                            vuelo.Tripulacion.Add(tripulante);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error procesando la fila: {ex.Message}");
                    }
                }

                MessageBox.Show("CSV cargado exitosamente.");
                return vuelos;
            }
        }
    }
    // Función para medir el ancho del texto



}
