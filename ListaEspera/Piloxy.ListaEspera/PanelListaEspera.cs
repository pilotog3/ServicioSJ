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
            CargarPacientesGrilla();
        }

        public void AjustesTamaño()
        {
            this.AutoSize = true;
            var panel = (Panel)this.Parent;
            panel.AutoSize = true;
        }

        private void CargarPacientesGrilla()
        {
            DataTable dat=new DataTable();
            foreach (var pac in _listaPacientes)
            {
                dat.Rows.Add
                    (
                        pac.Estado,
                        pac.Rut,
                        pac.Dv,
                        pac.ApellidoPaterno,
                        pac.ApellidoMaterno,
                        pac.Nombres,
                        pac.FechaEntrada,
                        pac.FechaSalida,
                        pac.SospechaDiagnostico,
                        pac.ConfirmacionDiagnostico,
                        pac.CausaSalida
                    );
            }


            grillaPacientes.DataSource = dat;
        }
        
    }
}
