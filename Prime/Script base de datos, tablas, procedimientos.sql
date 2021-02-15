
CREATE DATABASE prime; 
USE prime;

CREATE TABLE Estudiante
(
	Codigo varchar(10),
	Nombres varchar(100),
	Apellidos varchar(100),
	Acudiente varchar(200),
	Usuario varchar(20),
	Contraseña varchar(20),
	EstudianteId int identity(1, 1) primary key
)

CREATE TABLE Curso
(
	Codigo varchar(10),
	Nombre varchar(50),	
	CursoId int identity(1, 1) primary key
)

CREATE TABLE Horario
(
	Dia varchar(10),
	Hora time,
	Aula varchar(50),
	HorarioId int identity(1, 1) primary key,
	EstudianteId int foreign key references Estudiante(EstudianteId),
	Curso int foreign key references Curso(CursoId)
)

CREATE TABLE Direccion
(
	Pais varchar(50),
	Estado varchar(50),
	Ciudad varchar(50),
	Barrio varchar(100),
	Calle varchar(50),
	CasaApto varchar(20),
	DireccionId int identity(1, 1) primary key,
	EstudianteId int foreign key references Estudiante(EstudianteId)
)

-- Sp crear direccion
CREATE PROCEDURE DireccionInsert
(
	@Pais varchar(50),
	@Estado varchar(50),
	@Ciudad varchar(50),
	@Barrio varchar(100),
	@Calle varchar(50),
	@CasaApto varchar(20),
	@DireccionId int,
	@EstudianteId int
)
AS
BEGIN 
	INSERT INTO Direccion
	(
		Pais, 
		Estado, 
		Ciudad, 
		Barrio, 
		Calle, 
		CasaApto, 
		EstudianteId
	)
	VALUES
	(
		@Pais,
		@Estado, 
		@Ciudad, 
		@Barrio, 
		@Calle, 
		@CasaApto,
		@EstudianteId
	)
END

-- Sp selecccionar direccion todas
CREATE PROCEDURE DireccionSelect
AS
BEGIN
	SELECT * 
	FROM Direccion	
END

-- Sp seleccionar direccion x estudiante
CREATE PROCEDURE DireccionSelectByEstudianteId
(
	@EstudianteId int
)
AS
BEGIN
	SELECT * 
	FROM Direccion	
	WHERE EstudianteId = @EstudianteId
END

-- Sp actualizar Direccion
CREATE PROCEDURE DireccionUpdate
(
	@Pais varchar(50),
	@Estado varchar(50),
	@Ciudad varchar(50),
	@Barrio varchar(100),
	@Calle varchar(50),
	@CasaApto varchar(20),
	@DireccionId int,
	@EstudianteId int
)
AS
BEGIN
	UPDATE Direccion SET 
		Pais=@Pais, 
		Estado=@Estado, 
		Ciudad=@Ciudad, 
		Barrio=@Barrio, 
		Calle=@Calle, 
		CasaApto=@CasaApto, 
		EstudianteId=@EstudianteId
	WHERE 
		@DireccionId=@DireccionId
END

-- Sp Eliminar direccion
CREATE PROCEDURE DireccionDelete
(
	@DireccionId int
)
AS
BEGIN
	DELETE 
	FROM Direccion
	WHERE DireccionId = @DireccionId
END