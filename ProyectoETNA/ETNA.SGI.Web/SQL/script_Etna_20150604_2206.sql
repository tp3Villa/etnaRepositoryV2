USE [master]
GO
--/****** Object:  Database [ETNA]    Script Date: 04/06/2015 10:07:04 p.m. ******/
--CREATE DATABASE [ETNA] ON  PRIMARY 
--( NAME = N'ETNATP3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\Etna\ETNA.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'ETNATP3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\Etna\ETNA_1.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
--GO
--ALTER DATABASE [ETNA] SET COMPATIBILITY_LEVEL = 100
--GO
--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [ETNA].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO
--ALTER DATABASE [ETNA] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [ETNA] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [ETNA] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [ETNA] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [ETNA] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [ETNA] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [ETNA] SET AUTO_CREATE_STATISTICS ON 
--GO
--ALTER DATABASE [ETNA] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [ETNA] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [ETNA] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [ETNA] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [ETNA] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [ETNA] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [ETNA] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [ETNA] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [ETNA] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [ETNA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [ETNA] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [ETNA] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [ETNA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [ETNA] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [ETNA] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [ETNA] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [ETNA] SET RECOVERY FULL 
--GO
--ALTER DATABASE [ETNA] SET  MULTI_USER 
--GO
--ALTER DATABASE [ETNA] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [ETNA] SET DB_CHAINING OFF 
--GO
--EXEC sys.sp_db_vardecimal_storage_format N'ETNA', N'ON'
GO
USE [ETNA]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_INVENTARIO_PROGRAMADO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_INVENTARIO_PROGRAMADO]
(
	@IN_idProgInventario INTEGER,
	@DT_FechaProgramada DATETIME,
	@IN_TipoInventario INTEGER,
	@IN_idAlmacen INTEGER
)
AS
BEGIN
	DECLARE @IN_CONT INTEGER
	
	DECLARE @IN_MENSUAL INTEGER
	DECLARE @IN_ANUAL INTEGER
	DECLARE @IN_CICLICO INTEGER
	
	DECLARE @IN_ESTADO INTEGER
	
	SET @IN_ESTADO = (SELECT idTipo FROM tablaTipo WHERE UPPER(idTabla) = UPPER('tipoEstadoInventario') AND UPPER(nombre) = UPPER('PENDIENTE'))
	
	SET @IN_MENSUAL = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'MENSUAL' AND UPPER(idTabla) = 'tipoInventario')
	SET @IN_ANUAL = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'ANUAL' AND UPPER(idTabla) = 'tipoInventario')
	SET @IN_CICLICO = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'CICLICO' AND UPPER(idTabla) = 'tipoInventario')
	
	IF @IN_MENSUAL = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND MONTH(@DT_FechaProgramada) = MONTH(GETDATE())
																AND idEstadoInventario = @IN_ESTADO
																AND activo = 1
																AND idProgInventario <> @IN_idProgInventario),0)
	END
	
	IF @IN_ANUAL = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND YEAR(@DT_FechaProgramada) = YEAR(GETDATE())
																AND idEstadoInventario = @IN_ESTADO
																AND activo = 1
																AND idProgInventario <> @IN_idProgInventario),0)
	END
	
	IF @IN_CICLICO = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND MONTH(@DT_FechaProgramada) <= (MONTH(GETDATE())+ 3)
																AND idEstadoInventario = @IN_ESTADO
																AND activo = 1
																AND idProgInventario <> @IN_idProgInventario),0)
	END
	
	IF @IN_CONT = 0
	BEGIN
		UPDATE programacionInventario 
		SET tipoInventario = @IN_TipoInventario, fechaProgramada = @DT_FechaProgramada,
			idAlmacen = @IN_idAlmacen
		WHERE idProgInventario = @IN_idProgInventario
		
		SELECT 0
	END
	ELSE
	BEGIN
		SELECT 1
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AJUSTAR_INVENTARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AJUSTAR_INVENTARIO]
(
	@IN_idProgInventario INTEGER
)
AS
BEGIN
	BEGIN TRAN TX_AJUSTAR_INVENTARIO
	-- Variables para valores de tipos
	DECLARE @IN_situacion INTEGER
	DECLARE @IN_tipoDocIngreso INTEGER
	DECLARE @IN_tipoDocSalida INTEGER
	DECLARE @IN_estadoFinalizado INTEGER
	DECLARE @IN_idClienteProveedor INTEGER
	DECLARE @IN_activo INTEGER
	DECLARE @IN_inactivo INTEGER
	
	-- Asignar ID de situacion TOTAL, tipo mov INGRESO y tipo mov SALIDA
	SET @IN_situacion = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'PENDIENTE' AND UPPER(idTabla) = UPPER('estadoAtencion'))
	SET @IN_tipoDocIngreso = (SELECT idTipo FROM tablaTipo WHERE nombre = 'INGRESO')
	SET @IN_tipoDocSalida  = (SELECT idTipo FROM tablaTipo WHERE nombre = 'SALIDA')
	SET @IN_estadoFinalizado = (SELECT idTipo FROM tablaTipo WHERE nombre = 'FINALIZADO')
	SET @IN_activo = 1 -- activo
	SET @IN_inactivo = 0 -- inactivo
	
	-- Variables para recuperar datos del inventario
	DECLARE @IN_idProducto INTEGER, @IN_cantidad INTEGER, @IN_cantidadActual INTEGER, @IN_idInventario INTEGER,
			@Ch_Cod_Usuario CHAR(10), @IN_idAlmacen INTEGER
	
	-- Variables para grabar los documentos de ajuste		
	DECLARE @CH_numeroDoc VARCHAR(10), @IN_tipoDoc INTEGER, @IN_idDoc INTEGER, @IN_cantidadAjuste INTEGER
	
	-- Recuperar los datos del inventario al que se le procesa el ajuste
	BEGIN
		SELECT @IN_idInventario = idInventario, @Ch_Cod_Usuario = Cod_Usuario, @IN_idAlmacen = idAlmacen
		FROM inventario WHERE idProgInventario = @IN_idProgInventario
		
		SET @IN_idClienteProveedor  = (SELECT idPersona FROM persona WHERE Cod_Usuario = @Ch_Cod_Usuario)
	END
	
	-- Calcular las diferencias del inventario
	UPDATE detalleInventario
		SET cantidadAjuste = cantidadActual - cantidad
		WHERE idInventario = @IN_idInventario
	
	-- Leer un cursor de los productos faltantes, si existe por lo menos uno,
	-- generar el documento pendiente de atención INGRESO con la situación de atención TOTAL
	DECLARE detalle_pendiente_cursor CURSOR FOR 
		SELECT cantidadAjuste, idProducto
			FROM detalleInventario
			WHERE idInventario = @IN_idInventario 
				AND cantidadAjuste < 0
				
	-- Abrir el cursor
	OPEN detalle_pendiente_cursor
	
	-- Recuperar el primer producto con diferencia
	FETCH NEXT FROM detalle_pendiente_cursor 
	INTO @IN_cantidadAjuste, @IN_idProducto
	
	-- Como existe un producto por lo menos, crear la cabecera
	IF @@FETCH_STATUS = 0
	BEGIN
		-- Generar el número de documento
		SET @CH_numeroDoc = (SELECT RIGHT(REPLICATE('0',10) + CONVERT(VARCHAR(10), ISNULL(MAX(numeroDocPendiente),0) + 1),10) FROM documentoPendiente)
		
		SET @IN_idDoc = ISNULL((SELECT MAX(idDocPendiente) FROM documentoPendiente),0) + 1
		
		SET @IN_tipoDoc = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'ORDEN DE COMPRA' AND UPPER(idTabla) = UPPER('tipoDocumentoPendiente'))
		
		-- Maestro de documentoPendiente
		INSERT INTO documentoPendiente (idDocPendiente, numeroDocPendiente, tipoDocumentoPendiente, idClienteProveedor, fechaDocumento, situacionatencion,
				activo, Cod_Usuario, fechaCreacion, tipoMovimiento, idAlmacen, areaSolicitante, idUsuarioSolicitante)
		VALUES (@IN_idDoc, @CH_numeroDoc, @IN_tipoDoc, @IN_idClienteProveedor, GETDATE(), @IN_situacion, @IN_activo, @Ch_Cod_Usuario, GETDATE(), @IN_tipoDocIngreso, @IN_idAlmacen, 'Sistema', @Ch_Cod_Usuario)
		
	END
	-- Ingresar el detalle para todos los productos
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Registro de detalle
		INSERT INTO detalleDocumentoPendiente (idDocPendiente, idDetalleDocPendiente, idProducto, cantidadPedida, cantidadAtendida)
			VALUES (@IN_idDoc, @IN_idProducto, @IN_idProducto, ABS(@IN_cantidadAjuste), ABS(@IN_cantidadAjuste))
			
		-- Recuperar siguiente producto con diferencia
		FETCH NEXT FROM detalle_pendiente_cursor 
			INTO @IN_cantidadAjuste, @IN_idProducto
	END
	CLOSE detalle_pendiente_cursor
	DEALLOCATE detalle_pendiente_cursor
	
	-- Leer un cursor de los productos faltantes, si existe por lo menos uno,
	-- generar el documento pendiente de atención SALIDA con la situación de atención TOTAL
	DECLARE detalle_pendiente_cursor CURSOR FOR 
		SELECT cantidadAjuste, idProducto
			FROM detalleInventario
			WHERE idInventario = @IN_idInventario 
				AND cantidadAjuste > 0
				
	-- Abrir el cursor
	OPEN detalle_pendiente_cursor
	
	-- Recuperar el primer producto con diferencia
	FETCH NEXT FROM detalle_pendiente_cursor 
	INTO @IN_cantidadAjuste, @IN_idProducto
	
	-- Como existe un producto por lo menos, crear la cabecera
	IF @@FETCH_STATUS = 0
	BEGIN
		-- Generar el número de documento
		SET @CH_numeroDoc = (SELECT RIGHT(REPLICATE('0',10) + CONVERT(VARCHAR(10), ISNULL(MAX(numeroDocPendiente),0) + 1),10) FROM documentoPendiente)
		
		SET @IN_idDoc = ISNULL((SELECT MAX(idDocPendiente) FROM documentoPendiente),0) + 1
		
		SET @IN_tipoDoc = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'ORDEN DE PEDIDO' AND UPPER(idTabla) = UPPER('tipoDocumentoPendiente'))
		
		-- Maestro de documentoPendiente
		INSERT INTO documentoPendiente (idDocPendiente, numeroDocPendiente, tipoDocumentoPendiente, idClienteProveedor, fechaDocumento, situacionatencion,
				activo, Cod_Usuario, fechaCreacion, tipoMovimiento, idAlmacen, areaSolicitante, idUsuarioSolicitante)
		VALUES (@IN_idDoc, @CH_numeroDoc, @IN_tipoDoc, @IN_idClienteProveedor, GETDATE(), @IN_situacion, @IN_activo, @Ch_Cod_Usuario, GETDATE(), @IN_tipoDocSalida, @IN_idAlmacen, 'Sistema', @Ch_Cod_Usuario)
		
	END
	-- Ingresar el detalle para todos los productos
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Registro de detalle
		INSERT INTO detalleDocumentoPendiente (idDocPendiente, idDetalleDocPendiente, idProducto, cantidadPedida, cantidadAtendida)
			VALUES (@IN_idDoc, @IN_idProducto, @IN_idProducto, ABS(@IN_cantidadAjuste), ABS(@IN_cantidadAjuste))
			
		-- Recuperar siguiente producto con diferencia
		FETCH NEXT FROM detalle_pendiente_cursor 
			INTO @IN_cantidadAjuste, @IN_idProducto
	END
	CLOSE detalle_pendiente_cursor
	DEALLOCATE detalle_pendiente_cursor
	
	BEGIN
		-- Actualizar el estado de la programación de inventario a FINALIZADO
		UPDATE programacionInventario 
		SET idEstadoInventario = @IN_estadoFINALIZADO
		WHERE idProgInventario = @IN_idProgInventario
		
		-- Actualizar el inventario con la fecha de finalizado y estado INACTIVO
		UPDATE inventario
		SET activo = @IN_inactivo, fechaHoraFin = GETDATE()
		WHERE idInventario = @IN_idInventario
	END
	-- Finalizar la transacción	
	COMMIT TRAN TX_AJUSTAR_INVENTARIO
	
	SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DOCUMENTOPENDIENTE_LISTAR]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DOCUMENTOPENDIENTE_LISTAR]
