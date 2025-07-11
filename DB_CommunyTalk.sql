USE [DB_CommunyTalk]
GO
/****** Object:  Table [dbo].[AmigosXUsuario]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AmigosXUsuario](
	[IdUsuario] [int] NOT NULL,
	[IdAmigo] [int] NOT NULL,
 CONSTRAINT [PK_AmigosXUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdAmigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comunidades]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comunidades](
	[IdComunidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Empresa] [varchar](100) NULL,
	[FotoDeComunidad] [varchar](max) NULL,
	[Descripcion] [varchar](100) NULL,
	[Subdivision] [varchar](100) NULL,
 CONSTRAINT [PK_Comunidades] PRIMARY KEY CLUSTERED 
(
	[IdComunidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupos]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupos](
	[IdGrupo] [int] IDENTITY(1,1) NOT NULL,
	[IdAdmin] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[FotodePerfil] [varchar](max) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Privado] [bit] NOT NULL,
 CONSTRAINT [PK_Grupos] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IntegrantesXComunidad]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IntegrantesXComunidad](
	[IdComunidad] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[TopActividad] [int] NOT NULL,
 CONSTRAINT [PK_IntegrantesXComunidad] PRIMARY KEY CLUSTERED 
(
	[IdComunidad] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IntegrantesXGrupo]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IntegrantesXGrupo](
	[IdGrupo] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[TopActividad] [int] NOT NULL,
 CONSTRAINT [PK_IntegrantesXGrupo] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Intereses]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intereses](
	[IdInteres] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Intereses] PRIMARY KEY CLUSTERED 
(
	[IdInteres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InteresesXGrupo]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InteresesXGrupo](
	[IdGrupo] [int] NOT NULL,
	[IdInteres] [int] NOT NULL,
 CONSTRAINT [PK_InteresesXGrupo] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC,
	[IdInteres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InteresesXUsuario]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InteresesXUsuario](
	[IdUsuario] [int] NOT NULL,
	[IdInteres] [int] NOT NULL,
 CONSTRAINT [PK_InteresesXUsuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdInteres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mensajes]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensajes](
	[IdMensaje] [int] IDENTITY(1,1) NOT NULL,
	[Contenido] [varchar](1000) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[IdUsuario] [int] NULL,
	[IdGrupo] [int] NULL,
	[IdComunidad] [int] NULL,
	[IdUsuarioEmisor] [int] NOT NULL,
 CONSTRAINT [PK_Mensajes] PRIMARY KEY CLUSTERED 
(
	[IdMensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](700) NULL,
	[Nombre] [varchar](700) NULL,
	[Contraseña] [varchar](max) NOT NULL,
	[Pronombres] [varchar](20) NULL,
	[Nametag] [varchar](20) NOT NULL,
	[Foto] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [varchar](50) NULL,
	[Notificaciones] [int] NULL,
	[Email] [varchar](100) NOT NULL,
	[UltimaActividad] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comunidades] ON 

INSERT [dbo].[Comunidades] ([IdComunidad], [Nombre], [Empresa], [FotoDeComunidad], [Descripcion], [Subdivision]) VALUES (1, N'ort', N'educacion', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSF3rYWpOUu_ElAyuIgysugEvjtWFM2OBItyA&s', N'nose', N'se')
INSERT [dbo].[Comunidades] ([IdComunidad], [Nombre], [Empresa], [FotoDeComunidad], [Descripcion], [Subdivision]) VALUES (2, N'Banfield', N'S.A.', N'https://th.bing.com/th?id=OSB.8eQimEHobvQL_pbmz1vQsA--.png&w=50&h=50&c=6&qlt=90&o=6&dpr=2&pid=BingSports', N'mewing', N'nose')
INSERT [dbo].[Comunidades] ([IdComunidad], [Nombre], [Empresa], [FotoDeComunidad], [Descripcion], [Subdivision]) VALUES (3, N'Mercado Libre', N'Mercadoworks', N'https://www.google.com/url?sa=i&url=https%3A%2F%2Feleconomista.com.ar%2Fnegocios%2Fmercado-libre-cambio-logo-anuncio-descuentos-farmacias-monotributistas-compras-online-n32698&psig=AOvVaw01pcLxN8X5-https://statics.eleconomista.com.ar/2020/03/614e2f5f8c618.png', N'Compra y venta de productos', N'la mejor plataforma de latam')
SET IDENTITY_INSERT [dbo].[Comunidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Grupos] ON 

INSERT [dbo].[Grupos] ([IdGrupo], [IdAdmin], [Descripcion], [FotodePerfil], [Nombre], [Privado]) VALUES (1, 1, N'Tu grupo de musica favorito', N'MettalicaFoto.jfif', N'Metallica', 0)
INSERT [dbo].[Grupos] ([IdGrupo], [IdAdmin], [Descripcion], [FotodePerfil], [Nombre], [Privado]) VALUES (2, 1, N'Nos encantan los juegos de terror :)', N'TerrorFoto.jpg', N'Viva el Terror', 1)
INSERT [dbo].[Grupos] ([IdGrupo], [IdAdmin], [Descripcion], [FotodePerfil], [Nombre], [Privado]) VALUES (3, 1, N'PERCY JACKSOOOON', N'PercyFoto.jpg', N'Camp Half-Blood', 1)
INSERT [dbo].[Grupos] ([IdGrupo], [IdAdmin], [Descripcion], [FotodePerfil], [Nombre], [Privado]) VALUES (7, 1, N'aaa', N'https://cdn.britannica.com/49/182849-050-4C7FE34F/scene-Iron-Man.jpg', N'Iron man', 0)
SET IDENTITY_INSERT [dbo].[Grupos] OFF
GO
INSERT [dbo].[IntegrantesXComunidad] ([IdComunidad], [IdUsuario], [TopActividad]) VALUES (1, 1, 2)
INSERT [dbo].[IntegrantesXComunidad] ([IdComunidad], [IdUsuario], [TopActividad]) VALUES (2, 1, 1)
INSERT [dbo].[IntegrantesXComunidad] ([IdComunidad], [IdUsuario], [TopActividad]) VALUES (3, 1, 3)
GO
INSERT [dbo].[IntegrantesXGrupo] ([IdGrupo], [IdUsuario], [TopActividad]) VALUES (1, 1, 1)
INSERT [dbo].[IntegrantesXGrupo] ([IdGrupo], [IdUsuario], [TopActividad]) VALUES (2, 1, 2)
INSERT [dbo].[IntegrantesXGrupo] ([IdGrupo], [IdUsuario], [TopActividad]) VALUES (3, 1, 3)
INSERT [dbo].[IntegrantesXGrupo] ([IdGrupo], [IdUsuario], [TopActividad]) VALUES (7, 1, 4)
GO
SET IDENTITY_INSERT [dbo].[Intereses] ON 

INSERT [dbo].[Intereses] ([IdInteres], [Nombre]) VALUES (1, N'Voleyball')
INSERT [dbo].[Intereses] ([IdInteres], [Nombre]) VALUES (2, N'Percy Jackson')
SET IDENTITY_INSERT [dbo].[Intereses] OFF
GO
INSERT [dbo].[InteresesXGrupo] ([IdGrupo], [IdInteres]) VALUES (3, 2)
GO
SET IDENTITY_INSERT [dbo].[Mensajes] ON 

INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (1, N'Hola', CAST(N'2024-11-07T00:00:00.000' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (3, N'¿Cómo estás?', CAST(N'2024-11-07T00:01:00.000' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (4, N'probando', CAST(N'2024-11-28T14:58:39.920' AS DateTime), NULL, 1, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (5, N'probando', CAST(N'2024-11-28T14:58:42.933' AS DateTime), NULL, 1, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (6, N'probando', CAST(N'2024-11-28T14:58:45.037' AS DateTime), NULL, 1, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (11, N'a', CAST(N'2024-12-02T10:21:27.213' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (12, N'A', CAST(N'2024-12-02T10:21:31.307' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (13, N'b', CAST(N'2024-12-02T10:21:32.667' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (14, N'a', CAST(N'2024-12-02T10:21:34.690' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (15, N'/', CAST(N'2024-12-02T10:21:38.723' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (16, N'( ?° ?? ?°)', CAST(N'2024-12-02T10:22:11.010' AS DateTime), 1, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (17, N'( ?° ?? ?°)', CAST(N'2024-12-02T10:22:17.140' AS DateTime), 2, NULL, NULL, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (30, N'a', CAST(N'2024-12-02T10:44:30.350' AS DateTime), NULL, NULL, 1, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (31, N'a', CAST(N'2024-12-02T10:44:43.697' AS DateTime), NULL, NULL, 1, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (34, N'a', CAST(N'2024-12-02T10:45:54.273' AS DateTime), NULL, NULL, 1, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (37, N'a', CAST(N'2024-12-02T10:46:54.650' AS DateTime), NULL, NULL, 1, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (38, N'a', CAST(N'2024-12-02T10:46:56.027' AS DateTime), NULL, NULL, 1, 1)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (39, N'Probando', CAST(N'2024-12-03T13:46:33.950' AS DateTime), NULL, 1, NULL, 2)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (40, N'Omggggg', CAST(N'2024-12-04T07:55:31.230' AS DateTime), NULL, 1, NULL, 4)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (41, N'a', CAST(N'2024-12-04T09:38:25.923' AS DateTime), 2, NULL, NULL, 4)
INSERT [dbo].[Mensajes] ([IdMensaje], [Contenido], [FechaHora], [IdUsuario], [IdGrupo], [IdComunidad], [IdUsuarioEmisor]) VALUES (42, N'a', CAST(N'2024-12-04T09:45:22.297' AS DateTime), 4, NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[Mensajes] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Apellido], [Nombre], [Contraseña], [Pronombres], [Nametag], [Foto], [Descripcion], [Estado], [Notificaciones], [Email], [UltimaActividad]) VALUES (1, N'Martinez', N'Luna', N'SoyLuna1', NULL, N'Luma', NULL, NULL, NULL, NULL, N'SoyLuna@gmail.com', CAST(N'2024-12-04T09:38:25.923' AS DateTime))
INSERT [dbo].[Usuarios] ([IdUsuario], [Apellido], [Nombre], [Contraseña], [Pronombres], [Nametag], [Foto], [Descripcion], [Estado], [Notificaciones], [Email], [UltimaActividad]) VALUES (2, N'Aguilera', N'Santino', N'sasa', N'He/Him', N'Bon Alfredo', NULL, N'Restaurando Roma desde 476', NULL, NULL, N'sasa@gmail.com', CAST(N'2024-12-04T09:38:25.923' AS DateTime))
INSERT [dbo].[Usuarios] ([IdUsuario], [Apellido], [Nombre], [Contraseña], [Pronombres], [Nametag], [Foto], [Descripcion], [Estado], [Notificaciones], [Email], [UltimaActividad]) VALUES (4, N'Portnoi', N'Thiago Agustin', N'Thiago2007', N'el', N'a', NULL, NULL, NULL, NULL, N'thiago@gmail.com', CAST(N'2024-12-04T09:45:22.297' AS DateTime))
INSERT [dbo].[Usuarios] ([IdUsuario], [Apellido], [Nombre], [Contraseña], [Pronombres], [Nametag], [Foto], [Descripcion], [Estado], [Notificaciones], [Email], [UltimaActividad]) VALUES (5, N'Di Carlo', N'Marco ', N'marcos', NULL, N'Markitosss', NULL, N'me gusta la joda', NULL, NULL, N'marco@gmail.com', CAST(N'2024-12-04T09:38:25.923' AS DateTime))
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [idAmigo]    Script Date: 5/5/2025 10:06:14 ******/
CREATE NONCLUSTERED INDEX [idAmigo] ON [dbo].[AmigosXUsuario]
(
	[IdAmigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NombreComunidad]    Script Date: 5/5/2025 10:06:14 ******/
CREATE NONCLUSTERED INDEX [NombreComunidad] ON [dbo].[Comunidades]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_nombre]    Script Date: 5/5/2025 10:06:14 ******/
CREATE NONCLUSTERED INDEX [idx_nombre] ON [dbo].[Grupos]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AmigosXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_AmigosXUsuario_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[AmigosXUsuario] CHECK CONSTRAINT [FK_AmigosXUsuario_Usuarios]
GO
ALTER TABLE [dbo].[AmigosXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_AmigosXUsuario_Usuarios1] FOREIGN KEY([IdAmigo])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[AmigosXUsuario] CHECK CONSTRAINT [FK_AmigosXUsuario_Usuarios1]
GO
ALTER TABLE [dbo].[IntegrantesXComunidad]  WITH CHECK ADD  CONSTRAINT [FK_IntegrantesXComunidad_Comunidades] FOREIGN KEY([IdComunidad])
REFERENCES [dbo].[Comunidades] ([IdComunidad])
GO
ALTER TABLE [dbo].[IntegrantesXComunidad] CHECK CONSTRAINT [FK_IntegrantesXComunidad_Comunidades]
GO
ALTER TABLE [dbo].[IntegrantesXComunidad]  WITH CHECK ADD  CONSTRAINT [FK_IntegrantesXComunidad_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[IntegrantesXComunidad] CHECK CONSTRAINT [FK_IntegrantesXComunidad_Usuarios]
GO
ALTER TABLE [dbo].[IntegrantesXGrupo]  WITH CHECK ADD  CONSTRAINT [FK_IntegrantesXGrupo_Grupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[IntegrantesXGrupo] CHECK CONSTRAINT [FK_IntegrantesXGrupo_Grupos]
GO
ALTER TABLE [dbo].[IntegrantesXGrupo]  WITH CHECK ADD  CONSTRAINT [FK_IntegrantesXGrupo_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[IntegrantesXGrupo] CHECK CONSTRAINT [FK_IntegrantesXGrupo_Usuarios]
GO
ALTER TABLE [dbo].[InteresesXGrupo]  WITH CHECK ADD  CONSTRAINT [FK_InteresesXGrupo_Grupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[InteresesXGrupo] CHECK CONSTRAINT [FK_InteresesXGrupo_Grupos]
GO
ALTER TABLE [dbo].[InteresesXGrupo]  WITH CHECK ADD  CONSTRAINT [FK_InteresesXGrupo_Intereses] FOREIGN KEY([IdInteres])
REFERENCES [dbo].[Intereses] ([IdInteres])
GO
ALTER TABLE [dbo].[InteresesXGrupo] CHECK CONSTRAINT [FK_InteresesXGrupo_Intereses]
GO
ALTER TABLE [dbo].[InteresesXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_InteresesXUsuario_Intereses] FOREIGN KEY([IdInteres])
REFERENCES [dbo].[Intereses] ([IdInteres])
GO
ALTER TABLE [dbo].[InteresesXUsuario] CHECK CONSTRAINT [FK_InteresesXUsuario_Intereses]
GO
ALTER TABLE [dbo].[InteresesXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_InteresesXUsuario_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[InteresesXUsuario] CHECK CONSTRAINT [FK_InteresesXUsuario_Usuarios]
GO
ALTER TABLE [dbo].[Mensajes]  WITH CHECK ADD  CONSTRAINT [FK_Mensajes_Comunidades] FOREIGN KEY([IdComunidad])
REFERENCES [dbo].[Comunidades] ([IdComunidad])
GO
ALTER TABLE [dbo].[Mensajes] CHECK CONSTRAINT [FK_Mensajes_Comunidades]
GO
ALTER TABLE [dbo].[Mensajes]  WITH CHECK ADD  CONSTRAINT [FK_Mensajes_Grupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[Mensajes] CHECK CONSTRAINT [FK_Mensajes_Grupos]
GO
ALTER TABLE [dbo].[Mensajes]  WITH CHECK ADD  CONSTRAINT [FK_Mensajes_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Mensajes] CHECK CONSTRAINT [FK_Mensajes_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[añadirInfoUsuario]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[añadirInfoUsuario]
@nametag varchar(20), @foto varchar(100), @descripcion varchar(100)
as
begin
insert into Usuarios (Nametag, Foto, Descripcion) values (@nametag, @foto, @descripcion)
end
GO
/****** Object:  StoredProcedure [dbo].[buscarPorIntereses]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[buscarPorIntereses]
	@interes varchar(255)
AS
BEGIN
	SELECT g.IdGrupo, g.IdAdmin, g.FotodePerfil, g.Descripcion, g.Nombre, g.Privado
	FROM Grupos g 
	INNER JOIN InteresesXGrupo x ON x.IdGrupo = g.IdGrupo 
	INNER JOIN Intereses i ON x.IdInteres = i.idInteres 
	WHERE i.Nombre  LIKE '%' + @interes + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarMensaje]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[eliminarMensaje]
@MensajeID int
as
begin
delete Mensajes where IdMensaje=@MensajeID
end
GO
/****** Object:  StoredProcedure [dbo].[enviarMensaje]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[enviarMensaje]
@contenido varchar(1000), @fechaYHora datetime
as
begin 
insert into Mensajes(Contenido, FechaHora) values (@contenido, @fechaYHora)
end
GO
/****** Object:  StoredProcedure [dbo].[InicioDeSesion]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InicioDeSesion]
@email varchar(100),
@contraseña varchar(MAX)
AS 
BEGIN
SELECT Email FROM Usuarios WHERE Email = @email;
SELECT Contraseña FROM Usuarios WHERE Contraseña = @contraseña;
END
GO
/****** Object:  StoredProcedure [dbo].[registrarse]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*2: Registrarse*/
CREATE procedure [dbo].[registrarse]
@mail varchar(100), @nombre varchar(100), @contraseña varchar(100)
as
begin
begin transaction
begin try
IF EXISTS (SELECT 1 FROM Usuarios WHERE email = @mail)
BEGIN
THROW 50001, 'El correo ya está registrado.', 1;
END
INSERT INTO Usuarios (email, Nombre, Contraseña) 
VALUES (@mail, @nombre, @contraseña);
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;
THROW;
END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_crear_comunidad]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Crear Comunidad
CREATE PROCEDURE [dbo].[sp_crear_comunidad]
	@Nombre VARCHAR(100),
	@Empresa VARCHAR(100),
	@Descripcion VARCHAR(100),
	@Subdivision VARCHAR(100)
AS
BEGIN
	INSERT INTO Comunidades(Nombre, Empresa, Descripcion, Subdivision)
	VALUES (@Nombre, @Empresa, @Descripcion, @Subdivision);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_crear_grupo]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_crear_grupo]
@NombreUsuario VARCHAR(100),
@Descripcion VARCHAR(100),
@FotoDePerfil VARCHAR(100),
@NombreGrupo VARCHAR(100),
@PrivadoOPublico BIT
AS
BEGIN
DECLARE @IdUsuario INT

SELECT IdUsuario = @IdUsuario FROM Usuarios WHERE @NombreUsuario = Nombre;

INSERT INTO Grupos(IdAdmin, Descripcion, FotodePerfil, Nombre, Privado)
VALUES (@IdUsuario, @Descripcion, @FotodePerfil, @NombreGrupo, @PrivadoOPublico);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_amigo]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*Eliminar amigo*/
CREATE PROCEDURE [dbo].[sp_eliminar_amigo]
	@IdUsuario INT,
	@IdAmigo INT
AS
BEGIN
	DELETE FROM
		AmigosXUsuario
	WHERE
		IdUsuario = @IdUsuario AND IdAmigo = @IdAmigo;
END
GO
/****** Object:  StoredProcedure [dbo].[UnirseAUnGrupo]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UnirseAUnGrupo]
@idUsuario int, @IdGrupo int
as
begin
insert into IntegrantesXGrupo (IdGrupo, IdUsuario) values (@idUsuario, @IdGrupo)
end
GO
/****** Object:  StoredProcedure [dbo].[UnirseComunidad]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Unirse a una comunidad */
CREATE PROCEDURE [dbo].[UnirseComunidad]
	@IdU int,
	@IdC int
AS
BEGIN
	INSERT INTO IntegrantesXComunidad (IdUsuario, IdComunidad)
	VALUES (@IdU, @IdC)
END
GO
/****** Object:  Trigger [dbo].[actualizarActividad]    Script Date: 5/5/2025 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[actualizarActividad]
on [dbo].[Mensajes] after insert
as 
begin
update Usuarios set UltimaActividad = (select top 1 M.FechaHora from Mensajes M inner join Usuarios U on M.IdUsuarioEmisor = U.IdUsuario order by M.IdMensaje desc) where IdUsuario = (select top 1 M.IdUsuarioEmisor from Mensajes M inner join Usuarios U on M.IdUsuarioEmisor = U.IdUsuario order by M.IdMensaje desc)
end
GO
ALTER TABLE [dbo].[Mensajes] ENABLE TRIGGER [actualizarActividad]
GO
