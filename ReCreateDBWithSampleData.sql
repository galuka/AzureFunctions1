/*==========DROP EXISTING TABLES==========*/
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'User'))
BEGIN
	DROP TABLE [User]
END
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'City'))
BEGIN
	DROP TABLE City
END
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Job'))
BEGIN
	DROP TABLE Job
END
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Department'))
BEGIN
	DROP TABLE Department
END

/*==========CREATE TABLES WITH SAMPLE DATA==========*/
CREATE TABLE Department (
	Id int  NOT NULL IDENTITY(1, 1),
	[Name] nvarchar(1024) NOT NULL,
	CONSTRAINT department_pk PRIMARY KEY (Id)
);


INSERT INTO Department ([Name])
VALUES 
('Bioengineering'),
('Quantum mechanics')


CREATE TABLE [Job] (
	Id int  NOT NULL IDENTITY(1, 1),
	[Name] nvarchar(128)  NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Department(Id),
	CONSTRAINT job_pk PRIMARY KEY (Id)
);

INSERT INTO [Job] ([Name], DepartmentId)
VALUES 
('Research Laboratory Technician', 1),
('Data Scientist', 2),
('Genius', 2)



CREATE TABLE City (
	Id int  NOT NULL IDENTITY(1, 1),
	[Name] nvarchar(128)  NOT NULL,
	PostalCode nvarchar(16)  NOT NULL,
	Latitude decimal(8,6)  NOT NULL,
	Longitude decimal(9,6)  NOT NULL,
	CONSTRAINT city_pk PRIMARY KEY (Id)
);

INSERT INTO City ([Name], PostalCode, Latitude, Longitude)
VALUES 
('Stockholm', '10243', 59.3326, 18.0649),
('New York', '116', 40.7808, -73.9772),
('Sydney', '1021', 	-33.8678, 151.2073)


CREATE TABLE [User] (
	Id int  NOT NULL IDENTITY(1, 1),
	[Name] nvarchar(128)  NOT NULL,
	LastName nvarchar(128) NULL,
	Email nvarchar(128) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES City(Id),
	JobId INT FOREIGN KEY REFERENCES Job(Id),
	CONSTRAINT user_pk PRIMARY KEY (Id)
);

INSERT INTO [User] ([Name], LastName, Email, CityId, JobId)
VALUES 
('Niels', 'Bohr', 'niels.bohr@physics.com', 1, 3),
('James', 'Maxwell', 'james.maxwell@physics.com', 2, 2),
('Marie', 'Curie', 'marie.curie@physics.com', 3, 1)