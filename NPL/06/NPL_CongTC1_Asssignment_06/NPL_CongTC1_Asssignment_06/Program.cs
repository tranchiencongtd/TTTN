using System;
using System.Collections.Generic;

namespace NPL_CongTC1_Asssignment_06
{
    class Program
    {
        public static List<Employee> eList = new List<Employee>();
        static void Main(string[] args)
        {
            mainMenu();
        }

        private static void mainMenu()
        {
            int pick;
            do
            {
                Console.WriteLine("====== Assignment 06 - EmployeeManagement ======");
                Console.WriteLine("Please select the admin area you require");
                Console.WriteLine("1. Import Employee");
                Console.WriteLine("2. Display Employees Information");
                Console.WriteLine("3. Search Employee");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Menu Option Number: ");
                pick = int.Parse(Console.ReadLine());

                switch (pick)
                {
                    case 1:
                        importEmpployee();
                        break;
                    case 2:
                        displayEmployeesInfo();
                        break;
                    case 3:
                        searchEmployee();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        private static void searchEmployee()
        {
            int pick;
            do
            {
                Console.WriteLine("====== Search Employee ======");
                Console.WriteLine("1. By Employee Type");
                Console.WriteLine("2. By Employee Name");
                Console.WriteLine("3. Main menu");
                Console.Write("Enter Menu Option Number: ");
                pick = int.Parse(Console.ReadLine());

                switch (pick)
                {
                    case 1:
                        searchByType();
                        break;
                    case 2:
                        searchByName();
                        break;
                    case 3:
                        mainMenu();
                        break;
                }
            } while (true);
        }

        private static void searchByName()
        {
            int count = 0;
            Console.Write("Enter Employee Name: ");
            string eType = Console.ReadLine().Trim().ToLower();
            Console.Write("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "SSN", "First name", "Last name", "Birth date", "Phone", "Email");
            foreach (var item in eList)
            {
                Type e = item.GetType();
                if (e.Name == "HourlyEmployee" && item.LastName == eType)
                {
                    HourlyEmployee hEmployee = (HourlyEmployee)item;
                    hEmployee.Display();
                    count++;
                }
                if (e.Name == "SalariedEmployee" && item.LastName == eType)
                {
                    SalariedEmployee sEmployee = (SalariedEmployee)item;
                    sEmployee.Display();
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("Dont have Hourly Employee");
        }

        private static void searchByType()
        {
            Console.Write("Enter Employee Type: ");
            string eType = Console.ReadLine().ToLower();
            if (eType == "hourly") searchHourEmployee();
            if (eType == "salaried") searchSalariedEmployee();
        }

        private static void searchHourEmployee()
        {
            int count = 0;
            Console.Write("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "SSN", "First name", "Last name", "Birth date", "Phone", "Email");
            foreach (var item in eList)
            {
                Type e = item.GetType();
                if (e.Name == "HourlyEmployee")
                {
                    HourlyEmployee hEmployee = (HourlyEmployee)item;
                    hEmployee.Display();
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("Dont have Hourly Employee");
        }

        private static void searchSalariedEmployee()
        {
            int count = 0;
            Console.Write("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "SSN", "First name", "Last name", "Birth date", "Phone", "Email");
            foreach (var item in eList)
            {
                Type e = item.GetType();
                if (e.Name == "SalariedEmployee")
                {
                    SalariedEmployee sEmployee = (SalariedEmployee)item;
                    sEmployee.Display();
                    count++;
                }
            }
            if (count == 0) Console.WriteLine("Dont have Salaried Employee");
        }

        private static void displayEmployeesInfo()
        {
            if (eList.Count == 0) Console.WriteLine("===== Dont have employee =====");
            else
            {
                Console.WriteLine("========= All Employees =========");
                Console.Write("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "SSN", "First name","Last name", "Birth date", "Phone", "Email");
                foreach (var item in eList)
                {
                    item.Display();
                }
            }

        }

        private static void importEmpployee()
        {
            int pick;

            do
            {
                Console.WriteLine("====== Import Employee ======");
                Console.WriteLine("1. Salaried Employee");
                Console.WriteLine("2. Hour Employee");
                Console.WriteLine("3. Main menu");
                Console.Write("Enter Menu Option Number: ");
                pick = int.Parse(Console.ReadLine());

                switch (pick)
                {
                    case 1:
                        importSalariedEmployee();
                        break;
                    case 2:
                        importHourEmployee();
                        break;
                    case 3:
                        mainMenu();
                        break;
                }
            } while (true);
        }

        private static void importHourEmployee()
        {
            HourlyEmployee hEmployee = new HourlyEmployee();
            importEmployee(hEmployee);
            Console.Write("Enter Wage: ");
            hEmployee.Wage = double.Parse(Console.ReadLine());
            Console.Write("Enter Working Hour: ");
            hEmployee.WorkingHour = double.Parse(Console.ReadLine());
            eList.Add(hEmployee);
        }

        private static void importSalariedEmployee()
        {
            SalariedEmployee sEmployee = new SalariedEmployee();
            importEmployee(sEmployee);
            Console.Write("Enter commission rate: ");
            sEmployee.CommissionRate = double.Parse(Console.ReadLine());
            Console.Write("Enter gross sales: ");
            sEmployee.GrossSales = double.Parse(Console.ReadLine());
            Console.Write("Enter basic salary: ");
            sEmployee.BasicSalary = double.Parse(Console.ReadLine());
            eList.Add(sEmployee);
        }
        private static void importEmployee(Employee e)
        {
            Console.Write("Enter SSN: ");
            e.SSN = Console.ReadLine();
            Console.Write("Enter Frist name: ");
            e.FirstName = Console.ReadLine();
            Console.Write("Enter Last name: ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter Birth Day: ");
            e.BirthDate = Console.ReadLine();
            Console.Write("Enter Phone: ");
            e.Phone = Console.ReadLine();
            Console.Write("Enter Email: ");
            e.Email = Console.ReadLine();
        }

    }
}