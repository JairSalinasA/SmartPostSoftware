Use master;

go

-- Crear la base de datos
CREATE DATABASE smart_pos;
GO

-- Usar la base de datos creada
USE smart_pos;
GO

-- Crear la tabla de usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Email VARCHAR(100),
    Contraseña VARCHAR(100),
    ContraseñaHash VARCHAR(100),
    Rol VARCHAR(50) -- Agregamos el campo "Rol"
);
