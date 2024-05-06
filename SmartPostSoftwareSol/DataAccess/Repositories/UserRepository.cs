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
        private string getAll; // Consulta para obtener todos los usuarios
        private string insert; // Consulta para insertar un nuevo usuario
        private string update; // Consulta para actualizar un usuario existente
        private string delete; // Consulta para eliminar un usuario
        private string getById; // Consulta para obtener un usuario por su ID

        public UserRepository()
        {
            // Inicialización de las consultas SQL
            getAll = "SELECT * FROM usuarios";
            insert = "INSERT INTO usuarios VALUES (@Id, @Nombre, @Apellido, @Email, @Contraseña, @Rol)";
            update = "UPDATE usuarios SET nombre = @Nombre, apellido = @Apellido, email = @Email, contraseña = @Contraseña, rol = @Rol WHERE id = @Id";
            delete = "DELETE FROM usuarios WHERE id = @Id";
            getById = "SELECT * FROM usuarios WHERE id = @Id";
        }

        // Método para agregar un nuevo usuario a la base de datos
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

            // Ejecuta la consulta de inserción y retorna el resultado
            return ExecuteNonQuery(insert);
        }

        // Método para eliminar un usuario de la base de datos
        public int Delete(Usuario entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Id", entity.Id)
        };

            // Ejecuta la consulta de eliminación y retorna el resultado
            return ExecuteNonQuery(delete);
        }

        // Método para obtener todos los usuarios de la base de datos
        public IEnumerable<Usuario> GetAll()
        {
            List<Usuario> listUser = new List<Usuario>();
            try
            {
                // Ejecuta la consulta para obtener todos los usuarios
                var tableResult = ExecuteReader(getAll);

                // Itera sobre cada fila del resultado y crea objetos Usuario
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
                // Maneja la excepción según tus necesidades
                Console.WriteLine("Error al obtener usuarios: " + ex.Message);
            }
            return listUser;
        }

        // Método para obtener un usuario por su ID
        public Usuario GetById(int id)
        {
            Usuario user = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

                // Ejecuta la consulta para obtener un usuario por su ID
                var result = ExecuteReader(getById);

                // Verifica si se encontró un usuario con el ID especificado
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
                // Maneja la excepción según tus necesidades
                Console.WriteLine("Error al obtener usuario por ID: " + ex.Message);
            }
            return user;
        }

        // Método para actualizar un usuario en la base de datos
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

            // Ejecuta la consulta de actualización y retorna el resultado
            return ExecuteNonQuery(update);
        }
    }

}
