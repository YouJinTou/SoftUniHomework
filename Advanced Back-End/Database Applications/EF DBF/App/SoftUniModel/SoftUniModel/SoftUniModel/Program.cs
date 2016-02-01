using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SoftUniModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniEntities();
            var db2 = new SoftUniEntities();

            ////***PROBLEM 1***//

            Employee employee = new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "None",
                JobTitle = "Garbage Collector",
                DepartmentID = 2,
                AddressID = 5,
                ManagerID = 6,
                HireDate = DateTime.Now,
                Salary = 520m
            };

            EmployeeDAO.Add(employee);

            int employeeId = db.Employees
                .Where(e => e.JobTitle == "Garbage Collector")
                .First()
                .EmployeeID;
            Employee keyEmployee = EmployeeDAO.FindByKey(employeeId);
            Console.WriteLine("Employee ID of newly added employee: " + keyEmployee.EmployeeID);

            EmployeeDAO.Modify(keyEmployee);

            EmployeeDAO.Delete(keyEmployee);


            //***PROBLEM 2***//

            // Part 1
            var employees = db.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year >= 2001
                        && p.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerName = db.Employees
                        .Where(m => m.EmployeeID == e.ManagerID)
                        .FirstOrDefault()
                        .FirstName + " " 
                        + db.Employees
                        .Where(m => m.EmployeeID == e.ManagerID)
                        .FirstOrDefault()
                        .LastName,
                    Projects = e.Projects
                        .Select(p => new
                        {
                            p.Name,
                            p.StartDate,
                            p.EndDate
                        })
                }
                );

            foreach (var e in employees)
            {
                Console.WriteLine("Employee first name: " + e.FirstName);
                Console.WriteLine("Employee last name: " + e.LastName);
                Console.WriteLine("Employee manager name: " + e.ManagerName);

                foreach (var proj in e.Projects)
                {
                    Console.WriteLine("\t\tProject name: " + proj.Name);
                    Console.WriteLine("\t\tProject start date: " + proj.StartDate);
                    Console.WriteLine("\t\tProject end date: " + proj.EndDate);
                }

                Console.WriteLine();
            }

             //Part 2
            var addresses = db.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .Take(10)
                .OrderBy(a => a.Town.Name)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                });

            foreach (var a in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees",
                    a.AddressText,
                    a.TownName,
                    a.EmployeeCount);
            }

             //Part 3
            var emp = db.Employees
                .Where(e => e.EmployeeID == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.Projects
                        .Select(p => new
                        {
                            p.Name
                        })
                })
                .FirstOrDefault();

            Console.WriteLine("First name: " + emp.FirstName);
            Console.WriteLine("Last name: " + emp.LastName);
            Console.WriteLine("Job title: " + emp.JobTitle);
            Console.WriteLine("Projects: " + string.Join(", ", emp.Projects));

             //Part 4
            var deps = db.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    d.Name,
                    ManagerName = db.Employees
                        .Where(e => d.ManagerID == e.EmployeeID)
                        .FirstOrDefault()
                        .LastName,
                    Employees = db.Employees
                        .Where(e => e.DepartmentID == d.DepartmentID)
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.HireDate,
                            e.JobTitle
                        }),
                    EmployeesCount = d.Employees.Count()
                });

            foreach (var dep in deps)
            {
                Console.WriteLine("--{0} - Manager: {1}",
                    dep.Name,
                    dep.ManagerName);

                foreach (var e in dep.Employees)
                {
                    Console.WriteLine("\t" + e.FirstName);
                    Console.WriteLine("\t" + e.LastName);
                    Console.WriteLine("\t" + e.HireDate);
                    Console.WriteLine("\t" + e.JobTitle);
                }
            }


            //*** Problem 4***//
            var sw = new Stopwatch();

            sw.Start();

            var empCountLINQ = db.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName);

            Console.WriteLine("LINQ time: {0} ", sw.Elapsed);

            sw.Restart();

            var empCountNative = db.Database.SqlQuery<int>(
                "SELECT e.FirstName FROM Employees e" +
                "INNER JOIN EmployeesProjects ep" +
                "ON ep.ProjectID = e.EmployeeID" +
                "INNER JOIN Projects p" +
                "ON p.ProjectID = ep.ProjectID" +
                "WHERE DATEPART(YEAR, p.StartDate) = 2002");

            sw.Stop();

            Console.WriteLine("Native time: {0} ", sw.Elapsed);
             // Native is much faster


            //***Problem 5***//
            var address = db.Addresses.Find(1);
            address.AddressText = "Moon";

            var address2 = db2.Addresses.Find(1);
            address2.AddressText = "Mars";

            db.SaveChanges();
            db2.SaveChanges();

             //db2 is saved without Concurrency Mode
             //db is saved with Concurrency Mode


            //***Problem 6***//
            var projects = db.GetProjectsByEmployee("Ruth", "Ellerbrock");

            foreach (var p in projects)
            {
                Console.WriteLine("{0}, {1}, {2}", p.Name, p.Description, p.StartDate);
            }
        }
    }
}
