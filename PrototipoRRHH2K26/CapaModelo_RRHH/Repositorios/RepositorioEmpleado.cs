using CapaModelo_RRHH.Contratos;
using CapaModelo_RRHH.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_RRHH.Repositorios
{
    public class RepositorioEmpleado : RepositorioMaestro, IRepositorioEmpleados
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioEmpleado()
        {
            selectAll = "SELECT * FROM Tbl_Empleado";

            insert = @"INSERT INTO Tbl_Empleado
                        (
                            NombresEmpleado,
                            ApellidosEmpleado,
                            TelefonoEmpleado,
                            CorreoEmpleado,
                            PuestoEmpleado,
                            EstadoEmpleado
                        )
                        VALUES
                        (
                            ?,?,?,?,?,?
                        )";

            update = @"UPDATE Tbl_Empleado
                       SET
                            NombresEmpleado = ?,
                            ApellidosEmpleado = ?,
                            TelefonoEmpleado = ?,
                            CorreoEmpleado = ?,
                            PuestoEmpleado = ?,
                            EstadoEmpleado = ?
                       WHERE IdEmpleado = ?";

            delete = "DELETE FROM Tbl_Empleado WHERE IdEmpleado = ?";
        }

        public int Agregar(Empleado entidad)
        {
            var parametros = new List<OdbcParameter>();

            parametros.Add(new OdbcParameter("P_NombresEmpleado", entidad.NombresEmpleado));
            parametros.Add(new OdbcParameter("P_ApellidosEmpleado", entidad.ApellidosEmpleado));
            parametros.Add(new OdbcParameter("P_TelefonoEmpleado", entidad.TelefonoEmpleado));
            parametros.Add(new OdbcParameter("P_CorreoEmpleado", entidad.CorreoEmpleado));
            parametros.Add(new OdbcParameter("P_PuestoEmpleado", entidad.PuestoEmpleado));
            parametros.Add(new OdbcParameter("P_EstadoEmpleado", entidad.EstadoEmpleado));

            return EjecucionNonQuery(insert, parametros, CommandType.Text);
        }

        public int Editar(Empleado entidad)
        {
            var parametros = new List<OdbcParameter>();

            // El orden debe ser igual al UPDATE
            parametros.Add(new OdbcParameter("P_NombresEmpleado", entidad.NombresEmpleado));
            parametros.Add(new OdbcParameter("P_ApellidosEmpleado", entidad.ApellidosEmpleado));
            parametros.Add(new OdbcParameter("P_TelefonoEmpleado", entidad.TelefonoEmpleado));
            parametros.Add(new OdbcParameter("P_CorreoEmpleado", entidad.CorreoEmpleado));
            parametros.Add(new OdbcParameter("P_PuestoEmpleado", entidad.PuestoEmpleado));
            parametros.Add(new OdbcParameter("P_EstadoEmpleado", entidad.EstadoEmpleado));
            parametros.Add(new OdbcParameter("P_IdEmpleado", entidad.IdEmpleado));

            return EjecucionNonQuery(update, parametros, CommandType.Text);
        }

        public int Remover(Empleado entidad)
        {
            var parametros = new List<OdbcParameter>();

            parametros.Add(new OdbcParameter("P_IdEmpleado", entidad.IdEmpleado));

            return EjecucionNonQuery(delete, parametros, CommandType.Text);
        }

        public IEnumerable<Empleado> GetAll()
        {
            var listaEmpleado = new List<Empleado>();

            var tabla = EjecucionConsulta(selectAll, null, CommandType.Text);

            foreach (DataRow row in tabla.Rows)
            {
                var empleado = new Empleado();

                empleado.IdEmpleado = Convert.ToInt32(row["IdEmpleado"]);
                empleado.NombresEmpleado = row["NombresEmpleado"].ToString();
                empleado.ApellidosEmpleado = row["ApellidosEmpleado"].ToString();
                empleado.TelefonoEmpleado = row["TelefonoEmpleado"].ToString();
                empleado.CorreoEmpleado = row["CorreoEmpleado"].ToString();
                empleado.PuestoEmpleado = row["PuestoEmpleado"].ToString();
                empleado.EstadoEmpleado = Convert.ToBoolean(row["EstadoEmpleado"]);

                listaEmpleado.Add(empleado);
            }

            return listaEmpleado;
        }
    }
}