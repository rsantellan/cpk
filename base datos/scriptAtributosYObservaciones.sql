CREATE TABLE [dbo].[observaciones] (
  [id] int IDENTITY(1, 1) NOT NULL,
  [tarea] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [observacion] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [autor] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [fecha] datetime NOT NULL,
  [object_id] int NOT NULL,
  [object_class] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [object_version] int NOT NULL,
  PRIMARY KEY CLUSTERED ([id])
)
ON [PRIMARY]
GO

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
  [EsModificable] tinyint NULL,
  PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
GO



/* Data for the `dbo.AtributoInformacionGeneral` table  (Records 1 - 14) */


INSERT INTO [dbo].[AtributoInformacionGeneral] ([Id], [Identificador], [Autor], [Version], [FechaCreacion], [FechaVigenciaDesde], [FechaVigenciaHasta], [Nombre], [Descripcion], [EsModificable])
VALUES (1, 0, N'-', 0, NULL, NULL, NULL, N'', N'', 0)
GO

