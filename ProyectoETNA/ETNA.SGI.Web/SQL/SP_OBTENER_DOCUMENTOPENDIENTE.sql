USE [ETNA]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_DOCUMENTOPENDIENTE]    Script Date: 05/27/2015 16:34:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_OBTENER_DOCUMENTOPENDIENTE]
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