USE [serniaDB]
GO
/****** Object:  StoredProcedure [dbo].[devHistoryList]    Script Date: 2015/03/31 16:52:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[devHistoryList]


@PAGE int,
@PAGESIZE int,
@TOTALPAGE int = 0 OUTPUT


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @TOTAL INT


SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
WITH tbl_pagelist AS

(
SELECT ROW_NUMBER() OVER (ORDER BY idx DESC) AS RowNum, *

FROM devHistory
)

SELECT * FROM tbl_pagelist

WHERE RowNum BETWEEN (@PAGE - 1) * @PAGESIZE + 1 AND @PAGE * @PAGESIZE;

SELECT @TOTAL = count(idx)
FROM devHistory

SET @TOTALPAGE = @TOTAL

--EXEC(@SQL)
--print @SQL

END

GO
/****** Object:  Table [dbo].[devHistory]    Script Date: 2015/03/31 16:52:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[devHistory](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](25) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[details] [text] NOT NULL,
	[category] [nvarchar](10) NOT NULL,
	[createdate] [datetime] NOT NULL CONSTRAINT [DF_devHistory_createdate]  DEFAULT (getdate()),
	[deleteFlg] [bit] NOT NULL CONSTRAINT [DF_devHistory_deleteFlg]  DEFAULT ((0)),
 CONSTRAINT [PK_devHistory] PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[japaneseHistory]    Script Date: 2015/03/31 16:52:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[japaneseHistory](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[text] [text] NOT NULL,
 CONSTRAINT [PK_japaneseHistory] PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[japaneseMemo]    Script Date: 2015/03/31 16:52:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[japaneseMemo](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[kanzi] [nvarchar](10) NOT NULL,
	[katakana] [nvarchar](25) NOT NULL,
	[hangul] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_japaneseMemo] PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[serniaHistory]    Script Date: 2016/01/05 10:22:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[serniaHistory](
	[idx] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[details] [text] NOT NULL,
	[createdate] [datetime] NOT NULL CONSTRAINT [DF_serniaHistory_createdate]  DEFAULT (getdate()),
 CONSTRAINT [PK_serniaHistory] PRIMARY KEY CLUSTERED 
(
	[idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


