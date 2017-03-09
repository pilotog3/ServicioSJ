namespace Piloxy.ListaEspera
{
    partial class PanelCargaArchivo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCargarListaEspera = new System.Windows.Forms.Button();
            this.textRutaListaEspera = new System.Windows.Forms.TextBox();
            this.btnBuscarListaEspera = new System.Windows.Forms.Button();
            this.dialogFileListaEspera = new System.Windows.Forms.OpenFileDialog();
            this.workerCargaArchivos = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCargarListaEspera);
            this.groupBox1.Controls.Add(this.textRutaListaEspera);
            this.groupBox1.Controls.Add(this.btnBuscarListaEspera);
            this.groupBox1.Location = new System.Drawing.Point(28, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 116);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista De Espera";
            // 
            // btnCargarListaEspera
            // 
            this.btnCargarListaEspera.Location = new System.Drawing.Point(203, 87);
            this.btnCargarListaEspera.Name = "btnCargarListaEspera";
            this.btnCargarListaEspera.Size = new System.Drawing.Size(103, 23);
            this.btnCargarListaEspera.TabIndex = 2;
            this.btnCargarListaEspera.Text = "Cargar";
            this.btnCargarListaEspera.UseVisualStyleBackColor = true;
            this.btnCargarListaEspera.Click += new System.EventHandler(this.btnCargarListaEspera_Click);
            // 
            // textRutaListaEspera
            // 
            this.textRutaListaEspera.Location = new System.Drawing.Point(28, 49);
            this.textRutaListaEspera.Name = "textRutaListaEspera";
            this.textRutaListaEspera.ReadOnly = true;
            this.textRutaListaEspera.Size = new System.Drawing.Size(447, 20);
            this.textRutaListaEspera.TabIndex = 1;
            // 
            // btnBuscarListaEspera
            // 
            this.btnBuscarListaEspera.Location = new System.Drawing.Point(481, 47);
            this.btnBuscarListaEspera.Name = "btnBuscarListaEspera";
            this.btnBuscarListaEspera.Size = new System.Drawing.Size(42, 23);
            this.btnBuscarListaEspera.TabIndex = 0;
            this.btnBuscarListaEspera.Text = "...";
            this.btnBuscarListaEspera.UseVisualStyleBackColor = true;
            this.btnBuscarListaEspera.Click += new System.EventHandler(this.btnBuscarListaEspera_Click);
            // 
            // PanelCargaArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PanelCargaArchivo";
            this.Size = new System.Drawing.Size(578, 418);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCargarListaEspera;
        private System.Windows.Forms.TextBox textRutaListaEspera;
        private System.Windows.Forms.Button btnBuscarListaEspera;
        private System.Windows.Forms.OpenFileDialog dialogFileListaEspera;
        private System.ComponentModel.BackgroundWorker workerCargaArchivos;
    }
}
