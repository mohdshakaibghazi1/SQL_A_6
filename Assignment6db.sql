Create Database ProductInventoryDb
Use ProductInventoryDb
Create Table Products(
ProductId int Primary key,
ProductName nvarchar(50),
Price decimal,
Quantity int,
MfDate date,
ExpDate date
)
Insert into Products values(1,'Soap',10,10,'12-11-2017','12-11-2017');
Insert into Products values(2,'Creame',10,10,'12-12-2018','12-11-20122');
select * from Products