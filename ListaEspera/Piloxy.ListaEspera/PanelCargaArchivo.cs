using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Piloxy.ListaEspera
{
    public partial class PanelCargaArchivo : UserControl
    {
        public PanelCargaArchivo()
        {
            InitializeComponent();
        }

        private void btnBuscarListaEspera_Click(object sender, EventArgs e)
        {
            var result = dialogFileListaEspera.ShowDialog();

            if (result == DialogResult.OK)
                textRutaListaEspera.Text = dialogFileListaEspera.FileName;
        }

        private void btnCargarListaEspera_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textRutaListaEspera.Text))
            {
                MessageBox.Show("Debe seleccionar un archivo antes de cargar.", "Falta Archivo");
                return;
            }

            try
            {
                Commons.BarraProceso.Instance.IniciarBarraProceso();
                workerCargaArchivos.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Commons.BarraProceso.Instance.TerminarBarraProceso();
                MessageBox.Show(ex.Message, "Error de carga");
                return;
            }
        }
        
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            var excel = new Application.Excel.Excel(textRutaListaEspera.Text);
            Commons.ListaEsperaPacientes.Instance.ListaPacientes = excel.ObtenerModels<Models.Paciente>(Application.Enums.TipoArchivoEnum.ListaEspera, MostrarAvance);

        }

        private void CargarVentana(object sender, RunWorkerCompletedEventArgs e)
        {
            var ventana = Helper.FormHelper.GetPrincipal(this.Parent);
            ventana.CargarVentanaListaEspera();
        }

        private void Progress(object sender, ProgressChangedEventArgs e)
        {
            Commons.BarraProceso.Instance.SetValue(e.ProgressPercentage);

        }

        private void MostrarAvance(int porcentaje)
        {
            workerCargaArchivos.ReportProgress(porcentaje);
        }
    }
}
