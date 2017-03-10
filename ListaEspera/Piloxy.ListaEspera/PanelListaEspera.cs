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
        private List<Models.Paciente> _listaPacientes;
        public PanelListaEspera()
        {
            InitializeComponent();
        }

        public PanelListaEspera(ref List<Models.Paciente> listaPacientes)
        {
            _listaPacientes = listaPacientes;
            InitializeComponent();
            CargarPacientesGrilla(_listaPacientes);
        }

        public void AjustesTamaño()
        {
            this.AutoSize = true;
            var panel = (Panel)this.Parent;
            panel.AutoSize = true;
        }

        private void CargarPacientesGrilla(List<Models.Paciente> listaPacientes)
        {
            if (grillaPacientes.Rows.Count > 0)
                grillaPacientes.Rows.Clear();

            foreach (var pac in listaPacientes)
            {
                grillaPacientes.Rows.Add
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
                MessageBox.Show("Agrega un criterio de busqueda.","Error al buscar.");

            var filtro = textFiltro.Text;

            List<Models.Paciente> pacientesFiltrados = new List<Models.Paciente>();

            foreach (var paciente in _listaPacientes)
            {
                if (paciente.Rut.ToString().ToLower().Contains(filtro.ToLower()) ||
                    paciente.RutCompleto.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ApellidoPaterno.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ApellidoMaterno.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ApellidoPaterno.ToLower().Contains(filtro.ToLower()) ||
                   paciente.SospechaDiagnostico.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ConfirmacionDiagnostico.ToLower().Contains(filtro.ToLower())
                   )
                 pacientesFiltrados.Add(paciente);
            }

            CargarPacientesGrilla(pacientesFiltrados);
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
    }
}
