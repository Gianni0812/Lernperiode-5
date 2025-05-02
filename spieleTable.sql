USE [BlackJack]
GO

/****** Object:  Table [dbo].[spiele]    Script Date: 02.05.2025 11:27:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[spiele](
	[spiel_id] [int] IDENTITY(1,1) NOT NULL,
	[benutzer_id] [int] NOT NULL,
	[einsatz_jetons] [decimal](10, 2) NOT NULL,
	[spieler_karten] [nvarchar](100) NOT NULL,
	[dealer_karten] [nvarchar](100) NOT NULL,
	[ergebnis] [varchar](20) NOT NULL,
	[auszahlung] [decimal](10, 2) NOT NULL,
	[zeitpunkt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[spiel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[spiele] ADD  DEFAULT (getdate()) FOR [zeitpunkt]
GO

ALTER TABLE [dbo].[spiele]  WITH CHECK ADD FOREIGN KEY([benutzer_id])
REFERENCES [dbo].[benutzer] ([benutzer_id])
GO

ALTER TABLE [dbo].[spiele]  WITH CHECK ADD CHECK  (([ergebnis]='unentschieden' OR [ergebnis]='verloren' OR [ergebnis]='gewonnen'))
GO

