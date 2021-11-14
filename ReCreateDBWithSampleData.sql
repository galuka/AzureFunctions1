IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'City'))
BEGIN
	DROP TABLE City
END

BEGIN
	CREATE TABLE City (
		Id int  NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(128)  NOT NULL,
		PostalCode nvarchar(16)  NOT NULL,
		Latitude decimal(8,6)  NOT NULL,
		Longitude decimal(9,6)  NOT NULL,
		CONSTRAINT city_pk PRIMARY KEY (Id)
	);
END

INSERT INTO City ([Name], PostalCode, Latitude, Longitude)
VALUES 
('Stockholm', '10243', 59.3326, 18.0649),
('New York', '116', 40.7808, -73.9772),
('Sydney', '1021', 	-33.8678, 151.2073)

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'User'))
BEGIN
	DROP TABLE [User]
END

BEGIN
	CREATE TABLE [User] (
		Id int  NOT NULL IDENTITY(1, 1),
		[Name] nvarchar(128)  NOT NULL,
		LastName nvarchar(128) NULL,
		Email nvarchar(128) NOT NULL,
		CityId INT FOREIGN KEY REFERENCES City(Id),
		CONSTRAINT user_pk PRIMARY KEY (Id)
	);
END