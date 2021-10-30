using System;
using System.Collections.Generic;

namespace Assignment13
{
    class Program
    {
        public static List<Staff> listStaff = new List<Staff>();
        static void Main(string[] args)
        {
            int pick;
            do
            {
                Console.WriteLine();
                Console.WriteLine("=============================================================");
                Console.WriteLine("University Staff Management 1.0");
                Console.WriteLine("\t 1. Add staff");
                Console.WriteLine("\t 2. Sreach staff by name");
                Console.WriteLine("\t 3. Sreach staff by department/faculty");
                Console.WriteLine("\t 4. Display all staff");
                Console.WriteLine("\t 5. Exit");
                Console.Write("Select function (1,2,3,4 or 5): ");
                pick = Int32.Parse(Console.ReadLine());
                switch (pick)
                {
                    case 1:
                        {
                            addStaff();
                            break;
                        } 
                    case 2:
                        {
                            searchByName();
                            break;
                        } 

                    case 3:
                        {
                            searchByDepartment();
                            break;
                        } 
                        
                    case 4:
                        {
                            displayAllStaff();
                            break;
                        }
                    case 5:
                        return;
                    default:
                        Console.WriteLine("=> Pick number 1->5");
                        break;
                }
            } while (true);

        }

        private static void displayAllStaff()
        {
            Console.WriteLine("\n Results: ");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", "Name", "Fac/Dept", "Deg/Pos", "Sal Ratio", "Allowance", "T.Hours/W.Days", "Salary");
            foreach (var item in listStaff)
            {
                Console.WriteLine(item.ToString());
            }
        }
        private static void searchByDepartment()
        {
            Console.Write("\t Enter dept/fac to search: ");
            string nameDepartment = Console.ReadLine().Trim();
            Console.WriteLine("\n Results: ");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", "Name", "Fac/Dept", "Deg/Pos", "Sal Ratio", "Allowance", "T.Hours/W.Days", "Salary");
            foreach (var item in listStaff)
            {
                if (item.Department.ToLower().Contains(nameDepartment.ToLower()))
                {
                    Console.WriteLine(item.ToString());
                }  
            }
        }

        private static void searchByName()
        {
            Console.Write("\t Enter name to search: ");
            string name = Console.ReadLine().Trim();
            Console.WriteLine("\n Results: ");
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}", "Name", "Fac/Dept", "Deg/Pos", "Sal Ratio", "Allowance", "T.Hours/W.Days", "Salary");
            foreach (var item in listStaff)
            {
                if (item.FullName.ToLower().Contains(name.ToLower()))
                {
                    Console.WriteLine(item.ToString());
                }   
            }
        }

        private static void addStaff()
        {
            string pick;
            Console.Write("Do you want to create a Staff or Teacher (Enter S for Staff, otherwise for Teacher)? ");
            pick = Console.ReadLine().ToLower();

            if (pick == "s")
            {
                Staff staff = new Officer();
                staff.AddStaff();
                listStaff.Add(staff);
            }
            else
            {
                Teacher teacher = new Teacher();
                teacher.AddStaff();
                listStaff.Add(teacher);
            }
        }
    }
}
