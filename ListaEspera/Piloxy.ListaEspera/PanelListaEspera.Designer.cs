namespace Piloxy.ListaEspera
{
    partial class PanelListaEspera
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grillaPacientes = new System.Windows.Forms.DataGridView();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiagnosticoSospecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiagnosticoConfirmacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMuestra = new System.Windows.Forms.TextBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.workerFiltrarGrilla = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPacientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaPacientes
            // 
            this.grillaPacientes.AllowUserToAddRows = false;
            this.grillaPacientes.AllowUserToDeleteRows = false;
            this.grillaPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Estado,
            this.Rut,
            this.Dv,
            this.ApellidoP,
            this.ApellidoMaterno,
            this.Nombres,
            this.FechaIngreso,
            this.FechaEgreso,
            this.TipoEgreso,
            this.DiagnosticoSospecha,
            this.DiagnosticoConfirmacion});
            this.grillaPacientes.Location = new System.Drawing.Point(3, 139);
            this.grillaPacientes.Name = "grillaPacientes";
            this.grillaPacientes.Size = new System.Drawing.Size(1144, 462);
            this.grillaPacientes.TabIndex = 0;
            this.grillaPacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaPacientes_CellClick);
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // Rut
            // 
            this.Rut.HeaderText = "Rut";
            this.Rut.Name = "Rut";
            this.Rut.ReadOnly = true;
            // 
            // Dv
            // 
            this.Dv.HeaderText = "Dv";
            this.Dv.Name = "Dv";
            this.Dv.ReadOnly = true;
            // 
            // ApellidoP
            // 
            this.ApellidoP.HeaderText = "Ap. Paterno";
            this.ApellidoP.Name = "ApellidoP";
            this.ApellidoP.ReadOnly = true;
            // 
            // ApellidoMaterno
            // 
            this.ApellidoMaterno.HeaderText = "Ap. Materno";
            this.ApellidoMaterno.Name = "ApellidoMaterno";
            this.ApellidoMaterno.ReadOnly = true;
            // 
            // Nombres
            // 
            this.Nombres.HeaderText = "Nombres";
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.HeaderText = "Fecha de Ingreso";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.ReadOnly = true;
            // 
            // FechaEgreso
            // 
            this.FechaEgreso.HeaderText = "Fecha de Egreso";
            this.FechaEgreso.Name = "FechaEgreso";
            this.FechaEgreso.ReadOnly = true;
            // 
            // TipoEgreso
            // 
            this.TipoEgreso.HeaderText = "Tipo de Egreso";
            this.TipoEgreso.Name = "TipoEgreso";
            this.TipoEgreso.ReadOnly = true;
            // 
            // DiagnosticoSospecha
            // 
            this.DiagnosticoSospecha.HeaderText = "Sospecha de Diagnostico";
            this.DiagnosticoSospecha.Name = "DiagnosticoSospecha";
            this.DiagnosticoSospecha.ReadOnly = true;
            // 
            // DiagnosticoConfirmacion
            // 
            this.DiagnosticoConfirmacion.HeaderText = "Confirmacion de Diagnostico";
            this.DiagnosticoConfirmacion.Name = "DiagnosticoConfirmacion";
            this.DiagnosticoConfirmacion.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMuestra);
            this.groupBox1.Controls.Add(this.btnFiltro);
            this.groupBox1.Controls.Add(this.textFiltro);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1144, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // txtMuestra
            // 
            this.txtMuestra.Location = new System.Drawing.Point(545, 52);
            this.txtMuestra.Multiline = true;
            this.txtMuestra.Name = "txtMuestra";
            this.txtMuestra.Size = new System.Drawing.Size(404, 63);
            this.txtMuestra.TabIndex = 2;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(335, 74);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnFiltro.TabIndex = 1;
            this.btnFiltro.Text = "Buscar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(37, 76);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(276, 20);
            this.textFiltro.TabIndex = 0;
            // 
            // PanelListaEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grillaPacientes);
            this.Name = "PanelListaEspera";
            this.Size = new System.Drawing.Size(1151, 607);
            ((System.ComponentModel.ISupportInitialize)(this.grillaPacientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

            this.workerFiltrarGrilla.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FiltrarGrilla);
            this.workerFiltrarGrilla.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.TerminoGrilla);
        }

        #endregion

        private System.Windows.Forms.DataGridView grillaPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiagnosticoSospecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiagnosticoConfirmacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.TextBox textFiltro;
        private System.Windows.Forms.TextBox txtMuestra;
        private System.ComponentModel.BackgroundWorker workerFiltrarGrilla;
    }
}
