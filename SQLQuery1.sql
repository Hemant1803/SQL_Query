CREATE DATABASE Grocery_Store;

USE Grocery_Store;
CREATE TABLE Customer (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(255),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);

INSERT INTO Customer (CustomerName, Phone, Address)
VALUES
    ('Hemant Sharma', '7532026247', 'Delhi,India'),
    ('Prashant Sharma', '7532026307', 'Delhi,India');
    
	ALTER TABLE Customer
ADD Country VARCHAR(50),
Salary DECIMAL (10, 2),
Pincode VARCHAR(10);

UPDATE Customer
SET Country = 'INDIA', Salary = 50000, Pincode = '110093'WHERE CustomerName = 'Hemant Sharma';
SET Country = 'INDIA', Salary = 50000, Pincode = '110093'WHERE CustomerName = 'Prashant Sharma';
  

  UPDATE Customer
SET Phone = '7011190463'
WHERE CustomerName = 'Hemant Sharma';

SELECT Country, COUNT(*) AS NumberOfCustomers
FROM Customer
GROUP BY Country;

SELECT * FROM Customer;

SELECT
    MAX(Salary) AS MaximumSalary,
    MIN(Salary) AS MinimumSalary,
    SUM(Salary) AS TotalSalary,
    AVG(Salary) AS AverageSalary
FROM Customer;

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(255),
    Quantity INT,
    Rating INT
);

INSERT INTO Orders(ProductName, Quantity, Rating)
VALUES
    ('Coke', '99', '5'),
	('Pasta', '50', '4'),
	('Biscuit', '45', '3'),
	('Namkeen', '98', '5'),
    ('Maggie', '56', '5');
    

SELECT * FROM Customer;
SELECT * FROM Orders;