using OfficeOpenXml;
using Piloxy.ListaEspera.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Excel
{
    public class Excel
    {
        public ExcelWorkbook _excel;
        Lector _lector;
        Escritor _escritor;

        public Excel(string pathFile)
        {
            var package = new ExcelPackage(new System.IO.FileInfo(pathFile));
            _excel = package.Workbook;
            _lector = new Lector(_excel);
            _escritor = new Escritor(_excel);
        }

        public List<T> ObtenerModels<T>(TipoArchivoEnum tipoArchivo) where T : class
        {
            return _lector.ObtenerModels<T>(tipoArchivo);
        }
    }
}
