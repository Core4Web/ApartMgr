USE ApartMgrDB
GO
DELETE FROM [dbo].[Periods]
GO
SET IDENTITY_INSERT [dbo].[Periods] ON
GO
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(1, N'Январь')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(2, N'Февраль')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(3, N'Март')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(4, N'Апрель')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(5, N'Май')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(6, N'Июнь')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(7, N'Июль')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(8, N'Август')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(9, N'Сентябрь')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(10, N'Октябрь')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(11, N'Ноябрь')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(12, N'Декабрь')
GO
SET IDENTITY_INSERT [dbo].[Periods] OFF