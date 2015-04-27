USE [login]
GO

CREATE TABLE [dbo].[usuarios](
	[usuario] [varchar](10) NOT NULL,
	[pass] [varchar](10) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


INSERT INTO [dbo].[usuarios]
           ([usuario]
           ,[pass])
     VALUES
           ('admin','admin11')
           
GO

INSERT INTO [dbo].[usuarios]
           ([usuario]
           ,[pass])
     VALUES
           ('usuario','usuario11')
           
GO

