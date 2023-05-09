USE [master]
GO

CREATE DATABASE [SergioDB]
GO

USE [SergioDB]
GO

/****** Object:  Table [dbo].[Contact] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cars] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Make]        VARCHAR (MAX)   NULL,
	[Model]        VARCHAR (MAX)   NULL,
	[Year]        INT   NULL,
	[Doors]        INT   NULL,
	[Color]        VARCHAR (MAX)   NULL,
    [Price]       INT NULL,
	[Guess]        INT   NULL,
    [Guessed]        BIT   NULL,
);
GO

INSERT INTO [SergioDB].[dbo].[Cars] ([Make], [Model], [Year], [Doors], [Color], [Price], [Guess], [Guessed])
VALUES 
('Audi', 'R8', 2018, 2, 'Red', 79995, NULL, NULL),
('Tesla', '3', 2018, 4, 'Black', 54995, NULL, NULL),
('Porsche', '911 991', 2020, 2, 'White', 155000, NULL, NULL),
('Mercedes-Benz', 'GLE 63S', 2021, 5, 'Blue', 83995, NULL, NULL),
('BMW', 'X6 M', 2020, 5, 'Silver', 62995, NULL, NULL);
GO

CREATE TABLE Customers (
    PersonID INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Occupation VARCHAR(50) NOT NULL,
    MartialStatus VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    PersonID INT NOT NULL,
    DateCreated DATETIME NOT NULL,
    MethodOfPurchase VARCHAR(50) NOT NULL,
    FOREIGN KEY (PersonID) REFERENCES Customers(PersonID)
);
GO

CREATE TABLE OrderDetails (
    OrderID INT NOT NULL,
    OrderDetailID INT NOT NULL,
    ProductNumber VARCHAR(50) NOT NULL,
    ProductID VARCHAR(50) NOT NULL,
    ProductOrigin VARCHAR(50) NOT NULL,
    PRIMARY KEY (OrderID, OrderDetailID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);
GO

INSERT INTO Customers (PersonID, FirstName, LastName, Age, Occupation, MartialStatus)
VALUES
(1, 'John', 'Doe', 30, 'Software Engineer', 'Single'),
(2, 'Jane', 'Smith', 40, 'Accountant', 'Married'),
(3, 'Bob', 'Johnson', 25, 'Student', 'Single'),
(4, 'Alice', 'Williams', 50, 'Manager', 'Married');
GO

INSERT INTO Orders (OrderID, PersonID, DateCreated, MethodOfPurchase)
VALUES
(1001, 1, '2022-01-01', 'Online'),
(1002, 2, '2022-02-01', 'In Store'),
(1003, 3, '2022-03-01', 'Online'),
(1004, 4, '2022-04-01', 'In Store');
GO

INSERT INTO OrderDetails (OrderID, OrderDetailID, ProductNumber, ProductID, ProductOrigin)
VALUES
(1001, 1, '1001-001', '1112222333', 'USA'),
(1001, 2, '1001-002', '4445555666', 'China'),
(1002, 1, '1002-001', '1112222333', 'USA'),
(1003, 1, '1003-001', '1112222333', 'USA'),
(1003, 2, '1003-002', '7778888999', 'Mexico'),
(1004, 1, '1004-001', '1112222333', 'USA');
GO

