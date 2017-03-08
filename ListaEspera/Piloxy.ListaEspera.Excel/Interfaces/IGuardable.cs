using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Interfaces
{
    interface IGuardable<T> where T : class
    {
        bool GuardarEnDb(List<T> elementos);
        bool GuardarEnExcelRespaldo(List<T> elementos, string pathNuevoExcel);
    }
}
