USE [formFlows]
GO
/****** Objeto:  Table [dbo].[TreeNodos]    Fecha de la secuencia de comandos: 12/22/2009 21:00:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TreeNodos](
	[IDTree] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[NomTree] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IDParent] [numeric](18, 0) NULL,
	[IDAttr] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TreeNodos] PRIMARY KEY CLUSTERED 
(
	[IDTree] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF