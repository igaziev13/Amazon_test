USE [amazon_ig]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 15.02.2023 5:57:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Article] [varchar](50) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Price] [numeric](15, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Price]  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO

