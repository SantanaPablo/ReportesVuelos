using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PdfiumViewer;
using System.IO;
using Org.BouncyCastle.Utilities;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Linq;



namespace ReporteVueloFramework
{
    public partial class Form1 : Form

    {
        private FlightManager flightManager = new FlightManager();
        private List<Vuelo> listaVuelos = new List<Vuelo>();
        private Vuelo vuelo = new Vuelo();
        string existingPdfPath = @"Recursos\\rev2.pdf";
        string rutaCsvDestino = @"Recursos\\Destino.csv";
        private int currentFlightIndex = 0; // Índice para navegar entre los vuelos
        private Metodos metodos = new Metodos();
        private declaMetodos declametodos = new declaMetodos();



        // Control PdfViewer para mostrar el PDF


        public Form1()
        {
            InitializeComponent();
            pnlPDF.BackgroundImageLayout = ImageLayout.Zoom;
            ActualizarContador();
            CargarPdf();
        }
        private void ActualizarContador()
        {
            if (listaVuelos.Count > 0)
            {
                lblCantReportes.Text = $"{currentFlightIndex + 1} de {listaVuelos.Count} reportes";
                lblMensaje.Text = "Archivo: Reportes generados con éxito";
            }
            else
            {
                lblCantReportes.Text = $"0 de {listaVuelos.Count} reportes";
            }
        }

       

        private void CargarPdf()
        {
            if (listaVuelos.Count == 0)
            {
                // Cargar el PDF en el visor
                byte[] bytes = System.IO.File.ReadAllBytes(existingPdfPath);
                var stream = new MemoryStream(bytes);
                PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(stream);
                pdfViewer1.Document = pdfDocument;
                pdfViewer1.Dock = DockStyle.Fill;
            }
            else
            {
            }


        }

        private void btnCargarCSV_Click(object sender, EventArgs e)
        {

            // Open a file dialog to select the CSV file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Title = "Selecciona el archivo CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Call the CargarVuelos method to load flights from the CSV
                        listaVuelos.Clear();
                        listaVuelos = flightManager.CargarVuelos(filePath);
                        currentFlightIndex = 0; // Reiniciar el índice al primero
                        ActualizarContador();
                        ActualizarComboBox(); // Populate the ComboBox with loaded flights

                        // Mostrar el primer vuelo
                        if (listaVuelos.Count > 0)
                        {
                            metodos.CargarPdfConVuelo(listaVuelos[currentFlightIndex], existingPdfPath, pdfViewer1);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("No se puede acceder al archivo CSV porque está abierto en otro programa. Por favor, cierre el archivo e inténtelo de nuevo.",
                                        "Error de acceso al archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al cargar el archivo CSV. Por favor, inténtelo de nuevo.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        // Navegar al vuelo anterior
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (currentFlightIndex > 0)
            {
                currentFlightIndex--;
                metodos.CargarPdfConVuelo(listaVuelos[currentFlightIndex], existingPdfPath, pdfViewer1);
                ActualizarContador();
                cmbReportes.SelectedIndex = currentFlightIndex;
            }
        }

        // Navegar al vuelo siguiente
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (currentFlightIndex < listaVuelos.Count - 1)
            {
                currentFlightIndex++;
                metodos.CargarPdfConVuelo(listaVuelos[currentFlightIndex], existingPdfPath, pdfViewer1);
                ActualizarContador();
                cmbReportes.SelectedIndex = currentFlightIndex;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Limpiar lista?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                listaVuelos.Clear();
                currentFlightIndex = 0; // Reiniciar el índice al primero
                MessageBox.Show("Todos los reportes borrados");
                ActualizarContador();
                ActualizarComboBox();
                lblMensaje.Text = "Archivo CSV: Ningún archivo cargado";
                CargarPdf();
            }
           

        }

        private void ActualizarComboBox()
        {
            cmbReportes.Items.Clear();
            foreach (var vuelo in listaVuelos)
            {
                cmbReportes.Items.Add(vuelo.CodigoVuelo); // Or other flight property you want to display
            }

            if (cmbReportes.Items.Count > 0)
            {
               
                cmbReportes.SelectedIndex = 0; // Optionally select the first item by default
            }
        }

        // Event handler for when the selected flight changes
        private void CmbReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReportes.SelectedIndex >= 0)
            {
                currentFlightIndex = cmbReportes.SelectedIndex;
                metodos.CargarPdfConVuelo(listaVuelos[currentFlightIndex], existingPdfPath, pdfViewer1);
                ActualizarContador();
            }
        }

        private void cmbReportes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevent the default ComboBox behavior on Enter key
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            metodos.PrintAll(listaVuelos, pdfViewer1);
        }

        private void btnPrintOne_Click(object sender, EventArgs e)
        {
            metodos.PrintOne(listaVuelos, pdfViewer1, currentFlightIndex);

        }

        private void btnPrevisualizar_Click(object sender, EventArgs e)
        {

            // Mostrar el primer vuelo
            if (listaVuelos.Count > 0)
            {
                metodos.CargarPdfConVuelo(listaVuelos[currentFlightIndex], existingPdfPath, pdfViewer1);
                ActualizarContador();
                cmbReportes.SelectedIndex = currentFlightIndex;

            }
            else
            {
                MessageBox.Show("No hay vuelos cargados para previsualizar.");
            }
        }


        private void btnGenDecla_Click(object sender, EventArgs e)
        {
            if (listaVuelos == null || listaVuelos.Count == 0)
            {
                MessageBox.Show("La lista de vuelos está vacía o no se pudo cargar. No se puede generar la declaración.", "Error de lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var (esValido, ciudad, pais) = declametodos.VerificarDestino(listaVuelos[currentFlightIndex].Destino, rutaCsvDestino);
            if (esValido)
            {
                FormDecla formDecla = new FormDecla(listaVuelos[currentFlightIndex], ciudad, pais);
                formDecla.ShowDialog();
            }
            else
            {
                MessageBox.Show("El destino del vuelo no es válido. No se puede generar la declaración.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
