CREATE Database [ContactManagement]
GO

USE [ContactManagement]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON

GO

CREATE TABLE [dbo].[Contact]
(
	[Id] int Identity(1,1) NOT NULL,
	[FirstName] Varchar(20) NOT NULL,
	[LastName] Varchar(20) NOT NULL,
	[Email] Varchar(20),
	[PhoneNumber] int,
	[Status] Bit NOT NULL,
 	CONSTRAINT [PK_CONTACT] PRIMARY KEY CLUSTERED
	(
	      [id] ASC

	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

) ON [PRIMARY]
GO

SET ANSI_PADDING OFF

GO



INSERT [dbo].[Contact] ([Firstname],[Lastname],[Email], [PhoneNumber], [status])
			 VALUES ('Ab', 'Cd', 'ab@gmail.com', 1234,1)

INSERT [dbo].[Contact] ([Firstname],[Lastname],[Email], [PhoneNumber], [status])
			 VALUES ('Mn', 'Ef', 'mn@gmail.com', 5568,1)

