using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NPL_CongTC1_Asssignment_06
{
    public abstract class Employee
    {
        private string birthDate;
        private string phone;
        private string email;

        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate
        {
            get => this.birthDate;
            set
            {
                if (DateTime.TryParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                    this.birthDate = value;
                else
                    throw new ArgumentException($"{value} is invalid format(dd/MM/yyyy)");
            }
        }

        public string Phone
        {
            get => this.phone;
            set
            {
                if (value.Length>=7 && Int32.TryParse(value, out int result) && result > 0)
                    this.phone = value;
                else
                    throw new ArgumentException($"{value} is invalid phone(minimum 7 positive integers)");
            }
        }

        public string Email
        {
            get => this.email;
            set
            {
                string pattern = @"^\w+(\.?\w+[!#$%&'*+\-/=?^_{|}~]*)*@\w+-*[\D]+[^-]$";
                if (Regex.IsMatch(value, pattern))
                    this.email = value;
                else
                    throw new ArgumentException($"{value} is invalid email");
            }
        }
        public Employee()
        {

        }
        public Employee(string sSN, string firstName, string lastName)
        {
            SSN = sSN;
            FirstName = firstName;
            LastName = lastName;
           
        }

        public virtual void Display()
        {
            Console.Write("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", SSN, FirstName, LastName, BirthDate, Phone, Email);
        }

    }
}
