use smart_pos
GO

/*Crud Tabla*/

/*Crear (Create):*/
INSERT INTO usuarios (nombre, apellido, email, contraseña, rol)
VALUES ('Juan', 'Pérez', 'juan@example.com', 'contraseña123', 'empleado');

/*Leer (Read):*/
SELECT * FROM usuarios;

/*Actualizar (Update):*/
UPDATE usuarios
SET nombre = 'Carlos', apellido = 'González'
WHERE id = 1;

/*Eliminar (Delete):*/
DELETE FROM usuarios WHERE id = 1;




