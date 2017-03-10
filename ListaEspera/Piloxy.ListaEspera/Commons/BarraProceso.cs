using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piloxy.ListaEspera.Commons
{
    public class BarraProceso
    {
        private bool _estaActivo;
        private static BarraProceso instance;
        private PanelBarraCargando _panelBarraCargando;
        public Control FormPrincipal { get; set; }

        private BarraProceso() {
            _estaActivo = false;
        }

        public static BarraProceso Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BarraProceso();
                }
                return instance;
            }
        }

        public void IniciarBarraProceso()
        {
            if (_estaActivo)
                return;

            if (_panelBarraCargando == null)
                _panelBarraCargando = new PanelBarraCargando();

            _estaActivo = true;

            this.FormPrincipal.Invoke((MethodInvoker)delegate {
                _panelBarraCargando = new PanelBarraCargando();
            });
            
            _panelBarraCargando.SetUndefined();

            if (this.FormPrincipal != null)
                _panelBarraCargando.Show(this.FormPrincipal);
            else
                _panelBarraCargando.Show();
        }
        public void TerminarBarraProceso()
        {
            if (!_estaActivo)
                return;

            _estaActivo = false;
            _panelBarraCargando.Close();
        }
        public void SetUndefined()
        {
            _panelBarraCargando.SetUndefined();
        }

        public void SetValue(int value)
        {
            if (_panelBarraCargando != null)
                _panelBarraCargando.SetValue(value);
        }
        
    }
}
