using DataAccess.Contracts;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserModel
    {
        public class Usuario
        {
            // Propiedad para almacenar el ID del usuario
            private int id;

            // Propiedad para almacenar el nombre del usuario
            private string nombre;

            // Propiedad para almacenar el apellido del usuario
            private string apellido;

            // Propiedad para almacenar el email del usuario
            private string email;

            // Propiedad para almacenar la contraseña del usuario
            private string contraseña;

            // Propiedad para almacenar el rol del usuario (puede ser admin, usuario regular, etc.)
            private string rol;

            private IUserRepository UserRepository;
            public EntityState state { private get; set; }

            //Propiedades - validaciones -vaidar datos
            public int Id { get => id; set => id = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public string Apellido { get => apellido; set => apellido = value; }
            public string Email { get => email; set => email = value; }
            public string Contraseña { get => contraseña; set => contraseña = value; }
            public string Rol { get => rol; set => rol = value; }
        }
    }
}
