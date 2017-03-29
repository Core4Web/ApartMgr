USE ApartMgrDB
GO
DELETE FROM [dbo].[Invoices]
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
GO
SET IDENTITY_INSERT [dbo].[Providers] ON
GO
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(1, N'ООО СтройМАКС')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(2, N'АО ОЕИРЦ')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(3, N'ООО Мега-Т')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(4, N'ООО Газпром межрегионгаз Тула')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(5, N'ПАО Ростелеком')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(6, N'АО «ТНС энерго Тула»')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(7, N'ПАО «Вымпелком»')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(8, N'ОАО «НТВ-ПЛЮС»')
INSERT INTO [dbo].[Providers] (Id, ProviderName) VALUES(9, N'Финансовое управление администрации города Тулы')
GO
SET IDENTITY_INSERT [dbo].[Providers] OFF
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
  VALUES(5, N'АБ567', N'71018946546', 5, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(6, N'871010219034/1608', N'871010219034', 6, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(7, N'Без номера', N'99010602071', 3, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(8, N'1633053', N'100048189', 2, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(9, N'23298', N'101053026', 1, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(10, N'Без номера', N'1014106328', 4, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(11, N'Без номера', N'8604001460312265800012', 10, 2016)
INSERT INTO [dbo].[Invoices] (Id, Number, Account, PeriodId, Year) 
  VALUES(12, N'Без номера', N'7100092510652', 5, 2016)
GO
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO