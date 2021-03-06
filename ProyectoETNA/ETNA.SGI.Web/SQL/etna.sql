USE [ETNA]
GO
/****** Object:  Table [dbo].[IATA]    Script Date: 06/04/2015 16:42:08 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TABLA IATA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IATA'
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 06/04/2015 16:42:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[codEstado] [int] IDENTITY(1,1) NOT NULL,
	[desEstado] [varchar](30) NOT NULL,
 CONSTRAINT [pk_estado] PRIMARY KEY CLUSTERED 
(
	[codEstado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DosSIICEX]    Script Date: 06/04/2015 16:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DosSIICEX](
	[Cod_SIICEX] [int] IDENTITY(1,1) NOT NULL,
	[Des_SIICEX] [varchar](50) NULL,
 CONSTRAINT [PK_DosSIICEX] PRIMARY KEY CLUSTERED 
(
	[Cod_SIICEX] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Documentos SIICEX' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DosSIICEX'
GO
/****** Object:  Table [dbo].[OpcMenu]    Script Date: 06/04/2015 16:42:14 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Opciones Menu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpcMenu'
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 06/04/2015 16:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Moneda](
	[codMoneda] [int] NOT NULL,
	[desMoneda] [varchar](10) NOT NULL,
 CONSTRAINT [pk_Moneda] PRIMARY KEY CLUSTERED 
(
	[codMoneda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 06/04/2015 16:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[codMarca] [int] IDENTITY(1,1) NOT NULL,
	[desMarca] [varchar](30) NOT NULL,
 CONSTRAINT [pk_marca] PRIMARY KEY CLUSTERED 
(
	[codMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuMenu]    Script Date: 06/04/2015 16:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuMenu](
	[Cod_Usuario] [char](10) NOT NULL,
	[Cod_OpcionMenu] [char](6) NOT NULL,
 CONSTRAINT [PK_UsuMenu] PRIMARY KEY CLUSTERED 
(
	[Cod_Usuario] ASC,
	[Cod_OpcionMenu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Opciones Menu Usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsuMenu'
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 06/04/2015 16:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Cod_Usuario] [char](10) NOT NULL,
	[Pwd_Usuario] [char](10) NULL,
	[Nom_Usuario] [varchar](50) NULL,
	[Tipo_Usuario] [char](1) NULL,
	[Estado_Usuario] [char](1) NULL,
	[Filler1] [varchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Cod_Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Usuarios' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Usuario'
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 06/04/2015 16:42:18 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Pais' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pais'
GO
/****** Object:  Table [dbo].[docProdTEMP]    Script Date: 06/04/2015 16:42:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docProdTEMP](
	[idProducto] [int] NOT NULL,
	[Cod_SIICEX] [int] NOT NULL,
 CONSTRAINT [PK_docProdTEMP] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC,
	[Cod_SIICEX] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Temporal' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'docProdTEMP'
GO
/****** Object:  Table [dbo].[DocProdReq]    Script Date: 06/04/2015 16:42:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocProdReq](
	[Cod_Cab_Req] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[Cod_SIICEX] [int] NOT NULL,
 CONSTRAINT [PK_DocProdReq] PRIMARY KEY CLUSTERED 
(
	[Cod_Cab_Req] ASC,
	[idProducto] ASC,
	[Cod_SIICEX] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Documento Producto Requisicion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DocProdReq'
GO
/****** Object:  Table [dbo].[SolicitudAtencion]    Script Date: 06/04/2015 16:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SolicitudAtencion](
	[Cod_Solicitud] [int] IDENTITY(1,1) NOT NULL,
	[Cod_Cab_Req] [int] NOT NULL,
	[Res_Solicitud] [char](10) NULL,
	[Fec_Reg_Solicitud] [datetime] NOT NULL,
	[Fec_Res_Esp_Solicitud] [datetime] NOT NULL,
	[Fec_Desp_Solicitud] [datetime] NOT NULL,
	[Estado_Solicitud] [char](1) NULL,
	[Observacion_Solicitud] [varchar](max) NULL,
 CONSTRAINT [PK_SolicitudAtencion] PRIMARY KEY CLUSTERED 
(
	[Cod_Solicitud] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de solicitud de Atencion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SolicitudAtencion'
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 06/04/2015 16:42:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[codProveedor] [int] NOT NULL,
	[razonSocial] [varchar](30) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [numeric](9, 0) NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[email] [varchar](30) NOT NULL,
	[ruc] [numeric](11, 0) NOT NULL,
	[observacion] [varchar](100) NOT NULL,
 CONSTRAINT [pk_proveedor] PRIMARY KEY CLUSTERED 
(
	[codProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleDocExportacion]    Script Date: 06/04/2015 16:41:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetalleDocExportacion](
	[Cod_SIICEX] [int] NOT NULL,
	[Version] [char](5) NOT NULL,
	[Estado] [char](1) NULL,
	[Fecha_Publicacion] [datetime] NULL,
	[Fecha_Expiracion] [datetime] NULL,
	[Documento_Adjunto] [varchar](max) NULL,
	[Cod_Usuario] [char](10) NULL,
 CONSTRAINT [PK_DetalleDocExportacion] PRIMARY KEY CLUSTERED 
(
	[Cod_SIICEX] ASC,
	[Version] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 06/04/2015 16:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[codCargo] [int] IDENTITY(1,1) NOT NULL,
	[desCargo] [varchar](20) NOT NULL,
 CONSTRAINT [pk_cargo] PRIMARY KEY CLUSTERED 
(
	[codCargo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Requerimiento]    Script Date: 06/04/2015 16:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Requerimiento](
	[Cod_Cab_Req] [int] NOT NULL,
	[Cod_Cliente] [int] NOT NULL,
	[Cod_Pais] [char](3) NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Requerimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Requerimiento'
GO
/****** Object:  Table [dbo].[CondicionPago]    Script Date: 06/04/2015 16:41:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CondicionPago](
	[codCondicionPago] [int] NOT NULL,
	[desCondicionPago] [varchar](30) NOT NULL,
 CONSTRAINT [pk_condicionPago] PRIMARY KEY CLUSTERED 
(
	[codCondicionPago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Requerimiento_Detalle]    Script Date: 06/04/2015 16:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requerimiento_Detalle](
	[Cod_Det_Req] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[Cantidad] [int] NULL,
	[Precio_Unit] [decimal](18, 3) NULL,
	[CIF] [decimal](18, 3) NULL,
	[FOB] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Requerimiento_Detalle] PRIMARY KEY CLUSTERED 
(
	[Cod_Det_Req] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla Detalle de Requerimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Requerimiento_Detalle'
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/04/2015 16:41:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cod_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Ruc] [char](11) NOT NULL,
	[Razon_Social] [varchar](60) NULL,
	[Direccion] [varchar](100) NULL,
	[Cod_Pais] [char](3) NULL,
	[Telefono] [varchar](max) NULL,
	[Correo] [varchar](max) NULL,
	[Observaciones] [varchar](max) NULL,
	[Usuario] [char](11) NULL,
	[Pasword] [varchar](max) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cod_Cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Clientes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Cliente'
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 06/04/2015 16:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[codCategoria] [int] IDENTITY(1,1) NOT NULL,
	[desCategoria] [varchar](30) NOT NULL,
 CONSTRAINT [pk_categoria] PRIMARY KEY CLUSTERED 
(
	[codCategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AprobacionCotizacion]    Script Date: 06/04/2015 16:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AprobacionCotizacion](
	[codCotizacion] [int] NOT NULL,
	[codEstado] [int] NOT NULL,
	[codUsuario] [char](10) NOT NULL,
	[fechaAprobacion] [datetime] NOT NULL,
 CONSTRAINT [pk_aprobacionCotizacion] PRIMARY KEY CLUSTERED 
(
	[codCotizacion] ASC,
	[codEstado] ASC,
	[codUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AprobacionRequerimientoCompra]    Script Date: 06/04/2015 16:41:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AprobacionRequerimientoCompra](
	[codRequerimiento] [int] NOT NULL,
	[codEstado] [int] NOT NULL,
	[codUsuario] [char](10) NOT NULL,
	[fechaAprobacion] [datetime] NOT NULL,
 CONSTRAINT [pk_aprobacionCompra] PRIMARY KEY CLUSTERED 
(
	[codRequerimiento] ASC,
	[codEstado] ASC,
	[codUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenCompra]    Script Date: 06/04/2015 16:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenCompra](
	[codOrdenCompra] [int] IDENTITY(1,1) NOT NULL,
	[codRequerimiento] [int] NOT NULL,
	[codCotizacion] [int] NOT NULL,
	[codMoneda] [int] NOT NULL,
	[codCondicionPago] [int] NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[fechaActualizacion] [datetime] NOT NULL,
	[usuarioRegistro] [char](10) NULL,
	[usuarioModificacion] [char](10) NULL,
	[fechaEntrega] [datetime] NOT NULL,
	[lugarEntrega] [varchar](150) NULL,
	[subtotal] [decimal](18, 2) NULL,
	[descuento] [decimal](18, 2) NULL,
	[igv] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
	[observacion] [varchar](150) NULL,
 CONSTRAINT [pk_ordenCompra] PRIMARY KEY CLUSTERED 
(
	[codOrdenCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[producto]    Script Date: 06/04/2015 16:42:27 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 06/04/2015 16:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[codCotizacion] [int] NOT NULL,
	[codRequerimiento] [int] NOT NULL,
	[codProveedor] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[telefono] [numeric](9, 0) NULL,
	[fechaExpiracion] [datetime] NOT NULL,
 CONSTRAINT [pk_cotizacion] PRIMARY KEY CLUSTERED 
(
	[codCotizacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RequerimientoDetalleCompra]    Script Date: 06/04/2015 16:42:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequerimientoDetalleCompra](
	[codRequerimiento] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [pk_requerimientoDetalleCompra] PRIMARY KEY CLUSTERED 
(
	[codRequerimiento] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CotizacionDetalle]    Script Date: 06/04/2015 16:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotizacionDetalle](
	[codCotizacion] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioUnidad] [decimal](18, 2) NULL,
 CONSTRAINT [pk_CotizacionDetalle] PRIMARY KEY CLUSTERED 
(
	[codCotizacion] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenCompraDetalle]    Script Date: 06/04/2015 16:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenCompraDetalle](
	[codOrdenCompra] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[precioUnidad] [decimal](18, 2) NULL,
 CONSTRAINT [pk_OrdenCompraDetalle] PRIMARY KEY CLUSTERED 
(
	[codOrdenCompra] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequerimientoCompra]    Script Date: 06/04/2015 16:42:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RequerimientoCompra](
	[codRequerimiento] [int] IDENTITY(1,1) NOT NULL,
	[codEstado] [int] NOT NULL,
	[codCategoria] [int] NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[fechaActualizacion] [datetime] NOT NULL,
	[usuarioRegistro] [char](10) NULL,
	[usuarioModificacion] [char](10) NULL,
	[observacion] [varchar](150) NULL,
 CONSTRAINT [pk_requerimientoCompra] PRIMARY KEY CLUSTERED 
(
	[codRequerimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CONSULTA_DETALLEDOCEXPORTACION]    Script Date: 06/04/2015 16:41:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTA_DETALLEDOCEXPORTACION] 
@estado1 INT,
@estado2 CHAR(1),
@fecha1 CHAR(8),
@fecha2 CHAR(8),
@opcion int
as begin
declare @miVar int
SET @miVar=@opcion

if (@miVar=0)
  BEGIN
  
    SELECT D.Cod_SIICEX,S.Des_SIICEX,D.Version,D.Estado,
Convert(varchar(10), D.Fecha_Publicacion,103) AS Fecha_Publicacion,
Convert(varchar(10), D.Fecha_Expiracion,103) AS Fecha_Expiracion,
D.Documento_Adjunto FROM detalledocexportacion AS D LEFT OUTER JOIN
DosSIICEX S ON (D.COD_SIICEX=S.Cod_SIICEX);

  end
else
  BEGIN
  
SELECT D.Cod_SIICEX,S.Des_SIICEX,D.Version,D.Estado,
Convert(varchar(10), D.Fecha_Publicacion,103) AS Fecha_Publicacion,
Convert(varchar(10), D.Fecha_Expiracion,103) AS Fecha_Expiracion,
D.Documento_Adjunto FROM detalledocexportacion AS D LEFT OUTER JOIN
DosSIICEX S ON (D.COD_SIICEX=S.Cod_SIICEX) WHERE D.Cod_SIICEX=@estado1 AND D.ESTADO=@estado2 AND D.Fecha_Publicacion BETWEEN @fecha1 AND @fecha2;

  end
end
GO
/****** Object:  StoredProcedure [dbo].[CONSULTA_APROBACION_SOLICITUD]    Script Date: 06/04/2015 16:41:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTA_APROBACION_SOLICITUD] 
@estado1 CHAR(1),
@estado2 CHAR(1),
@fecha1 CHAR(8),
@fecha2 CHAR(8),
@opcion int
as begin
declare @miVar int
SET @miVar=@opcion

if (@miVar=0)
  begin
    SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_reg_solicitud,103) AS fec_reg_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN
	Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN
	cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud IN (@estado1,@estado2);
  end
else
  begin
    SELECT cod_solicitud,S.Cod_Cab_Req AS cod_cab_req_solicitud,razon_social,Convert(varchar(10), fec_reg_solicitud,103) AS fec_reg_solicitud FROM SolicitudAtencion AS S LEFT OUTER JOIN
	Requerimiento AS R ON (S.Cod_Cab_Req=R.Cod_Cab_Req) LEFT OUTER JOIN
	cliente AS C ON (R.Cod_Cliente=C.Cod_Cliente) where estado_solicitud IN (@estado1,@estado2)  AND fec_reg_solicitud BETWEEN @fecha1 AND @fecha2;
  end
end
GO
/****** Object:  ForeignKey [fk_estadoAprobacionCotizacion]    Script Date: 06/04/2015 16:41:49 ******/
ALTER TABLE [dbo].[AprobacionCotizacion]  WITH CHECK ADD  CONSTRAINT [fk_estadoAprobacionCotizacion] FOREIGN KEY([codEstado])
REFERENCES [dbo].[Estado] ([codEstado])
GO
ALTER TABLE [dbo].[AprobacionCotizacion] CHECK CONSTRAINT [fk_estadoAprobacionCotizacion]
GO
/****** Object:  ForeignKey [fk_personalAprobacionCotizacion]    Script Date: 06/04/2015 16:41:49 ******/
ALTER TABLE [dbo].[AprobacionCotizacion]  WITH CHECK ADD  CONSTRAINT [fk_personalAprobacionCotizacion] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[AprobacionCotizacion] CHECK CONSTRAINT [fk_personalAprobacionCotizacion]
GO
/****** Object:  ForeignKey [fk_requerimientoAprobacionCotizacion]    Script Date: 06/04/2015 16:41:49 ******/
ALTER TABLE [dbo].[AprobacionCotizacion]  WITH CHECK ADD  CONSTRAINT [fk_requerimientoAprobacionCotizacion] FOREIGN KEY([codCotizacion])
REFERENCES [dbo].[Cotizacion] ([codCotizacion])
GO
ALTER TABLE [dbo].[AprobacionCotizacion] CHECK CONSTRAINT [fk_requerimientoAprobacionCotizacion]
GO
/****** Object:  ForeignKey [fk_estadoAprobacionCompra]    Script Date: 06/04/2015 16:41:50 ******/
ALTER TABLE [dbo].[AprobacionRequerimientoCompra]  WITH CHECK ADD  CONSTRAINT [fk_estadoAprobacionCompra] FOREIGN KEY([codEstado])
REFERENCES [dbo].[Estado] ([codEstado])
GO
ALTER TABLE [dbo].[AprobacionRequerimientoCompra] CHECK CONSTRAINT [fk_estadoAprobacionCompra]
GO
/****** Object:  ForeignKey [fk_personalAprobacionCompra]    Script Date: 06/04/2015 16:41:50 ******/
ALTER TABLE [dbo].[AprobacionRequerimientoCompra]  WITH CHECK ADD  CONSTRAINT [fk_personalAprobacionCompra] FOREIGN KEY([codUsuario])
REFERENCES [dbo].[Usuario] ([Cod_Usuario])
GO
ALTER TABLE [dbo].[AprobacionRequerimientoCompra] CHECK CONSTRAINT [fk_personalAprobacionCompra]
GO
/****** Object:  ForeignKey [fk_requerimientoAprobacionCompra]    Script Date: 06/04/2015 16:41:50 ******/
ALTER TABLE [dbo].[AprobacionRequerimientoCompra]  WITH CHECK ADD  CONSTRAINT [fk_requerimientoAprobacionCompra] FOREIGN KEY([codRequerimiento])
REFERENCES [dbo].[RequerimientoCompra] ([codRequerimiento])
GO
ALTER TABLE [dbo].[AprobacionRequerimientoCompra] CHECK CONSTRAINT [fk_requerimientoAprobacionCompra]
GO
/****** Object:  ForeignKey [fk_proveedorCotizacion]    Script Date: 06/04/2015 16:41:55 ******/
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [fk_proveedorCotizacion] FOREIGN KEY([codProveedor])
REFERENCES [dbo].[Proveedor] ([codProveedor])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [fk_proveedorCotizacion]
GO
/****** Object:  ForeignKey [fk_requerimiento_cotizacion]    Script Date: 06/04/2015 16:41:55 ******/
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [fk_requerimiento_cotizacion] FOREIGN KEY([codRequerimiento])
REFERENCES [dbo].[RequerimientoCompra] ([codRequerimiento])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [fk_requerimiento_cotizacion]
GO
/****** Object:  ForeignKey [fk_productoCotizacion]    Script Date: 06/04/2015 16:41:56 ******/
ALTER TABLE [dbo].[CotizacionDetalle]  WITH CHECK ADD  CONSTRAINT [fk_productoCotizacion] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[CotizacionDetalle] CHECK CONSTRAINT [fk_productoCotizacion]
GO
/****** Object:  ForeignKey [fk_condPago]    Script Date: 06/04/2015 16:42:17 ******/
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [fk_condPago] FOREIGN KEY([codCondicionPago])
REFERENCES [dbo].[CondicionPago] ([codCondicionPago])
GO
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [fk_condPago]
GO
/****** Object:  ForeignKey [fk_cotizacion_oc]    Script Date: 06/04/2015 16:42:17 ******/
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [fk_cotizacion_oc] FOREIGN KEY([codCotizacion])
REFERENCES [dbo].[Cotizacion] ([codCotizacion])
GO
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [fk_cotizacion_oc]
GO
/****** Object:  ForeignKey [fk_moneda]    Script Date: 06/04/2015 16:42:17 ******/
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [fk_moneda] FOREIGN KEY([codMoneda])
REFERENCES [dbo].[Moneda] ([codMoneda])
GO
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [fk_moneda]
GO
/****** Object:  ForeignKey [fk_requerimiento_oc]    Script Date: 06/04/2015 16:42:17 ******/
ALTER TABLE [dbo].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [fk_requerimiento_oc] FOREIGN KEY([codRequerimiento])
REFERENCES [dbo].[RequerimientoCompra] ([codRequerimiento])
GO
ALTER TABLE [dbo].[OrdenCompra] CHECK CONSTRAINT [fk_requerimiento_oc]
GO
/****** Object:  ForeignKey [fk_OrdenCompra]    Script Date: 06/04/2015 16:42:18 ******/
ALTER TABLE [dbo].[OrdenCompraDetalle]  WITH CHECK ADD  CONSTRAINT [fk_OrdenCompra] FOREIGN KEY([codOrdenCompra])
REFERENCES [dbo].[OrdenCompra] ([codOrdenCompra])
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] CHECK CONSTRAINT [fk_OrdenCompra]
GO
/****** Object:  ForeignKey [fk_productoD]    Script Date: 06/04/2015 16:42:18 ******/
ALTER TABLE [dbo].[OrdenCompraDetalle]  WITH CHECK ADD  CONSTRAINT [fk_productoD] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[OrdenCompraDetalle] CHECK CONSTRAINT [fk_productoD]
GO
/****** Object:  ForeignKey [fk_categoriaRequerimientoCompra]    Script Date: 06/04/2015 16:42:36 ******/
ALTER TABLE [dbo].[RequerimientoCompra]  WITH CHECK ADD  CONSTRAINT [fk_categoriaRequerimientoCompra] FOREIGN KEY([codCategoria])
REFERENCES [dbo].[Categoria] ([codCategoria])
GO
ALTER TABLE [dbo].[RequerimientoCompra] CHECK CONSTRAINT [fk_categoriaRequerimientoCompra]
GO
/****** Object:  ForeignKey [fk_producto]    Script Date: 06/04/2015 16:42:37 ******/
ALTER TABLE [dbo].[RequerimientoDetalleCompra]  WITH CHECK ADD  CONSTRAINT [fk_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[RequerimientoDetalleCompra] CHECK CONSTRAINT [fk_producto]
GO
/****** Object:  ForeignKey [fk_requerimientoCompra]    Script Date: 06/04/2015 16:42:37 ******/
ALTER TABLE [dbo].[RequerimientoDetalleCompra]  WITH CHECK ADD  CONSTRAINT [fk_requerimientoCompra] FOREIGN KEY([codRequerimiento])
REFERENCES [dbo].[RequerimientoCompra] ([codRequerimiento])
GO
ALTER TABLE [dbo].[RequerimientoDetalleCompra] CHECK CONSTRAINT [fk_requerimientoCompra]
GO




INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'H.G. TRADING CORP.', '12226 S.W. 131 AVENUE - MIAMI - FLORIDA 33186', 'US', ',8747215135.53334', 'mchiolju@IIIIII.com', '', 'ET22200', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'SANDOVAL PULIDO EDINSON ARCELIO', 'TRANSVERSAL 42 NO. 4-29 BARRIO LA PRIMAVERA', 'CO', ',661433884.775582', 'mchiolju@IIIIII.com', '', 'ET26584', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'TEXTILES OMNES S.A.', 'CARRERA 16 N. 36-98 DOSQUEBRADAS-RISARALDA-PEREIRA', 'CO', ',6323635591.64069', 'mchiolju@IIIIII.com', '', 'ET40217', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'TEX FABRIC S.A.', 'SIMONE 587  6700 LUJAN  -  BUENOS AIRES', 'AR', ',5055305781.46386', 'mchiolju@IIIIII.com', '', 'ET59375', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'DUSA DUPONT SABANCI ARGENTINA S.A.', 'AV. MADERO 1020(1106) - BUENOS AIRES - ARGENTINA', 'AR', ',4433838954.37895', 'mchiolju@IIIIII.com', '', 'ET59385', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'BRIDGESTONE CHILE S.A.', 'AVENIDA KENNEDY 5735 OF.1202,TPONIENTE, LAS CONDES', 'BO', ',8361584307.51807', 'mchiolju@IIIIII.com', '', 'ET70155', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'BRIDGESTONE CHILE S.A.', 'AVENIDA KENNEDY 5735 OF.1202,T.PONIENTE,LAS CONDES', 'CL', ',3993115776.02299', 'mchiolju@IIIIII.com', '', 'ET70156', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'COMERCIALIZADORA GLOBAL TRADING SPA', 'NUEVA COSTANERA 3668 VITACURA - SANTIAGO DE CHILE', 'CL', ',2749888488.95075', 'mchiolju@IIIIII.com', '', 'ET70160', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'JAIME COPA CHOQUE', 'AV.6 DE MARZO 750 LA PAZ-BOLIVIA', 'BO', ',739021577.145398', 'mchiolju@IIIIII.com', '', 'ET75689', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'MARISOL ARISPE ARAOZ', 'AV. INGAVI 2426 - COCHABAMBA', 'BO', ',8279735675.97554', 'mchiolju@IIIIII.com', '', 'ET75695', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'BRIDGESTONE ARGENTINA S.A.I.C.', 'AV.ANTARTIDA ARGENTINA  2715 LLAVALLOL(1836)', 'AR', ',3538083250.83273', 'mchiolju@IIIIII.com', '', 'ET75924', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'IMPORTADORA ORTIZ S.R.L.', 'AV. CRISTOBAL DE MENDOZA 757 SANTA CRUZ BOLIVIA', 'BO', ',3126609347.4905', 'mchiolju@IIIIII.com', '', 'ET84576', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'GOOD YEAR CHILE, SAIC', 'CAMINO MELIPILLA KM 16 - SANTIAGO DE CHILE', 'CL', ',8526350118.28612', 'mchiolju@IIIIII.com', '', 'ET90005', '123456');
INSERT INTO dbo.Cliente ( Ruc, Razon_Social, Direccion, Cod_Pais, Telefono, Correo, Observaciones, Usuario, Pasword)
VALUES ( '00000000000', 'ENKA DE COLOMBIA S.A.', 'MEDELLIN - COLOMBIA', 'CO', ',1043624457.42127', 'mchiolju@IIIIII.com', '', 'ET90006', '123456');



INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET02', '123456', 'SANDOVAL PULIDO EDINSON ARCELIO', 'C', 'A', '2');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET03', '123456', 'TEXTILES OMNES S.A.', 'C', 'A', '3');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET04', '123456', 'TEX FABRIC S.A.', 'C', 'A', '4');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET05', '123456', 'DUSA DUPONT SABANCI ARGENTINA S.A.', 'C', 'A', '5');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET06', '123456', 'BRIDGESTONE CHILE S.A.', 'C', 'A', '6');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET07', '123456', 'BRIDGESTONE CHILE S.A.', 'C', 'A', '7');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET08', '123456', 'COMERCIALIZADORA GLOBAL TRADING SPA', 'C', 'A', '8');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET09', '123456', 'JAIME COPA CHOQUE', 'C', 'A', '9');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET10', '123456', 'MARISOL ARISPE ARAOZ', 'C', 'A', '10');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET11', '123456', 'BRIDGESTONE ARGENTINA S.A.I.C.', 'C', 'A', '11');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET12', '123456', 'IMPORTADORA ORTIZ S.R.L.', 'C', 'A', '12');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET13', '123456', 'GOOD YEAR CHILE, SAIC', 'C', 'A', '13');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET14', '123456', 'ENKA DE COLOMBIA S.A.', 'C', 'A', '14');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ET22200', '123456', 'H.G. TRADING CORP.', 'C', 'A', '1');
INSERT INTO dbo.Usuario (Cod_Usuario, Pwd_Usuario, Nom_Usuario, Tipo_Usuario, Estado_Usuario, Filler1)
VALUES ('ETIER1', '123456', 'ICCHER ESPINOZA', 'E', 'A', '');


INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN01', 'Sistema - Transaccion');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN02', 'Sistema - Tablas');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN03', 'Ventas - Menu Ventas');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN04', 'Compras - Menu compras');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN05', 'Exportación - Requerimiento');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN06', 'Exportación - Solicitud Atencion');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN07', 'Exportación - Formato Comercial');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN08', 'Exportación - Aprobacion Solicitud');
INSERT INTO dbo.OpcMenu (Cod_OpcionMenu, Des_opcionMenu)
VALUES ('ETN09', 'Exportación - Cronograma Despacho');


INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET02', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET03', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET04', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET05', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET06', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET07', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET08', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET09', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET10', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET11', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET12', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET13', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET14', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET22200', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET40217', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN01');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN02');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN03');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN04');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN06');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN07');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ET4618', 'ETN08');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN01');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN02');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN03');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN04');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN06');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN07');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN08');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETIER1', 'ETN09');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN01');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN02');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN03');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN04');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN06');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN07');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN08');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETJMS1', 'ETN09');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN01');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN02');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN03');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN04');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN06');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN07');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN08');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETOMS1', 'ETN09');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN01');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN02');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN03');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN04');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN06');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN07');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN08');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETSTN1', 'ETN09');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN01');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN02');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN03');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN04');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN05');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN06');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN07');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN08');
INSERT INTO dbo.UsuMenu (Cod_Usuario, Cod_OpcionMenu)
VALUES ('ETWPF1', 'ETN09');



INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1011110', 'Bateria S5 65 D', 'UND', 0, 0, 0, 0, 0, 0, 15.640000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 15.615, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031182', 'Bateria S4 100 E', 'UND', 0, 0, 0, 0, 0, 0, 15.300000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 63.379, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031184', 'Bateria S4 150 D', 'UND', 0, 0, 0, 0, 0, 0, 15.6, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 52.316, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031188', 'Bateria S4 62 E', 'UND', 0, 0, 0, 0, 0, 0, 12.300000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 113.592, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031194', 'Bateria S4 62 D', 'UND', 0, 0, 0, 0, 0, 0, 18.199999999999999, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 44.957, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031538', 'Bateria S4 55 E', 'UND', 0, 0, 0, 0, 0, 0, 17.600000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 70.533, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031548', 'Bateria S4 55 D', 'UND', 0, 0, 0, 0, 0, 0, 13.896000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 134.954, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031596', 'Bateria S4 36 DA', 'UND', 0, 0, 0, 0, 0, 0, 17.649999999999999, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 129.322, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1031730', 'Bateria S4 180 E', 'UND', 0, 0, 0, 0, 0, 0, 13.5, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 105.892, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1032068', 'Bateria S3 65 D', 'UND', 0, 0, 0, 0, 0, 0, 17.559999999999999, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 48.775, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1032098', 'Bateria S4 45 DA', 'UND', 0, 0, 0, 0, 0, 0, 19.559999999999999, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 41.895, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1041937', 'Bateria S5 170 D', 'UND', 0, 0, 0, 0, 0, 0, 17.539999999999999, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 47.34, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1041940', 'Bateria S3 45 D', 'UND', 0, 0, 0, 0, 0, 0, 17.530000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 51.506, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1041960', 'Bateria S5 70 E', 'UND', 0, 0, 0, 0, 0, 0, 19.52, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 111.389, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1042937', 'Bateria S5 70 D', 'UND', 0, 0, 0, 0, 0, 0, 15.65, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 90.13, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1042940', 'Bateria S5 170 E', 'UND', 0, 0, 0, 0, 0, 0, 14.85, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 145.955, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1051944', 'Bateria S5 90 D', 'UND', 0, 0, 0, 0, 0, 0, 19.870000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 73.961, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1054648', 'Bateria S3 45 E', 'UND', 0, 0, 0, 0, 0, 0, 16.539999999999999, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 34.62, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1284168', 'Bateria S5 62 DH', 'UND', 0, 0, 0, 0, 0, 0, 12.57, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 43.325, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '1284174', 'Bateria S5 90 DM', 'UND', 0, 0, 0, 0, 0, 0, 16.539999999999999, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 124.937, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '2254174', 'Bateria S5 75 EH', 'UND', 0, 0, 0, 0, 0, 0, 13.532, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 108.822, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '2254175', 'Bateria S5 75 DH', 'UND', 0, 0, 0, 0, 0, 0, 17.562000000000001, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 73.421, 0, 0);
INSERT INTO dbo.producto ( tipoProducto, codigoProducto, descripcionProducto, tipounidadMedida, numeroPlacas, capacidadNominal, capacidadArranque, largo, ancho, alto, peso, periodoRecarga, tiempoMaxSinCarga, temperaturaMaxCarga, tipoDeUso, tiempoGarantia, stockMinimo, stockMaximo, activo, Cod_Usuario, fechaCreacion, fechaModificacion, pre_prod, codCategoria, codMarca)
VALUES ( NULL, '8244168', 'Bateria S5 62 EH', 'UND', 0, 0, 0, 0, 0, 0, 18.52, 0, 0, 0, 0, 0, 0, 0, 0, 'ETIER1', '2015-05-20', '2015-05-20', 1.642, 0, 0);





INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AE', 'EMIRATOS ARABES');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AF', 'AFGANISTAN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AL', 'ALBANIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AN', 'ANTILLAS HOLANDESAS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AO', 'ANGOLA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AR', 'ARGENTINA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AT', 'AUSTRIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AU', 'AUSTRALIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('AW', 'ANTILLAS HOLANDESAS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BA', 'BOSNIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BB', 'BARBADOS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BD', 'BANGLADESH');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BE', 'BELGICA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BG', 'BULGARIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BH', 'BAHRAIN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BI', 'BURUNDI');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BJ', 'BENIN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BM', 'ISLAS BERMUDAS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BN', 'BRUNEI');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BO', 'BOLIVIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BR', 'BRASIL');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BS', 'BAHAMAS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('BZ', 'BELICE');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CA', 'CANADA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CF', 'REP. CENTRO AFRICANA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CG', 'CONGO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CH', 'SUIZA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CI', 'COSTA DE MARFIL');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CL', 'CHILE');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CM', 'CAMERUM');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CN', 'CHINA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CO', 'COLOMBIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CR', 'COSTA RICA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CU', 'CUBA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CV', 'CABO VERDE');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CY', 'CHIPRE');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CYL', 'CHIPRE');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('CZ', 'REP. CHECA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('DE', 'ALEMANIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('DJ', 'YIBUTI');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('DK', 'DINAMARCA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('DO', 'REP. DOMINICANA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('DZ', 'ARGELIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('EC', 'ECUADOR');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('EG', 'EGIPTO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ER', 'ERITREA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ES', 'ESPAÑA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ET', 'ETIOPIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('FI', 'FINLANDIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('FJ', 'FIJI');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('FR', 'FRANCIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GA', 'GABON');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GB', 'GRAN BRETAÑA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GD', 'GRANADA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GF', 'GUAYANA FRANCESA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GH', 'GHANA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GI', 'GRAN BRETAÑA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GM', 'GAMBIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GN', 'GUINEA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GP', 'ANTILLAS FRANCESAS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GR', 'GRECIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GT', 'GUATEMALA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('GY', 'GUYANA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('HK', 'HONG KONG');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('HN', 'HONDURAS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('HR', 'CROACIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('HT', 'HAITI');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('HU', 'HUNGRIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ID', 'INDONESIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('IE', 'IRLANDA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('IL', 'ISRAEL');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('IN', 'INDIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('IQ', 'IRAQ');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('IR', 'IRAN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('IS', 'ISLANDIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('IT', 'ITALIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('JM', 'JAMAICA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('JO', 'JORDANIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('JP', 'JAPON');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('KE', 'KENYA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('KM', 'IS. COMORES');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('KR', 'KOREA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('KW', 'KUWAIT');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('LB', 'LIBANO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('LC', 'SANTA LUCIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('LK', 'SRI-LANKA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('LR', 'LIBERIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('LU', 'LUXEMBURGO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('LY', 'LIBIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MA', 'MARRUECOS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MG', 'MADAGASCAR');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ML', 'MALI');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MN', 'MONGOLIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MQ', 'MARTINICA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MR', 'MAURITANIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MT', 'MALTA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MU', 'IS. MAURICIO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MW', 'MALAWI');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MX', 'MEXICO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MY', 'MALASIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('MZ', 'MOZAMBIQUE');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('NA', 'NAMIBIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('NG', 'NIGERIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('NI', 'NICARAGUA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('NL', 'HOLANDA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('NO', 'NORUEGA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('NP', 'NEPAL');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('NZ', 'NUEVA ZELANDA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('OM', 'OMAN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PA', 'PANAMA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PE', 'PERU');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PF', 'POLINESIA FRANCESA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PH', 'FILIPINAS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PK', 'PAKISTAN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PL', 'POLONIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PR', 'PUERTO RICO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PT', 'PORTUGAL');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('PY', 'PARAGUAY');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('QA', 'QATAR');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('RE', 'FRANCIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('RO', 'RUMANIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('RU', 'RUSIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('RW', 'RUANDA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SA', 'ARABIA SAUDITA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SC', 'SEYCHELLES');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SD', 'SUDAN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SE', 'SUECIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SG', 'SINGAPUR');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SI', 'SLOVENIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SK', 'ESLOVAQUIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SL', 'SIERRA LEONA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SN', 'SENEGAL');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SO', 'SOMALIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SR', 'SURINAM');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SV', 'EL SALVADOR');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('SY', 'SIRIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TD', 'CHAD');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TG', 'TOGO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TH', 'THAILANDIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TN', 'TUNEZ');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TO', 'TONGA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TR', 'TURQUIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TT', 'TRINIDAD TOBAGO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TW', 'TAIWAN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('TZ', 'TANZANIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('UA', 'UCRANIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('UG', 'UGANDA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('UK', 'REINO UNIDO');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('US', 'ESTADOS UNIDOS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('UY', 'URUGUAY');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('VE', 'VENEZUELA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('VI', 'ESTADOS UNIDOS');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('VN', 'VIETNAM');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('WS', 'SAMOA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('YE', 'REP. DEL YEMEN');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('YU', 'YUGOSLAVIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ZA', 'SUDAFRICA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ZM', 'ZAMBIA');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ZR', 'ZAIRE');
INSERT INTO dbo.Pais (Cod_Pais, Nom_Pais)
VALUES ('ZW', 'ZIMBABWE');


INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ABA', 'RU', 'ABAKAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ABD', 'IR', 'ABADAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ABJ', 'CI', 'ABIDJAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ACC', 'GH', 'ACCRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ACE', 'ES', 'LANZAROTE, ISLAS CANARIAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ADD', 'ET', 'ADDIS ABABA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ADE', 'YE', 'ADEN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ADL', 'AU', 'ADELAIDA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ADZ', 'CO', 'SAN ANDRES IS.');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AGP', 'ES', 'MALAGA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AJU', 'BR', 'ARACAJU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AKL', 'NZ', 'AUCKLAND');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ALC', 'ES', 'ALICANTE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ALG', 'DZ', 'ARGEL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ALP', 'SY', 'ALEPPO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ALT', 'MX', 'ALTAMIRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ALY', 'EG', 'ALEJANDRIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AMM', 'JO', 'AMMAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AMS', 'NL', 'AMSTERDAM');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ANC', 'US', 'ANCHORAGE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ANF', 'CL', 'ANTOFAGASTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ANK', 'TR', 'ANKARA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ANR', 'BE', 'ANTWERP');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('APW', 'WS', 'APIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AQP', 'PE', 'AREQUIPA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ARH', 'GR', 'ATENAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ARI', 'CL', 'ARICA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ASM', 'ER', 'ASMARA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ASU', 'PY', 'ASUNCION');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ATL', 'US', 'ATLANTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AUA', 'AW', 'ARUBA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AUH', 'AE', 'ABU DHABI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AVI', 'CU', 'CIEGO DE AVILA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AYP', 'PE', 'AYACUCHO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('AYT', 'TR', 'ANTALYA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BAH', 'BH', 'BAHRAIN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BAQ', 'CO', 'BARRANQUILLA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BCN', 'ES', 'BARCELONA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BDA', 'BM', 'BERMUDA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BEG', 'YU', 'BELGRADO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BEL', 'BR', 'BELEM');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BEN', 'LY', 'BENGHAZI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BEY', 'LB', 'BEIRUT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BGF', 'CF', 'BANGUI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BGI', 'BB', 'BARBADOS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BGO', 'NO', 'BERGEN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BGW', 'IQ', 'BAGHDAD');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BHD', 'GB', 'BELFAST');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BHI', 'AR', 'BAHIA BLANCA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BHZ', 'BR', 'BELO HORIZONTE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BIO', 'ES', 'BILBAO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BJL', 'GM', 'BANJUL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BJM', 'BI', 'BUJUMBURA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BJS', 'CN', 'BEIJING');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BKK', 'TH', 'BANGKOK');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BKO', 'ML', 'BAMAKO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BKY', 'ZR', 'BUKAVU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BLQ', 'IT', 'BOLONIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BLZ', 'MW', 'BLANTYRE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BNA', 'US', 'NASHVILLE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BOD', 'FR', 'BORDEAUX');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BOG', 'CO', 'BOGOTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BOL', 'US', 'HARTFORD');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BOM', 'IN', 'BOMBAY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BON', 'AN', 'BONAIRE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BOS', 'US', 'BOSTON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BRE', 'DE', 'BREMENHAVEN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BRI', 'IT', 'BARI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BRN', 'CH', 'BERNA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BRU', 'BE', 'BRUSELAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BSB', 'BR', 'BRASILIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BSL', 'CH', 'BASILEA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BSR', 'IQ', 'BASRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BTS', 'SK', 'BRATISLAVA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BUD', 'HU', 'BUDAPEST');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BUE', 'AR', 'BUENOS AIRES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BUF', 'US', 'BUFFALO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BUH', 'RO', 'BUCAREST');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BUN', 'CO', 'BUENAVENTURA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BUQ', 'ZW', 'BULAWAYO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BWI', 'US', 'BALTIMORE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BWN', 'BN', 'BANDAR SERI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BZC', 'BR', 'BUZIOS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BZE', 'BZ', 'BELICE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('BZV', 'CG', 'BRAZZAVILLE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CAI', 'EG', 'CAIRO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CAL', 'CR', 'PUERTO CALDERA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CAN', 'CN', 'GUANGZHOU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CAS', 'MA', 'CASABLANCA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CAU', 'DO', 'CAUCEDO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CAY', 'GF', 'CAYENNE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CBB', 'BO', 'COCHABAMBA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CBR', 'AU', 'CAMBERRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CCS', 'VE', 'CARACAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CCU', 'IN', 'CALCUTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CGB', 'BR', 'CUIABA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CGN', 'DE', 'COLONIA/BONN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CHC', 'NZ', 'CHRISTCHURCH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CHI', 'US', 'CHICAGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CHM', 'PE', 'CHIMBOTE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CHS', 'US', 'CHARLESTON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CIO', 'NI', 'CORINTO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CIX', 'PE', 'CHICLAYO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CKY', 'GN', 'CONAKRY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CLE', 'US', 'CLEVELAND');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CLL', 'PE', 'CALLAO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CLO', 'CO', 'CALI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CMB', 'LK', 'COLOMBO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CMH', 'US', 'COLUMBUS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CNS', 'AU', 'CAIRNS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('COO', 'BJ', 'COTONOU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CPH', 'DK', 'COPENHAGUE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CPT', 'ZA', 'CIUDAD DEL CABO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CTG', 'CO', 'CARTAGENA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CTW', 'ZA', 'CAPE TOWN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CUN', 'MX', 'CANCUN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CUR', 'AN', 'CURAÇAO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CVG', 'US', 'CINCINATI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CWB', 'BR', 'CURITIBA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CWN', 'CN', 'CHIWAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CYO', 'CU', 'CAYO LARGO DEL SUR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CYR', 'UY', 'COLONIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('CZM', 'MX', 'COZUMEL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DAC', 'BD', 'DHAKA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DAM', 'SY', 'DAMASCO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DAR', 'TZ', 'DAR ES SALAAM');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DAY', 'US', 'DAYTON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DBV', 'HR', 'DUBROBVNIK');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DEL', 'IN', 'DELHI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DEN', 'US', 'DENVER');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DFW', 'US', 'DALLAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DHA', 'SA', 'DHAHRAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DIR', 'ET', 'DIRE DAWA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DKR', 'SN', 'DAKAR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DLA', 'CM', 'DOUALA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DLC', 'CN', 'DALIAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DOH', 'QA', 'DOHA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DPS', 'ID', 'DENPASAR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DRS', 'DE', 'DRESDE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DTT', 'US', 'DETROIT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DUB', 'IE', 'DUBLIN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DUR', 'ZA', 'DURBAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DUS', 'DE', 'DUSSELDORF');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('DXB', 'AE', 'DUBAI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('EBB', 'UG', 'ENTEBBE KAMPALA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('EDI', 'GB', 'EDIMBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('EMA', 'GB', 'EAST MIDLANDS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('EWR', 'US', 'NEWARK');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FAO', 'PT', 'FARO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FBM', 'ZR', 'LUBUMBASHI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FDF', 'MQ', 'FORT DE FRANCE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FIH', 'ZR', 'KINSHASA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FLN', 'BR', 'FLORIANOPOLIS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FLR', 'IT', 'FLORENCIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FLX', 'UK', 'FELIXSTOWE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FNA', 'SL', 'FREETOWN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FNC', 'PT', 'FUNCHAL ISLA MADEIRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FOR', 'BR', 'FORTALEZA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FPO', 'BS', 'FREEPORT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FRA', 'DE', 'FRANKFURT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FUE', 'ES', 'FUERTE VENTURA, ISLAS CANARIAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('FUK', 'JP', 'FUKUOKA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GBE', 'GI', 'GABORONE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GDL', 'MX', 'GUADALAJARA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GEO', 'GY', 'GEORGETOWN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GIB', 'GI', 'GIBRALTAR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GLA', 'GB', 'GLASGOW');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GND', 'GD', 'GRANADA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GOT', 'SE', 'GOTEMBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GRZ', 'AT', 'GRAZ');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GUA', 'GT', 'GUATEMALA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GVA', 'CH', 'GINEBRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GYE', 'EC', 'GUAYAQUIL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GYM', 'MX', 'GUAYMAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('GYN', 'BR', 'GOIANIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HAM', 'DE', 'HAMBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HAN', 'VN', 'HANDI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HAV', 'CU', 'LA HABANA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HBA', 'AU', 'HOBART');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HEL', 'FI', 'HELSINKI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HKG', 'HK', 'HONG KONG');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HKT', 'TH', 'PHUKET');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HNL', 'US', 'HONOLULU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HOG', 'CU', 'HOLGUIN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HOR', 'PT', 'HORTA, ISLAS AZORES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HOU', 'US', 'HOUSTON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('HRE', 'ZW', 'HARARE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IBB', 'BR', 'IMBITUBA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IBZ', 'ES', 'IBIZA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IEV', 'UA', 'KIEV');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IGU', 'BR', 'FOZ DO IGUAÇU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ILO', 'PE', 'ILO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IND', 'US', 'INDIANAPPOLIS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IOS', 'BR', 'ILHEUS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IPC', 'CL', 'IS. DE PASCUA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IQQ', 'CL', 'IQUIQUE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IQT', 'PE', 'IQUITOS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ISB', 'PK', 'ISLAMABAD');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IST', 'SE', 'ESTAMBUL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('IZM', 'TR', 'ESMIRNA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JAX', 'US', 'JAKSONVILLE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JED', 'SA', 'JEDDAH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JIB', 'DJ', 'YIBUTI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JKT', 'ID', 'JAKARTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JNB', 'ZA', 'JOHANNESBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JPA', 'BR', 'JOAO PESSOA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JRS', 'IL', 'JERUSALEM');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('JUL', 'PE', 'JULIACA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KAN', 'NG', 'KANO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KBL', 'AF', 'KABUL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KGL', 'RW', 'KIGALI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KHH', 'TW', 'KAOHSIUNG');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KHI', 'PK', 'KARACHI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KIN', 'JM', 'KINGSTON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KLU', 'AT', 'KLAGENFURT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KRS', 'NO', 'KRISTIANSAND');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KRT', 'SD', 'KHARTOUM');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KTM', 'NP', 'KATMANDU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KUL', 'MY', 'KUALA LUMPUR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KWI', 'KW', 'KUWAIT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('KYE', 'LY', 'TRIPOLI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LAD', 'AO', 'LUANDA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LAG', 'VE', 'LA GUAIRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LAS', 'US', 'LAS VEGAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LAX', 'US', 'LOS ANGELES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LBA', 'GB', 'LEEDS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LBV', 'GA', 'LIBREVILLE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LCA', 'CYL', 'LARNACA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LCG', 'ES', 'LA CORUÑA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LEI', 'ES', 'ALMEIRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LEJ', 'DE', 'LEIPZIG');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LFW', 'TG', 'LOME');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LGB', 'US', 'LONG BEACH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LHV', 'FR', 'LE HAVRE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LIL', 'FR', 'LILLE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LIM', 'PE', 'LIMA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LIO', 'CR', 'PUERTO LIMON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LIS', 'PT', 'LISBOA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LJU', 'SI', 'LJUBLJANA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LLW', 'MW', 'LILONGWE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LNZ', 'AT', 'LINZ');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LON', 'GB', 'LONDRES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LOS', 'NG', 'LAGOS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LPA', 'ES', 'GRAN CANARIA, ISLAS CANARIAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LPB', 'BO', 'LA PAZ');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LQN', 'CL', 'LIRQUEN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LSC', 'CL', 'LA SERENA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LUN', 'ZM', 'LUSAKA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LUX', 'LU', 'LUXEMBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LYS', 'FR', 'LYON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('LZC', 'MX', 'LAZARO CARDENAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MAA', 'IN', 'MADRAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MAD', 'ES', 'MADRID');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MAH', 'ES', 'MENORCA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MAO', 'BR', 'MANAOS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MAR', 'VE', 'MARACAIBO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MBJ', 'JM', 'MONTEGO BAY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MCT', 'OM', 'MUSCAT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MCZ', 'BR', 'MACEIO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MDE', 'CO', 'MEDELLIN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MEL', 'AU', 'MELBOURNE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MEM', 'US', 'MEMPHIS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MEX', 'MX', 'MEXICO, CIUDAD DE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MGA', 'NI', 'MANAGUA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MGQ', 'SO', 'MOGADISHU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MIA', 'US', 'MIAMI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MID', 'MX', 'MERIDA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MIL', 'IT', 'MILAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MIT', 'PA', 'MANZANILLO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MJV', 'ES', 'MURCIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MKC', 'US', 'KANSAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MKE', 'US', 'MILWAUKEE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MLA', 'MT', 'MALTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MLH', 'FR', 'MULHOUSE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MLW', 'LR', 'MONROVIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MMA', 'SE', 'MALMO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MME', 'GB', 'TEESSIDE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MNL', 'PH', 'MANILA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MOW', 'RU', 'MOSCU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MPM', 'MZ', 'MAPUTO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MRI', 'PE', 'MATARANI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MRS', 'FR', 'MARSELLA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MRU', 'MU', 'MAURICIO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MSP', 'US', 'MINNEAPOLIS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MSY', 'US', 'NEW ORLEANS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MTY', 'MX', 'MONTERREY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MUC', 'DE', 'MUNICH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MVD', 'UY', 'MONTEVIDEO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MZO', 'CU', 'MANZANILLO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('MZT', 'MX', 'MAZATLAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NAN', 'FJ', 'NADI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NAP', 'IT', 'NAPOLES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NAS', 'BS', 'NASSAU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NAT', 'BR', 'NATAL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NBO', 'KE', 'NAIROBI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NCE', 'FR', 'NIZA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NDJ', 'TD', 'N´DJAMENA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NGB', 'CN', 'NINGBO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NGO', 'JP', 'NAGOYA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NIC', 'CY', 'NICOSIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NIM', 'NG', 'NIAMEY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NKC', 'MR', 'NOUAKCHOTT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NOR', 'US', 'NORFOLK');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('NYC', 'US', 'NEW YORK');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ODS', 'UA', 'ODESA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('OKA', 'JP', 'OKINAWA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ONX', 'PA', 'COLON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('OPO', 'PT', 'OPORTO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ORL', 'US', 'ORLANDO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('OSA', 'JP', 'OSAKA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('OSL', 'NO', 'OSLO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('OVD', 'ES', 'OVIEDO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PAI', 'PE', 'PAITA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PAP', 'HT', 'PORT AU PRINCE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PAR', 'FR', 'PARIS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PBL', 'VE', 'PUERTO CABELLO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PBM', 'SR', 'PARAMARIBO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PCL', 'PE', 'PUCALPA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PCR', 'HN', 'PUERTO CORTES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PDL', 'PT', 'POINTE DELGADO, AZORES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PDP', 'UY', 'PUNTA del ESTE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PDX', 'US', 'PORTLAND');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PEF', 'US', 'EVERGLADES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PEM', 'PE', 'PUERTO MALDONADO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PEN', 'MY', 'PENANG');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PER', 'AU', 'PERTH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PEZ', 'ZA', 'PORT ELIZABETH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PFO', 'CY', 'PAPHOS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PGO', 'MX', 'PUERTO PROGRESO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PHL', 'US', 'FILADELFIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PHX', 'US', 'PHOENIX');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PIE', 'US', 'ST. PETERSBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PIT', 'US', 'PITTSBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PIU', 'PE', 'PIURA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PMC', 'CL', 'PUERTO MONTT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PMI', 'ES', 'PALMA DE MALLORCA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PMO', 'IT', 'PALERMO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PMV', 'VE', 'PORLAMAR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PNA', 'ES', 'PAMPLONA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PNG', 'BR', 'PARANAGUA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('POA', 'BR', 'PORTO ALEGRE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('POS', 'TT', 'PUERTO ESPAÑA, ISLA MADEIRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PPT', 'PF', 'PAPEETE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PRG', 'CZ', 'ISLA MADEIRA, PRAGA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PRQ', 'GT', 'PUERTO QUETZAL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PRY', 'ZA', 'PRETORIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PTP', 'GP', 'POINTE A PRITE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PTY', 'PA', 'PANAMA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PUJ', 'DO', 'PUNTA CANA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PUQ', 'CL', 'PUNTA ARENAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PUS', 'KR', 'BUSAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PVR', 'MX', 'PUERTO VALLARTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('PXO', 'PT', 'PORTO SANTO, ISLA MADERA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('QFS', 'BR', 'SAO FRANCISCO DO SUL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('RAK', 'MA', 'MARRAKECH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('RBA', 'MA', 'RABAT');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('RDU', 'US', 'RALEIGH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('REC', 'BR', 'RECIFE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('REK', 'IS', 'REYKJAVYK');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('RIC', 'US', 'RICHMOND');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('RIO', 'BR', 'RIO DE JANEIRO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ROC', 'US', 'ROCHESTER');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ROM', 'IT', 'ROMA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('RUH', 'SA', 'RIYADH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('RUN', 'RE', 'ST. DENIS, ISLA REUNION');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SAH', 'YE', 'SANA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SAI', 'CL', 'SAN ANTONIO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SAL', 'SV', 'SAN SALVADOR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SAN', 'US', 'SAN DIEGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SAO', 'BR', 'SAN PABLO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SAP', 'HN', 'SAN PEDRO SULA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SAV', 'US', 'SAVANNAH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SCL', 'CL', 'SANTIAGO DE CHILE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SCQ', 'ES', 'SANTIAGO DE COMPOSTERA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SDQ', 'DO', 'SANTO DOMINGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SDR', 'ES', 'SANTANDER');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SEA', 'US', 'SEATTLE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SEL', 'KR', 'SEUL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SEZ', 'SC', 'MAHE ISLAND');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SFG', 'GP', 'ST. MARTIN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SFO', 'US', 'SAN FRANCISCO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SGN', 'VN', 'HO CHI MINH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SHA', 'CN', 'SHANGHAI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SHJ', 'AE', 'SHARJAH');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SID', 'CV', 'ILHA DO SAL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SIE', 'PT', 'SINES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SIN', 'SG', 'SINGAPUR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SJC', 'US', 'SAN JOSE ( C.A.L )');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SJJ', 'BA', 'SARAJEVO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SJO', 'CR', 'SAN JOSE ( C. R. )');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SJU', 'PR', 'SAN JUAN ( P. R )');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SLC', 'US', 'SALT LAKE CITY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SLU', 'LC', 'SANTA LUCIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SLZ', 'BR', 'SAN LUIS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SMR', 'CO', 'SANTA MARTA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SNN', 'IE', 'SHANNON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SOF', 'BG', 'SOFIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SPE', 'IT', 'SPEZIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SRZ', 'BO', 'SANTA CRUZ DE LA SIERRA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SSA', 'BR', 'SALVADOR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SSZ', 'BR', 'SANTOS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('STL', 'US', 'ST. LOUIS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('STO', 'SE', 'ESTOCOLMO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('STR', 'DE', 'STUTTGART');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('STT', 'VI', 'ST. THOMAS, ISLAS VIRGENES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('STX', 'VI', 'ST. CROIX, ISLAS VIRGENES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SUV', 'FJ', 'SUVA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SVE', 'CL', 'SAN VICENTE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SVG', 'NO', 'STAVANGER');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SVQ', 'ES', 'SEVILLA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SXB', 'FR', 'ESTRASBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SXM', 'AN', 'ST. MAARTEN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SYD', 'AU', 'SYDNEY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('SZG', 'AT', 'SALZBURGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TAM', 'MX', 'TAMPICO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TBP', 'PE', 'TUMBES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TBU', 'TO', 'TONGATAPU');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TCI', 'ES', 'TENERIFE, ISLAS CANARIAS');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TCQ', 'PE', 'TACNA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TER', 'PT', 'TERCEIRA, ISLAS AZORES');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TGU', 'HN', 'TEGUCIGALPA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('THO', 'CL', 'TALCAHUANO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('THR', 'IR', 'TEHERAN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TIA', 'AL', 'TIRANA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TJA', 'BO', 'TARIJA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TLV', 'IL', 'TEL AVIV');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TNG', 'MA', 'TANGER');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TNR', 'MG', 'ANTANANARIVO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TPA', 'US', 'TAMPA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TPE', 'TW', 'TAIPEI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TPP', 'PE', 'TARAPOTO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TRN', 'IT', 'TORINO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TRU', 'PE', 'TRUJILLO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TSR', 'RO', 'TIMISOARA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TUN', 'TN', 'TUNEZ');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TUS', 'US', 'TUCSON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('TYO', 'JP', 'TOKIO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('UIO', 'EC', 'QUITO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ULN', 'MN', 'ULAN BATOR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('USH', 'AR', 'USUAHIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VAN', 'US', 'VANCOUVER');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VAP', 'CL', 'VALPARAISO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VER', 'DE', 'BERLIN');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VER', 'MX', 'VERACRUZ');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VFA', 'ZW', 'CATARATAS VICTORIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VGO', 'ES', 'VIGO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VIE', 'AT', 'VIENA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VIT', 'ES', 'VITORIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VIX', 'BR', 'VITORIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VLC', 'ES', 'VALENCIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VLN', 'VE', 'VALENCIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('VRA', 'CU', 'VARADERO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('WAS', 'US', 'WASHINGTON D. C.');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('WAW', 'PL', 'VARSOVIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('WDH', 'NA', 'WINDHOEK');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('WLG', 'NZ', 'WELLINGTON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YAO', 'CM', 'YAOUNDE');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YEG', 'CA', 'EDMONTON');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YOK', 'JP', 'YOKOHAMA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YOW', 'CA', 'OTTAWA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YQG', 'CA', 'WINDSOR');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YTO', 'CA', 'TORONTO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YUL', 'CA', 'MONTREAL');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YVA', 'KM', 'MORONI');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YVR', 'CA', 'VANCOUVER');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YWG', 'CA', 'WINNIPEG');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YYC', 'CA', 'CALGARY');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('YYJ', 'CA', 'VICTORIA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ZAG', 'HR', 'ZAGREB');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ZAZ', 'ES', 'ZARAGOZA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ZCO', 'CL', 'TEMUCO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ZIH', 'MX', 'IXTAPA');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ZLO', 'MX', 'MANZANILLO');
INSERT INTO dbo.IATA (IATA_COD, IATA_PAIS, IATA_DES)
VALUES ('ZRH', 'CH', 'ZURICH');



INSERT INTO dbo.DosSIICEX ( Des_SIICEX)
VALUES ( 'Requisitos de Calidad e Inocuidad');
INSERT INTO dbo.DosSIICEX ( Des_SIICEX)
VALUES ( 'Eventos Comerciales');
INSERT INTO dbo.DosSIICEX ( Des_SIICEX)
VALUES ( 'Aranceles Preferenciales');
INSERT INTO dbo.DosSIICEX ( Des_SIICEX)
VALUES ( 'Empresas Exportadoras');
INSERT INTO dbo.DosSIICEX ( Des_SIICEX)
VALUES ( 'Ficha Comercial');
INSERT INTO dbo.DosSIICEX ( Des_SIICEX)
VALUES ( 'Estadisticas Nacionales');



