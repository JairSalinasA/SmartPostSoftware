use smart_pos
GO

-- CREATE: Insertar un nuevo usuario 
INSERT INTO Usuarios (Id, Nombre, Apellido, Email, Contrase�a, Contrase�aHash, Rol)
VALUES (1, 'Juan', 'P�rez', 'juan@example.com', 'password123', 'hashed_password_123', 'admin');


-- READ: Obtener todos los usuarios
SELECT * FROM Usuarios;

-- READ: Obtener un usuario por su ID
SELECT * FROM Usuarios WHERE Id = 1;
 
-- UPDATE: Actualizar un usuario
UPDATE Usuarios
SET Email = 'nuevo_email@example.com', Contrase�a = 'nueva_contrase�a', Rol = 'nuevo_rol'
WHERE Id = 1;



-- DELETE: Eliminar un usuario por su ID
DELETE FROM Usuarios WHERE Id = 1;
