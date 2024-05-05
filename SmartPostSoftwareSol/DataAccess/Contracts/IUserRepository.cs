using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUserRepository : IGenericRepository<Usuario>
    {
        public IEnumerable<Usuario> GetAll()
        {

        }

        public Usuario GetById(int id)
        {
        }

        public void Add(Usuario entity)
        {

        }

        public void Update(Usuario entity)
        {

        }

        public void Delete(Usuario entity)
        {

        }
    }
}
