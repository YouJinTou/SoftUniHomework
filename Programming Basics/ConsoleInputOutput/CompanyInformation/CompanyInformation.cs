using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInformation
{
    class Company
    {
        private string name;
        private string address;
        private string phoneNumber;
        private string faxNumber;
        private string webSite;
        private string managerFirstName;
        private string managerLastName;
        private ushort managerAge;
        private string managerPhone;
        
        public Company(string name, string address, string phone,
            string webSite, string managerFirstName,
            string managerLastName, ushort managerAge, string managerPhone)
        {
            this.name = name;
            this.address = address;
            phoneNumber = phone;
            this.webSite = webSite;
            this.managerFirstName = managerFirstName;
            this.managerLastName = managerLastName;
            this.managerAge = managerAge;
            this.managerPhone = managerPhone;

            faxNumber = null;
        }

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public string FaxNumber
        {
            get
            {
                return faxNumber;
            }

            set
            {
                faxNumber = value;
            }
        }

        public string WebSite
        {
            get
            {
                return webSite;
            }

            set
            {
                webSite = value;
            }
        }

        public string ManagerFirstName
        {
            get
            {
                return managerFirstName;
            }

            set
            {
                managerFirstName = value;
            }
        }

        public string ManagerLastName
        {
            get
            {
                return managerLastName;
            }

            set
            {
                managerLastName = value;
            }
        }

        public ushort ManagerAge
        {
            get
            {
                return managerAge;
            }

            set
            {
                managerAge = value;
            }
        }

        public string ManagerPhone
        {
            get
            {
                return managerPhone;
            }

            set
            {
                managerPhone = value;
            }
        }
        #endregion

        public override string ToString()
        {
            string result =
                "Company: " + name +
                "\nAddress: " + address +
                "\nPhone: " + phoneNumber +
                "\nFax: " + faxNumber +
                "\nWebsite: " + webSite +
                "\nManager: " + ManagerFirstName +
                " " + managerLastName +
                "\nManager's age: " + managerAge +
                "\nManager's phone: " + managerPhone;
            return result;
        }
    }
    class CompanyInformation
    {
        static void Main(string[] args)
        {
            Company softUni = new Company("Software University", "15-18 Tintyava, Sofia",
                "+359 899 55 55 92", "https://softuni.bg", "Svetlin", "Nakov",
                27, "+359 2 981 981");
            Console.WriteLine(softUni);
        }
    }
}
