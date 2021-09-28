USE LearnASPNETCoreWebAPIWithRealApps;

-- create table

create table Product(
	Id int identity(1,1) NOT NULL PRIMARY KEY,
	Name varchar(250) NULL,
	Price money NULL,
	Quantity int NULL,
	Status bit NOT NULL
)

-- Dumping data for table Product

insert into Product(Name,Price,Quantity,Status) 
values
('Name 1',200000,4,1),
('Name 2',120000,8,0),
('Name 3',40000,3,1),
('Name 4',17000,8,1)