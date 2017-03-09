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
        private static BarraProceso instance;
        private PanelBarraCargando _panelBarraCargando;
        private ProgressBar _bar;
        public Control FormPrincipal { get; set; }

        private BarraProceso() {
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

        public void IniciarBarraProceso(BackgroundWorker worker)
        {

            this.FormPrincipal.Invoke((MethodInvoker)delegate {

                _panelBarraCargando = new PanelBarraCargando();
            });
            
            if (this.FormPrincipal != null)
                _panelBarraCargando.Show(this.FormPrincipal);
            else
                _panelBarraCargando.Show();

            worker.RunWorkerAsync();
        }
        public void TerminarBarraProceso()
        {
            //_task.Dispose();
            _panelBarraCargando.Close();
        }

        private void GetBarra(Control.ControlCollection controles)
        {
            if (_bar != null)
                return;

            foreach (var control in controles)
            {
                if (control.GetType() == typeof(ProgressBar))
                {
                    _bar = (ProgressBar)control;
                    break;
                }
            }
        }
        
    }
}
