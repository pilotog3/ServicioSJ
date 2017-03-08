using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Models
{
    public class Paciente
    {
        public string Estado { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }

        public string Servicio { get; set; }
        public int? Plano { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int? CausaSalida { get; set; }
        public string SospechaDiagnostico { get; set; }
        public string ConfirmacionDiagnostico { get; set; }
        public string FonoFijo { get; set; }
        public string FojoMovil { get; set; }
        public string CausaText { private set { } get { return Helpers.ListaEsperaHelper.GetNombreCausa(this.CausaSalida); } }
        public string RutCompleto { private set { } get { return this.Rut + "-" + this.Dv; } }
    }
}
