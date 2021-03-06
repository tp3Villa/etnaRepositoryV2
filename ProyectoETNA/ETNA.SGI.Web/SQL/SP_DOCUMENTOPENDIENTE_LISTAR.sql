USE [ETNA]
GO
/****** Object:  StoredProcedure [dbo].[SP_DOCUMENTOPENDIENTE_LISTAR]    Script Date: 05/26/2015 16:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_DOCUMENTOPENDIENTE_LISTAR]
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