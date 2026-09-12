using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_RRHH.Contratos
{
    public interface IRepositorioGenerico<Entity> where Entity : class
    {

        int Agregar(Entity entidad);

        int Editar(Entity entidad);

        int Remover(Entity entidad);

        IEnumerable<Entity> GetAll();
    }
}
