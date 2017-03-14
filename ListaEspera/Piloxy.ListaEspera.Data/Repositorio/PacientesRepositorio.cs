using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Piloxy.ListaEspera.Data.Repositorio
{
    class PacientesRepositorio:IDisposable  
    {
        private const string SpConfiguracionExcel = "ObtenerConfiguracionExcel";
        private const string SqlInsertParametros = "INSERT INTO Entries(id, name) VALUES(@id, @name);";
        private SqlConnection _sqlConn;

        public PacientesRepositorio()
        {
            _sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["PacientesEntities"].ToString());
        }

        public bool GuardarPacientes(List<Models.Paciente> pacientes)
        {
            using (var command = new SqlCommand(SpConfiguracionExcel, _sqlConn))
            {
                command.CommandText = SqlInsertParametros;
                command.Parameters.Add("@id");
                command.Parameters.Add("@name");

                _sqlConn.Open();
                foreach (var entry in pacientes)
                {
                    command.Parameters["@id"].Value = entry.Rut;
                    command.Parameters["@name"].Value = entry.Dv;
                }
                _sqlConn.Close();
            }
            return true;
        }

        public List<Models.ConfiguracionExcel> ObtenerConfiguracion(int idExcel)
        {
            var listaConfiguracion = new List<Models.ConfiguracionExcel>();

            try
            {
                using (var command = new SqlCommand(SpConfiguracionExcel, _sqlConn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdExcel", idExcel);

                    _sqlConn.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listaConfiguracion.Add(new Models.ConfiguracionExcel()
                        {
                            NombreColumnaExcel = reader["NombreColumnaExcel"].ToString(),
                            NombreColumnaSql = reader["NombreColumnaSql"].ToString(),
                            NombreHeaderColumnaExcel = reader["NombreHeaderColumnaExcel"].ToString()

                        });
                    }
                    _sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                //log.Error(ex);
                throw new Exception("No es posible leer la configuración del excel.");
            }

            return listaConfiguracion;
        }

        public void Dispose()
        {
            if(_sqlConn.State == System.Data.ConnectionState.Open)
                _sqlConn.Close();
        }
    }
}
