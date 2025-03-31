using iTextSharp.text.pdf;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReporteVueloFramework
{
    public class declaMetodos
    {

        public (bool esValido, string ciudad, string pais) VerificarDestino(string destino, string rutaCsvDestino)
        {
            var datosDestinos = CargarDatosDesdeCsv(rutaCsvDestino);
            var datosDestino = datosDestinos.FirstOrDefault(d => d[0] == destino);

            if (datosDestino != null)
            {
                return (true, datosDestino[1], datosDestino[2]);
            }

            return (false, null, null);
        }
        public List<TripulanteDecla> CargarTripulantesConDatosAdicionales(List<Tripulante> tripulantes, string rutaCsvPilotos, string rutaCsvTcp)
        {
            var tripulantesDecla = new List<TripulanteDecla>();

            // Cargar datos de los CSV
            var datosPilotos = CargarDatosDesdeCsv(rutaCsvPilotos);
            var datosTcp = CargarDatosDesdeCsv(rutaCsvTcp);

            foreach (var tripulante in tripulantes)
            {
                List<string> datosAdicionales = null;

                // Buscar los datos en el CSV correspondiente según el tipo
                if (tripulante.Tipo == "F")
                {
                    datosAdicionales = datosPilotos.FirstOrDefault(d => d[0] == tripulante.Legajo);
                }
                else if (tripulante.Tipo == "C")
                {
                    datosAdicionales = datosTcp.FirstOrDefault(d => d[0] == tripulante.Legajo);
                }

                if (datosAdicionales != null)
                {
                    // Concatenar el apellido y nombre de las columnas B y C
                    string nombreCompleto = $"{datosAdicionales[1]} {datosAdicionales[2]}";
                    // Columna D para el rol
                    string rol = datosAdicionales[3];

                    var tripulanteDecla = new TripulanteDecla(
                        tripulante.Tipo,
                        tripulante.Legajo,
                        tripulante.Operacion,
                        rol,
                        nombreCompleto)
                    {
                        fechaNacimiento = DateTime.Parse(datosAdicionales[4]),
                        dni = datosAdicionales[6],
                        nacionalidad = datosAdicionales[7]
                    };

                    tripulantesDecla.Add(tripulanteDecla);
                }
            }

            return tripulantesDecla;
        }

        private List<List<string>> CargarDatosDesdeCsv(string rutaCsv)
        {
            var datos = new List<List<string>>();

            try
            {
                foreach (var linea in File.ReadLines(rutaCsv))
                {
                    var columnas = linea.Split(';').ToList();
                    datos.Add(columnas);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"No se puede acceder al archivo CSV en {rutaCsv} porque está siendo usado por otro programa. Cierra el archivo e intenta de nuevo.",
                                "Error de acceso al archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar cargar el archivo CSV: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datos;
        }
        public void CargarPdfDecla(Vuelo vuelo, string pdfPath, PdfViewer pdfViewer, List<TripulanteDecla> tripulantedecla, string ciudad, string pais, string autorizante)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfReader pdfReader = new PdfReader(pdfPath))
                {
                    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, ms))
                    {
                        PdfContentByte pdfContentByte = pdfStamper.GetOverContent(1);

                        // Aquí podrías agregar contenido o modificaciones al PDF
                        // Ejemplo: Agregar texto u otros elementos


                        pdfContentByte.BeginText();
                        pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Matricula, 234, 660, 0);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.CodigoVuelo, 415, 660, 0);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.FechaVuelo, 526, 660, 0);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "AEROPARQUE- ARGENTINA", 100, 640, 0);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{ciudad} - {pais}", 424, 640, 0);

                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Origen, 67, 507, 0);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Destino, 67, 453, 0);


                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Origen, 450, 555, 0);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, vuelo.Destino, 450, 470, 0);

                        

                        //Tripulacion
                        //int tripulacionx = 100;
                        //int tripulaciony = 568;

                        //pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 8);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[0].Rol, tripulacionx, tripulaciony, 0);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[0].Nombre, tripulacionx+36, tripulaciony, 0);

                        //pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 7);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[0].fechaNacimiento.ToString(), tripulacionx, tripulaciony-10, 0);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"DNI {tripulantedecla[0].dni}", tripulacionx+80, tripulaciony-10, 0);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"LEG. {tripulantedecla[0].Legajo}", tripulacionx + 140, tripulaciony - 10, 0);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[0].nacionalidad, tripulacionx + 186, tripulaciony - 10, 0);

                        //pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 8);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[1].Rol, tripulacionx, tripulaciony, 0);
                        //pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[1].Nombre, tripulacionx+36, tripulaciony-22, 0);

                        int tripulacionX = 100;
                        int tripulacionY = 568;
                        int spacingY = 22; // Espacio vertical entre tripulantes

                        pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 8);

                        for (int i = 0; i < tripulantedecla.Count; i++)
                        {
                            // Calcula la posición Y para cada tripulante
                            int offsetY = tripulacionY - (i * spacingY);

                            // Información principal del tripulante (Rol y Nombre)
                            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[i].Rol, tripulacionX, offsetY, 0);
                            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[i].Nombre, tripulacionX + 42, offsetY, 0);

                            // Información secundaria (fecha de nacimiento, DNI, Legajo, nacionalidad)
                            pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 7);
                            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[i].fechaNacimiento.ToString("dd/MM/yyyy"), tripulacionX, offsetY - 10, 0);
                            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"DNI {tripulantedecla[i].dni}", tripulacionX + 80, offsetY - 10, 0);
                            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"LEG. {tripulantedecla[i].Legajo}", tripulacionX + 140, offsetY - 10, 0);
                            pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tripulantedecla[i].nacionalidad, tripulacionX + 186, offsetY - 10, 0);

                            // Restablece el tamaño de la fuente para el siguiente tripulante
                            pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 8);
                        }

                        pdfContentByte.SetFontAndSize(BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 7);
                        pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, autorizante, 410, 65, 0);


                        pdfContentByte.EndText();
                    }
                }

                // Recargar el PDF modificado en el visor
                CargarPdfEnVisor(pdfViewer, ms);
            }
        }

        // Método auxiliar para cargar el PDF en el visor
        private void CargarPdfEnVisor(PdfViewer pdfViewer, MemoryStream ms)
        {
            byte[] pdfBytes = ms.ToArray();
            var stream = new MemoryStream(pdfBytes);
            PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(stream);
            pdfViewer.Document = pdfDocument;
        }


        // Método para buscar tripulante en los CSV
        public TripulanteDecla BuscarTripulantePorLegajo(string legajo, string rutaCsvPilotos, string rutaCsvTcp)
        {
            // Carga los datos de los CSV
            var datosPilotos = CargarDatosDesdeCsv(rutaCsvPilotos);
            var datosTcp = CargarDatosDesdeCsv(rutaCsvTcp);

            // Buscar en CSV de Pilotos
            var datosAdicionales = datosPilotos.FirstOrDefault(d => d[0] == legajo);

            if (datosAdicionales == null)
            {
                // Si no se encontró en Pilotos, busca en TCP
                datosAdicionales = datosTcp.FirstOrDefault(d => d[0] == legajo);
            }

            if (datosAdicionales != null)
            {
                string nombreCompleto = $"{datosAdicionales[1]} {datosAdicionales[2]}";
                string rol = datosAdicionales[3];

                return new TripulanteDecla("TipoDesconocido", legajo, "OperacionDesconocida", rol, nombreCompleto)
                {
                    fechaNacimiento = DateTime.Parse(datosAdicionales[4]),
                    dni = datosAdicionales[6],
                    nacionalidad = datosAdicionales[7]
                };
            }

            return null;
        }
        public List<(string Nombre, string Detalle)> CargarAutorizantes(string rutaCsv)
        {
            List<(string Nombre, string Detalle)> autorizantes = new List<(string Nombre, string Detalle)>();

            using (var reader = new StreamReader(rutaCsv))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (values.Length >= 3)
                    {
                        autorizantes.Add((values[1], values[2])); // Nombre y Detalle
                    }
                }
            }
            return autorizantes;
        }


    }
}
