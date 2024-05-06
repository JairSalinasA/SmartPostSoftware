using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    // Clase MasterRepository que extiende de Repository
    public class MasterRepository : Repository
    {
        // Lista de parámetros que se utilizarán en consultas SQL
        protected List<SqlParameter> parameter;

        // Método para ejecutar consultas que no devuelven resultados (INSERT, UPDATE, DELETE)
        protected int ExecuteNonQuery(string transacSql)
        {
            // Utiliza una conexión
            using (var connection = GetConnection()) 
            {
                // Abre la conexión
                connection.Open(); 
                using (var command = new SqlCommand()) // Crea un comando SQL
                {
                    command.Connection = connection;
                    command.CommandText = transacSql; // Establece la consulta SQL
                    command.CommandType = CommandType.Text; // Especifica el tipo de comando como texto

                    // Agrega los parámetros al comando
                    foreach (SqlParameter item in parameter)
                    {
                        command.Parameters.Add(item);
                    }

                    int result = command.ExecuteNonQuery(); // Ejecuta la consulta y devuelve el número de filas afectadas
                    parameter.Clear(); // Limpia los parámetros para la próxima consulta
                    return result; // Retorna el resultado de la ejecución
                }
            }
        }

        // Método para ejecutar consultas que devuelven un conjunto de resultados (SELECT)
        protected DataTable ExecuteReader(string transacSql)
        {
            using (var connection = GetConnection()) // Utiliza una conexión
            {
                connection.Open(); // Abre la conexión
                using (var command = new SqlCommand()) // Crea un comando SQL
                {
                    command.Connection = connection;
                    command.CommandText = transacSql; // Establece la consulta SQL
                    command.CommandType = CommandType.Text; // Especifica el tipo de comando como texto

                    SqlDataReader reader = command.ExecuteReader(); // Ejecuta la consulta y obtiene un lector de datos

                    using (var table = new DataTable()) // Crea una tabla para almacenar los resultados
                    {
                        table.Load(reader); // Carga los datos del lector en la tabla
                        reader.Dispose(); // Libera recursos del lector
                        return table; // Retorna la tabla con los resultados
                    }
                }
            }
        }
    }

}
