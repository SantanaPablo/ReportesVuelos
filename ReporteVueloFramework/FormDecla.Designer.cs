namespace ReporteVueloFramework
{
    partial class FormDecla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPDF = new System.Windows.Forms.Panel();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.btnAgregarTripulante = new System.Windows.Forms.Button();
            this.lblCantReportes = new System.Windows.Forms.Label();
            this.pdfViewer1 = new ReporteVueloFramework.CustomPdfViewer();
            this.cmbAutorizantes = new System.Windows.Forms.ComboBox();
            this.lblAutoriza = new System.Windows.Forms.Label();
            this.pnlPDF.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPDF
            // 
            this.pnlPDF.Controls.Add(this.lblAutoriza);
            this.pnlPDF.Controls.Add(this.cmbAutorizantes);
            this.pnlPDF.Controls.Add(this.txtLegajo);
            this.pnlPDF.Controls.Add(this.btnAgregarTripulante);
            this.pnlPDF.Controls.Add(this.lblCantReportes);
            this.pnlPDF.Controls.Add(this.pdfViewer1);
            this.pnlPDF.Location = new System.Drawing.Point(0, 0);
            this.pnlPDF.Name = "pnlPDF";
            this.pnlPDF.Size = new System.Drawing.Size(785, 760);
            this.pnlPDF.TabIndex = 4;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(378, 12);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(100, 20);
            this.txtLegajo.TabIndex = 5;
            // 
            // btnAgregarTripulante
            // 
            this.btnAgregarTripulante.Location = new System.Drawing.Point(297, 2);
            this.btnAgregarTripulante.Name = "btnAgregarTripulante";
            this.btnAgregarTripulante.Size = new System.Drawing.Size(75, 39);
            this.btnAgregarTripulante.TabIndex = 4;
            this.btnAgregarTripulante.Text = "Agregar Extra";
            this.btnAgregarTripulante.UseVisualStyleBackColor = true;
            this.btnAgregarTripulante.Click += new System.EventHandler(this.btnAgregarTripulante_Click);
            // 
            // lblCantReportes
            // 
            this.lblCantReportes.AutoSize = true;
            this.lblCantReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantReportes.Location = new System.Drawing.Point(231, 10);
            this.lblCantReportes.Name = "lblCantReportes";
            this.lblCantReportes.Size = new System.Drawing.Size(51, 20);
            this.lblCantReportes.TabIndex = 3;
            this.lblCantReportes.Text = "label1";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BackColor = System.Drawing.Color.DarkGray;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pdfViewer1.Size = new System.Drawing.Size(785, 760);
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // cmbAutorizantes
            // 
            this.cmbAutorizantes.FormattingEnabled = true;
            this.cmbAutorizantes.Location = new System.Drawing.Point(638, 12);
            this.cmbAutorizantes.Name = "cmbAutorizantes";
            this.cmbAutorizantes.Size = new System.Drawing.Size(121, 21);
            this.cmbAutorizantes.TabIndex = 6;
            // 
            // lblAutoriza
            // 
            this.lblAutoriza.AutoSize = true;
            this.lblAutoriza.Location = new System.Drawing.Point(584, 15);
            this.lblAutoriza.Name = "lblAutoriza";
            this.lblAutoriza.Size = new System.Drawing.Size(48, 13);
            this.lblAutoriza.TabIndex = 7;
            this.lblAutoriza.Text = "Autoriza:";
            // 
            // FormDecla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 721);
            this.Controls.Add(this.pnlPDF);
            this.MaximumSize = new System.Drawing.Size(800, 760);
            this.Name = "FormDecla";
            this.Text = "FormDecla";
            this.pnlPDF.ResumeLayout(false);
            this.pnlPDF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPDF;
        private System.Windows.Forms.Label lblCantReportes;
        private CustomPdfViewer pdfViewer1;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Button btnAgregarTripulante;
        private System.Windows.Forms.Label lblAutoriza;
        private System.Windows.Forms.ComboBox cmbAutorizantes;
    }
}