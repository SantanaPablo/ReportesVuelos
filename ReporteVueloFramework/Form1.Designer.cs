namespace ReporteVueloFramework
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenDecla = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnPrintOne = new System.Windows.Forms.Button();
            this.btnPrevisualizar = new System.Windows.Forms.Button();
            this.btnCargarCSV = new System.Windows.Forms.Button();
            this.pnlPerfil = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.pnlfoot = new System.Windows.Forms.Panel();
            this.pnlPDF = new System.Windows.Forms.Panel();
            this.cmbReportes = new System.Windows.Forms.ComboBox();
            this.lblCantReportes = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.pdfViewer1 = new ReporteVueloFramework.CustomPdfViewer();
            this.panel2.SuspendLayout();
            this.pnlPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPDF.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.btnGenDecla);
            this.panel2.Controls.Add(this.btnBorrar);
            this.panel2.Controls.Add(this.btnPrintAll);
            this.panel2.Controls.Add(this.btnPrintOne);
            this.panel2.Controls.Add(this.btnPrevisualizar);
            this.panel2.Controls.Add(this.btnCargarCSV);
            this.panel2.Location = new System.Drawing.Point(0, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 440);
            this.panel2.TabIndex = 1;
            // 
            // btnGenDecla
            // 
            this.btnGenDecla.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGenDecla.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenDecla.FlatAppearance.BorderSize = 0;
            this.btnGenDecla.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenDecla.Font = new System.Drawing.Font("Neo Sans Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenDecla.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenDecla.Image = global::ReporteVueloFramework.Properties.Resources.icon_one;
            this.btnGenDecla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenDecla.Location = new System.Drawing.Point(0, 300);
            this.btnGenDecla.Name = "btnGenDecla";
            this.btnGenDecla.Size = new System.Drawing.Size(219, 60);
            this.btnGenDecla.TabIndex = 9;
            this.btnGenDecla.Text = "Generar Decla";
            this.btnGenDecla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenDecla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenDecla.UseVisualStyleBackColor = false;
            this.btnGenDecla.Click += new System.EventHandler(this.btnGenDecla_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBorrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBorrar.Font = new System.Drawing.Font("Neo Sans Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBorrar.Image = global::ReporteVueloFramework.Properties.Resources.icon_goma;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.Location = new System.Drawing.Point(0, 240);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(219, 60);
            this.btnBorrar.TabIndex = 8;
            this.btnBorrar.Text = "Borrar todo";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrintAll.FlatAppearance.BorderSize = 0;
            this.btnPrintAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintAll.Font = new System.Drawing.Font("Neo Sans Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAll.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrintAll.Image = global::ReporteVueloFramework.Properties.Resources.icon_todos;
            this.btnPrintAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintAll.Location = new System.Drawing.Point(0, 180);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(219, 60);
            this.btnPrintAll.TabIndex = 7;
            this.btnPrintAll.Text = "Generar todos";
            this.btnPrintAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintAll.UseVisualStyleBackColor = false;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnPrintOne
            // 
            this.btnPrintOne.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrintOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrintOne.FlatAppearance.BorderSize = 0;
            this.btnPrintOne.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintOne.Font = new System.Drawing.Font("Neo Sans Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintOne.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrintOne.Image = global::ReporteVueloFramework.Properties.Resources.icon_one;
            this.btnPrintOne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintOne.Location = new System.Drawing.Point(0, 120);
            this.btnPrintOne.Name = "btnPrintOne";
            this.btnPrintOne.Size = new System.Drawing.Size(219, 60);
            this.btnPrintOne.TabIndex = 6;
            this.btnPrintOne.Text = "Generar seleccionado";
            this.btnPrintOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintOne.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintOne.UseVisualStyleBackColor = false;
            this.btnPrintOne.Click += new System.EventHandler(this.btnPrintOne_Click);
            // 
            // btnPrevisualizar
            // 
            this.btnPrevisualizar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnPrevisualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPrevisualizar.FlatAppearance.BorderSize = 0;
            this.btnPrevisualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrevisualizar.Font = new System.Drawing.Font("Neo Sans Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevisualizar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrevisualizar.Image = global::ReporteVueloFramework.Properties.Resources.icon_ojo;
            this.btnPrevisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevisualizar.Location = new System.Drawing.Point(0, 60);
            this.btnPrevisualizar.Name = "btnPrevisualizar";
            this.btnPrevisualizar.Size = new System.Drawing.Size(219, 60);
            this.btnPrevisualizar.TabIndex = 5;
            this.btnPrevisualizar.Text = "Previsualizar";
            this.btnPrevisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrevisualizar.UseVisualStyleBackColor = false;
            this.btnPrevisualizar.Click += new System.EventHandler(this.btnPrevisualizar_Click);
            // 
            // btnCargarCSV
            // 
            this.btnCargarCSV.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCargarCSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCargarCSV.FlatAppearance.BorderSize = 0;
            this.btnCargarCSV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCargarCSV.Font = new System.Drawing.Font("Neo Sans Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarCSV.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCargarCSV.Image = global::ReporteVueloFramework.Properties.Resources.icon_csv;
            this.btnCargarCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarCSV.Location = new System.Drawing.Point(0, 0);
            this.btnCargarCSV.Name = "btnCargarCSV";
            this.btnCargarCSV.Size = new System.Drawing.Size(219, 60);
            this.btnCargarCSV.TabIndex = 4;
            this.btnCargarCSV.Text = "Cargar CSV";
            this.btnCargarCSV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargarCSV.UseVisualStyleBackColor = false;
            this.btnCargarCSV.Click += new System.EventHandler(this.btnCargarCSV_Click);
            // 
            // pnlPerfil
            // 
            this.pnlPerfil.Controls.Add(this.pictureBox1);
            this.pnlPerfil.Controls.Add(this.lblMensaje);
            this.pnlPerfil.Controls.Add(this.lblPerfil);
            this.pnlPerfil.Location = new System.Drawing.Point(0, 0);
            this.pnlPerfil.Name = "pnlPerfil";
            this.pnlPerfil.Size = new System.Drawing.Size(219, 219);
            this.pnlPerfil.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(5, 195);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(214, 15);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Archivo CSV: Ningún archivo cargado  ";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Neo Sans Pro", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.Location = new System.Drawing.Point(34, 31);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(135, 26);
            this.lblPerfil.TabIndex = 0;
            this.lblPerfil.Text = "CHECK POINT";
            // 
            // pnlfoot
            // 
            this.pnlfoot.BackColor = System.Drawing.Color.LightBlue;
            this.pnlfoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlfoot.Location = new System.Drawing.Point(0, 655);
            this.pnlfoot.Name = "pnlfoot";
            this.pnlfoot.Size = new System.Drawing.Size(1184, 26);
            this.pnlfoot.TabIndex = 4;
            // 
            // pnlPDF
            // 
            this.pnlPDF.Controls.Add(this.cmbReportes);
            this.pnlPDF.Controls.Add(this.lblCantReportes);
            this.pnlPDF.Controls.Add(this.btnSiguiente);
            this.pnlPDF.Controls.Add(this.btnAnterior);
            this.pnlPDF.Controls.Add(this.pdfViewer1);
            this.pnlPDF.Location = new System.Drawing.Point(220, 0);
            this.pnlPDF.Name = "pnlPDF";
            this.pnlPDF.Size = new System.Drawing.Size(960, 760);
            this.pnlPDF.TabIndex = 3;
            // 
            // cmbReportes
            // 
            this.cmbReportes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReportes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReportes.FormattingEnabled = true;
            this.cmbReportes.Location = new System.Drawing.Point(607, 13);
            this.cmbReportes.Name = "cmbReportes";
            this.cmbReportes.Size = new System.Drawing.Size(150, 21);
            this.cmbReportes.TabIndex = 4;
            this.cmbReportes.SelectedIndexChanged += new System.EventHandler(this.CmbReportes_SelectedIndexChanged);
            this.cmbReportes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbReportes_KeyDown);
            // 
            // lblCantReportes
            // 
            this.lblCantReportes.AutoSize = true;
            this.lblCantReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantReportes.Location = new System.Drawing.Point(393, 14);
            this.lblCantReportes.Name = "lblCantReportes";
            this.lblCantReportes.Size = new System.Drawing.Size(51, 20);
            this.lblCantReportes.TabIndex = 3;
            this.lblCantReportes.Text = "label1";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.Location = new System.Drawing.Point(265, 2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(50, 50);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.Transparent;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(214, 2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(50, 50);
            this.btnAnterior.TabIndex = 1;
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BackColor = System.Drawing.Color.DarkGray;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pdfViewer1.Size = new System.Drawing.Size(960, 760);
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pnlfoot);
            this.Controls.Add(this.pnlPDF);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlPerfil);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 720);
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Reportes";
            this.panel2.ResumeLayout(false);
            this.pnlPerfil.ResumeLayout(false);
            this.pnlPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPDF.ResumeLayout(false);
            this.pnlPDF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCargarCSV;
        private System.Windows.Forms.Panel pnlPerfil;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Panel pnlPDF;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Label lblCantReportes;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ComboBox cmbReportes;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.Button btnPrintOne;
        private System.Windows.Forms.Button btnPrevisualizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomPdfViewer pdfViewer1;
        private System.Windows.Forms.Panel pnlfoot;
        private System.Windows.Forms.Button btnGenDecla;
    }
}

