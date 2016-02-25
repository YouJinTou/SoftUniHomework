using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{    
    class EmployeeData
    {
        private string firstName;
        private string lastName;
        private ushort age;
        private char gender;
        private string personalID;
        private string uniqueID;

        public EmployeeData(string firstName, string lastName,
            ushort age, char gender, string personalID, string uniqueID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
            this.personalID = personalID;
            this.uniqueID = uniqueID;
        }

        public override string ToString()
        {
            string data = "First name: " + firstName
                + "\nLast name: " + lastName
                + "\nAge: " + age
                + "\nGender: " + gender
                + "\nPersonal ID: " + personalID
                + "\nUnique Employee Number: " + uniqueID;
            return data;
        }

        static void Main(string[] args)
        {
            EmployeeData employeeAmanda =
                new EmployeeData("Amanda", "Johnson", 27, 'f',
                "8306112507", "27563571");

            Console.WriteLine(employeeAmanda);
        }
    }
}
