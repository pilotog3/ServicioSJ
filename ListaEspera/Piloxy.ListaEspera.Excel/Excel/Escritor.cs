using OfficeOpenXml;
using Piloxy.ListaEspera.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Excel
{
    class Escritor
    {
        ExcelWorkbook _excel;
        public Escritor(ExcelWorkbook excel)
        {
            _excel = excel;
        }

        public bool GuardarEnDB<T>(TipoArchivoEnum tipoArchivo, List<T> elementos) where T : class
        {
            var manipulador = Factory.FactoryListaEspera.ObtenerGuardable<T>(tipoArchivo);
            return manipulador.GuardarEnDb(elementos);
        }
    }
}
