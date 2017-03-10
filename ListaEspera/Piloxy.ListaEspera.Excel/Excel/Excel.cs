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
        string[] extensionesValidas = { ".xls", ".xlsx" };

        public Excel(string pathFile)
        {
            var info = new System.IO.FileInfo(pathFile);
            if (!extensionesValidas.Contains(info.Extension))
                throw new Exception("Formato de archivo no valido. Por favor seleccione un archivo excel.");

            var package = new ExcelPackage(info);
            _excel = package.Workbook;
            _lector = new Lector(_excel);
            _escritor = new Escritor(_excel);
        }

        public List<T> ObtenerModels<T>(TipoArchivoEnum tipoArchivo) where T : class
        {
            try
            {
                return _lector.ObtenerModels<T>(tipoArchivo);
            }
            catch(Exception ex)
            {
                //Log(ex.Error);
                throw new Exception("No es posible cargar el Excel.");
            }
        }

        public List<T> ObtenerModels<T>(TipoArchivoEnum tipoArchivo,Action<int> callback) where T : class
        {
            try
            {
                return _lector.ObtenerModels<T>(tipoArchivo,callback);
            }
            catch (Exception ex)
            {
                //Log(ex.Error);
                throw new Exception("No es posible cargar el Excel.");
            }
        }
    }
}
