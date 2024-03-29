-- SQL Manager 2008 for SQL Server 3.3.0.1
-- ---------------------------------------
-- Host      : (local)
-- Database  : formFlows
-- Version   : Microsoft SQL Server  9.00.3073.00


CREATE DATABASE [formFlows]
ON PRIMARY
  ( NAME = [formFlows],
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\formFlows.mdf',
    SIZE = 2240 KB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 1 MB )
LOG ON
  ( NAME = [formFlows_log],
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\formFlows_log.LDF',
    SIZE = 504 KB,
    MAXSIZE = 0 MB,
    FILEGROWTH = 10 % )
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

USE [formFlows]
GO

--
-- Definition for table AtributoInformacionGeneral : 
--

CREATE TABLE [dbo].[AtributoInformacionGeneral] (
  [Id] int IDENTITY(1, 1) NOT NULL,
  [Identificador] int NULL,
  [Autor] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Version] int NULL,
  [FechaCreacion] datetime NULL,
  [FechaVigenciaDesde] datetime NULL,
  [FechaVigenciaHasta] datetime NULL,
  [Nombre] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Descripcion] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EsModificable] tinyint NULL
)
ON [PRIMARY]
GO

--
-- Data for table dbo.AtributoInformacionGeneral  (LIMIT 0,500)
--

SET IDENTITY_INSERT [dbo].[AtributoInformacionGeneral] ON
GO

BEGIN TRANSACTION
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (3, 1, N'Administrator', 1, '20091206', '20091208', '20091225', N'hola', N'hola', 0)
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (4, 1, N'Administrator', 1, '20091206', '20091208', '20091225', N'hola', N'hola', 0)
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (5, 1, N'Administrator', 1, '20091206', '20091130', '20091210', N'Mi atributo', N'Mi atributo', 1)
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (6, 1, N'Administrator', 1, '20091206', '20091130', '20091210', N'Nuevo atributo', N'Nuevo atributo', 1)
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (7, 1, N'Administrator', 1, '20091206', '20091130', '20091210', N'Nuevo atributo', N'Nuevo atributo', 1)
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (8, 1, N'Administrator', 1, '20091206', '20091130', '20091210', N'Nuevo atributo', N'Nuevo atributo', 1)
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (9, 1, N'Administrator', 1, '20091206', '20091130', '20091210', N'Nuevo atributo', N'Nuevo atributo', 1)
GO

INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES 
  (10, 1, N'Administrator', 1, '20091206', '20091130', '20091210', N'Nuevo atributo', N'Nuevo atributo', 1)
GO

COMMIT
GO

SET IDENTITY_INSERT [dbo].[AtributoInformacionGeneral] OFF
GO

--
-- Definition for indices : 
--

ALTER TABLE [dbo].[AtributoInformacionGeneral]
ADD PRIMARY KEY CLUSTERED ([Id])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

