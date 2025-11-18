USE [InventarioUH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articulo](
    [id] [int] IDENTITY(1000,100) NOT NULL,
      NOT NULL,
    [precio] [decimal](10, 4) NULL,
    [cantidad] [int] NOT NULL,
    [idbodega] [int] NULL,
    [idtipo] [int] NULL,
PRIMARY KEY CLUSTERED ([id] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Articulo] ADD DEFAULT ((0)) FOR [precio];
ALTER TABLE [dbo].[Articulo] ADD DEFAULT ((0)) FOR [cantidad];
GO

ALTER TABLE [dbo].[Articulo] WITH CHECK ADD CONSTRAINT [FK_bodega] FOREIGN KEY([idbodega])
REFERENCES [dbo].[Bodega] ([id]);
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_bodega];
GO

ALTER TABLE [dbo].[Articulo] WITH CHECK ADD CONSTRAINT [FK_idtipoArticulo] FOREIGN KEY([idtipo])
REFERENCES [dbo].[TipoArticulo] ([id]);
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_idtipoArticulo];
GO

