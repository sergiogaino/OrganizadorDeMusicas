USE [Musicas]
GO
/****** Object:  Table [dbo].[tbMidia]    Script Date: 19/11/2016 19:30:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbMidia]') AND type in (N'U'))
DROP TABLE [dbo].[tbMidia]
GO
/****** Object:  Table [dbo].[tbGenero]    Script Date: 19/11/2016 19:30:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbGenero]') AND type in (N'U'))
DROP TABLE [dbo].[tbGenero]
GO
/****** Object:  Table [dbo].[tbArtista]    Script Date: 19/11/2016 19:30:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbArtista]') AND type in (N'U'))
DROP TABLE [dbo].[tbArtista]
GO
/****** Object:  Table [dbo].[tbAlbum]    Script Date: 19/11/2016 19:30:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbAlbum]') AND type in (N'U'))
DROP TABLE [dbo].[tbAlbum]
GO
/****** Object:  Table [dbo].[tbAlbum]    Script Date: 19/11/2016 19:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbAlbum]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbAlbum](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](150) NULL,
	[capa] [image] NULL,
 CONSTRAINT [PK_tbAlbum] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbArtista]    Script Date: 19/11/2016 19:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbArtista]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbArtista](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](150) NULL,
 CONSTRAINT [PK_tbArtista] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbGenero]    Script Date: 19/11/2016 19:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbGenero]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbGenero](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nomeGenero] [varchar](50) NULL,
 CONSTRAINT [PK_tbGenero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbMidia]    Script Date: 19/11/2016 19:30:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbMidia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbMidia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](150) NULL,
	[ano] [int] NULL,
	[numero] [int] NULL,
	[idGenero] [int] NULL,
	[idAlbum] [int] NULL,
	[idArtista] [int] NULL,
 CONSTRAINT [PK_tbMidia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
