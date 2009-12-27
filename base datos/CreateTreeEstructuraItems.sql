USE [formFlows]
GO
/****** Objeto:  Table [dbo].[TreeEstructuraItems]    Fecha de la secuencia de comandos: 12/27/2009 17:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TreeEstructuraItems](
	[IDTreeEstructuraItem] [numeric](18, 0) NOT NULL,
	[EsRequerido] [bit] NULL,
	[SoloLectura] [bit] NULL,
	[MultiSeleccion] [bit] NULL,
	[SubTipo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OrigenDeDatos] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Valores] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Ruta] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Metodo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Tipo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Largo] [numeric](18, 0) NULL,
	[Decimales] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TreeEstructura] PRIMARY KEY CLUSTERED 
(
	[IDTreeEstructuraItem] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF