create procedure pr_SaveCategories
(@CategoryName nvarchar(50), @Description nvarchar(50))
as
Insert into Categories (CategoryName, Description) values (@CategoryName, @Description)


go

create procedure pr_UpdateCategories
(@CategoryID int, @CategoryName nvarchar(50), @Description nvarchar(50))
as
update Categories set CategoryName=@CategoryName, Description=@Description where CategoryID=@CategoryID


go


create procedure pr_DeleteCategories
(@CategoryID int)
as
delete from Categories where CategoryID=@CategoryID