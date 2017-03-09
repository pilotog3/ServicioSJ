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
        private Application.Excel.Excel _excel;
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
                Commons.BarraProceso.Instance.IniciarBarraProceso(workerCargaArchivos);
                _excel = new Application.Excel.Excel(textRutaListaEspera.Text);
                var listaPacientes = _excel.ObtenerModels<Models.Paciente>(Application.Enums.TipoArchivoEnum.ListaEspera);
                var ventana = Helper.FormHelper.GetPrincipal(this.Parent);

                ventana.CargarVentanaListaEspera(listaPacientes);
            }
            catch (Exception ex)
            {
                Commons.BarraProceso.Instance.TerminarBarraProceso();
                MessageBox.Show(ex.Message, "Error de carga");
                return;
            }
        }

        
        
    }
}
