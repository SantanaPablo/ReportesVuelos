using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using PdfiumViewer;
using System;

namespace ReporteVueloFramework
{
    public class CustomPdfViewer : PdfViewer
    {


        public CustomPdfViewer()
        {
            // Llama al constructor para que se cargue el control base
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Usa Reflection para acceder al ToolStrip privado
            var toolStripField = typeof(PdfViewer).GetField("_toolStrip", BindingFlags.NonPublic | BindingFlags.Instance);
            if (toolStripField != null)
            {
                var toolStrip = (ToolStrip)toolStripField.GetValue(this);

                // Modificar propiedades como el color de fondo
                toolStrip.BackColor = Color.LightBlue;


                // Recorrer los botones existentes y modificar su tamaño
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item is ToolStripButton button)
                    {
                        button.AutoSize = false; // Deshabilitar el ajuste automático de tamaño
                        button.Size = new Size(50, 50); // Cambiar el tamaño de los botones
                        //toolStrip.ImageScalingSize = new Size(24, 24); // Cambiar el tamaño de las imágenes a 48x48

                        // Asegurarse de que la imagen se ajuste al botón
                        if (button.Image != null)
                        {
                            button.ImageAlign = ContentAlignment.MiddleCenter; // Centrar la imagen
                            
                        }
                    }
                }
                // Agregar un separador en el ToolStrip
                var separator = new ToolStripSeparator();
                toolStrip.Items.Add(separator); // Añadir el separador al ToolStrip
            }

        }
    }
}
