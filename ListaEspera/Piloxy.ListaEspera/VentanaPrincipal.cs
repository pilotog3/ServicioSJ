using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Piloxy.ListaEspera
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
            CargarPanelCargaArchivo();
            Commons.BarraProceso.Instance.FormPrincipal = this;
        }
        public void CargarVentanaListaEspera()
        {
            Commons.BarraProceso.Instance.TerminarBarraProceso();
            panelPrincipal.Controls.Clear();
            var panelListaEspera = new PanelListaEspera();
            panelPrincipal.Controls.Add(panelListaEspera);
            panelListaEspera.AjustesTamaño();
            panelPrincipal.Controls[0].Visible = true;
        }
        public void CargarVentanaListaEspera(List<Models.Paciente> pacientes)
        {
            Commons.BarraProceso.Instance.TerminarBarraProceso();
            panelPrincipal.Controls.Clear();
            var panelListaEspera = new PanelListaEspera(ref pacientes);
            panelPrincipal.Controls.Add(panelListaEspera);
            panelListaEspera.AjustesTamaño();
            panelPrincipal.Controls[0].Visible = true;
        }
        public void CargarPanelCargaArchivo()
        {
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(new PanelCargaArchivo());
            panelPrincipal.Controls[0].Visible = true;            
        }        

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        
    }
}
