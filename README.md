# TallerTechnologiesWS

Car Service App

This is a C# web service application built using .NET version 6. It allows you to perform basic CRUD operations against a list of cars. The cars are represented by a Car model with the following properties: make, model, year, doors, colors, and price.

## Prerequisites

Before running the project, you will need to create the database and table and insert seed data. To do this, run the script inside the Data folder called Script.sql.

## Functionality

The app has three sections accessible from the header:

- Home: allows the user to guess the price of each car and displays a message in green if the guess is within 5,000 of the actual price.
- CRUD: allows the user to create, read, update, and delete a car.
- Order detail: displays SQL in C# code.

## Car Guessing Challenge

In addition to the basic CRUD functionality, the app includes a car guessing challenge. The user can guess the price of each car, and if their guess is within 5,000 of the actual price, a message in green is displayed.

## SQL Query

The app also includes an SQL query that retrieves information about orders and their associated products. The query is based on the following code:

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, c.Age, o.OrderID, o.DateCreated, o.MethodOfPurchase AS PurchaseMethod, od.ProductNumber, od.ProductOrigin
FROM Customer c
JOIN Orders o ON c.PersonID = o.PersonID
JOIN OrderDetails od ON o.OrderID = od.OrderID
WHERE od.ProductID = '1112222333';

This query retrieves the full name and age of the customer, the order ID, date created, method of purchase, product number, and product origin for a specific product ID.

## Technologies Used

- C#
- Razor views
- Entity Framework
