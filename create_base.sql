USE [FoodTruck]
GO
/****** Object:  Table [dbo].[Allergene]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergene](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Allergene] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Catalogue]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogue](
	[ProduitId] [numeric](18, 0) NOT NULL,
	[DateDisponibilite] [datetime] NOT NULL,
 CONSTRAINT [PK_Catalogue] PRIMARY KEY CLUSTERED 
(
	[ProduitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commande]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commande](
	[ProduitId] [numeric](18, 0) NOT NULL,
	[UtilisateurId] [numeric](18, 0) NOT NULL,
	[DateCommande] [datetime] NOT NULL,
 CONSTRAINT [PK_Commande] PRIMARY KEY CLUSTERED 
(
	[ProduitId] ASC,
	[UtilisateurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contenir]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contenir](
	[MenuId] [numeric](18, 0) NOT NULL,
	[ProduitId] [numeric](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historique]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historique](
	[ProduitId] [numeric](18, 0) NOT NULL,
	[Timestamp] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Label] [varchar](50) NOT NULL,
	[Prix] [numeric](18, 2) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produit]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produit](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](max) NOT NULL,
	[Prix] [numeric](18, 2) NOT NULL,
	[Image] [varchar](max) NOT NULL,
	[Quantite] [numeric](18, 3) NOT NULL,
	[Unite] [varchar](max) NOT NULL,
	[TypeMenu] [int] NOT NULL,
 CONSTRAINT [PK_Produit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProduitAllergene]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProduitAllergene](
	[ProduitId] [numeric](18, 0) NOT NULL,
	[AllergeneId] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ProduitAllergene] PRIMARY KEY CLUSTERED 
(
	[ProduitId] ASC,
	[AllergeneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 23/10/2018 16:37:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Nom] [varchar](max) NOT NULL,
	[Prenom] [varchar](max) NOT NULL,
	[DateNaissance] [datetime] NOT NULL,
	[Adresse] [varchar](max) NOT NULL,
	[Societe] [varchar](max) NULL,
	[Genre] [int] NOT NULL,
 CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(6 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(8 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(33 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(33 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(35 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(35 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(37 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(37 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(38 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(38 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(20 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(21 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(17 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(20 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(21 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(22 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(23 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(28 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(29 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(32 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(28 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(28 AS Numeric(18, 0)))
INSERT [dbo].[Contenir] ([MenuId], [ProduitId]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(28 AS Numeric(18, 0)))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(N'2018-10-22T11:23:19.350' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(N'2018-10-22T11:25:04.477' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.270' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.277' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.277' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.277' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.280' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.280' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.280' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.280' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.280' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.283' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.283' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(N'2018-10-22T15:03:48.283' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(N'2018-10-22T17:00:00.750' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(0 AS Numeric(18, 0)), CAST(N'2018-10-22T17:00:00.750' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(N'2018-10-22T17:34:29.317' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(0 AS Numeric(18, 0)), CAST(N'2018-10-23T15:20:25.560' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(N'2018-10-23T15:20:25.590' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(N'2018-10-23T15:20:25.590' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(23 AS Numeric(18, 0)), CAST(N'2018-10-23T15:20:25.593' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(0 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.787' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.790' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.790' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.790' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.790' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.793' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.793' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.793' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.793' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.797' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.797' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.797' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.800' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.800' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.800' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(32 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.800' AS DateTime))
INSERT [dbo].[Historique] ([ProduitId], [Timestamp]) VALUES (CAST(33 AS Numeric(18, 0)), CAST(N'2018-10-23T16:15:32.800' AS DateTime))
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [Label], [Prix], [Number]) VALUES (CAST(1 AS Numeric(18, 0)), N'Petit déjeuner', CAST(5.00 AS Numeric(18, 2)), 1)
INSERT [dbo].[Menu] ([Id], [Label], [Prix], [Number]) VALUES (CAST(2 AS Numeric(18, 0)), N'Déjeuner', CAST(12.00 AS Numeric(18, 2)), 2)
INSERT [dbo].[Menu] ([Id], [Label], [Prix], [Number]) VALUES (CAST(3 AS Numeric(18, 0)), N'Goûter', CAST(5.00 AS Numeric(18, 2)), 3)
INSERT [dbo].[Menu] ([Id], [Label], [Prix], [Number]) VALUES (CAST(4 AS Numeric(18, 0)), N'Dîner', CAST(15.00 AS Numeric(18, 2)), 4)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Produit] ON 

INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(3 AS Numeric(18, 0)), N'Bouchée végétarienne de panés de lentilles vertes ', CAST(8.00 AS Numeric(18, 2)), N'Media/Bouche.png', CAST(3.000 AS Numeric(18, 3)), N'pièces', 1)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(4 AS Numeric(18, 0)), N'Tartare de boeuf, citron vert et avocat', CAST(9.00 AS Numeric(18, 2)), N'Media/TartareB.png', CAST(150.000 AS Numeric(18, 3)), N'g', 1)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(5 AS Numeric(18, 0)), N'Jus d''orange', CAST(2.00 AS Numeric(18, 2)), N'Media/Jus.jpg', CAST(30.000 AS Numeric(18, 3)), N'cl', 3)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(6 AS Numeric(18, 0)), N'Chocolat chaud', CAST(2.00 AS Numeric(18, 2)), N'Media/Chocolat.jpg', CAST(25.000 AS Numeric(18, 3)), N'cl', 3)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(7 AS Numeric(18, 0)), N'Gâteau banane chocolat', CAST(5.00 AS Numeric(18, 2)), N'Media/GateauChoc.jpg', CAST(1.000 AS Numeric(18, 3)), N'pièce', 2)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(8 AS Numeric(18, 0)), N'Madeleine framboise', CAST(4.00 AS Numeric(18, 2)), N'Media/MadeleineF.png', CAST(1.000 AS Numeric(18, 3)), N'pièce', 2)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(9 AS Numeric(18, 0)), N'Menu petit déjeuner', CAST(5.00 AS Numeric(18, 2)), N'Media/FormulePetitDej.jpg', CAST(1.000 AS Numeric(18, 3)), N'menu', 4)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(13 AS Numeric(18, 0)), N'Menu déjeuner', CAST(12.00 AS Numeric(18, 2)), N'Media/FormuleDejeuner.jpg', CAST(1.000 AS Numeric(18, 3)), N'menu', 4)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(14 AS Numeric(18, 0)), N'Menu goûter', CAST(5.00 AS Numeric(18, 2)), N'Media/Gouter.jpg', CAST(1.000 AS Numeric(18, 3)), N'menu', 4)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(15 AS Numeric(18, 0)), N'Menu dîner', CAST(15.00 AS Numeric(18, 2)), N'Media/FormuleDiner.png', CAST(1.000 AS Numeric(18, 3)), N'menu', 4)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(17 AS Numeric(18, 0)), N'Biscuit croquant aux mueslis', CAST(4.00 AS Numeric(18, 2)), N'Media/BiscuitCroquant.png', CAST(1.000 AS Numeric(18, 3)), N'pièce', 2)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(20 AS Numeric(18, 0)), N'Fruits Frais', CAST(4.00 AS Numeric(18, 2)), N'Media/FruitsFrais.jpg', CAST(3.000 AS Numeric(18, 3)), N'pièce', 2)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(21 AS Numeric(18, 0)), N'Smoothie aux yaourts et fruits frais', CAST(5.00 AS Numeric(18, 2)), N'Media/Smoothie.png', CAST(40.000 AS Numeric(18, 3)), N'cl', 2)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(22 AS Numeric(18, 0)), N'Yaourt maison', CAST(3.50 AS Numeric(18, 2)), N'Media/YaourtM.png', CAST(1.000 AS Numeric(18, 3)), N'pièce', 2)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(23 AS Numeric(18, 0)), N'Café', CAST(2.00 AS Numeric(18, 2)), N'Media/Cafe.jpg', CAST(20.000 AS Numeric(18, 3)), N'cl', 3)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(28 AS Numeric(18, 0)), N'Jus de pomme', CAST(2.50 AS Numeric(18, 2)), N'Media/Jus.jpg', CAST(30.000 AS Numeric(18, 3)), N'cl', 3)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(29 AS Numeric(18, 0)), N'Thé vert', CAST(2.50 AS Numeric(18, 2)), N'Media/The.jpg', CAST(25.000 AS Numeric(18, 3)), N'cl', 3)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(32 AS Numeric(18, 0)), N'Muesli aux fruits rouges', CAST(4.00 AS Numeric(18, 2)), N'Media/MuesliF.jpg', CAST(100.000 AS Numeric(18, 3)), N'g', 2)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(33 AS Numeric(18, 0)), N'Gratin de pomme de terre au munster', CAST(8.00 AS Numeric(18, 2)), N'Media/Gratin.png', CAST(250.000 AS Numeric(18, 3)), N'g', 1)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(35 AS Numeric(18, 0)), N'Poulet sauté à la paysanne', CAST(9.00 AS Numeric(18, 2)), N'Media/Poulet.png', CAST(250.000 AS Numeric(18, 3)), N'g', 1)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(37 AS Numeric(18, 0)), N'Risotto aux asperges et parmesan', CAST(10.00 AS Numeric(18, 2)), N'Media/Risotto.png', CAST(300.000 AS Numeric(18, 3)), N'g', 1)
INSERT [dbo].[Produit] ([Id], [Designation], [Prix], [Image], [Quantite], [Unite], [TypeMenu]) VALUES (CAST(38 AS Numeric(18, 0)), N'Tartare de saumon et thon à la coriandre et aux agrumes', CAST(10.00 AS Numeric(18, 2)), N'Media/TartareS.png', CAST(300.000 AS Numeric(18, 3)), N'g', 1)
SET IDENTITY_INSERT [dbo].[Produit] OFF
SET IDENTITY_INSERT [dbo].[Utilisateur] ON 

INSERT [dbo].[Utilisateur] ([Id], [Email], [Password], [Nom], [Prenom], [DateNaissance], [Adresse], [Societe], [Genre]) VALUES (CAST(2 AS Numeric(18, 0)), N'christiantagne@yahoo.fr', N'07A38D59D99EF1A71A891305C00B0E2B701C8BDF9AA0EE3000B904953E253FB3', N'Tagne', N'Christian', CAST(N'1987-11-06T00:00:00.000' AS DateTime), N'10 rue Bretonnerie', N'', 0)
INSERT [dbo].[Utilisateur] ([Id], [Email], [Password], [Nom], [Prenom], [DateNaissance], [Adresse], [Societe], [Genre]) VALUES (CAST(4 AS Numeric(18, 0)), N'granger.magali@yahoo.fr', N'07A38D59D99EF1A71A891305C00B0E2B701C8BDF9AA0EE3000B904953E253FB3', N'Granger', N'Magali', CAST(N'1988-01-01T00:00:00.000' AS DateTime), N'12 gidhj 45000', N'', 1)
INSERT [dbo].[Utilisateur] ([Id], [Email], [Password], [Nom], [Prenom], [DateNaissance], [Adresse], [Societe], [Genre]) VALUES (CAST(5 AS Numeric(18, 0)), N'jean.hoskovec@gmail.com', N'0812595C460741EEE24D8A49F06900237B33DC257F5CCB2110F0698D0DB9F982', N'Hoskovec', N'Jan', CAST(N'1989-07-14T00:00:00.000' AS DateTime), N'16 avenue de Bel Air, 69100 Villeurbanne', N'', 0)
INSERT [dbo].[Utilisateur] ([Id], [Email], [Password], [Nom], [Prenom], [DateNaissance], [Adresse], [Societe], [Genre]) VALUES (CAST(6 AS Numeric(18, 0)), N'laissa@groupeastek.fr', N'FC90A69F33F798F936F48D5AE70D470B85AB750A33379316A690DFD5A5141268', N'AISSA', N'Lamia', CAST(N'1988-10-23T15:17:54.000' AS DateTime), N'12 rue Pr Jean Bernard', N'ASTEK', 1)
INSERT [dbo].[Utilisateur] ([Id], [Email], [Password], [Nom], [Prenom], [DateNaissance], [Adresse], [Societe], [Genre]) VALUES (CAST(7 AS Numeric(18, 0)), N'rochard.olivier@gmail.com', N'31F7A65E315586AC198BD798B6629CE4903D0899476D5741A9F32E2E521B6A66', N'Rochard', N'Olivier', CAST(N'1982-04-30T00:00:00.000' AS DateTime), N'70 Rue maryse bastie 69008 lyon', N'', 0)
SET IDENTITY_INSERT [dbo].[Utilisateur] OFF
ALTER TABLE [dbo].[Historique] ADD  CONSTRAINT [DF_Historique_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Catalogue]  WITH CHECK ADD  CONSTRAINT [FK_Catalogue_Catalogue] FOREIGN KEY([ProduitId])
REFERENCES [dbo].[Produit] ([Id])
GO
ALTER TABLE [dbo].[Catalogue] CHECK CONSTRAINT [FK_Catalogue_Catalogue]
GO
ALTER TABLE [dbo].[Commande]  WITH CHECK ADD  CONSTRAINT [FK_Commande_Produit] FOREIGN KEY([ProduitId])
REFERENCES [dbo].[Produit] ([Id])
GO
ALTER TABLE [dbo].[Commande] CHECK CONSTRAINT [FK_Commande_Produit]
GO
ALTER TABLE [dbo].[Commande]  WITH CHECK ADD  CONSTRAINT [FK_Commande_Utilisateur] FOREIGN KEY([UtilisateurId])
REFERENCES [dbo].[Utilisateur] ([Id])
GO
ALTER TABLE [dbo].[Commande] CHECK CONSTRAINT [FK_Commande_Utilisateur]
GO
ALTER TABLE [dbo].[Contenir]  WITH CHECK ADD  CONSTRAINT [FK_Contenir_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[Contenir] CHECK CONSTRAINT [FK_Contenir_Menu]
GO
ALTER TABLE [dbo].[Contenir]  WITH CHECK ADD  CONSTRAINT [FK_Contenir_Produit] FOREIGN KEY([ProduitId])
REFERENCES [dbo].[Produit] ([Id])
GO
ALTER TABLE [dbo].[Contenir] CHECK CONSTRAINT [FK_Contenir_Produit]
GO
ALTER TABLE [dbo].[ProduitAllergene]  WITH CHECK ADD  CONSTRAINT [FK_ProduitAllergene_Allergene] FOREIGN KEY([AllergeneId])
REFERENCES [dbo].[Allergene] ([Id])
GO
ALTER TABLE [dbo].[ProduitAllergene] CHECK CONSTRAINT [FK_ProduitAllergene_Allergene]
GO
ALTER TABLE [dbo].[ProduitAllergene]  WITH CHECK ADD  CONSTRAINT [FK_ProduitAllergene_ProduitAllergene] FOREIGN KEY([ProduitId])
REFERENCES [dbo].[Produit] ([Id])
GO
ALTER TABLE [dbo].[ProduitAllergene] CHECK CONSTRAINT [FK_ProduitAllergene_ProduitAllergene]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0: homme, 1: femme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Utilisateur', @level2type=N'COLUMN',@level2name=N'Genre'
GO
