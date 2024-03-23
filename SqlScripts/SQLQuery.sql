--риэлтор
create table Agents
(
Id int primary key,
FirstName nvarchar(20) not null,
MiddleName nvarchar(15) not null,
LastName nvarchar(20) not null,
DealShare int
)

--клиент
create table Clients
(
Id int primary key,
FirstName nvarchar(20),
MiddleName nvarchar(15),
LastName nvarchar(20),
Phone nvarchar(11),
Email nvarchar(max),
)

--координаты
create table Districts
(
Id int primary key,
[Name] nvarchar(100),
Area nvarchar(max)
)

--тип недвижимоссти
create table RealEstate
(
Id int primary key,
[Name] nvarchar(15)
)

--объект
create table [Object]
(
Id int primary key,
Address_City nvarchar(20),
Address_Street nvarchar(30),
Address_House int,
Address_Number int,
Coordinate_latitude int,
Coordinate_longitude int,
TotalArea float,
Rooms int,
[Floor] int,
RealEstateId int references RealEstate(Id)
)

--требования/пожелания
create table ObjectDemands
(
Id int primary key,
Address_City nvarchar(20),
Address_Street nvarchar(30),
Address_House int,
Address_Number int,
RealEstateId int references RealEstate(Id),
MinPrice float,
MaxPrice float,
AgentId int references Agents(Id),
ClientId int references Clients(Id),
MinArea float,
MaxArea float,
MinRooms int,
MaxRooms int,
MinFloor int,
MaxFloor int
)

--предложение клиента-продавца
create table Offer
(
Id int primary key,
SalesManId int references Clients(Id),
RealEstateId int references RealEstate(Id),
Address_City nvarchar(20),
Address_Street nvarchar(30),
Address_House int,
Address_Number int,
TotalArea float,
Rooms int,
[Floor] int,
Price money
)

--сделка
create table Deal
(
Id int primary key,
SalesManId int references Clients(Id),
BuyerId int references Clients(Id),
AgentId int references Agents(Id),
ObjectDemandsId int references ObjectDemands(Id),
OfferId int references Offer(Id),
PriceServices money
)