(
	@IN_SITUACIONATENCION INTEGER = 0,
	@IN_IDALMACEN INTEGER = 0,
	@IN_TIPOMOVIMIENTO INTEGER = 0
)
AS
BEGIN
	SELECT	documentoPendiente.idDocPendiente,
			documentoPendiente.numeroDocPendiente,
			documentoPendiente.idClienteProveedor,
			documentoPendiente.tipoDocumentoPendiente,
			(select nombre
			 from tablaTipo
			  where tablaTipo.idTabla = 'tipoDocumentoPendiente'
			   and tablaTipo.idTipo = documentoPendiente.tipoDocumentoPendiente)
			 as descripcionDocumentoPendiente,
			documentoPendiente.fechaDocumento,
			documentoPendiente.activo,
			documentoPendiente.situacionatencion,
			ISNULL((select nombre
			 from tablaTipo
			  where tablaTipo.idTabla = 'estadoAtencion'
			   and tablaTipo.idTipo = documentoPendiente.situacionatencion),'')
			 as descripcionSituacionAtencion,
			persona.nombres + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno  as Origen ,
			persona.centrocosto,
			ISNULL(documentoPendiente.idAlmacen,0) idAlmacen,
			ISNULL(almacen.descripcionAlmacen,'') descripcionAlmacen,
			ISNULL(documentoPendiente.tipoMovimiento,0) tipoMovimiento,
			ISNULL((select nombre
			 from tablaTipo
			  where tablaTipo.idTabla = 'tipoMovimiento'
			   and tablaTipo.idTipo = documentoPendiente.tipoMovimiento),'')
			 as descripcionTipoMovimiento
	FROM	documentoPendiente 
			inner join persona persona on documentoPendiente.idClienteProveedor = persona.idPersona
			left outer join almacen on almacen.idAlmacen = documentoPendiente.idAlmacen
	WHERE	documentoPendiente.activo = 1
			AND (@IN_SITUACIONATENCION = 0 or documentoPendiente.situacionatencion = @IN_SITUACIONATENCION)
			AND (@IN_TIPOMOVIMIENTO = 0 OR documentoPendiente.tipoMovimiento = @IN_TIPOMOVIMIENTO)
			AND (@IN_IDALMACEN = 0 OR documentoPendiente.idAlmacen = @IN_IDALMACEN)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_DETALLEMOVIMIENTO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EDITAR_DETALLEMOVIMIENTO]
(
	@IN_IDDOCPENDIENTE INTEGER,
	@IN_IDPRODUCTO INTEGER,
	@IN_CANTIDAD INTEGER
)
AS
BEGIN

	UPDATE detalleDocumentoPendiente 
	SET cantidadAtendida = @IN_CANTIDAD
	WHERE idDocPendiente = @IN_IDDOCPENDIENTE
	AND idProducto = @IN_IDPRODUCTO
	
	SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_STOCKPRODUCTO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EDITAR_STOCKPRODUCTO]
(
	@IN_IDALMACEN INTEGER,
	@IN_IDPRODUCTO INTEGER,
	@IN_CANTIDADRESERVADA INTEGER
)
AS
BEGIN

	UPDATE stock 
	SET cantidadReservada = @IN_CANTIDADRESERVADA
	WHERE idAlmacen = @IN_IDALMACEN
	AND idProducto = @IN_IDPRODUCTO
	
	SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_TOMA_INVENTARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EDITAR_TOMA_INVENTARIO]
