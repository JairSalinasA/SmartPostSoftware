using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    /// <summary>
    /// Interfaz para el repositorio de usuarios.
    /// </summary>
    public interface IUserRepository : IGenericRepository<Usuario>
    {
         
    }
}
