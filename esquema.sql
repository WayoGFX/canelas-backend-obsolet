CREATE TABLE [Categorias] (
    [CategoriaID] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Activo] bit NOT NULL DEFAULT CAST(1 AS bit),
    [Descripcion] nvarchar(500) NULL,
    [ImagenUrl] nvarchar(500) NULL,
    [Icono] nvarchar(100) NULL,
    [Slug] nvarchar(150) NOT NULL,
    CONSTRAINT [PK__Categori__F353C1C5DDF7CA49] PRIMARY KEY ([CategoriaID])
);
GO


CREATE TABLE [Productos] (
    [ProductoID] int NOT NULL IDENTITY,
    [CategoriaID] int NOT NULL,
    [Nombre] nvarchar(150) NULL,
    [Descripcion] nvarchar(max) NULL,
    [ImagenUrl] nvarchar(500) NULL,
    [Activo] bit NOT NULL DEFAULT CAST(1 AS bit),
    [Slug] nvarchar(250) NOT NULL DEFAULT N'',
    [EsDeTemporada] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK__Producto__A430AE83F7DC6428] PRIMARY KEY ([ProductoID]),
    CONSTRAINT [FK__Productos__Categ__398D8EEE] FOREIGN KEY ([CategoriaID]) REFERENCES [Categorias] ([CategoriaID])
);
GO


CREATE TABLE [ProductoPrecios] (
    [ProductoPrecioID] int NOT NULL IDENTITY,
    [ProductoID] int NOT NULL,
    [DescripcionPrecio] nvarchar(100) NOT NULL,
    [Precio] decimal(10,2) NOT NULL,
    CONSTRAINT [PK__Producto__9B63E9A7233E63A6] PRIMARY KEY ([ProductoPrecioID]),
    CONSTRAINT [FK__ProductoP__Produ__3D5E1FD2] FOREIGN KEY ([ProductoID]) REFERENCES [Productos] ([ProductoID])
);
GO


CREATE INDEX [IX_ProductoPrecios_ProductoID] ON [ProductoPrecios] ([ProductoID]);
GO


CREATE INDEX [IX_Productos_CategoriaID] ON [Productos] ([CategoriaID]);
GO


