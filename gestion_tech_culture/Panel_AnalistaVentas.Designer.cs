namespace gestion_tech_culture
{
    partial class Panel_AnalistaVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_AnalistaVentas));
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.cboBuscarPor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscarVenta = new System.Windows.Forms.Button();
            this.lbCantidadVendida = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotalVentas = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.cbFechaImporta = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(70, 303);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 24;
            this.dgvVentas.Size = new System.Drawing.Size(661, 333);
            this.dgvVentas.TabIndex = 0;
            // 
            // cboBuscarPor
            // 
            this.cboBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuscarPor.FormattingEnabled = true;
            this.cboBuscarPor.Items.AddRange(new object[] {
            "Código de Venta",
            "Código de Empleado",
            "Código de Laptop",
            "Mostrar todo"});
            this.cboBuscarPor.Location = new System.Drawing.Point(876, 554);
            this.cboBuscarPor.Name = "cboBuscarPor";
            this.cboBuscarPor.Size = new System.Drawing.Size(182, 28);
            this.cboBuscarPor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(775, 555);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar por:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(27, 53);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(222, 27);
            this.dtpDesde.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mostrar desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(27, 139);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(222, 27);
            this.dtpHasta.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(344, 687);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 38);
            this.label4.TabIndex = 8;
            this.label4.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(63, 691);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 38);
            this.label5.TabIndex = 9;
            this.label5.Text = "Monto obtenido (RD$):";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtCodigo.Location = new System.Drawing.Point(779, 623);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(169, 27);
            this.txtCodigo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(775, 597);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Código:";
            // 
            // btnBuscarVenta
            // 
            this.btnBuscarVenta.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBuscarVenta.Font = new System.Drawing.Font("MS PGothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarVenta.ForeColor = System.Drawing.Color.White;
            this.btnBuscarVenta.Location = new System.Drawing.Point(973, 618);
            this.btnBuscarVenta.Name = "btnBuscarVenta";
            this.btnBuscarVenta.Size = new System.Drawing.Size(85, 34);
            this.btnBuscarVenta.TabIndex = 13;
            this.btnBuscarVenta.Text = "Buscar";
            this.btnBuscarVenta.UseVisualStyleBackColor = false;
            this.btnBuscarVenta.Click += new System.EventHandler(this.btnBuscarVenta_Click);
            // 
            // lbCantidadVendida
            // 
            this.lbCantidadVendida.AutoSize = true;
            this.lbCantidadVendida.BackColor = System.Drawing.Color.Transparent;
            this.lbCantidadVendida.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadVendida.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbCantidadVendida.Location = new System.Drawing.Point(323, 648);
            this.lbCantidadVendida.Name = "lbCantidadVendida";
            this.lbCantidadVendida.Size = new System.Drawing.Size(28, 38);
            this.lbCantidadVendida.TabIndex = 18;
            this.lbCantidadVendida.Text = "-";
            this.lbCantidadVendida.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(63, 648);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 38);
            this.label8.TabIndex = 17;
            this.label8.Text = "Laptops vendidas:";
            // 
            // lbTotalVentas
            // 
            this.lbTotalVentas.AutoSize = true;
            this.lbTotalVentas.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalVentas.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalVentas.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbTotalVentas.Location = new System.Drawing.Point(393, 691);
            this.lbTotalVentas.Name = "lbTotalVentas";
            this.lbTotalVentas.Size = new System.Drawing.Size(28, 38);
            this.lbTotalVentas.TabIndex = 19;
            this.lbTotalVentas.Text = "-";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSalir.Font = new System.Drawing.Font("MS PGothic", 10.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(973, 703);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(85, 42);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(351, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(449, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCerrarSesion.Font = new System.Drawing.Font("MS PGothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 12);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(83, 55);
            this.btnCerrarSesion.TabIndex = 22;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // cbFechaImporta
            // 
            this.cbFechaImporta.AutoSize = true;
            this.cbFechaImporta.BackColor = System.Drawing.Color.Transparent;
            this.cbFechaImporta.Checked = true;
            this.cbFechaImporta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFechaImporta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFechaImporta.ForeColor = System.Drawing.Color.White;
            this.cbFechaImporta.Location = new System.Drawing.Point(779, 303);
            this.cbFechaImporta.Name = "cbFechaImporta";
            this.cbFechaImporta.Size = new System.Drawing.Size(203, 24);
            this.cbFechaImporta.TabIndex = 23;
            this.cbFechaImporta.Text = "Tomar fecha en cuenta";
            this.cbFechaImporta.UseVisualStyleBackColor = false;
            this.cbFechaImporta.CheckedChanged += new System.EventHandler(this.cbFechaImporta_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.Controls.Add(this.dtpHasta);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpDesde);
            this.panel2.Location = new System.Drawing.Point(779, 333);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 195);
            this.panel2.TabIndex = 25;
            // 
            // Panel_AnalistaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1119, 805);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbFechaImporta);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lbTotalVentas);
            this.Controls.Add(this.lbCantidadVendida);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBuscarVenta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboBuscarPor);
            this.Controls.Add(this.dgvVentas);
            this.Name = "Panel_AnalistaVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.ComboBox cboBuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscarVenta;
        private System.Windows.Forms.Label lbCantidadVendida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotalVentas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.CheckBox cbFechaImporta;
        private System.Windows.Forms.Panel panel2;
    }
}