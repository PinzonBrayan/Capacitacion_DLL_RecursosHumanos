using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_RRHH.Contratos;
using CapaModelo_RRHH.Entidades;
using CapaModelo_RRHH.Repositorios;
using System.ComponentModel.DataAnnotations;

namespace CapaControlador_RRHH
{
    public class ModeloEmpleado
    {
        private int _idEmpleado;
        private string _nombresEmpleado;
        private string _apellidosEmpleado;
        private string _telefonoEmpleado;
        private string _correoEmpleado;
        private string _puestoEmpleado;
        private bool _estadoEmpleado;

        private IRepositorioEmpleados repositorioEmpleado;

        public EstadoEntidad Estado { private get; set; }

        private List<ModeloEmpleado> listaEmpleados;
        public int IdEmpleado
        {
            get { return _idEmpleado; }
            set { _idEmpleado = value; }
        }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZÁÉÍÓÚáéíóúÑñ ]+$",
            ErrorMessage = "Solo se permiten letras.")]
        [StringLength(100,
            MinimumLength = 3,
            ErrorMessage = "Debe contener entre 3 y 100 caracteres.")]
        public string NombresEmpleado
        {
            get { return _nombresEmpleado; }
            set { _nombresEmpleado = value; }
        }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZÁÉÍÓÚáéíóúÑñ ]+$",
            ErrorMessage = "Solo se permiten letras.")]
        [StringLength(100,
            MinimumLength = 3,
            ErrorMessage = "Debe contener entre 3 y 100 caracteres.")]
        public string ApellidosEmpleado
        {
            get { return _apellidosEmpleado; }
            set { _apellidosEmpleado = value; }
        }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^[0-9]+$",
            ErrorMessage = "Solo números.")]
        public string TelefonoEmpleado
        {
            get { return _telefonoEmpleado; }
            set { _telefonoEmpleado = value; }
        }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        public string CorreoEmpleado
        {
            get { return _correoEmpleado; }
            set { _correoEmpleado = value; }
        }

        [Required(ErrorMessage = "El puesto es obligatorio.")]
        public string PuestoEmpleado
        {
            get { return _puestoEmpleado; }
            set { _puestoEmpleado = value; }
        }

        public bool EstadoEmpleado
        {
            get { return _estadoEmpleado; }
            set { _estadoEmpleado = value; }
        }
        public ModeloEmpleado()
        {
            repositorioEmpleado = new RepositorioEmpleado();
        }
        public string GrabarCambios()
        {
            string mensaje = null;

            try
            {
                Empleado modeloDatosEmpleado = new Empleado();

                modeloDatosEmpleado.IdEmpleado = _idEmpleado;
                modeloDatosEmpleado.NombresEmpleado = _nombresEmpleado;
                modeloDatosEmpleado.ApellidosEmpleado = _apellidosEmpleado;
                modeloDatosEmpleado.TelefonoEmpleado = _telefonoEmpleado;
                modeloDatosEmpleado.CorreoEmpleado = _correoEmpleado;
                modeloDatosEmpleado.PuestoEmpleado = _puestoEmpleado;
                modeloDatosEmpleado.EstadoEmpleado = _estadoEmpleado;

                switch (Estado)
                {
                    case EstadoEntidad.Added:

                        repositorioEmpleado.Agregar(modeloDatosEmpleado);

                        mensaje = "Empleado agregado correctamente";
                        break;

                    case EstadoEntidad.Modified:

                        repositorioEmpleado.Editar(modeloDatosEmpleado);

                        mensaje = "Empleado actualizado correctamente";
                        break;

                    case EstadoEntidad.Deleted:

                        repositorioEmpleado.Remover(modeloDatosEmpleado);

                        mensaje = "Empleado eliminado correctamente";
                        break;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }
        public List<ModeloEmpleado> GetAll()
        {
            var modeloDatosEmpleado = repositorioEmpleado.GetAll();

            listaEmpleados = new List<ModeloEmpleado>();

            foreach (Empleado item in modeloDatosEmpleado)
            {
                listaEmpleados.Add(new ModeloEmpleado()
                {
                    _idEmpleado = item.IdEmpleado,
                    _nombresEmpleado = item.NombresEmpleado,
                    _apellidosEmpleado = item.ApellidosEmpleado,
                    _telefonoEmpleado = item.TelefonoEmpleado,
                    _correoEmpleado = item.CorreoEmpleado,
                    _puestoEmpleado = item.PuestoEmpleado,
                    _estadoEmpleado = item.EstadoEmpleado
                });
            }

            return listaEmpleados;
        }
        public IEnumerable<ModeloEmpleado> FindById(string filtro)
        {
            return listaEmpleados.FindAll(
                e =>
                e.NombresEmpleado.ToUpper().Contains(filtro.ToUpper()) ||
                e.ApellidosEmpleado.ToUpper().Contains(filtro.ToUpper()));
        }
    }
}