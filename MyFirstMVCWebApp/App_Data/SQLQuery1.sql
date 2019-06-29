
CREATE TABLE Users(
Id NVARCHAR(50),
Username NVARCHAR(50),
Password NVARCHAR(50),
Name NVARCHAR(30),
Surname NVARCHAR(30),
Gender NVARCHAR(10),
Role NVARCHAR(10)
PRIMARY KEY (Id)
);

CREATE TABLE Locations(
Id NVARCHAR(50),
Address NVARCHAR(20),
Lattitude float,
Longitude float,
PRIMARY KEY (Id)
);


CREATE TABLE Apartments(
Id NVARCHAR(50),
Type NVARCHAR(50),
RoomsCapacity INT,
GuestCapacity INT,
LocationId NVARCHAR(50),
RentableDates NVARCHAR(500),
FreeDates NVARCHAR(500),
UserId NVARCHAR(50),
Comments NVARCHAR(500),
Pictures NVARCHAR(300),
DailyPrice INT,
EnteringTime NVARCHAR(20),
LeavingTime NVARCHAR(20),
IsActive BIT,
Amenities NVARCHAR(200),
PRIMARY KEY (Id)
);

CREATE TABLE ApartmentItems(
Id NVARCHAR(50),
Item NVARCHAR(20)
PRIMARY KEY (Id)
);

CREATE TABLE Comments(
Id NVARCHAR(50),
UserId NVARCHAR(50),
ApartmentId NVARCHAR(50),
Text NVARCHAR(100),
Rating INT,
PRIMARY KEY (Id)
);

CREATE TABLE Reservations(
Id NVARCHAR(50),
UserId NVARCHAR(50),
ApartmentId NVARCHAR(50),
StartingDate DATETIME2,
OvernightStaysNum INT,
TotalPrice INT,
Status NVARCHAR(20),
PRIMARY KEY (Id)
);
