using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public string ContraseñaHash { get;  set; }

        // Propiedad para almacenar el rol del usuario (puede ser admin, usuario regular, etc.)
        public string Rol { get; set; } 
        // Método para establecer la contraseña y generar su hash
        public void SetContraseña(string contraseña)
        {
            // Generar un salt aleatorio
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Generar el hash de la contraseña con PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combinar el salt y el hash en un solo arreglo
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convertir el hash en una cadena base64
            ContraseñaHash = Convert.ToBase64String(hashBytes);
        }
    }

}
    