using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Commons
{
    class ListaEsperaPacientes
    {
        public List<Models.Paciente> ListaPacientes { get; set; }
        private ListaEsperaPacientes() { }
        private static ListaEsperaPacientes _instance;

        public static ListaEsperaPacientes Instance
        {
            get{
                if (_instance == null)
                    _instance = new ListaEsperaPacientes();
                
                return _instance;
            }
        }

        public List<Models.Paciente> Filtro(string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
                return ListaPacientes;

            var pacientesFiltrados = new List<Models.Paciente>();
            foreach (var paciente in ListaPacientes)
            {
                if (paciente.Rut.ToString().ToLower().Contains(filtro.ToLower()) ||
                    paciente.RutCompleto.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ApellidoPaterno.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ApellidoMaterno.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ApellidoPaterno.ToLower().Contains(filtro.ToLower()) ||
                   paciente.SospechaDiagnostico.ToLower().Contains(filtro.ToLower()) ||
                   paciente.ConfirmacionDiagnostico.ToLower().Contains(filtro.ToLower())
                   )
                    pacientesFiltrados.Add(paciente);
            }
            return pacientesFiltrados;
        }
    }
}
