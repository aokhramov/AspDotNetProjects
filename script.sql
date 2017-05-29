USE [PetShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 29.05.2017 10:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 29.05.2017 10:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 29.05.2017 10:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaserName] [nvarchar](255) NULL,
	[PostAddress] [nvarchar](255) NULL,
	[Comment] [nvarchar](255) NULL,
	[StateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderState]    Script Date: 29.05.2017 10:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 29.05.2017 10:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Category] [int] NULL,
	[Price] [decimal](19, 5) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductsImages]    Script Date: 29.05.2017 10:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[ProductId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderItem] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_Order_OrderItem]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_Product_OrdersItems] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_Product_OrdersItems]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderState] FOREIGN KEY([StateId])
REFERENCES [dbo].[OrderState] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_OrderState]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[ProductsImages]  WITH CHECK ADD  CONSTRAINT [FK_Product_Images] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductsImages] CHECK CONSTRAINT [FK_Product_Images]
GO

INSERT INTO [dbo].[Category]([Name]) VALUES ('“овары дл€ кошек')
GO
INSERT INTO [dbo].[Category]([Name]) VALUES ('“овары дл€ собак')
GO
INSERT INTO [dbo].[Category]([Name]) VALUES ('“овары дл€ птиц')
GO

INSERT INTO [dbo].[Product] ([Name],[Description],[Category],[Price],[Quantity])
     VALUES ('ƒразнилка-удочка Ћ€гушка ST-105' ,'ƒразнилка дл€ кошек' ,1 ,145.00 ,1)
GO

INSERT INTO [dbo].[Product] ([Name],[Description],[Category],[Price],[Quantity])
     VALUES ('ƒразнилка-удочка ћ€ч 107' ,'ƒразнилка дл€ кошек' ,1 ,145.00 ,0)
GO

INSERT INTO [dbo].[Product] ([Name],[Description],[Category],[Price],[Quantity])
     VALUES ('ƒразнилка-удочка ћ€ч зефир с пером' ,'ƒразнилка дл€ кошек' ,1 ,120.00 ,1)
GO

INSERT INTO [dbo].[Product] ([Name],[Description],[Category],[Price],[Quantity])
     VALUES ('»грушка дл€ кошек м€ч' ,'»грушка м€чик дл€ кошек' ,1 ,49.00 ,2)
GO

INSERT INTO [dbo].[Product] ([Name],[Description],[Category],[Price],[Quantity])
     VALUES ('»грушка дл€ собак винил ¬етка мала€ 22 см' ,'»грушка дл€ собак' ,2 ,95.00 ,3)
GO

INSERT INTO [dbo].[Product] ([Name],[Description],[Category],[Price],[Quantity])
     VALUES ('Versele-Laga ѕалочка дл€ попугаев 1х30г Ћесные €годы' 
	 ,'VERSELE-LAGA палочка дл€ волнистых попугаев Prestige с лесными €годами 1х30 г
—остав: —емена, злаковые, мед, различные сахара, €годы (€годы бузины, клюква, плоды шиповника) пекарские продукты, масла и жиры' 
	 ,3 ,99.00 ,1)
GO

INSERT INTO [dbo].[ProductsImages] ([Name] ,[ProductId])
   VALUES  ('tovar14927559714.jpg'  ,1)
GO

INSERT INTO [dbo].[ProductsImages] ([Name] ,[ProductId])
   VALUES  ('tovar14915439650.jpg'  ,2)
GO

INSERT INTO [dbo].[ProductsImages] ([Name] ,[ProductId])
   VALUES  ('tovar14530149941.jpg'  ,3)
GO

INSERT INTO [dbo].[ProductsImages] ([Name] ,[ProductId])
   VALUES  ('tovar14818652510.jpg'  ,4)
GO

INSERT INTO [dbo].[ProductsImages] ([Name] ,[ProductId])
   VALUES  ('tovar14927543545.jpg'  ,4)
GO

INSERT INTO [dbo].[ProductsImages] ([Name] ,[ProductId])
   VALUES  ('tovar14537882833.jpg'  ,5)
GO

INSERT INTO [dbo].[ProductsImages] ([Name] ,[ProductId])
   VALUES  ('tovar14887048012.jpg'  ,6)
GO

INSERT INTO [dbo].[OrderState]([Name])VALUES('ќжидает выполнени€')
GO

INSERT INTO [dbo].[OrderState]([Name])VALUES('¬ыполнено')
GO

INSERT INTO [dbo].[OrderState]([Name])VALUES('ќтменено')
GO