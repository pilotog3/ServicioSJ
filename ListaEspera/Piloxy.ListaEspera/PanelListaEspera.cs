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
    public partial class PanelListaEspera : UserControl
    {
        private DataTable _dataTable;
        public PanelListaEspera()
        {
            InitializeComponent();
            _dataTable = CloneGridView(grillaPacientes);
            Commons.BarraProceso.Instance.SetUndefined();
            Commons.BarraProceso.Instance.IniciarBarraProceso();
            workerFiltrarGrilla.RunWorkerAsync();
        }

        private DataTable CloneGridView(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }
            return dt;
        }

        public PanelListaEspera(ref List<Models.Paciente> listaPacientes)
        {
            CargarPacientesGrilla(Commons.ListaEsperaPacientes.Instance.ListaPacientes);
        }

        public void AjustesTamaño()
        {
            this.AutoSize = true;
            var panel = (Panel)this.Parent;
            panel.AutoSize = true;
        }

        private void CargarPacientesGrilla(List<Models.Paciente> listaPacientes)
        {
            if (listaPacientes == null || !listaPacientes.Any())
                return;

            if (grillaPacientes.Rows.Count > 0)
                _dataTable.Rows.Clear();

            int i = 0;
            foreach (var pac in listaPacientes)
            {
                _dataTable.Rows.Add
                    (
                        pac.Estado,
                        pac.Rut,
                        pac.Dv,
                        pac.ApellidoPaterno,
                        pac.ApellidoMaterno,
                        pac.Nombres,
                        pac.FechaEntrada,
                        pac.FechaSalida,
                        pac.CausaSalida,
                        pac.SospechaDiagnostico,
                        pac.ConfirmacionDiagnostico
                    );
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textFiltro.Text))
            {
                MessageBox.Show("Agrega un criterio de busqueda.", "Error al buscar.");
                return;
            }

            if (!workerFiltrarGrilla.IsBusy)
            {
                Commons.BarraProceso.Instance.SetUndefined();
                Commons.BarraProceso.Instance.IniciarBarraProceso();
                workerFiltrarGrilla.RunWorkerAsync();
            }

        }

        private void grillaPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            CambiarTextoMuestra(e.RowIndex, e.ColumnIndex);
        }

        private void CambiarTextoMuestra(int row, int column)
        {
            var cell = grillaPacientes.Rows[row].Cells[column];
            if (cell.Value == null)
                txtMuestra.Text = "";
            
            txtMuestra.Text = cell.Value.ToString();
        }
        

        public void FiltrarGrilla(object sender, DoWorkEventArgs e)
        {
            var pacientesFiltrados = Commons.ListaEsperaPacientes.Instance.Filtro(textFiltro.Text);
            CargarPacientesGrilla(pacientesFiltrados);
        }

        public void TerminoGrilla(object sender,RunWorkerCompletedEventArgs e)
        {
            grillaPacientes.Columns.Clear();
            grillaPacientes.DataSource = _dataTable;
            Commons.BarraProceso.Instance.TerminarBarraProceso();
        }
    }
}