(
	@IN_IDDETALLEINVENTARIO INTEGER,
	@IN_CANTIDAD INTEGER
)
AS
BEGIN

	UPDATE detalleInventario 
	SET cantidad = @IN_CANTIDAD
	WHERE idDetalleInventario = @IN_IDDETALLEINVENTARIO
	
	SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_INVENTARIO_PROGRAMADO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_INVENTARIO_PROGRAMADO]
(
	@IN_idProgInventario INTEGER
)
AS
BEGIN

	UPDATE programacionInventario 
	SET activo = 0
	WHERE idProgInventario = @IN_idProgInventario
	
	SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_FINALIZAR_TOMA_INVENTARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FINALIZAR_TOMA_INVENTARIO]
(
	@IN_IDINVENTARIO INTEGER
)
AS
BEGIN

	DECLARE @IN_IDPROGINVENTARIO INTEGER
	DECLARE @IN_CONT INTEGER
	DECLARE @IN_CONT_CANTIDAD INTEGER
	
	SET @IN_CONT = (SELECT COUNT(*) FROM detalleInventario d 
					INNER JOIN producto p ON d.idProducto = p.idProducto
					WHERE d.idInventario = @IN_IDINVENTARIO)
					
	SET @IN_CONT_CANTIDAD = (SELECT COUNT(*) FROM detalleInventario d 
							INNER JOIN producto p ON d.idProducto = p.idProducto
							WHERE d.idInventario = @IN_IDINVENTARIO AND ISNULL(d.cantidad,0) > 0)
					
	IF @IN_CONT = @IN_CONT_CANTIDAD
	BEGIN		
		SET @IN_IDPROGINVENTARIO = (SELECT idProgInventario FROM inventario WHERE idInventario = @IN_IDINVENTARIO)

		UPDATE programacionInventario 
		SET idEstadoInventario = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = UPPER('CONTABILIZADO'))
		WHERE idProgInventario = @IN_IDPROGINVENTARIO
		
		SELECT 0
	END
	ELSE
	BEGIN
		SELECT 1
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_DETALLEMOVIMIENTO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GUARDAR_DETALLEMOVIMIENTO]
(
	@IN_IDDOCPENDIENTE INTEGER
)
AS
BEGIN

	DECLARE @IN_CANTIDAD_ATENDIDA INTEGER,@IN_CANTIDAD_PEDIDA INTEGER, @TOTAL INTEGER, @PARCIAL INTEGER
	
	SELECT @TOTAL = 0, @PARCIAL = 0


	DECLARE detalle_cursor CURSOR FOR 
	SELECT sum(cantidadAtendida) as cantidadAtendida ,sum(cantidadPedida) as cantidadPedida
	FROM detalleDocumentoPendiente
	WHERE idDocPendiente = @IN_IDDOCPENDIENTE
	
	OPEN detalle_cursor
	
	FETCH NEXT FROM detalle_cursor 
	INTO @IN_CANTIDAD_ATENDIDA,@IN_CANTIDAD_PEDIDA
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@IN_CANTIDAD_ATENDIDA < @IN_CANTIDAD_PEDIDA)
		BEGIN
			SET @PARCIAL = 1
		END
		ELSE
		BEGIN
			SET @TOTAL = 1
		END
		
		FETCH NEXT FROM detalle_cursor 
		INTO @IN_CANTIDAD_ATENDIDA,@IN_CANTIDAD_PEDIDA
	END 
	CLOSE detalle_cursor
	DEALLOCATE detalle_cursor

	/*
	DECLARE detalle_cursor CURSOR FOR 
	SELECT cantidadAtendida
	FROM detalleDocumentoPendiente
	WHERE idDocPendiente = @IN_IDDOCPENDIENTE
	
	OPEN detalle_cursor
	
	FETCH NEXT FROM detalle_cursor 
	INTO @IN_CANTIDAD_ATENDIDA
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@IN_CANTIDAD_ATENDIDA < 1)
		BEGIN
			SET @PARCIAL = 1
		END
		ELSE
		BEGIN
			SET @TOTAL = 1
		END
		
		FETCH NEXT FROM detalle_cursor 
		INTO @IN_CANTIDAD_ATENDIDA
	END 
	CLOSE detalle_cursor
	DEALLOCATE detalle_cursor
	*/
	IF (@PARCIAL = 1 AND @TOTAL = 0)
	BEGIN
		UPDATE documentoPendiente 
		SET situacionatencion = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = UPPER('PARCIAL') AND UPPER(idTabla) = UPPER('estadoAtencion'))
		WHERE idDocPendiente = @IN_IDDOCPENDIENTE
	END
	
	IF (@PARCIAL = 0 AND @TOTAL = 1)
	BEGIN
		UPDATE documentoPendiente 
		SET situacionatencion = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = UPPER('TOTAL') AND UPPER(idTabla) = UPPER('estadoAtencion'))
		WHERE idDocPendiente = @IN_IDDOCPENDIENTE
	END
	
	SELECT 0
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INICIAR_INVENTARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INICIAR_INVENTARIO]
(
	@IN_idProgInventario INTEGER
)
AS
BEGIN

	BEGIN
		UPDATE programacionInventario 
		SET idEstadoInventario = (SELECT idTipo FROM tablaTipo WHERE nombre = 'INICIADO')
		WHERE idProgInventario = @IN_idProgInventario
	END
	
	DECLARE @IN_idAlmacen INTEGER, @CH_Cod_Usuario CHAR(10), @IN_tipoInventario INTEGER, @IN_idPersona INTEGER, 
			@IN_idProducto INTEGER, @IN_cantidad INTEGER, @IN_idInventario INTEGER
	
	BEGIN
		SELECT @IN_idAlmacen = idAlmacen, @CH_Cod_Usuario = Cod_Usuario, @IN_tipoInventario = tipoInventario, @IN_idPersona = idPersona
		FROM programacionInventario WHERE idProgInventario = @IN_idProgInventario
	END
	
	BEGIN
		INSERT INTO inventario (idAlmacen, idProgInventario, fechaHoraInicio, tipo, activo, Cod_Usuario, fechaCreacion)
		VALUES (@IN_idAlmacen, @IN_idProgInventario, GETDATE(), @IN_tipoInventario, 1, @CH_Cod_Usuario, GETDATE())
	
		SELECT @IN_idInventario = SCOPE_IDENTITY()
	END
	
	DECLARE inventario_cursor CURSOR FOR 
	SELECT idProducto, cantidad
	FROM stock
	WHERE idAlmacen = @IN_idAlmacen AND Cod_Usuario = @CH_Cod_Usuario
	
	OPEN inventario_cursor
	
	FETCH NEXT FROM inventario_cursor 
	INTO @IN_idProducto, @IN_cantidad
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		INSERT INTO detalleInventario (idInventario, idAlmacen, idProducto, idOperadorAlmacen, cantidadActual, fechaHoraToma)
		VALUES (@IN_idInventario, @IN_idAlmacen, @IN_idProducto, @IN_idPersona, @IN_cantidad, GETDATE())
		
		FETCH NEXT FROM inventario_cursor 
		INTO @IN_idProducto, @IN_cantidad
	END 
	CLOSE inventario_cursor;
	DEALLOCATE inventario_cursor;
	
	SELECT 0
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_INVENTARIO_PROGRAMADO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_INVENTARIO_PROGRAMADO]
(
	@DT_FechaProgramada DATETIME,
	@IN_TipoInventario INTEGER,
	@CH_Cod_Usuario CHAR(10),
	@IN_idAlmacen INTEGER
)
AS
BEGIN

	DECLARE @IN_IDPROGRAMACION INTEGER

	DECLARE @IN_idPersona INTEGER
	DECLARE @IN_CONT INTEGER
	
	DECLARE @IN_MENSUAL INTEGER
	DECLARE @IN_ANUAL INTEGER
	DECLARE @IN_CICLICO INTEGER
	
	DECLARE @IN_ESTADO INTEGER
	
	SET @IN_ESTADO = (SELECT idTipo FROM tablaTipo WHERE UPPER(idTabla) = UPPER('tipoEstadoInventario') AND UPPER(nombre) = UPPER('PENDIENTE'))
	
	SET @IN_MENSUAL = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'MENSUAL' AND UPPER(idTabla) = UPPER('tipoInventario'))
	SET @IN_ANUAL = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'ANUAL' AND UPPER(idTabla) = UPPER('tipoInventario'))
	SET @IN_CICLICO = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'CICLICO' AND UPPER(idTabla) = UPPER('tipoInventario'))
	
	IF @IN_MENSUAL = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND idEstadoInventario = @IN_ESTADO
																AND MONTH(@DT_FechaProgramada) = MONTH(GETDATE())
																AND activo = 1),0)
	END
	
	IF @IN_ANUAL = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND idEstadoInventario = @IN_ESTADO
																AND YEAR(@DT_FechaProgramada) = YEAR(GETDATE())
																AND activo = 1),0)
	END
	
	IF @IN_CICLICO = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND idEstadoInventario = @IN_ESTADO
																AND MONTH(@DT_FechaProgramada) <= (MONTH(GETDATE())+ 3)
																AND activo = 1),0)
	END
	
	IF @IN_CONT = 0
	BEGIN
		SET @IN_idPersona = (SELECT idPersona FROM persona WHERE Cod_Usuario = @CH_Cod_Usuario)

		INSERT INTO programacionInventario
		(
			tipoInventario,
			fechaProgramada,
			idAlmacen,
			idPersona,
			idEstadoInventario,
			activo,
			Cod_Usuario,
			fechaCreacion
		)
		VALUES
		(
			@IN_TipoInventario,
			@DT_FechaProgramada,
			@IN_idAlmacen,
			@IN_idPersona,
			@IN_ESTADO,
			1,
			@CH_Cod_Usuario,
			GETDATE()
		)
		
		SELECT @IN_IDPROGRAMACION = ISNULL(SCOPE_IDENTITY(),0)
		
		IF @IN_IDPROGRAMACION = 0
		BEGIN
			SELECT 1
		END
		ELSE
		BEGIN
			SELECT 0
		END
	END
	ELSE
	BEGIN
		SELECT 2
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_DETALLE_INVENTARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_DETALLE_INVENTARIO]
(
	@IN_IDINVENTARIO INTEGER
)
AS
BEGIN
	SELECT	d.idDetalleInventario id, p.descripcionProducto producto, d.fechaHoraToma fecha, d.cantidad cantidad
	FROM detalleInventario d INNER JOIN producto p ON d.idProducto = p.idProducto
	WHERE d.idInventario = @IN_IDINVENTARIO
	ORDER BY p.descripcionProducto ASC
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_DETALLEMOVIMIENTOS]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_DETALLEMOVIMIENTOS]
(
	@IN_IDDOCPENDIENTE INTEGER
)
AS
BEGIN

	SELECT d.idProducto, d.cantidadPedida, d.cantidadAtendida, p.codigoProducto, p.descripcionProducto
	FROM detalleDocumentoPendiente d INNER JOIN producto p ON d.idProducto = p.idProducto
	WHERE d.idDocPendiente = @IN_IDDOCPENDIENTE
	ORDER BY d.idProducto ASC
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_DOCUMENTOPENDIENTE]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_OBTENER_DOCUMENTOPENDIENTE]
(
	@IN_IDDOCPENDIENTE INTEGER
)
AS
BEGIN

	IF((SELECT situacionatencion FROM documentoPendiente WHERE idDocPendiente = @IN_IDDOCPENDIENTE) = 
		(SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = UPPER('PENDIENTE') AND UPPER(idTabla) = UPPER('estadoAtencion')))
	BEGIN
		UPDATE detalleDocumentoPendiente
		SET cantidadAtendida = 0
		WHERE idDocPendiente = @IN_IDDOCPENDIENTE
	END

	SELECT ISNULL((select nombre from tablaTipo where tablaTipo.idTabla = 'tipoMovimiento' and tablaTipo.idTipo = d.tipoMovimiento),'') tipoMovimiento,
			ISNULL((select nombre from tablaTipo where tablaTipo.idTabla = 'estadoAtencion' and tablaTipo.idTipo = d.situacionatencion),'') situacionAtencion,
			ISNULL((select descripcionAlmacen from almacen where almacen.idAlmacen = d.idAlmacen),'') almacen,
			fechaDocumento,
			ISNULL(areaSolicitante,'') areaSolicitante,
			ISNULL(idUsuarioSolicitante,'') usuarioSolicitante
	FROM documentoPendiente d WHERE d.idDocPendiente = ISNULL(@IN_IDDOCPENDIENTE,0)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_INVENTARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_INVENTARIO]
(
	@CH_CODUSUARIO CHAR(10),
	@IN_IDALMACEN INTEGER
)
AS
BEGIN

	SELECT i.idInventario id, i.fechaHoraInicio fechaInicio, t.nombre tipo, p.nombres responsable
	FROM inventario i 
		INNER JOIN tablaTipo t ON i.tipo = t.idTipo
		INNER JOIN persona p ON p.Cod_Usuario = i.Cod_Usuario
	WHERE i.Cod_Usuario = @CH_CODUSUARIO 
		AND i.idAlmacen = @IN_IDALMACEN 
		AND i.activo = 1
		AND i.idProgInventario = isnull((SELECT TOP 1 idProgInventario FROM programacionInventario 
										WHERE Cod_Usuario = @CH_CODUSUARIO 
										AND idAlmacen = @IN_IDALMACEN
										AND idEstadoInventario = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = UPPER('INICIADO'))
										ORDER BY fechaProgramada ASC),0)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_INVENTARIOS]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_INVENTARIOS]
(
	@IN_ESTADOINVENTARIO INTEGER,
	@IN_IDALMACEN INTEGER
)
AS
BEGIN
	SELECT	p.idProgInventario id, p.fechaProgramada fecha, p.tipoInventario idTipo, 
			t.nombre tipo, p.idAlmacen idAlmacen, a.descripcionAlmacen almacen, u.nombres usuario, e.nombre estado
	FROM programacionInventario p INNER JOIN tablaTipo t ON p.tipoInventario = t.idTipo
	INNER JOIN almacen a ON p.idAlmacen = a.idAlmacen
	INNER JOIN persona u ON p.Cod_Usuario = u.Cod_Usuario
	INNER JOIN tablaTipo e ON p.idEstadoInventario = e.idTipo
	WHERE p.activo = 1 
		  AND p.idAlmacen IN (SELECT ua.idAlmacen FROM UsuarioAlmacen ua WHERE ua.Cod_Usuario = p.Cod_Usuario AND ua.activo = 1)
		  AND (@IN_ESTADOINVENTARIO = 0 OR p.idEstadoInventario = @IN_ESTADOINVENTARIO)
		  AND (@IN_IDALMACEN = 0 OR p.idAlmacen = @IN_IDALMACEN)
	ORDER BY p.fechaProgramada
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_INVENTARIOS_PROGRAMADOS]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_INVENTARIOS_PROGRAMADOS]
(
	@IN_TIPOINVENTARIO INTEGER,
	@IN_IDALMACEN INTEGER
)
AS
BEGIN

	DECLARE @ESTADO INTEGER
	
	SET @ESTADO = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = UPPER('PENDIENTE') AND UPPER(idTabla) = UPPER('tipoEstadoInventario'))

	SELECT	p.idProgInventario id, p.fechaProgramada fecha, p.tipoInventario idTipo, 
			t.nombre tipo, p.idAlmacen idAlmacen, a.descripcionAlmacen almacen, u.nombres usuario, e.nombre estado
	FROM programacionInventario p INNER JOIN tablaTipo t ON p.tipoInventario = t.idTipo
	INNER JOIN almacen a ON p.idAlmacen = a.idAlmacen
	INNER JOIN persona u ON p.Cod_Usuario = u.Cod_Usuario
	INNER JOIN tablaTipo e ON p.idEstadoInventario = e.idTipo
	WHERE p.activo = 1 AND p.idEstadoInventario = @ESTADO
		AND (@IN_TIPOINVENTARIO = 0 or p.tipoInventario = @IN_TIPOINVENTARIO)
		AND (@IN_IDALMACEN = 0 or p.idAlmacen = @IN_IDALMACEN)
	ORDER BY p.fechaProgramada
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_STOCKPRODUCTOS]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_STOCKPRODUCTOS]
(
	@VC_COD_DESCRIP_PRODUCTO VARCHAR(200),
	@IN_IDALMACEN INTEGER
)
AS
BEGIN

	SELECT  p.idProducto idProducto, p.codigoProducto codigoProducto, p.descripcionProducto descripcionProducto, s.cantidad cantidad, isnull(s.cantidadReservada,0) cantidadReservada
	FROM	producto p INNER JOIN stock s ON p.idProducto = s.idProducto
	WHERE	p.activo = 1 AND s.idAlmacen = @IN_IDALMACEN AND s.cantidad <= p.stockMinimo AND s.estado = 1 AND
			UPPER(p.codigoProducto) + ' ' + UPPER(p.descripcionProducto) LIKE '%'+UPPER(@VC_COD_DESCRIP_PRODUCTO)+'%'
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TIPO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_TIPO] 
	@IN_TIPOTABLA NVARCHAR(100)
