using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Test
{
    public class TestClass
    {
        public static void Test()
        {
            string path = @"C:\Users\hcortes\Downloads\Lista de Espera FEBRERO 2017.xlsx";
            var excel = new Excel.Excel(path);
            var listaPacientes = excel.ObtenerModels<Models.Paciente>(Enums.TipoArchivoEnum.ListaEspera);
        }
    }
}
