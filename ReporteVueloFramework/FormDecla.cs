using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReporteVueloFramework
{
    public partial class FormDecla : Form
    {
        private List<TripulanteDecla> tripulantes = new List<TripulanteDecla>();
        private Vuelo vuelo = null;
        string existingPdfPath = @"Recursos\\DeclaVacia.pdf";
        string rutaCsvPilotos = @"Recursos\\Pilotos.csv";
        string rutaCsvTcp = @"Recursos\\TCP.csv";
        string rutaCsvAutorizantes = @"Recursos\\Autorizantes.csv";
        private List<(string Nombre, string Detalle)> autorizantes;
        string autorizante;
        string ciudad;
        string pais;

        private declaMetodos declametodos = new declaMetodos();
        public FormDecla()
        {
            InitializeComponent();
        }

        public FormDecla(Vuelo vuelo, string ciudad, string pais)
        {
            InitializeComponent();
            this.vuelo = vuelo;
            pnlPDF.BackgroundImageLayout = ImageLayout.Zoom;
            this.ciudad = ciudad;
            this.pais = pais;
            lblCantReportes.Text = vuelo.CodigoVuelo;

            autorizantes = declametodos.CargarAutorizantes(rutaCsvAutorizantes);
            cmbAutorizantes.DataSource = autorizantes.Select(a => a.Nombre).ToList();
            autorizante = $"{autorizantes[0].Nombre} - {autorizantes[0].Detalle}";

            tripulantes = declametodos.CargarTripulantesConDatosAdicionales(vuelo.Tripulacion, rutaCsvPilotos, rutaCsvTcp);
            declametodos.CargarPdfDecla(vuelo, existingPdfPath, pdfViewer1, tripulantes, ciudad, pais, autorizante);

            cmbAutorizantes.SelectedIndexChanged += CmbAutorizantes_SelectedIndexChanged;
        }

        // Evento para actualizar "nombre - detalle"
        private void CmbAutorizantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbAutorizantes.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < autorizantes.Count)
            {
                var autorizanteSeleccionado = autorizantes[selectedIndex];
                autorizante = $"{autorizanteSeleccionado.Nombre} - {autorizanteSeleccionado.Detalle}";

                // Recargar el PDF con el nuevo autorizante seleccionado
                declametodos.CargarPdfDecla(vuelo, existingPdfPath, pdfViewer1, tripulantes, this.ciudad, this.pais, autorizante);
            }
        }


        private void btnAgregarTripulante_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text;

            if (string.IsNullOrWhiteSpace(legajo))
            {
                MessageBox.Show("No se encontró el tripulante con el legajo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el legajo ya existe en la lista de tripulantes
            if (tripulantes.Any(t => t.Legajo == legajo))
            {
                MessageBox.Show("El tripulante ya está en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar tripulante en los archivos CSV
            TripulanteDecla nuevoTripulante = declametodos.BuscarTripulantePorLegajo(legajo, rutaCsvPilotos, rutaCsvTcp);

            if (nuevoTripulante != null)
            {
                // Preguntar al usuario si desea agregar al tripulante encontrado
                DialogResult resultado = MessageBox.Show($"¿Desea agregar a {nuevoTripulante.Nombre} a la lista?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Insertar el tripulante en la posición adecuada según su rol
                    if (nuevoTripulante.Rol == "CTE")
                    {
                        tripulantes.Insert(0, nuevoTripulante); // Insertar en la primera posición
                    }
                    else if (nuevoTripulante.Rol == "1ER OFIC")
                    {
                        // Buscar el índice después del último "CTE"
                        int index = tripulantes.FindLastIndex(t => t.Rol == "CTE");
                        if (index != -1)
                        {
                            tripulantes.Insert(index + 1, nuevoTripulante); // Insertar después del último "CTE"
                        }
                        else
                        {
                            tripulantes.Insert(0, nuevoTripulante); // Insertar en el inicio si no hay "CTE"
                        }
                    }
                    else
                    {
                        tripulantes.Add(nuevoTripulante); // Agregar al final para otros roles
                    }

                    MessageBox.Show("Tripulante agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    declametodos.CargarPdfDecla(vuelo, existingPdfPath, pdfViewer1, tripulantes, vuelo.Destino, "", autorizante);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el tripulante con el legajo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Limpiar el cuadro de texto
            txtLegajo.Clear();
        }
    }
}
