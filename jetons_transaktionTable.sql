USE [BlackJack]
GO

/****** Object:  Table [dbo].[jeton_transaktionen]    Script Date: 02.05.2025 11:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jeton_transaktionen](
	[transaktion_id] [int] IDENTITY(1,1) NOT NULL,
	[benutzer_id] [int] NOT NULL,
	[typ] [varchar](10) NOT NULL,
	[anzahl_jetons] [decimal](10, 2) NOT NULL,
	[betrag_geld] [decimal](10, 2) NOT NULL,
	[zeitpunkt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[transaktion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[jeton_transaktionen] ADD  DEFAULT (getdate()) FOR [zeitpunkt]
GO

ALTER TABLE [dbo].[jeton_transaktionen]  WITH CHECK ADD FOREIGN KEY([benutzer_id])
REFERENCES [dbo].[benutzer] ([benutzer_id])
GO

ALTER TABLE [dbo].[jeton_transaktionen]  WITH CHECK ADD CHECK  (([typ]='verkauf' OR [typ]='kauf'))
GO

