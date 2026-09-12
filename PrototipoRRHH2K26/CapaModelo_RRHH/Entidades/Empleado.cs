using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_RRHH.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string NombresEmpleado { get; set; }

        public string ApellidosEmpleado { get; set; }

        public string TelefonoEmpleado { get; set; }

        public string CorreoEmpleado { get; set; }

        public string PuestoEmpleado { get; set; }

        public bool EstadoEmpleado { get; set; }
    }
}
