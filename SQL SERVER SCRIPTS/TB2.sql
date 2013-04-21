USE [SAPPXML]
GO

/****** Object:  Table [dbo].[tSScript3]    Script Date: 04/21/2013 09:55:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tSScript3](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tTSTwo] [nchar](10) NULL,
	[tFile] [nchar](23) NULL,
	[tLine] [nchar](500) NULL,
	[tRoutine] [nvarchar](500) NULL,
	[tHost] [nvarchar](500) NULL,
	[tProcess] [nvarchar](500) NULL,
	[tThread] [nvarchar](500) NULL,
	[tContext] [nvarchar](500) NULL,
	[tSourceObject] [nvarchar](500) NULL,
	[tStackId] [nchar](500) NULL,
	[tStackLevel] [nchar](500) NULL,
	[CData] [nvarchar](4000) NULL,
	[Script] [text] NULL,
	[Creation] [datetime] NULL,
	[Problem] [nchar](500) NULL,
	[AnnoMes] [int] NULL,
	[Dia] [int] NULL,
	[Hora] [int] NULL,
	[Min] [int] NULL,
	[Mils] [int] NULL,
	[User1] [float] NULL,
	[User2] [int] NULL,
	[User3] [nchar](100) NULL,
	[User4] [nchar](100) NULL,
	[CreateRow] [datetime] NULL,
	[Tag] [nchar](10) NULL,
 CONSTRAINT [PK_tSScript3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tSScript3] SET (LOCK_ESCALATION = AUTO)
GO

ALTER TABLE [dbo].[tSScript3] ADD  CONSTRAINT [DF_tSScript3_CreateRow]  DEFAULT (getdate()) FOR [CreateRow]
GO

