using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        // Método para obtener todos los registros
        IEnumerable<Entity> GetAll();

        // Método para obtener un registro por ID
        Entity GetById(int id);

        // Método para añadir un nuevo registro
        int Add(Entity entity);

        // Método para actualizar un registro existente
        int Update(Entity entity);

        // Método para eliminar un registro
        int Delete(Entity entity);
    }
}

    
