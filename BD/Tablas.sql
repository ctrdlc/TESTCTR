USE [TEST]
GO

/****** Object:  Table [dbo].[Ventas_Contactos]    Script Date: 23/12/2016 7:44:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ventas_Contactos](
	[ID_Contacto] [int] IDENTITY(1,1) NOT NULL,
	[Apellido_paterno] [varchar](30) NOT NULL,
	[Apellido_materno] [varchar](30) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Correo_electronico] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono_movil] [varchar](15) NOT NULL,
	[Telefono_fijo] [varchar](15) NOT NULL,
	[Fecha_registro] [datetime] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Ventas_Clientes]    Script Date: 23/12/2016 7:44:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ventas_Clientes](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [varchar](50) NOT NULL,
	[ID_Contacto] [int] NOT NULL,
	[Direccion] [varchar](60) NOT NULL,
	[Ciudad] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[CodigoPostal] [varchar](50) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ventas_Contactos] ADD  CONSTRAINT [DF_Ventas_Contactos_Apellido_paterno]  DEFAULT (space((0))) FOR [Apellido_paterno]
GO

ALTER TABLE [dbo].[Ventas_Contactos] ADD  CONSTRAINT [DF_Ventas_Contactos_Apellido_materno]  DEFAULT (space((0))) FOR [Apellido_materno]
GO

ALTER TABLE [dbo].[Ventas_Contactos] ADD  CONSTRAINT [DF_Ventas_Contactos_Nombres]  DEFAULT (SPACE((0))) FOR [Nombres]
GO

ALTER TABLE [dbo].[Ventas_Contactos] ADD  CONSTRAINT [DF_Ventas_Contactos_Correo_electronico]  DEFAULT (SPACE((0))) FOR [Correo_electronico]
GO

ALTER TABLE [dbo].[Ventas_Contactos] ADD  CONSTRAINT [DF_Ventas_Contactos_Direccion]  DEFAULT (SPACE((0))) FOR [Direccion]
GO

ALTER TABLE [dbo].[Ventas_Contactos] ADD  CONSTRAINT [DF_Ventas_Contactos_Telefono_movil]  DEFAULT (SPACE((0))) FOR [Telefono_movil]
GO

ALTER TABLE [dbo].[Ventas_Contactos] ADD  CONSTRAINT [DF_Ventas_Contactos_Telefono_fijo]  DEFAULT (SPACE((0))) FOR [Telefono_fijo]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_NombreCliente]  DEFAULT (SPACE((0))) FOR [NombreCliente]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_ID_Contacto]  DEFAULT ((0)) FOR [ID_Contacto]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_Direccion]  DEFAULT (SPACE((0))) FOR [Direccion]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_Ciudad]  DEFAULT (SPACE((0))) FOR [Ciudad]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_Region]  DEFAULT (SPACE((0))) FOR [Region]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_CodigoPostal]  DEFAULT (SPACE((0))) FOR [CodigoPostal]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_Pais]  DEFAULT (SPACE((0))) FOR [Pais]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_Telefono]  DEFAULT (SPACE((0))) FOR [Telefono]
GO

ALTER TABLE [dbo].[Ventas_Clientes] ADD  CONSTRAINT [DF_Ventas_Clientes_email]  DEFAULT (SPACE((0))) FOR [email]
GO

ALTER TABLE [dbo].[Ventas_Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Clientes_Ventas_Clientes] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Ventas_Clientes] ([ID_Cliente])
GO

ALTER TABLE [dbo].[Ventas_Clientes] CHECK CONSTRAINT [FK_Ventas_Clientes_Ventas_Clientes]
GO


