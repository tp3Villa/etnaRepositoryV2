USE [ETNA]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_STOCKPRODUCTOS]    Script Date: 05/28/2015 18:35:37 ******/
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
	WHERE	p.activo = 1 AND s.idAlmacen = @IN_IDALMACEN AND 
			UPPER(p.codigoProducto) + ' ' + UPPER(p.descripcionProducto) LIKE '%'+UPPER(@VC_COD_DESCRIP_PRODUCTO)+'%'
END
GO
