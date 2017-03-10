using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Interfaces
{
    interface ILeible<T> where T:class
    {
        List<T> ObtenerDatos(ExcelWorkbook excel);
        List<T> ObtenerDatos(ExcelWorkbook excel,Action<int> callback);
    }
}
