create procedure pr_SaveSuppliers
(@CompanyName nvarchar(50),@ContactName nvarchar(50),@ContactTitle nvarchar(50),@City nvarchar(50),@Country nvarchar(50),@Address nvarchar(60),@Phone nvarchar(50))
as
insert into Suppliers (CompanyName,ContactName,ContactTitle,City,Country,Address,Phone) values (@CompanyName,@ContactName,@ContactTitle,@City,@Country,@Address,@Phone)


go

create procedure pr_UpdateSuppliers
(@SupplierID int, @CompanyName nvarchar(50),@ContactName nvarchar(50),@ContactTitle nvarchar(50),@City nvarchar(50),@Country nvarchar(50),@Address nvarchar(60),@Phone nvarchar(50))
as
update Suppliers set CompanyName=@CompanyName , ContactName=@ContactName, ContactTitle=@ContactTitle, City=City, Country=@Country, Address=@Address,Phone=@Phone where SupplierID=@SupplierID


go

create procedure pr_DeleteSuppliers
(@SupplierID int)
as
delete from Suppliers where SupplierID=@SupplierID