USE [EscuelaMusica]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 20/08/2025 06:46:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[IdAlumno] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[FechaNacimiento] [date] NULL,
	[Matricula] [nvarchar](10) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escuela]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escuela](
	[IdEscuela] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Codigo] [nvarchar](10) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_Escuela] PRIMARY KEY CLUSTERED 
(
	[IdEscuela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EscuelaProfesor]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EscuelaProfesor](
	[IdEscuelaProf] [int] IDENTITY(1,1) NOT NULL,
	[IdEscuela] [int] NOT NULL,
	[IdProfesor] [int] NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_EscuelaProf] PRIMARY KEY CLUSTERED 
(
	[IdEscuelaProf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inscripcion]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripcion](
	[IdInscripcion] [int] IDENTITY(1,1) NOT NULL,
	[IdEscuela] [int] NULL,
	[IdAlumno] [int] NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Inscripcion] PRIMARY KEY CLUSTERED 
(
	[IdInscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[IdProfesor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[DNI] [nvarchar](10) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[IdProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfesorAlumno]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesorAlumno](
	[IdProfAlum] [int] IDENTITY(1,1) NOT NULL,
	[IdProfesor] [int] NULL,
	[IdInscripcion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_ProfesorAlumno] PRIMARY KEY CLUSTERED 
(
	[IdProfAlum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EscuelaProfesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesor] ([IdProfesor])
GO
ALTER TABLE [dbo].[EscuelaProfesor] CHECK CONSTRAINT [FK_Profesor]
GO
ALTER TABLE [dbo].[EscuelaProfesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Escuela] FOREIGN KEY([IdEscuela])
REFERENCES [dbo].[Escuela] ([IdEscuela])
GO
ALTER TABLE [dbo].[EscuelaProfesor] CHECK CONSTRAINT [FK_Profesor_Escuela]
GO
ALTER TABLE [dbo].[Inscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Inscripcion_Alumno] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([IdAlumno])
GO
ALTER TABLE [dbo].[Inscripcion] CHECK CONSTRAINT [FK_Inscripcion_Alumno]
GO
ALTER TABLE [dbo].[Inscripcion]  WITH CHECK ADD  CONSTRAINT [FK_Inscripcion_Escuela] FOREIGN KEY([IdEscuela])
REFERENCES [dbo].[Escuela] ([IdEscuela])
GO
ALTER TABLE [dbo].[Inscripcion] CHECK CONSTRAINT [FK_Inscripcion_Escuela]
GO
ALTER TABLE [dbo].[ProfesorAlumno]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorAlumno_Inscripcion] FOREIGN KEY([IdInscripcion])
REFERENCES [dbo].[Inscripcion] ([IdInscripcion])
GO
ALTER TABLE [dbo].[ProfesorAlumno] CHECK CONSTRAINT [FK_ProfesorAlumno_Inscripcion]
GO
ALTER TABLE [dbo].[ProfesorAlumno]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorAlumno_Profesor] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesor] ([IdProfesor])
GO
ALTER TABLE [dbo].[ProfesorAlumno] CHECK CONSTRAINT [FK_ProfesorAlumno_Profesor]
GO
/****** Object:  StoredProcedure [dbo].[SpAlumnoActualiza]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpAlumnoActualiza]
	@IdAlumno int = 0,
	@Nombre NVARCHAR(50) = '',
	@Apellido NVARCHAR(50) = '',
	@FechaNacimiento DATE,
	@Matricula NVARCHAR(10) = ''
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		SELECT @Id = IdAlumno FROM Alumno
		WHERE  (IdAlumno = @IdAlumno)
		IF(@Id != 0)
		BEGIN
			UPDATE Alumno
			SET          Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Matricula = @Matricula, FechaActualizacion = GETDATE()
			WHERE  (IdAlumno = @IdAlumno)
			SET @Id = @IdAlumno
			SET @Mensaje ='Actualización correcta.'
		END
		ELSE
		BEGIN
			SET @Id = 0
			SET @Mensaje ='El registro no existe.'
		END
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'La información que intentas ingresar ya existe: ' +  @ErrorMessage
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;

END
GO
/****** Object:  StoredProcedure [dbo].[SpAlumnoConsulta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpAlumnoConsulta]
	@IdAlumno int = 0
AS
BEGIN
	SET NOCOUNT ON;
SELECT IdAlumno, Nombre, Apellido, FechaNacimiento,Matricula
FROM     Alumno
WHERE  (IdAlumno = @IdAlumno)
END
GO
/****** Object:  StoredProcedure [dbo].[SpAlumnoElimina]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpAlumnoElimina]
	@IdAlumno int = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		SELECT @Id = IdAlumno FROM Alumno
		WHERE  (IdAlumno = @IdAlumno)
		IF(@Id != 0)
		BEGIN
			DELETE FROM Alumno
			WHERE  (IdAlumno = @IdAlumno)
			SET @Id = @Id
			SET @Mensaje ='Registro eliminado.'
		END
		ELSE
		BEGIN
			SET @Id = 0
			SET @Mensaje ='El registro no existe.'
		END
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH		
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SpAlumnoInserta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpAlumnoInserta]
	@Nombre NVARCHAR(50) = '',
	@Apellido NVARCHAR(50) = '',
	@FechaNacimiento DATE,
	@Matricula NVARCHAR(10) = ''
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		INSERT INTO Alumno
                  (Nombre, Apellido, FechaNacimiento, Matricula, FechaCreacion)
		VALUES (@Nombre,@Apellido,@FechaNacimiento,@Matricula, GETDATE());SELECT @Id =SCOPE_IDENTITY();
		SET @Mensaje ='Registro correcto. '
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'La información que intentas ingresar ya existe: ' +  @ErrorMessage
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SpEscuelaActualiza]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpEscuelaActualiza]
	@IdEscuela int = 0,
	@Nombre nvarchar(200) = '',
	@Descripcion nvarchar(MAX) = '',
	@Codigo nvarchar(10) = ''
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		SELECT @Id = IdEscuela FROM Escuela
		WHERE  (IdEscuela = @IdEscuela)
		IF(@Id != 0)
		BEGIN
			UPDATE Escuela
			SET          Nombre = @Nombre, Descripcion = @Descripcion, Codigo = @Codigo, FechaActualizacion = GETDATE()
			WHERE  (IdEscuela = @IdEscuela)
			SET @Id = @IdEscuela
			SET @Mensaje ='Actualización correcta.'
		END
		ELSE
		BEGIN
			SET @Id = 0
			SET @Mensaje ='El registro no existe.'
		END
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'La información que intentas ingresar ya existe: ' +  @ErrorMessage
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;

END
GO
/****** Object:  StoredProcedure [dbo].[SpEscuelaConsulta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpEscuelaConsulta]
	@IdEscuela int = 0
AS
BEGIN
	SET NOCOUNT ON;
SELECT IdEscuela, Nombre, Descripcion, Codigo
FROM     Escuela
where IdEscuela = @IdEscuela

END
GO
/****** Object:  StoredProcedure [dbo].[SpEscuelaElimina]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpEscuelaElimina]
	@IdEscuela int = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''
	BEGIN TRY
		SELECT @Id = IdEscuela FROM Escuela
		WHERE  (IdEscuela = @IdEscuela)
		IF(@Id != 0)
		BEGIN
			DELETE FROM Escuela
			WHERE  (IdEscuela = @Id)
			SET @Id = @Id
			SET @Mensaje ='Registro eliminado.'
		END
		ELSE
		BEGIN
			SET @Id = 0
			SET @Mensaje ='El registro no existe.'
		END
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH		
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SPEscuelaInserta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPEscuelaInserta] 
	@Nombre nvarchar(200) = '',
	@Descripcion nvarchar(MAX) = '',
	@Codigo nvarchar(10) = ''
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		INSERT INTO Escuela
						  (Nombre, Descripcion, Codigo, FechaCreacion)
		VALUES (@Nombre,@Descripcion,@Codigo,GETDATE());SELECT @Id =SCOPE_IDENTITY();
		SET @Mensaje ='Registro correcto. '
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'La información que intentas ingresar ya existe: ' +  @ErrorMessage
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SpEscuelaProfesorInserta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Primero se asigna el profesor a una escuela
--Segundo se realiza la inscripción del alumno a una escuela 
--tercero se asigna N alumnos a un profesor 

--primer paso se asigna el profesor a una escuela
CREATE PROCEDURE [dbo].[SpEscuelaProfesorInserta]
	@IdEscuela int = 0,
	@IdProfesor int = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		INSERT INTO EscuelaProfesor
                  (IdEscuela, IdProfesor, FechaCreacion)
		VALUES (@IdEscuela,@IdProfesor, GETDATE());SELECT @Id =SCOPE_IDENTITY();
		SET @Mensaje ='Registro correcto. '
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE()
			set @Id = 0

			DECLARE @Inicio INT = CHARINDEX('índice único ''', @ErrorMessage) + LEN('índice único ''')
			DECLARE @Fin INT = CHARINDEX('''', @ErrorMessage, @Inicio)
			DECLARE @NombreMensaje NVARCHAR(50) = SUBSTRING(@ErrorMessage, @Inicio, @Fin - @Inicio)

			IF(@NombreMensaje = 'ProfesorEscuela' or @NombreMensaje = 'IX_EscuelaProfesor')
			BEGIN
				SET @Mensaje = 'El profesor ' + (SELECT Nombre + ' ' + Apellido FROM Profesor WHERE IdProfesor =  @IdProfesor) + ' ya ha sido asignado a la escuela ' 
				+ ( SELECT Nombre FROM Escuela WHERE IdEscuela = @IdEscuela) + '.'
			END
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SpEscuelasProfesorConsulta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpEscuelasProfesorConsulta]
AS
BEGIN
	SET NOCOUNT ON;

SELECT Escuela.Nombre as Escuela,  Profesor.Nombre + ' ' + Profesor.Apellido as Profesor, Alumno.Nombre + ' ' + Alumno.Apellido as Alumno
FROM     Escuela INNER JOIN
                  EscuelaProfesor ON Escuela.IdEscuela = EscuelaProfesor.IdEscuela INNER JOIN
                  Profesor ON EscuelaProfesor.IdProfesor = Profesor.IdProfesor INNER JOIN
                  Inscripcion ON Escuela.IdEscuela = Inscripcion.IdEscuela INNER JOIN
                  Alumno ON Inscripcion.IdAlumno = Alumno.IdAlumno INNER JOIN
                  ProfesorAlumno ON Profesor.IdProfesor = ProfesorAlumno.IdProfesor AND Inscripcion.IdInscripcion = ProfesorAlumno.IdInscripcion

END
GO
/****** Object:  StoredProcedure [dbo].[SpInscripcionConsulta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpInscripcionConsulta]
	@IdInscripcion int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT Inscripcion.IdInscripcion, Escuela.Nombre AS Escuela, Alumno.Nombre + ' ' + Alumno.Apellido AS Alumno
FROM     Inscripcion INNER JOIN
                  Escuela ON Inscripcion.IdEscuela = Escuela.IdEscuela INNER JOIN
                  Alumno ON Inscripcion.IdAlumno = Alumno.IdAlumno
WHERE  (Inscripcion.IdInscripcion = @IdInscripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInscripcionInserta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--segundo se realiza la inscripción del alumno a una escuela 
CREATE PROCEDURE [dbo].[SpInscripcionInserta] 
	@IdEscuela int = 0,
	@IdAlumno int = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		INSERT INTO Inscripcion
                  (IdEscuela, IdAlumno, FechaCreacion)
		VALUES (@IdEscuela,@IdAlumno, GETDATE());SELECT @Id =SCOPE_IDENTITY();
		SET @Mensaje ='Registro correcto. '
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE()
			set @Id = 0

			DECLARE @Inicio INT = CHARINDEX('índice único ''', @ErrorMessage) + LEN('índice único ''')
			DECLARE @Fin INT = CHARINDEX('''', @ErrorMessage, @Inicio)
			DECLARE @NombreMensaje NVARCHAR(50) = SUBSTRING(@ErrorMessage, @Inicio, @Fin - @Inicio)

			IF(@NombreMensaje = 'InscripcionAlumno' or @NombreMensaje = 'IX_Inscripcion')
			BEGIN
				SET @Mensaje = 'El alumno ' + (SELECT Nombre + ' ' + Apellido FROM Alumno WHERE IdAlumno =  @IdAlumno) + ' ya ha sido asignado a la escuela ' 
				+ ( SELECT Nombre FROM Escuela WHERE IdEscuela = @IdEscuela) + '.'
			END
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SpProfesorActualiza]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpProfesorActualiza] --'A','AA','A'
	@IdProfesor int = 0,
	@Nombre NVARCHAR(50) = '',
	@Apellido NVARCHAR(50) = '',
	@DNI NVARCHAR(10) = ''
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		SELECT @Id = IdProfesor FROM Profesor
		WHERE  (IdProfesor = @IdProfesor)
		IF(@Id != 0)
		BEGIN
			UPDATE Profesor
			SET          Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, FechaActualizacion = GETDATE()
			WHERE  (IdProfesor = @IdProfesor)
			SET @Id = @IdProfesor
			SET @Mensaje ='Actualización correcta.'
		END
		ELSE
		BEGIN
			SET @Id = 0
			SET @Mensaje ='El registro no existe.'
		END
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'La información que intentas ingresar ya existe: ' +  @ErrorMessage
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;

END
GO
/****** Object:  StoredProcedure [dbo].[SpProfesorAlumnoInserta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--tercero se asigna N alumnos a un profesor 
CREATE PROCEDURE [dbo].[SpProfesorAlumnoInserta]-- 1,1, 3
	@IdProfesor int = 0,
	@IdEscuela int = 0,
	@IdInscripcion int = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''
	DECLARE @IdEscuelaAlumno int = 0
	DECLARE @IdEscuelaProfesor int = 0
	BEGIN TRY
		SELECT @IdEscuelaAlumno = IdEscuela
		FROM     Inscripcion
		WHERE  (IdInscripcion = @IdInscripcion)

		SELECT @IdEscuelaProfesor = IdEscuela
		FROM     EscuelaProfesor
		WHERE  (IdProfesor = @IdProfesor)

		--valida que el alumno se registre en la misma escuela del profesor
		--select @IdEscuelaAlumno , @IdEscuelaProfesor
		IF(@IdEscuelaAlumno = @IdEscuelaProfesor )
		BEGIN
			INSERT INTO ProfesorAlumno
                  (IdProfesor, IdInscripcion, FechaCreacion)
			VALUES (@IdProfesor,@IdInscripcion, GETDATE());SELECT @Id =SCOPE_IDENTITY();			
			SET @Mensaje = 'Registro correcto. '
		END
		ELSE
		BEGIN
			SET @Id = 0 
			SET @Mensaje = 'El alumno y el profesor deben pertenecer a la misma escuela.'
		END
		
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE()
			set @Id = 0

			DECLARE @Inicio INT = CHARINDEX('índice único ''', @ErrorMessage) + LEN('índice único ''')
			DECLARE @Fin INT = CHARINDEX('''', @ErrorMessage, @Inicio)
			DECLARE @NombreMensaje NVARCHAR(50) = SUBSTRING(@ErrorMessage, @Inicio, @Fin - @Inicio)

			IF(@NombreMensaje = 'IX_ProfesorAlumno')
			BEGIN
				SET @Mensaje = 'El alumno ' + (SELECT Nombre + ' ' + Apellido FROM Alumno WHERE IdAlumno =  
					(SELECT IdAlumno FROM Inscripcion where IdInscripcion = @IdInscripcion)) + ' ya ha sido registrado con el mismo profesor. ' 				
			END
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SpProfesorAlumnosConsulta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpProfesorAlumnosConsulta]  --1
	@IdProfesor int = 0
AS
BEGIN
	SET NOCOUNT ON;
SELECT Profesor.Nombre + ' ' + Profesor.Apellido as Profesor, Escuela.Nombre AS Escuela, Alumno.Nombre + ' ' + Alumno.Apellido AS Alumno
FROM     Inscripcion INNER JOIN
                  Escuela ON Inscripcion.IdEscuela = Escuela.IdEscuela INNER JOIN
                  Alumno ON Inscripcion.IdAlumno = Alumno.IdAlumno INNER JOIN
                  EscuelaProfesor ON Escuela.IdEscuela = EscuelaProfesor.IdEscuela INNER JOIN
                  Profesor ON EscuelaProfesor.IdProfesor = Profesor.IdProfesor
WHERE  (Profesor.IdProfesor = @IdProfesor)

END
GO
/****** Object:  StoredProcedure [dbo].[SpProfesorConsulta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpProfesorConsulta]
	@IdProfesor int = 0 
AS
BEGIN
	SET NOCOUNT ON;

SELECT IdProfesor, Nombre, Apellido, DNI
FROM     Profesor
WHERE  (IdProfesor = @IdProfesor)

END
GO
/****** Object:  StoredProcedure [dbo].[SpProfesorElimina]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpProfesorElimina]
	@IdProfesor int = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''
	BEGIN TRY
		SELECT @Id = IdProfesor FROM Profesor
		WHERE  (IdProfesor = @IdProfesor)
		IF(@Id != 0)
		BEGIN
			DELETE FROM Profesor
			WHERE  (IdProfesor = @Id)
			SET @Id = @Id
			SET @Mensaje ='Registro eliminado.'
		END
		ELSE
		BEGIN
			SET @Id = 0
			SET @Mensaje ='El registro no existe.'
		END
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH		
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SpProfesorInserta]    Script Date: 20/08/2025 06:46:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpProfesorInserta]
	@Nombre NVARCHAR(50) = '',
	@Apellido NVARCHAR(50) = '',
	@DNI NVARCHAR(10) = ''
AS
BEGIN
	SET NOCOUNT ON;
	   
	DECLARE @Id int = 0 
	DECLARE @Mensaje nvarchar(max) = ''

	BEGIN TRY
		INSERT INTO Profesor
                  (Nombre, Apellido, DNI, FechaCreacion)
		VALUES (@Nombre,@Apellido,@DNI, GETDATE());SELECT @Id =SCOPE_IDENTITY();
		SET @Mensaje ='Registro correcto. '
		SELECT @Id as IdRegistro, @Mensaje as Mensaje
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER() = 2601
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE();
			set @Id = 0
			SET @Mensaje = 'La información que intentas ingresar ya existe: ' +  @ErrorMessage
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
		ELSE
		BEGIN
			set @Id = 0
			SET @Mensaje = 'Ocurrió un error inesperado.' + CAST(ERROR_NUMBER() AS VARCHAR(10));
			SELECT @Id as IdRegistro, @Mensaje as Mensaje
		END
	END CATCH;
END
GO
