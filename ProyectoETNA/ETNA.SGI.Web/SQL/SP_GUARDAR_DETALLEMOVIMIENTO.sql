USE [ETNA]
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_DETALLEMOVIMIENTO]    Script Date: 05/27/2015 15:49:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_GUARDAR_DETALLEMOVIMIENTO]
(
	@IN_IDDOCPENDIENTE INTEGER
)
AS
BEGIN

	DECLARE @IN_CANTIDAD_ATENDIDA INTEGER, @TOTAL INTEGER, @PARCIAL INTEGER
	
	SELECT @TOTAL = 0, @PARCIAL = 0

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
	
	IF (@PARCIAL = 1 AND @TOTAL = 1)
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