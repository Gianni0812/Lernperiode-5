USE [BlackJack]
GO

/****** Object:  Table [dbo].[benutzer]    Script Date: 02.05.2025 11:26:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[benutzer](
	[benutzer_id] [int] IDENTITY(1,1) NOT NULL,
	[benutzername] [nvarchar](100) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[guthaben_geld] [decimal](10, 2) NULL,
	[guthaben_jetons] [decimal](10, 2) NULL,
	[registriert_am] [datetime] NULL,
	[passwort] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[benutzer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[benutzername] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[benutzer] ADD  DEFAULT ((0.00)) FOR [guthaben_geld]
GO

ALTER TABLE [dbo].[benutzer] ADD  DEFAULT ((0.00)) FOR [guthaben_jetons]
GO

ALTER TABLE [dbo].[benutzer] ADD  DEFAULT (getdate()) FOR [registriert_am]
GO

