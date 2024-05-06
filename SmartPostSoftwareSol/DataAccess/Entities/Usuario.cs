using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Usuario
    {
        // Propiedad para almacenar el ID del usuario
        public int Id { get; set; }

        // Propiedad para almacenar el nombre del usuario
        public string Nombre { get; set; }

        // Propiedad para almacenar el apellido del usuario
        public string Apellido { get; set; }

        // Propiedad para almacenar el email del usuario
        public string Email { get; set; }

        // Propiedad para almacenar la contraseña del usuario
        public string Contraseña { get; set; }

        // Propiedad para almacenar el rol del usuario (puede ser admin, usuario regular, etc.)
        public string Rol { get; set; }
    }

}
    