USE [ETNA]
GO
/****** Object:  StoredProcedure [dbo].[SP_AJUSTAR_INVENTARIO]    Script Date: 06/04/2015 11:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_AJUSTAR_INVENTARIO]
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
