Use master;

go

-- Crear la base de datos
CREATE DATABASE smart_pos;
GO

-- Usar la base de datos creada
USE smart_pos;
GO

-- Crear la tabla de usuarios
CREATE TABLE usuarios (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    contraseña VARCHAR(100) NOT NULL,
    rol VARCHAR(20) NOT NULL
);
