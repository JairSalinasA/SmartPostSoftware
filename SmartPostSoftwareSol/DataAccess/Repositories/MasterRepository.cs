using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Repositories
{
    // Clase MasterRepository que extiende de Repository
    public class MasterRepository : Repository
    {
        // Constructor de la clase MasterRepository
        public MasterRepository() : base()
        {
            // Inicializa la lista de parámetros
            parameter = new List<SqlParameter>();
        }

        // Lista de parámetros que se utilizarán en consultas SQL
        protected List<SqlParameter> parameter;

        // Método para ejecutar consultas que no devuelven resultados (INSERT, UPDATE, DELETE)
        protected int ExecuteNonQuery(string transacSql, List<SqlParameter> parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transacSql;
                    command.CommandType = CommandType.Text;

                    // Agregar los parámetros al comando
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    int result = command.ExecuteNonQuery();
                    return result;
                }
            }
        }


        // Método para ejecutar consultas que devuelven un conjunto de resultados (SELECT)
        protected DataTable ExecuteReader(string transacSql, List<SqlParameter> parameters)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transacSql;
                    command.CommandType = CommandType.Text;

                    // Agregar los parámetros al comando
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    SqlDataReader reader = command.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

    }
}

