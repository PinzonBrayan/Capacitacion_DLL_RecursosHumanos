using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_RRHH.Repositorios
{
    public abstract class RepositorioMaestro : Repositorio
    {
        // Tabla donde se almacenarán los resultados
        private DataTable tablaDatos;

        // Ejecuta INSERT, UPDATE y DELETE
        public int EjecucionNonQuery(
            string _comandoTexto,
            List<OdbcParameter> _parametros,
            CommandType _comandoTipo)
        {

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var ocComando = new OdbcCommand())
                {
                    ocComando.Connection = conexion;
                    ocComando.CommandText = _comandoTexto;
                    ocComando.CommandType = _comandoTipo;
                    ocComando.Parameters.AddRange(_parametros.ToArray());

                    return ocComando.ExecuteNonQuery();
                }
            }

        }
        public DataTable EjecucionConsulta(
            string _comandoTexto,
            List<OdbcParameter> parametros,
            CommandType _comandoTipo)
        {
            tablaDatos = new DataTable();

            using (var conexion = ObtenerConexion())
            {
                conexion.Open();

                using (var ocComando = new OdbcCommand())
                {
                    ocComando.Connection = conexion;
                    ocComando.CommandText = _comandoTexto;
                    ocComando.CommandType = _comandoTipo;
                    using (var reader = ocComando.ExecuteReader())
                        tablaDatos.Load(reader);
                }
                return tablaDatos;
            }
        }
    }
}