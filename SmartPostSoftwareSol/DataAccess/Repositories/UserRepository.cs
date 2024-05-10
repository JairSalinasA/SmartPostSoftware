using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Contracts;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Repositorio para la entidad Usuario.
    /// </summary>
    public class UserRepository : MasterRepository, IUserRepository
    {
        private readonly string getAllQuery = "SELECT * FROM Usuarios";
        private readonly string getByIdQuery = "SELECT * FROM Usuarios WHERE Id = @id";
        private readonly string insertQuery = "INSERT INTO Usuarios (Nombre, Apellido, Email, Contraseña, Rol) VALUES (@nombre, @apellido, @Email, @Contraseña, @Rol)";
        private readonly string updateQuery = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Contraseña = @Contraseña, Rol = @Rol WHERE Id = @Id";
        private readonly string deleteQuery = "DELETE FROM Usuarios WHERE Id = @Id";

        /// <inheritdoc/>
        public int Add(Usuario usuario)
        {
            // Lista de parámetros para la consulta
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Apellido", usuario.Apellido),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Contraseña", usuario.Contraseña),
                new SqlParameter("@Rol", usuario.Rol)
            };

            // Ejecutar la consulta de inserción y devolver el resultado
            return ExecuteNonQuery(insertQuery, parameters);
        }

        /// <inheritdoc/>
        public int Delete(int id)
        {
            // Lista de parámetros para la consulta
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            // Ejecutar la consulta de eliminación y devolver el resultado
            return ExecuteNonQuery(deleteQuery, parameters);
        }

        /// <inheritdoc/>
        /// <inheritdoc/>
        public IEnumerable<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                // Ejecutar la consulta SELECT y obtener los resultados
                DataTable resultTable = ExecuteReader(getAllQuery, new List<SqlParameter>()); // <-- Corrección aquí

                // Iterar sobre cada fila y mapearla a un objeto Usuario
                foreach (DataRow row in resultTable.Rows)
                {
                    Usuario usuario = MapDataRowToUsuario(row);
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                LogError("Error al obtener usuarios", ex);
            }

            return usuarios;
        }


        /// <inheritdoc/>
        public Usuario GetById(int id)
        {
            Usuario usuario = null;

            try
            {
                // Lista de parámetros para la consulta
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", id)
                };

                // Ejecutar la consulta SELECT y obtener los resultados
                DataTable resultTable = ExecuteReader(getByIdQuery, parameters);

                // Verificar si se encontró un usuario y mapearlo
                if (resultTable.Rows.Count > 0)
                {
                    DataRow row = resultTable.Rows[0];
                    usuario = MapDataRowToUsuario(row);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                LogError("Error al obtener usuario por ID", ex);
            }

            return usuario;
        }

        /// <inheritdoc/>
        public int Update(Usuario usuario)
        {
            // Lista de parámetros para la consulta
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", usuario.Id),
                new SqlParameter("@Nombre", usuario.Nombre),
                new SqlParameter("@Apellido", usuario.Apellido),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Contraseña", usuario.Contraseña),
                new SqlParameter("@Rol", usuario.Rol)
            };

            // Ejecutar la consulta de actualización y devolver el resultado
            return ExecuteNonQuery(updateQuery, parameters);
        }

        private Usuario MapDataRowToUsuario(DataRow row)
        {
            // Crear un objeto Usuario y mapear los datos de la fila
            return new Usuario
            {
                Id = Convert.ToInt32(row["Id"]),
                Nombre = row["Nombre"].ToString(),
                Apellido = row["Apellido"].ToString(),
                Email = row["Email"].ToString(),
                Contraseña = row["Contraseña"].ToString(),
                ContraseñaHash = row["ContraseñaHash"].ToString(),
                Rol = row["Rol"].ToString()
            };
        }

        private void LogError(string message, Exception ex)
        {
            // Manejo de errores: puedes registrar los errores en un archivo de registro
            Console.WriteLine($"{message}: {ex.Message}");
        }
    }
}
