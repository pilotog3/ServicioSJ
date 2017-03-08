using OfficeOpenXml;
using Piloxy.ListaEspera.Application.Enums;
using Piloxy.ListaEspera.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Excel
{
    public class Lector    {

        ExcelWorkbook _excel;
        public Lector(ExcelWorkbook excel)
        {
            _excel = excel;
        }

        public List<T> ObtenerModels<T>(TipoArchivoEnum tipoArchivo) where T:class
        {
            var manipulador = Factory.FactoryListaEspera.ObtenerLeible<T>(tipoArchivo);
            return manipulador.ObtenerDatos(_excel);
        }
        
    }
}
