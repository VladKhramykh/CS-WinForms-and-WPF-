create database lab8;
use lab8;

create table Customer
(
	id int primary key identity (1,1),
	firstName nvarchar(30),
	seconName nvarchar(30),
	mail nvarchar(30),
	picture varbinary(MAX) 

);

create table Announcement
(
	id int primary key identity(1,1),
	sellerID int foreign key references customer(id),
	about nvarchar(300)
);