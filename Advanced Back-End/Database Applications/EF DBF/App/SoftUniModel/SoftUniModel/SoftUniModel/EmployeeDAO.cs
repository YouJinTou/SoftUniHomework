using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniModel
{
    class EmployeeDAO
    {
        static SoftUniEntities db = new SoftUniEntities();

        public static void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            Employee employee = db.Employees.Find(key);

            return employee;
        }

        public static void Modify(Employee employee)
        {
            db.Employees.Attach(employee);
            employee.FirstName = "Aurelius";
            db.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