AS
BEGIN
	SELECT	idTipo,
			nombre
	FROM tablaTipo
	WHERE idTabla = @IN_TIPOTABLA
	ORDER BY nombre
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TIPOALMACEN]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_TIPOALMACEN]
AS
BEGIN
	SELECT	idTipo,
			nombre
	FROM tablaTipo
	WHERE idTabla = 'tipoAlmacen'
	ORDER BY nombre
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TIPOINVENTARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_TIPOINVENTARIO]
AS
BEGIN
	SELECT	idTipo,
			nombre
	FROM tablaTipo
	WHERE idTabla = 'tipoInventario'
	ORDER BY nombre
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_USUARIOALMACEN]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OBTENER_USUARIOALMACEN]
(
	@CH_COD_USUARIO CHAR(10)
)
AS
BEGIN
	SELECT	UsuarioAlmacen.idAlmacen,
			(select almacen.descripcionAlmacen from almacen where almacen.idAlmacen = UsuarioAlmacen.idAlmacen) descripcionAlmacen
	FROM UsuarioAlmacen
	WHERE UsuarioAlmacen.Cod_Usuario = @CH_COD_USUARIO and UsuarioAlmacen.activo = 1
	ORDER BY descripcionAlmacen
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTINFOUSUARIOLOGIN]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_OBTINFOUSUARIOLOGIN]
(
	@CH_Cod_Usuario char(10)
)
as
begin
	DECLARE @VC_TIPOUSUARIO VARCHAR(50)
	
	SET @VC_TIPOUSUARIO = (SELECT t.nombre FROM Usuario u INNER JOIN tablaTipo t ON u.Tipo_Usuario = t.idTipo WHERE u.Cod_Usuario = @CH_Cod_Usuario)

	select idPersona, nombres, apellidoPaterno, @VC_TIPOUSUARIO tipoUsuario from persona
	WHERE Cod_Usuario = @CH_Cod_Usuario and activo = 1
end

