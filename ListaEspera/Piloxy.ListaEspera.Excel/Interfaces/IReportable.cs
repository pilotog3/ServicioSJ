using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Interfaces
{
    interface IReportable<T> where T : class
    {
        string ReporteCompleto(List<T> elementos);
        string ReporteEntradaSalidaPacientes(List<T> elementos);
        
    }
}
