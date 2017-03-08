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
        
        public List<Paciente> ObtenerDatos(ExcelWorkbook excel)
        {
            return ObtenerAbierto(excel);
        }

        private List<Paciente> ObtenerAbierto(ExcelWorkbook excel)
        {
            var excelAbiertos = ObtenerByName(excel, "abiertos");

            var header = ObtenerHeader(excelAbiertos);
            
            var pacientes = new List<Paciente>();
            for (int j = excelAbiertos.Dimension.Start.Row + 1; j <= excelAbiertos.Dimension.End.Row; j++)
            {
                var cells = excelAbiertos.Cells;

                var paciente = new Paciente()
                {
                    Estado = ExcelHelper.GetColumnNumberByContainName(header, cells, j, "Estado"),
                    Rut = ExcelHelper.GetColumnNumberByName<int>(header, cells, j,"Run"),
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
