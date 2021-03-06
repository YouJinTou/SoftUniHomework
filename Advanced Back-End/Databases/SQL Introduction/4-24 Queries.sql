-- Problem 4.	Write an SQL query to find all information about all departments (use "SoftUni" database).
select * from Departments

-- Problem 5.	Write an SQL query to find all department names.
select Name from Departments

-- Problem 6.	Write an SQL query to find the salary of each employee. 
select FirstName + ' ' + LastName as [Name], Salary from Employees order by Salary

-- Problem 7.	Write an SQL to find the full name of each employee. 
select FirstName + ' ' + LastName as [Full Name] from Employees

-- Problem 8.	Write an SQL query to find the email addresses of each employee.
select FirstName + ' ' + LastName as [Full Name],
FirstName + '.' + LastName + '@softuni.bg' as [Full Email Address] from Employees

-- Problem 9.	Write an SQL query to find all different employee salaries. 
-- select FirstName + ' ' + LastName as [Name], distinct on Salary from Employees 
select distinct Salary from Employees

-- Problem 10.	Write an SQL query to find all information about the employees whose
-- job title is “Sales Representative“.
select * from Employees where JobTitle = 'Sales Representative'

-- Problem 11.	Write an SQL query to find the names of all employees whose first name
-- starts with "SA".
select FirstName + ' ' + LastName as [Name] from Employees
where FirstName like 'SA%'

-- Problem 12.	Write an SQL query to find the names of all employees whose last name contains "ei".
select FirstName + ' ' + LastName as [Name] from Employees
where LastName like '%ei%'

-- Problem 13.	Write an SQL query to find the salary of all employees whose salary is in the range
-- [20000…30000].
select FirstName + ' ' + LastName as [Name], Salary from Employees
where Salary >= 20000 and Salary <= 30000

-- Problem 14.	Write an SQL query to find the names of all employees whose salary is 25000, 14000,
-- 12500 or 23600.
select FirstName + ' ' + LastName as [Name], Salary from Employees
where Salary in (25000, 14000, 125000, 23600)

-- Problem 15.	Write an SQL query to find all employees that do not have manager.
select * from Employees where ManagerID is null

-- Problem 16.	Write an SQL query to find all employees that have salary more than 50000.
-- Order them in decreasing order by salary.
select * from Employees
where Salary > 50000
order by Salary desc

-- Problem 17.	Write an SQL query to find the top 5 best paid employees.
select top 5 * from Employees order by Salary desc

-- Problem 18.	Write an SQL query to find all employees along with their address.
select FirstName + ' ' + LastName as [Name], a.AddressText as [Address] from Employees e
inner join Addresses a
on e.AddressID = a.AddressID

-- Problem 19.	Write an SQL query to find all employees and their address.
select e.FirstName + ' ' + e.LastName as [Name], a.AddressText as [Address]
from Employees e, Addresses a
where e.AddressID = a.AddressID

-- Problem 20.	Write an SQL query to find all employees along with their manager.
select e.FirstName + ' ' + e.LastName as [Name],
m.FirstName + ' ' + m.LastName as [Manager]
from Employees e
inner join Employees m
on e.ManagerID = m.EmployeeID

-- Problem 21.	Write an SQL query to find all employees, along with their manager
-- and their address.
-- (I'll take it it's the manager's address)
select e.FirstName + ' ' + e.LastName as [Name],
m.FirstName + ' ' + m.LastName as [Manager],
a.AddressText as [Manager Address]
from Employees e
inner join Employees m
on e.ManagerID = m.EmployeeID
inner join Addresses a
on m.EmployeeID = a.AddressID

-- Problem 22.	Write an SQL query to find all departments and all town names as a single list.
select Name from Departments
union
select Name from Towns

-- Problem 23.	Write an SQL query to find all the employees and the manager for each of them along
-- with the employees that do not have manager. 
select e.FirstName + ' ' + e.LastName as [Name],
m.FirstName + ' ' + m.LastName as [Manager]
from Employees e
left join Employees m
on e.ManagerID = m.EmployeeID

-- Problem 24.	Write an SQL query to find the names of all employees from the departments "Sales"
-- and "Finance" whose hire year is between 1995 and 2005.
select FirstName + ' ' + LastName as [Name], HireDate, d.Name as [Department]
from Employees e
join Departments d
on e.DepartmentID = d.DepartmentID
where HireDate between '1995/01/01'and '2005/12/31'

