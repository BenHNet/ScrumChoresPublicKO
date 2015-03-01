/****** Object:  Login [ScrumUser]  ******/
CREATE LOGIN [ScrumUser] WITH PASSWORD=N'password', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [SchrumChores]
GO

/****** Object:  User [ScrumUser]   ******/
GO

CREATE USER [ScrumUser] FOR LOGIN [ScrumUser] WITH DEFAULT_SCHEMA=[dbo]
GO