using CapaModelo_RRHH.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_RRHH.Entidades;
using System.Data.Odbc;
using System.Runtime.Remoting.Lifetime;
using System.Data;
namespace CapaModelo_RRHH.Repositorios
    
{


public class RepositorioEmpleado: RepositorioMaestro,IRepositorioEmpleados
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioEmpleado()
        {
            selectAll = "SELECT * FROM Tbl_Empleado";
            insert = "INSRT INTO Tbl_Empleado value (NULL, ?,?,?,?,?,?)";
            update = "UPDATE Tbl_Empleado SET NombresEmpleado=?, ApellidosEmpleado = ?, TelefonoEmpleado=?, CorreoEmpleado=?, PuestoEmpleado=?,EstadoEmpleado=? WHERE IdEmpleado = ?";
            delete = "DELETE FROM Tbl:Empleado WHERE IdEmpleado 0 ?";
        }

        public int Agregar (Empleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("P_NombresEmpleado", entidad.NombresEmpleado));
            _parametros.Add(new OdbcParameter("P_ApellidosEmpleado", entidad.ApellidosEmpleado));
            _parametros.Add(new OdbcParameter("P_TelefonoEmpleado", entidad.TelefonoEmpleado));
            _parametros.Add(new OdbcParameter("P_CorreoEmpleado", entidad.CorreoEmpleado));
            _parametros.Add(new OdbcParameter("P_PuestoEmpleado", entidad.PuestoEmpleado));
            _parametros.Add(new OdbcParameter("P_EstadoEmpleado", entidad.EstadoEmpleado));
            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Editar(Empleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("P_IdEmpleado", entidad.IdEmpleado));
            _parametros.Add(new OdbcParameter("P_NombresEmpleado", entidad.NombresEmpleado));
            _parametros.Add(new OdbcParameter("P_ApellidosEmpleado", entidad.ApellidosEmpleado));
            _parametros.Add(new OdbcParameter("P_TelefonoEmpleado", entidad.TelefonoEmpleado));
            _parametros.Add(new OdbcParameter("P_CorreoEmpleado", entidad.CorreoEmpleado));
            _parametros.Add(new OdbcParameter("P_PuestoEmpleado", entidad.PuestoEmpleado));
            _parametros.Add(new OdbcParameter("P_EstadoEmpleado", entidad.EstadoEmpleado));
            return EjecucionNonQuery(update, _parametros, CommandType.Text);

        }

        public int Remover (Empleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
        _parametros.Add(new OdbcParameter("P_IdEmpleado", entidad.IdEmpleado));
        return EjecucionNonQuery(delete, _parametros, CommandType.Text);        
    }

        public IEnumerable<Empleado> GetAll()
    {
        var lstEmpleado = new List<Empleado>();
        var tblTabla = EjecucionConsulta(selectAll,null,CommandType.Text);
        foreach (DataRow row in tblTabla.Rows)
        {
            var empleado = new Empleado();
            empleado.IdEmpleado = Convert.ToInt32(row[0]);
            empleado.NombresEmpleado = row[1].ToString();
            empleado.ApellidosEmpleado = row[2].ToString();
            empleado.TelefonoEmpleado = row[3].ToString();
            empleado.CorreoEmpleado = row[4].ToString();
            empleado.PuestoEmpleado = row[5].ToString();
            empleado.PuestoEmpleado = row[6].ToString();
            lstEmpleado.Add(empleado);
        }
        tblTabla.Clear();
        tblTabla = null;
        return lstEmpleado;
    }
    
}
}
