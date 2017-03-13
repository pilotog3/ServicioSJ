using Piloxy.ListaEspera.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Piloxy.ListaEspera.Models;
using OfficeOpenXml;
using Piloxy.ListaEspera.Application.Helper;

namespace Piloxy.ListaEspera.Application.Excel
{
    class ListaEspera : ILeible<Paciente>, IGuardable<Paciente>
    {
        private Dictionary<string, int> _columnHeader;
        private int _totalPacientes;
        private int _numeroActual;
        
        public List<Paciente> ObtenerDatos(ExcelWorkbook excel)
        {
            _totalPacientes = 0;
            _numeroActual = 0;
            var hojaAbierto = ObtenerAbierto(excel);
            var hojaCerrado = ObtenerCerrado(excel);
            var listaPaciente = MapearExcel(hojaAbierto);
            listaPaciente.AddRange(MapearExcel(hojaCerrado));
            return listaPaciente;
        }
        public List<Paciente> ObtenerDatos(ExcelWorkbook excel, Action<int> callback)
        {
            _totalPacientes = 0;
            _numeroActual = 0;
            var hojaAbierto = ObtenerAbierto(excel);
            var hojaCerrado = ObtenerCerrado(excel);
            var listaPaciente = MapearExcel(hojaAbierto,callback);
            listaPaciente.AddRange(MapearExcel(hojaCerrado,callback));
            return listaPaciente;
        }

        private ExcelWorksheet ObtenerAbierto(ExcelWorkbook excel)
        {
            var excelAbiertos = ObtenerByName(excel, "abiertos");
            _totalPacientes += excelAbiertos.Dimension.End.Row - 1;
            return excelAbiertos;
        }

        private ExcelWorksheet ObtenerCerrado(ExcelWorkbook excel)
        {
            var excelCerrados = ObtenerByName(excel, "cerrado");
            _totalPacientes += excelCerrados.Dimension.End.Row - 1;
            return excelCerrados;
        }

        private List<Paciente> MapearExcel(ExcelWorksheet hoja)
        {

            var header = ObtenerHeader(hoja);

            var pacientes = new List<Paciente>();
            for (int j = hoja.Dimension.Start.Row + 1; j <= hoja.Dimension.End.Row; j++)
            {
                var cells = hoja.Cells;

                var paciente = new Paciente()
                {
                    Estado = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Estado"),
                    Rut = ExcelHelper.GetColumnNumberByName<int>(header, cells, j, "Run"),
                    Dv = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Dv"),
                    Nombres = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Nombres"),
                    ApellidoPaterno = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Primer_Apellido"),
                    ApellidoMaterno = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Segundo_Apellido"),
                    FechaEntrada = ExcelHelper.GetColumnNumberByContainName<DateTime>(header, cells, j, "F_Entrada"),
                    FechaSalida = ExcelHelper.GetColumnNumberByContainName<DateTime>(header, cells, j, "F_Salida"),
                    CausaSalida = ExcelHelper.GetColumnNumberByContainNameNullable<int>(header, cells, j, "C_Salida"),
                    SospechaDiagnostico = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Sospecha"),
                    ConfirmacionDiagnostico = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Confi"),
                    Plano = ExcelHelper.GetColumnNumberByContainNameNullable<int>(header, cells, j, "Plano"),
                    Servicio = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Servicio"),
                    FonoFijo = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Fijo"),
                    FojoMovil = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Movil")
                };

                pacientes.Add(paciente);
            }


            return pacientes;
        }
        
        private List<Paciente> MapearExcel(ExcelWorksheet hoja,Action<int> callback)
        {
            var header = ObtenerHeader(hoja);

            var pacientes = new List<Paciente>();
            for (int j = hoja.Dimension.Start.Row + 1; j <= hoja.Dimension.End.Row; j++)
            {
                var cells = hoja.Cells;

                var paciente = new Paciente()
                {
                    Estado = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Estado"),
                    Rut = ExcelHelper.GetColumnNumberByName<int>(header, cells, j, "Run"),
                    Dv = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Dv"),
                    Nombres = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Nombres"),
                    ApellidoPaterno = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Primer_Apellido"),
                    ApellidoMaterno = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Segundo_Apellido"),
                    FechaEntrada = ExcelHelper.GetColumnNumberByContainName<DateTime>(header, cells, j, "F_Entrada"),
                    FechaSalida = ExcelHelper.GetColumnNumberByContainName<DateTime>(header, cells, j, "F_Salida"),
                    CausaSalida = ExcelHelper.GetColumnNumberByContainNameNullable<int>(header, cells, j, "C_Salida"),
                    SospechaDiagnostico = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Sospecha"),
                    ConfirmacionDiagnostico = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Confi"),
                    Plano = ExcelHelper.GetColumnNumberByContainNameNullable<int>(header, cells, j, "Plano"),
                    Servicio = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Servicio"),
                    FonoFijo = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Fijo"),
                    FojoMovil = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Movil")
                };
                pacientes.Add(paciente);
                var porcentaje = ((++_numeroActual) * 100 / _totalPacientes);
                callback(porcentaje);
            }



            return pacientes;
        }

        public List<string> GetAllColumns(ExcelWorkbook excel)
        {
            var hoja = ObtenerAbierto(excel);

            var listaColumnas = new List<string>();
            for (int i = hoja.Dimension.Start.Column; i <= hoja.Dimension.End.Column; i++)
            {
                var cellValue = hoja.Cells[1, i].Value;
                if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
                    continue;

                var stringValue = cellValue.ToString();
                stringValue = stringValue.Replace("_", " ");
                stringValue = stringValue.ToLower();
                System.Globalization.TextInfo textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                stringValue = textInfo.ToTitleCase(stringValue);
                stringValue = stringValue.Replace(" ", "");

                listaColumnas.Add(stringValue);
            }

            return listaColumnas;
        }
        private ExcelWorksheet ObtenerByName(ExcelWorkbook excel,string name)
        {
            return excel.Worksheets.FirstOrDefault(d => d.Name.ToLower().Contains(name));
        }

        private Dictionary<string, int> ObtenerHeader(ExcelWorksheet hoja)
        {
            var diccionario = new Dictionary<string, int>();

            for (int i = hoja.Dimension.Start.Column; i <= hoja.Dimension.End.Column; i++)
            {
                var cellValue = hoja.Cells[1, i].Value;
                if (cellValue == null || string.IsNullOrEmpty(cellValue.ToString()))
                    continue;
                
                diccionario.Add(cellValue.ToString().ToLower(), i);
            }

            return diccionario;
        }

        public bool GuardarEnDb(List<Paciente> elementos)
        {
            return true;
        }

        public bool GuardarEnExcelRespaldo(List<Paciente> elementos, string pathNuevoExcel)
        {
            return true;
        }
    }
}
