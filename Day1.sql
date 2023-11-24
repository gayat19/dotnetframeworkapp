create database dbShopping24Nov23
Go
use dbShopping24Nov23
Go

create table Products
(id int identity(101,1) primary key,
name varchar(20),
price float,
quantity int,
description varchar(1000))
GO

Select * from Products

create proc proc_AddProduct(@pname varchar(20),@pprice float,@pquantity int,@pdecription varchar(1000))
as
begin
insert into products(name,price,quantity,description)
 values(@pname,@pprice,@pquantity,@pdecription)
 end
 Go

exec proc_AddProduct 'test',1,1,'check'

delete from Products

create proc proc_updateProduct(@pid int,@pname varchar(20),@pprice float,@pquantity int,@pdecription varchar(1000))
as
begin
	update products set name=@pname,price=@pprice,quantity=@pquantity,description=@pdecription
	where id=@pid
 end
 Go