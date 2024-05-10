using DataAccess.Contracts;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            // Propiedad para el ID del usuario. Utiliza una expresión lambda para acceder al campo privado id y establecer su valor.

            [Required(ErrorMessage = "El nombre es obligatorio")]
            public string Nombre { get => nombre; set => nombre = value; }
            // Propiedad para el nombre del usuario. Utiliza una expresión lambda para acceder al campo privado nombre y establecer su valor. 
            // La anotación [Required] indica que este campo es obligatorio y muestra el mensaje de error especificado si el valor es nulo o vacío.

            [Required(ErrorMessage = "El apellido es obligatorio")]
            public string Apellido { get => apellido; set => apellido = value; }
            // Propiedad para el apellido del usuario. Utiliza una expresión lambda para acceder al campo privado apellido y establecer su valor.
            // La anotación [Required] indica que este campo es obligatorio y muestra el mensaje de error especificado si el valor es nulo o vacío.

            [Required(ErrorMessage = "El email es obligatorio")]
            [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
            public string Email { get => email; set => email = value; }
            // Propiedad para el email del usuario. Utiliza una expresión lambda para acceder al campo privado email y establecer su valor.
            // La anotación [Required] indica que este campo es obligatorio y muestra el mensaje de error especificado si el valor es nulo o vacío.
            // La anotación [EmailAddress] valida que el valor tenga un formato de dirección de correo electrónico válido y muestra el mensaje de error especificado si no lo tiene.

            [Required(ErrorMessage = "La contraseña es obligatoria")]
            [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
            public string Contraseña { get => contraseña; set => contraseña = value; }
            // Propiedad para la contraseña del usuario. Utiliza una expresión lambda para acceder al campo privado contraseña y establecer su valor.
            // La anotación [Required] indica que este campo es obligatorio y muestra el mensaje de error especificado si el valor es nulo o vacío.
            // La anotación [MinLength] valida que la longitud del valor sea de al menos 6 caracteres y muestra el mensaje de error especificado si no lo es.

            [Required(ErrorMessage = "El rol es obligatorio")]
            public string Rol { get => rol; set => rol = value; }
            // Propiedad para el rol del usuario. Utiliza una expresión lambda para acceder al campo privado rol y establecer su valor.
            // La anotación [Required] indica que este campo es obligatorio y muestra el mensaje de error especificado si el valor es nulo o vacío.

        }
    }
}
