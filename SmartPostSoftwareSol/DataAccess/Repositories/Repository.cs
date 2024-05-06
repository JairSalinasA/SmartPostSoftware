using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class Repository
    {
        private readonly string connectionString; // Cadena de conexión a la base de datos

        // Constructor de la clase Repository
        public Repository()
        {
            // Obtiene la cadena de conexión del archivo de configuración (app.config o web.config)
            connectionString = ConfigurationManager.ConnectionStrings["con_Smartpos_db"].ToString();
        }

        // Método para obtener una conexión a la base de datos
        protected SqlConnection GetConnection()
        {
            // Crea y retorna una nueva conexión utilizando la cadena de conexión
            return new SqlConnection(connectionString);
        }
    }

}
