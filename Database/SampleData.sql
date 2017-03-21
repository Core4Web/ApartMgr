USE ApartMgrDB
GO
DELETE FROM [dbo].[Invoices]
DELETE FROM [dbo].[Periods]
GO
SET IDENTITY_INSERT [dbo].[Periods] ON
GO
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(1, N'������')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(2, N'�������')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(3, N'����')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(4, N'������')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(5, N'���')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(6, N'����')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(7, N'����')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(8, N'������')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(9, N'��������')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(10, N'�������')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(11, N'������')
INSERT INTO [dbo].[Periods] (Id, PeriodName) VALUES(12, N'�������')
GO
SET IDENTITY_INSERT [dbo].[Periods] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON
GO
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(1, N'1234-F56', N'71', 3, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year)
  VALUES(2, N'80-895-12', N'5435454343454354354534', 7, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(3, N'123456', N'0000000000', 8, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(4, N'145', N'946546', 7, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(5, N'��567', N'71018946546', 5, 2016)
GO
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO