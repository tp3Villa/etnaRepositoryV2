USE [ETNA]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_USUARIOALMACEN]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TIPOINVENTARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TIPOALMACEN]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_TIPO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_VALIDARUSUARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTINFOUSUARIOLOGIN]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_DOCUMENTOPENDIENTE]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_DETALLEMOVIMIENTOS]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_DETALLEMOVIMIENTO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_DETALLEMOVIMIENTO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_DOCUMENTOPENDIENTE_LISTAR]    Script Date: 06/05/2015 18:40:16 ******/
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
			isnull(documentoPendiente.tipoDocumentoPendiente,'') as tipoDocumentoPendiente,
			isnull((select nombre
			 from tablaTipo
			  where tablaTipo.idTabla = 'tipoDocumentoPendiente'
			   and tablaTipo.idTipo = documentoPendiente.tipoDocumentoPendiente),'')
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
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_INVENTARIO_PROGRAMADO]    Script Date: 06/05/2015 18:40:16 ******/
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
	
	SET @IN_MENSUAL = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'MENSUAL' AND UPPER(idTabla) = 'tipoInventario')
	SET @IN_ANUAL = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'ANUAL' AND UPPER(idTabla) = 'tipoInventario')
	SET @IN_CICLICO = (SELECT idTipo FROM tablaTipo WHERE UPPER(nombre) = 'CICLICO' AND UPPER(idTabla) = 'tipoInventario')
	
	IF @IN_MENSUAL = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = (SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND MONTH(@DT_FechaProgramada) = MONTH(fechaProgramada)
																AND YEAR(@DT_FechaProgramada) = YEAR(fechaProgramada)
																AND activo = 1
																AND idProgInventario <> @IN_idProgInventario)
	END
	
	IF @IN_ANUAL = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = (SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND YEAR(@DT_FechaProgramada) = YEAR(fechaProgramada)
																AND activo = 1
																AND idProgInventario <> @IN_idProgInventario)
	END
	
	IF @IN_CICLICO = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = (SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND YEAR(@DT_FechaProgramada) = YEAR(fechaProgramada)
																AND (MONTH(@DT_FechaProgramada) BETWEEN (MONTH(fechaProgramada)) AND (MONTH(fechaProgramada) - 3)
																	OR MONTH(@DT_FechaProgramada) BETWEEN MONTH(fechaProgramada) AND (MONTH(fechaProgramada) + 3))
																AND activo = 1
																AND idProgInventario <> @IN_idProgInventario)
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
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_INVENTARIO_PROGRAMADO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_INVENTARIO_PROGRAMADO]    Script Date: 06/05/2015 18:40:16 ******/
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
																AND MONTH(@DT_FechaProgramada) = MONTH(fechaProgramada)
																AND YEAR(@DT_FechaProgramada) = YEAR(fechaProgramada)
																AND activo = 1),0)
	END
	
	IF @IN_ANUAL = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND YEAR(@DT_FechaProgramada) = YEAR(fechaProgramada)
																AND activo = 1),0)
	END
	
	IF @IN_CICLICO = @IN_TipoInventario
	BEGIN
		SET @IN_CONT = ISNULL((SELECT COUNT(*) FROM programacionInventario WHERE tipoInventario = @IN_TipoInventario 
																AND	idAlmacen = @IN_idAlmacen
																AND YEAR(@DT_FechaProgramada) = YEAR(fechaProgramada)
																AND (MONTH(@DT_FechaProgramada) BETWEEN (MONTH(fechaProgramada)) AND (MONTH(fechaProgramada) - 3)
																	OR MONTH(@DT_FechaProgramada) BETWEEN MONTH(fechaProgramada) AND (MONTH(fechaProgramada) + 3))
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_STOCKPRODUCTOS]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_INVENTARIOS_PROGRAMADOS]    Script Date: 06/05/2015 18:40:16 ******/
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
	SELECT	p.idProgInventario id, p.fechaProgramada fecha, p.tipoInventario idTipo, 
			t.nombre tipo, p.idAlmacen idAlmacen, a.descripcionAlmacen almacen, u.nombres usuario, e.nombre estado
	FROM programacionInventario p INNER JOIN tablaTipo t ON p.tipoInventario = t.idTipo
	INNER JOIN almacen a ON p.idAlmacen = a.idAlmacen
	INNER JOIN persona u ON p.Cod_Usuario = u.Cod_Usuario
	INNER JOIN tablaTipo e ON p.idEstadoInventario = e.idTipo
	WHERE p.activo = 1 AND (@IN_TIPOINVENTARIO = 0 or p.tipoInventario = @IN_TIPOINVENTARIO)
		AND (@IN_IDALMACEN = 0 or p.idAlmacen = @IN_IDALMACEN)
	ORDER BY p.fechaProgramada
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_INVENTARIOS]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_STOCKPRODUCTO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_REALIZARPEDIDO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_INVENTARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_DETALLE_INVENTARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INICIAR_INVENTARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_FINALIZAR_TOMA_INVENTARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_TOMA_INVENTARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_AJUSTAR_INVENTARIO]    Script Date: 06/05/2015 18:40:16 ******/
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
