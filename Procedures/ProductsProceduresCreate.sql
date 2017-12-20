create procedure pr_SaveProducts
(
@ProductName nvarchar(20),@UnitPrice money,@UnitsInStock int,@CategoryID int ,@SupplierID int
)
as
insert into Products (ProductName,UnitPrice,UnitsInStock,CategoryID,SupplierID) values (@ProductName,@UnitPrice,@UnitsInStock,@CategoryID,@SupplierID)

go
create procedure pr_UpdateProducts
(@ProductID int, @ProductName nvarchar(20),@UnitPrice money,@UnitsInStock int,@CategoryID int ,@SupplierID int)
as
update Products set ProductName=@ProductName,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,CategoryID=@CategoryID,SupplierID=@SupplierID where ProductID=@ProductID
go
create procedure pr_DeleteProducts
(@ProductID int)
as 
delete from Products where ProductID=@ProductID