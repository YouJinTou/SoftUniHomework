using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountData
{
    class BankAccountData
    {
        private string firstName;
        private string lastName;
        private decimal balance;
        private string bankName;
        private string IBAN;
        private string firstCardNumber;
        private string secondCardNumber;
        private string thirdCardNumber;
        
        public BankAccountData(string firstName, string lastName,
            decimal balance, string bankName, string IBAN,
            string firstCardNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
            this.bankName = bankName;
            this.IBAN = IBAN;
            this.firstCardNumber = firstCardNumber;
            secondCardNumber = null;
            thirdCardNumber = null;
        }

        public string SecondCardNumber
        {
            get
            {
                return secondCardNumber;
            }

            set
            {
                secondCardNumber = value;
            }
        }

        public string ThirdCardNumber
        {
            get
            {
                return thirdCardNumber;
            }

            set
            {
                thirdCardNumber = value;
            }
        }

        static void Main(string[] args)
        {
            BankAccountData someDepositor =
                new BankAccountData("John", "Doe", 100000.01m,
                "Bank of Timbucktwo", "TBT0123456789", "123-456-789-012");
            someDepositor.secondCardNumber = "987-654-321-098";
            someDepositor.thirdCardNumber = "111-222-333-444";
        }
    }
}