GO
/****** Object:  StoredProcedure [dbo].[SP_REALIZARPEDIDO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_REALIZARPEDIDO]
(
	@VC_COD_DESCRIP_PRODUCTO VARCHAR(200),
	@IN_IDALMACEN INTEGER
)
AS
BEGIN

	DECLARE @IN_codRequerimiento INTEGER
	DECLARE @IN_idProducto INTEGER
	DECLARE @IN_cantidad INTEGER
	DECLARE @IN_cont INTEGER
	
	SET @IN_cont = ISNULL((	SELECT  COUNT(p.idProducto)
							FROM	producto p INNER JOIN stock s ON p.idProducto = s.idProducto
							WHERE	p.activo = 1 AND s.idAlmacen = @IN_IDALMACEN AND s.cantidad <= p.stockMinimo AND s.estado = 1 AND 
									isnull(s.cantidadReservada,0) > 0 AND
									UPPER(p.codigoProducto) + ' ' + UPPER(p.descripcionProducto) LIKE '%'+UPPER(@VC_COD_DESCRIP_PRODUCTO)+'%'),0)
							
	IF (@IN_cont > 0)
	BEGIN
		INSERT INTO RequerimientoCompras (codPersonal, codEstado, codCategoria, fechaRegistro, observacion)
		VALUES (1, 1, 1, GETDATE(), 'REPOSICION DE STOCK')
		
		SELECT @IN_codRequerimiento = SCOPE_IDENTITY()
		
		DECLARE stock_cursor CURSOR FOR
		SELECT  p.idProducto idProducto, s.cantidadReservada cantidadReservada
		FROM	producto p INNER JOIN stock s ON p.idProducto = s.idProducto
		WHERE	p.activo = 1 AND s.idAlmacen = @IN_IDALMACEN AND s.cantidad <= p.stockMinimo AND s.estado = 1 AND 
				isnull(s.cantidadReservada,0) > 0 AND
				UPPER(p.codigoProducto) + ' ' + UPPER(p.descripcionProducto) LIKE '%'+UPPER(@VC_COD_DESCRIP_PRODUCTO)+'%'

		OPEN stock_cursor
		
		FETCH NEXT FROM stock_cursor 
		INTO @IN_idProducto, @IN_cantidad
		
		WHILE @@FETCH_STATUS = 0
		BEGIN
		
			INSERT INTO RequerimientoDetalle (codRequerimiento, idProducto, cantidad)
			VALUES (@IN_codRequerimiento, @IN_idProducto, @IN_cantidad)
			
			UPDATE stock SET estado = 0 WHERE idAlmacen = @IN_IDALMACEN AND idProducto = @IN_idProducto
			
			FETCH NEXT FROM stock_cursor 
			INTO @IN_idProducto, @IN_cantidad
		END
		CLOSE stock_cursor
		DEALLOCATE stock_cursor
		
		SELECT 0
	END
	ELSE
	BEGIN
		
		SELECT 1	
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDARUSUARIO]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_VALIDARUSUARIO] 
(  
	@usuario varchar(50),  
	@password varchar(50)
)
AS
BEGIN
	DECLARE @cod_usuario CHAR(10)
	
	SET @cod_usuario = (SELECT u.Cod_Usuario FROM Usuario u 
							WHERE u.Nom_Usuario = @usuario 
							AND u.Pwd_Usuario = @password
							AND u.Estado_Usuario = 1)
   
	IF (ISNULL(@cod_usuario,0) > 0)
    BEGIN
		select @cod_usuario
	END
	ELSE
	BEGIN
		select 0
	END
END

GO
/****** Object:  Table [dbo].[almacen]    Script Date: 04/06/2015 10:07:06 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[almacen](
	[idAlmacen] [int] IDENTITY(1,1) NOT NULL,
	[descripcionAlmacen] [varchar](100) NOT NULL,
	[idSupervisorAlmacen] [int] NOT NULL,
	[direccion] [varchar](50) NULL,
	[ubigeo] [varchar](10) NULL,
	[telefono] [varchar](20) NULL,
	[tipoAlmacen] [int] NULL,
	[metraje] [float] NULL,
	[activo] [int] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[fechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Aprobacion]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aprobacion](
	[codRequerimiento] [int] NOT NULL,
	[codEstado] [int] NOT NULL,
	[codPersonal] [int] NOT NULL,
 CONSTRAINT [pk_aprobacion] PRIMARY KEY CLUSTERED 
(
	[codRequerimiento] ASC,
	[codEstado] ASC,
	[codPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[codCargo] [int] NOT NULL,
	[desCargo] [varchar](20) NOT NULL,
 CONSTRAINT [pk_cargo] PRIMARY KEY CLUSTERED 
(
	[codCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[codCategoria] [int] NOT NULL,
	[desCategoria] [varchar](30) NOT NULL,
 CONSTRAINT [pk_categoria] PRIMARY KEY CLUSTERED 
(
	[codCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Codigo] [numeric](9, 0) NOT NULL,
	[Ruc] [char](11) NULL,
	[Razon_Social] [varchar](60) NULL,
	[Direccion] [varchar](100) NULL,
	[CodPai] [char](3) NULL,
	[Telefono] [varchar](max) NULL,
	[Correo] [varchar](max) NULL,
	[Observaciones] [varchar](max) NULL,
	[Usuario] [char](11) NULL,
	[Pasword] [varchar](max) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalleDocumentoAlmacen]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleDocumentoAlmacen](
	[correlativo] [int] NOT NULL,
	[idDetalleDocAlmacen] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleDocAlmacen] ASC,
	[correlativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalleDocumentoPendiente]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleDocumentoPendiente](
	[idDocPendiente] [int] NOT NULL,
	[idDetalleDocPendiente] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidadPedida] [int] NULL,
	[cantidadAtendida] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleDocPendiente] ASC,
	[idDocPendiente] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalleInventario]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleInventario](
	[idDetalleInventario] [int] IDENTITY(1,1) NOT NULL,
	[idInventario] [int] NOT NULL,
	[idAlmacen] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[idOperadorAlmacen] [int] NOT NULL,
	[cantidadActual] [int] NULL,
	[cantidad] [int] NULL,
	[cantidadAjuste] [int] NULL,
	[fechaHoraToma] [datetime] NULL,
	[numeroToma] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleInventario] ASC,
	[idInventario] ASC,
	[idAlmacen] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocProdReq]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocProdReq](
	[Doc_Req] [decimal](10, 0) NOT NULL,
	[Doc_Prod] [numeric](7, 0) NOT NULL,
	[Doc_Siicex] [char](3) NOT NULL,
 CONSTRAINT [PK_DocProdReq] PRIMARY KEY CLUSTERED 
(
	[Doc_Req] ASC,
	[Doc_Prod] ASC,
	[Doc_Siicex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[docProdTEMP]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[docProdTEMP](
	[Doc_Prod] [numeric](7, 0) NOT NULL,
	[Doc_Siicex] [char](3) NOT NULL,
 CONSTRAINT [PK_docProdTEMP] PRIMARY KEY CLUSTERED 
(
	[Doc_Prod] ASC,
	[Doc_Siicex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[documentoAlmacen]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[documentoAlmacen](
	[correlativo] [int] NOT NULL,
	[idDocPendiente] [int] NOT NULL,
	[numeroDocAlmacen] [varchar](20) NOT NULL,
	[tipoMovimiento] [int] NULL,
	[fechaDocumento] [datetime] NULL,
	[idAlmacen] [int] NULL,
	[activo] [int] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[correlativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[documentoPendiente]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[documentoPendiente](
	[idDocPendiente] [int] NOT NULL,
	[numeroDocPendiente] [varchar](10) NOT NULL,
	[tipoDocumentoPendiente] [int] NULL,
	[idClienteProveedor] [int] NOT NULL,
	[fechaDocumento] [datetime] NULL,
	[situacionatencion] [int] NULL,
	[activo] [int] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[tipoMovimiento] [int] NULL,
	[idAlmacen] [int] NULL,
	[areaSolicitante] [varchar](100) NULL,
	[idUsuarioSolicitante] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDocPendiente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DosSIICEX]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DosSIICEX](
	[Cod_SIICEX] [char](3) NOT NULL,
	[Des_SIICEX] [varchar](50) NULL,
 CONSTRAINT [PK_DosSIICEX] PRIMARY KEY CLUSTERED 
(
	[Cod_SIICEX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[codEstado] [int] NOT NULL,
	[desEstado] [varchar](30) NOT NULL,
 CONSTRAINT [pk_estado] PRIMARY KEY CLUSTERED 
(
	[codEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IATA]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IATA](
	[IATA_COD] [char](3) NOT NULL,
	[IATA_PAIS] [char](3) NOT NULL,
	[IATA_DES] [varchar](50) NULL,
 CONSTRAINT [PK_IATA] PRIMARY KEY CLUSTERED 
(
	[IATA_COD] ASC,
	[IATA_PAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[inventario]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[inventario](
	[idInventario] [int] IDENTITY(1,1) NOT NULL,
	[idAlmacen] [int] NOT NULL,
	[idProgInventario] [int] NOT NULL,
	[fechaHoraInicio] [datetime] NULL,
	[fechaHoraFin] [datetime] NULL,
	[tipo] [int] NULL,
	[activo] [int] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[lote]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[lote](
	[idLote] [int] IDENTITY(1,1) NOT NULL,
	[fechaFabricacion] [datetime] NULL,
	[ordenFabricacion] [int] NULL,
	[fechaTomaMuestra] [datetime] NULL,
	[bloqueado] [int] NULL,
	[cantidadProducida] [int] NULL,
	[activo] [tinyint] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[fechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[codMarca] [int] NOT NULL,
	[desMarca] [varchar](30) NOT NULL,
 CONSTRAINT [pk_marca] PRIMARY KEY CLUSTERED 
(
	[codMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OpcMenu]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OpcMenu](
	[Cod_OpcionMenu] [char](6) NOT NULL,
	[Des_opcionMenu] [varchar](100) NULL,
 CONSTRAINT [PK_OpcMenu] PRIMARY KEY CLUSTERED 
(
	[Cod_OpcionMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pais](
	[Cod_Pais] [char](3) NOT NULL,
	[Nom_Pais] [varchar](50) NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[Cod_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[persona]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[tipoPersona] [int] NULL,
	[nombres] [varchar](40) NULL,
	[apellidoPaterno] [varchar](40) NULL,
	[apellidoMaterno] [varchar](40) NULL,
	[razonSocial] [varchar](60) NULL,
	[tipoDocIdentidad] [int] NULL,
	[numeroDocIdentidad] [varchar](15) NULL,
	[direccion] [varchar](60) NULL,
	[telefono] [varchar](20) NULL,
	[correo] [varchar](40) NULL,
	[paginaWeb] [varchar](60) NULL,
	[fechaNacimiento] [datetime] NULL,
	[cargo] [varchar](50) NULL,
	[centrocosto] [varchar](50) NULL,
	[activo] [tinyint] NULL,
	[fechaIngreso] [datetime] NULL,
	[Cod_Usuario] [char](10) NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[fechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personal](
	[codPersonal] [int] NOT NULL,
	[codCargo] [int] NOT NULL,
	[nomPersonal] [varchar](30) NULL,
	[telefono] [numeric](9, 0) NULL,
	[direccion] [varchar](30) NULL,
	[usuario] [varchar](15) NULL,
	[clave] [varchar](15) NULL,
 CONSTRAINT [pk_personal] PRIMARY KEY CLUSTERED 
(
	[codPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[producto]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[tipoProducto] [int] NULL,
	[codigoProducto] [varchar](50) NULL,
	[descripcionProducto] [varchar](200) NULL,
	[tipounidadMedida] [char](3) NULL,
	[numeroPlacas] [int] NULL,
	[capacidadNominal] [int] NULL,
	[capacidadArranque] [int] NULL,
	[largo] [float] NULL,
	[ancho] [float] NULL,
	[alto] [float] NULL,
	[peso] [float] NULL,
	[periodoRecarga] [int] NULL,
	[tiempoMaxSinCarga] [int] NULL,
	[temperaturaMaxCarga] [int] NULL,
	[tipoDeUso] [int] NULL,
	[tiempoGarantia] [int] NULL,
	[stockMinimo] [int] NULL,
	[stockMaximo] [int] NULL,
	[activo] [int] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[fechaModificacion] [datetime] NULL,
	[pre_prod] [decimal](18, 3) NULL,
	[codCategoria] [int] NULL,
	[codMarca] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto_expo]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto_expo](
	[Cod_Prod] [numeric](7, 0) NOT NULL,
	[Des_Prod] [varchar](150) NULL,
	[Cod_Unidad] [char](3) NULL,
	[Pre_Prod] [decimal](18, 3) NULL,
	[Pes_Prod] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Cod_Prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[programacionInventario]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[programacionInventario](
	[idProgInventario] [int] IDENTITY(1,1) NOT NULL,
	[tipoInventario] [int] NULL,
	[fechaProgramada] [datetime] NULL,
	[frecuencia] [int] NULL,
	[idAlmacen] [int] NOT NULL,
	[idPersona] [int] NOT NULL,
	[idEstadoInventario] [int] NOT NULL,
	[activo] [tinyint] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProgInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Requerimiento]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Requerimiento](
	[Cod_Cab_Req] [decimal](10, 0) NOT NULL,
	[Cli_Cab_Req] [numeric](9, 0) NULL,
	[Pais_Cab_Req] [char](3) NULL,
	[Destino_Cab_Req] [varchar](100) NULL,
	[IATA_Cab_Req] [char](5) NULL,
	[Fec_Reg_Cab_Req] [decimal](8, 0) NULL,
	[Fec_Esp_Cab_Req] [decimal](8, 0) NULL,
	[Pre_Tot_Cab_Req] [decimal](18, 3) NULL,
	[Est_Cab_Req] [char](1) NULL,
	[Obs_Cab_Req] [varchar](max) NULL,
 CONSTRAINT [PK_Requerimiento] PRIMARY KEY CLUSTERED 
(
	[Cod_Cab_Req] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Requerimiento_Detalle]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requerimiento_Detalle](
	[Cod_Det_Req] [decimal](10, 0) NOT NULL,
	[Cod_Prod_Det_Req] [decimal](7, 0) NOT NULL,
	[Cantidad] [int] NULL,
	[Precio_Unit] [decimal](18, 3) NULL,
	[CIF] [decimal](18, 3) NULL,
	[FOB] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Requerimiento_Detalle] PRIMARY KEY CLUSTERED 
(
	[Cod_Det_Req] ASC,
	[Cod_Prod_Det_Req] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RequerimientoCompras]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequerimientoCompras](
	[codRequerimiento] [int] IDENTITY(1,1) NOT NULL,
	[codPersonal] [int] NOT NULL,
	[codEstado] [int] NOT NULL,
	[codCategoria] [int] NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[observacion] [varchar](150) NULL,
 CONSTRAINT [pk_requerimientoCompras] PRIMARY KEY CLUSTERED 
(
	[codRequerimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RequerimientoDetalle]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequerimientoDetalle](
	[codRequerimiento] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [pk_requerimientoDetalle] PRIMARY KEY CLUSTERED 
(
	[codRequerimiento] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolicitudAtencion]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SolicitudAtencion](
	[Cod_Solicitud] [decimal](10, 0) NOT NULL,
	[Cod_Cab_Req_Solicitud] [decimal](10, 0) NULL,
	[Res_Solicitud] [char](10) NULL,
	[Fec_Reg_Solicitud] [decimal](8, 0) NULL,
	[Fec_Res_Esp_Solicitud] [decimal](8, 0) NULL,
	[Fec_Desp_Solicitud] [decimal](8, 0) NULL,
	[Estado_Solicitud] [char](1) NULL,
	[Observacion_Solicitud] [varchar](max) NULL,
 CONSTRAINT [PK_SolicitudAtencion] PRIMARY KEY CLUSTERED 
(
	[Cod_Solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stock]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stock](
	[idAlmacen] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[idLote] [int] NOT NULL,
	[cantidad] [int] NULL,
	[cantidadReservada] [int] NULL,
	[activo] [int] NULL,
	[Cod_Usuario] [char](10) NOT NULL,
	[fechaCreacion] [datetime] NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idAlmacen] ASC,
	[idProducto] ASC,
	[idLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tablaTipo]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tablaTipo](
	[idTipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](200) NULL,
	[idTabla] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Cod_Usuario] [char](10) NOT NULL,
	[Pwd_Usuario] [varchar](50) NOT NULL,
	[Nom_Usuario] [varchar](50) NULL,
	[Tipo_Usuario] [int] NOT NULL,
	[Estado_Usuario] [int] NOT NULL,
	[Filler1] [varchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Cod_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioAlmacen]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioAlmacen](
	[Cod_Usuario] [char](10) NOT NULL,
	[idAlmacen] [int] NOT NULL,
	[activo] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuMenu]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuMenu](
	[Cod_Usu] [char](10) NOT NULL,
	[Cod_Men] [char](6) NOT NULL,
 CONSTRAINT [PK_UsuMenu] PRIMARY KEY CLUSTERED 
(
	[Cod_Usu] ASC,
	[Cod_Men] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[zona]    Script Date: 04/06/2015 10:07:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[zona](
	[idZona] [int] IDENTITY(1,1) NOT NULL,
	[idAlmacen] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[fila] [int] NULL,
	[columna] [int] NULL,
	[nivel] [int] NULL,
	[posicion] [int] NULL,
	[metraje] [int] NULL,
	[capacidad] [int] NULL,
	[disponibilidad] [int] NULL,
	[observacion] [varchar](250) NULL,
	[activo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idZona] ASC,
	[idAlmacen] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Aprobacion]  WITH CHECK ADD  CONSTRAINT [fk_estado_aprobacion] FOREIGN KEY([codEstado])
REFERENCES [dbo].[Estado] ([codEstado])
GO
ALTER TABLE [dbo].[Aprobacion] CHECK CONSTRAINT [fk_estado_aprobacion]
GO
ALTER TABLE [dbo].[Aprobacion]  WITH CHECK ADD  CONSTRAINT [fk_personal_aprobacion] FOREIGN KEY([codPersonal])
REFERENCES [dbo].[Personal] ([codPersonal])
GO
ALTER TABLE [dbo].[Aprobacion] CHECK CONSTRAINT [fk_personal_aprobacion]
GO
ALTER TABLE [dbo].[Aprobacion]  WITH CHECK ADD  CONSTRAINT [fk_requerimiento_aprobacion] FOREIGN KEY([codRequerimiento])
REFERENCES [dbo].[RequerimientoCompras] ([codRequerimiento])
GO
ALTER TABLE [dbo].[Aprobacion] CHECK CONSTRAINT [fk_requerimiento_aprobacion]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Cliente] FOREIGN KEY([Codigo])
REFERENCES [dbo].[Cliente] ([Codigo])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Cliente]
GO
ALTER TABLE [dbo].[detalleDocumentoAlmacen]  WITH CHECK ADD  CONSTRAINT [detalleDocumentoAlmacen_FKCONSTRAINT1] FOREIGN KEY([correlativo])
REFERENCES [dbo].[documentoAlmacen] ([correlativo])
GO
ALTER TABLE [dbo].[detalleDocumentoAlmacen] CHECK CONSTRAINT [detalleDocumentoAlmacen_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[detalleDocumentoPendiente]  WITH CHECK ADD  CONSTRAINT [detalleDocumentoPendiente_FKCONSTRAINT2] FOREIGN KEY([idDocPendiente])
REFERENCES [dbo].[documentoPendiente] ([idDocPendiente])
GO
ALTER TABLE [dbo].[detalleDocumentoPendiente] CHECK CONSTRAINT [detalleDocumentoPendiente_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[detalleInventario]  WITH CHECK ADD  CONSTRAINT [detalleInventario_FKCONSTRAINT1] FOREIGN KEY([idInventario])
REFERENCES [dbo].[inventario] ([idInventario])
GO
ALTER TABLE [dbo].[detalleInventario] CHECK CONSTRAINT [detalleInventario_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[detalleInventario]  WITH CHECK ADD  CONSTRAINT [detalleInventario_FKCONSTRAINT2] FOREIGN KEY([idOperadorAlmacen])
REFERENCES [dbo].[persona] ([idPersona])
GO
ALTER TABLE [dbo].[detalleInventario] CHECK CONSTRAINT [detalleInventario_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[detalleInventario]  WITH CHECK ADD  CONSTRAINT [detalleInventario_FKCONSTRAINT3] FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[almacen] ([idAlmacen])
GO
ALTER TABLE [dbo].[detalleInventario] CHECK CONSTRAINT [detalleInventario_FKCONSTRAINT3]
GO
ALTER TABLE [dbo].[documentoAlmacen]  WITH CHECK ADD  CONSTRAINT [documentoAlmacen_FKCONSTRAINT1] FOREIGN KEY([idDocPendiente])
REFERENCES [dbo].[documentoPendiente] ([idDocPendiente])
GO
ALTER TABLE [dbo].[documentoAlmacen] CHECK CONSTRAINT [documentoAlmacen_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[documentoAlmacen]  WITH CHECK ADD  CONSTRAINT [documentoAlmacen_FKCONSTRAINT2] FOREIGN KEY([tipoMovimiento])
REFERENCES [dbo].[tablaTipo] ([idTipo])
GO
ALTER TABLE [dbo].[documentoAlmacen] CHECK CONSTRAINT [documentoAlmacen_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[documentoAlmacen]  WITH CHECK ADD  CONSTRAINT [documentoAlmacen_FKCONSTRAINT3] FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[documentoAlmacen] CHECK CONSTRAINT [documentoAlmacen_FKCONSTRAINT3]
GO
ALTER TABLE [dbo].[documentoAlmacen]  WITH CHECK ADD  CONSTRAINT [documentoAlmacen_FKCONSTRAINT4] FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[almacen] ([idAlmacen])
GO
ALTER TABLE [dbo].[documentoAlmacen] CHECK CONSTRAINT [documentoAlmacen_FKCONSTRAINT4]
GO
ALTER TABLE [dbo].[inventario]  WITH CHECK ADD  CONSTRAINT [inventario_FKCONSTRAINT1] FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[almacen] ([idAlmacen])
GO
ALTER TABLE [dbo].[inventario] CHECK CONSTRAINT [inventario_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[inventario]  WITH CHECK ADD  CONSTRAINT [inventario_FKCONSTRAINT2] FOREIGN KEY([idProgInventario])
REFERENCES [dbo].[programacionInventario] ([idProgInventario])
GO
ALTER TABLE [dbo].[inventario] CHECK CONSTRAINT [inventario_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[inventario]  WITH CHECK ADD  CONSTRAINT [inventario_FKCONSTRAINT3] FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[inventario] CHECK CONSTRAINT [inventario_FKCONSTRAINT3]
GO
ALTER TABLE [dbo].[lote]  WITH CHECK ADD  CONSTRAINT [lote_FKCONSTRAINT1] FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[lote] CHECK CONSTRAINT [lote_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[persona]  WITH CHECK ADD  CONSTRAINT [persona_FKCONSTRAINT1] FOREIGN KEY([tipoPersona])
REFERENCES [dbo].[tablaTipo] ([idTipo])
GO
ALTER TABLE [dbo].[persona] CHECK CONSTRAINT [persona_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[persona]  WITH CHECK ADD  CONSTRAINT [persona_FKCONSTRAINT2] FOREIGN KEY([tipoDocIdentidad])
REFERENCES [dbo].[tablaTipo] ([idTipo])
GO
ALTER TABLE [dbo].[persona] CHECK CONSTRAINT [persona_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[persona]  WITH CHECK ADD  CONSTRAINT [persona_FKCONSTRAINT3] FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[persona] CHECK CONSTRAINT [persona_FKCONSTRAINT3]
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD  CONSTRAINT [fk_cargo] FOREIGN KEY([codCargo])
REFERENCES [dbo].[Cargo] ([codCargo])
GO
ALTER TABLE [dbo].[Personal] CHECK CONSTRAINT [fk_cargo]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [producto_FKCONSTRAINT1] FOREIGN KEY([tipoProducto])
REFERENCES [dbo].[tablaTipo] ([idTipo])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [producto_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [producto_FKCONSTRAINT2] FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [producto_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[programacionInventario]  WITH CHECK ADD  CONSTRAINT [programacionInventario_FKCONSTRAINT1] FOREIGN KEY([tipoInventario])
REFERENCES [dbo].[tablaTipo] ([idTipo])
GO
ALTER TABLE [dbo].[programacionInventario] CHECK CONSTRAINT [programacionInventario_FKCONSTRAINT1]
GO
ALTER TABLE [dbo].[programacionInventario]  WITH CHECK ADD  CONSTRAINT [programacionInventario_FKCONSTRAINT2] FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[programacionInventario] CHECK CONSTRAINT [programacionInventario_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[programacionInventario]  WITH CHECK ADD  CONSTRAINT [programacionInventario_FKCONSTRAINT3] FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[almacen] ([idAlmacen])
GO
ALTER TABLE [dbo].[programacionInventario] CHECK CONSTRAINT [programacionInventario_FKCONSTRAINT3]
GO
ALTER TABLE [dbo].[programacionInventario]  WITH CHECK ADD  CONSTRAINT [programacionInventario_FKCONSTRAINT4] FOREIGN KEY([idPersona])
REFERENCES [dbo].[persona] ([idPersona])
GO
ALTER TABLE [dbo].[programacionInventario] CHECK CONSTRAINT [programacionInventario_FKCONSTRAINT4]
GO
ALTER TABLE [dbo].[programacionInventario]  WITH CHECK ADD  CONSTRAINT [programacionInventario_FKCONSTRAINT5] FOREIGN KEY([idEstadoInventario])
REFERENCES [dbo].[tablaTipo] ([idTipo])
GO
ALTER TABLE [dbo].[programacionInventario] CHECK CONSTRAINT [programacionInventario_FKCONSTRAINT5]
GO
ALTER TABLE [dbo].[RequerimientoCompras]  WITH CHECK ADD  CONSTRAINT [fk_categoria_req] FOREIGN KEY([codCategoria])
REFERENCES [dbo].[Categoria] ([codCategoria])
GO
ALTER TABLE [dbo].[RequerimientoCompras] CHECK CONSTRAINT [fk_categoria_req]
GO
ALTER TABLE [dbo].[RequerimientoCompras]  WITH CHECK ADD  CONSTRAINT [fk_personal_req] FOREIGN KEY([codPersonal])
REFERENCES [dbo].[Personal] ([codPersonal])
GO
ALTER TABLE [dbo].[RequerimientoCompras] CHECK CONSTRAINT [fk_personal_req]
GO
ALTER TABLE [dbo].[RequerimientoDetalle]  WITH CHECK ADD  CONSTRAINT [fk_articulo] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[RequerimientoDetalle] CHECK CONSTRAINT [fk_articulo]
GO
ALTER TABLE [dbo].[RequerimientoDetalle]  WITH CHECK ADD  CONSTRAINT [fk_requerimientoCompras] FOREIGN KEY([codRequerimiento])
REFERENCES [dbo].[RequerimientoCompras] ([codRequerimiento])
GO
ALTER TABLE [dbo].[RequerimientoDetalle] CHECK CONSTRAINT [fk_requerimientoCompras]
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD  CONSTRAINT [stock_FKCONSTRAINT2] FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[almacen] ([idAlmacen])
GO
ALTER TABLE [dbo].[stock] CHECK CONSTRAINT [stock_FKCONSTRAINT2]
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD  CONSTRAINT [stock_FKCONSTRAINT3] FOREIGN KEY([idLote])
REFERENCES [dbo].[lote] ([idLote])
GO
ALTER TABLE [dbo].[stock] CHECK CONSTRAINT [stock_FKCONSTRAINT3]
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD  CONSTRAINT [stock_FKCONSTRAINT4] FOREIGN KEY([Cod_Usuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[stock] CHECK CONSTRAINT [stock_FKCONSTRAINT4]
GO
ALTER TABLE [dbo].[zona]  WITH CHECK ADD  CONSTRAINT [zona_FKCONSTRAINT1] FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[almacen] ([idAlmacen])
GO
ALTER TABLE [dbo].[zona] CHECK CONSTRAINT [zona_FKCONSTRAINT1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Clientes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Documento Producto Requisicion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocProdReq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Temporal' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'docProdTEMP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Documentos SIICEX' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DosSIICEX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TABLA IATA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IATA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Opciones Menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpcMenu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Pais' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pais'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Productos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Producto_expo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Requerimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Requerimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla Detalle de Requerimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Requerimiento_Detalle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de solicitud de Atencion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SolicitudAtencion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Usuarios' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Opciones Menu Usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuMenu'
GO
USE [master]
GO
ALTER DATABASE [ETNA] SET  READ_WRITE 
GO
