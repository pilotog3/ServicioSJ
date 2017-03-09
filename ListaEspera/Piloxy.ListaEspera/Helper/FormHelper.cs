using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Piloxy.ListaEspera.Helper
{
    class FormHelper
    {
        public static VentanaPrincipal GetPrincipal(object control)
        {
            if (control == null)
                throw new InvalidOperationException("No es posible realizar cambio de pantalla.");

            if(control.GetType() != typeof(Panel) && control.GetType() != typeof(VentanaPrincipal))
                throw new InvalidOperationException("No es posible realizar cambio de pantalla.");

            if (control.GetType() == typeof(Panel))
            {
                var panel = (Panel)control;
                if(panel.Parent.GetType() != typeof(VentanaPrincipal))
                    throw new InvalidOperationException("No es posible realizar cambio de pantalla.");

                var ventanaPrincipal = (VentanaPrincipal)panel.Parent;
                return ventanaPrincipal;
            }

            if (control.GetType() == typeof(VentanaPrincipal))
            {
                var ventanaPrincipal = (VentanaPrincipal)control;
                return ventanaPrincipal;
            }

            throw new Exception("No es posible realizar el cambio de pantalla.");
        }
    }
}
