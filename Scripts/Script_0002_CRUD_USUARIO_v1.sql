use smart_pos
GO

/*Crud Tabla*/

/*Crear (Create):*/
INSERT INTO usuarios (nombre, apellido, email, contrase�a, rol)
VALUES ('Juan', 'P�rez', 'juan@example.com', 'contrase�a123', 'empleado');

/*Leer (Read):*/
SELECT * FROM usuarios;

/*Actualizar (Update):*/
UPDATE usuarios
SET nombre = 'Carlos', apellido = 'Gonz�lez'
WHERE id = 1;

/*Eliminar (Delete):*/
DELETE FROM usuarios WHERE id = 1;




