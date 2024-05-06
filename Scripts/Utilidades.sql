

/*Para obtener los nombres de los campos (columnas) de la tabla "usuarios" en SQL Server, puedes utilizar la siguiente consulta:*/

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'usuarios';