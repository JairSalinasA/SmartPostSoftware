using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserModel
    {
        private readonly IUserRepository _userRepository;

        // Constructor que inyecta la dependencia IUserRepository
        public UserModel(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // Propiedades del usuario con validaciones
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email no tiene un formato válido")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una letra minúscula, un número y un carácter especial")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; }

        // EntityState se puede cambiar solo internamente en el modelo
        public EntityState EntityState { private get; set; }

        // Método para guardar los cambios en el repositorio
        public string SaveChanges()
        {
            try
            {
                var userDataModel = new Usuario
                {
                    Id = Id,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Email = Email,
                    Contraseña = Contraseña,
                    Rol = Rol
                };

                switch (EntityState)
                {
                    case EntityState.Unchanged:
                    case EntityState.Added:
                        _userRepository.Add(userDataModel);
                        return "Usuario agregado correctamente";
                    case EntityState.Modified:
                        _userRepository.Update(userDataModel);
                        return "Usuario actualizado correctamente";
                    case EntityState.Deleted:
                        _userRepository.Delete(Id);
                        return "Usuario eliminado correctamente";
                    default:
                        return "Operación desconocida";
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                if (sqlEx.Number == 2627)
                {
                    return "Dato duplicado, por favor revisar el dato";
                }
                else
                {
                    return "Error al guardar los cambios: " + sqlEx.Message;
                }
            }
            catch (Exception ex)
            {
                return "Error al guardar los cambios: " + ex.Message;
            }
        }

        // Método para obtener todos los usuarios del repositorio
        public List<UserModel> GetAll()
        {
            var userDataModel = _userRepository.GetAll();
            var listUsers = new List<UserModel>();
            foreach (Usuario item in userDataModel)
            {
                listUsers.Add(new UserModel(_userRepository)
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Email = item.Email,
                    Contraseña = item.Contraseña,
                    Rol = item.Rol
                });
            }
            return listUsers;
        }
    }
}

