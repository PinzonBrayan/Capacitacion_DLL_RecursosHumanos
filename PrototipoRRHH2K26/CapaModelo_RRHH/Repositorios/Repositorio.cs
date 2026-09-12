using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaModelo_RRHH.Repositorios
{
    public abstract class Repositorio
    {
        // Cadena de conexión
        protected string connectionString;

        // Constructor
        public Repositorio()
        {
            connectionString = "DSN=DSN_Polideportivo;";
        }

        // Método que devuelve la conexión
        protected OdbcConnection ObtenerConexion()
        {
            return new OdbcConnection(connectionString);
        }
    }
}