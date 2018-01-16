USE [master]
GO

IF db_id('MyRestfullApp') is not null
BEGIN
ALTER DATABASE [MyRestfullApp]
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [MyRestfullApp]
END

CREATE DATABASE [MyRestfullApp]
GO

USE [MyRestfullApp]

CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](20) NOT NULL,
	[apellido] [nvarchar](20) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
([id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_email] UNIQUE NONCLUSTERED 
([email] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO [dbo].[User] ([nombre], [apellido], [email], [password]) VALUES ('Joel', 'Perez', 'joperezr@gmail.com', 'Pass123');
INSERT INTO [dbo].[User] ([nombre], [apellido], [email], [password]) VALUES ('Juan', 'Sanchez', 'juansanchez@gmail.com', '123456');
INSERT INTO [dbo].[User] ([nombre], [apellido], [email], [password]) VALUES ('Lionel', 'Messi', 'info@messi.com', '654321');

SELECT * FROM [User]

