using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class UserRepository : MasterRepository, IUserRepository
    {
        private string getAll;
        private string insert;
        private string update;
        private string delete;
        private string getById;

        public UserRepository()
        {
            getAll = "SELECT * FROM usuarios";
            insert = "INSERT INTO usuarios VALUES (@Id, @Nombre, @Apellido, @Email, @Contraseña, @Rol)";
            update = "UPDATE usuarios SET nombre = @Nombre, apellido = @Apellido, email = @Email, contraseña = @Contraseña, rol = @Rol WHERE id = @Id";
            delete = "DELETE FROM usuarios WHERE id = @Id";
            getById = "SELECT * FROM usuarios WHERE id = @Id";
        }

        public int Add(Usuario entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Id", entity.Id),
            new SqlParameter("@Nombre", entity.Nombre),
            new SqlParameter("@Apellido", entity.Apellido),
            new SqlParameter("@Email", entity.Email),
            new SqlParameter("@Contraseña", entity.Contraseña),
            new SqlParameter("@Rol", entity.Rol)
        };

            return ExecuteNonQuery(insert);
        }

        public int Delete(Usuario entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Id", entity.Id)
        };

            return ExecuteNonQuery(delete);
        }

        public IEnumerable<Usuario> GetAll()
        {
            List<Usuario> listUser = new List<Usuario>();
            try
            {
                var tableResult = ExecuteReader(getAll);
                foreach (DataRow item in tableResult.Rows)
                {
                    listUser.Add(new Usuario
                    {
                        Id = Convert.ToInt32(item["id"]),
                        Nombre = item["nombre"].ToString(),
                        Apellido = item["apellido"].ToString(),
                        Email = item["email"].ToString(),
                        Contraseña = item["contraseña"].ToString(),
                        Rol = item["rol"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al obtener usuarios: " + ex.Message);
            }
            return listUser;
        }

        public Usuario GetById(int id)
        {
            Usuario user = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

                var result = ExecuteReader(getById);
                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    user = new Usuario
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Email = row["email"].ToString(),
                        Contraseña = row["contraseña"].ToString(),
                        Rol = row["rol"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al obtener usuario por ID: " + ex.Message);
            }
            return user;
        }

        public int Update(Usuario entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Id", entity.Id),
            new SqlParameter("@Nombre", entity.Nombre),
            new SqlParameter("@Apellido", entity.Apellido),
            new SqlParameter("@Email", entity.Email),
            new SqlParameter("@Contraseña", entity.Contraseña),
            new SqlParameter("@Rol", entity.Rol)
        };

            return ExecuteNonQuery(update);
        }
    }

}
