using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL.M.A011.EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            EmployeeQueryRepository employeeQuery = new EmployeeQueryRepository();
            EmployeeMethodRepository employeeMethod = new EmployeeMethodRepository();
            string choose;
            do
            {
                Console.WriteLine("============= Assignment 14 - Employee Management =============");
                Console.WriteLine("1. Display All");
                Console.WriteLine("2. Search Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Exit");
                Console.Write("Enter menu option number:");
                choose = Console.ReadLine();
                Console.Clear();
                try
                {
                    switch (choose)
                    {
                        case "1":
                            Console.WriteLine("==== Query ====");
                            employeeQuery.DisplayAll();
                            Console.WriteLine("==== Method ====");
                            employeeMethod.DisplayAll();
                            break;
                        case "2":
                           
                            SearchEmp(employeeQuery,employeeMethod);
                            break;
                        case "3":
                            Console.Write("Enter id:");
                            int id = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("==== Query ====");
                            if (employeeQuery.Delete(id)) Console.WriteLine("Delete success!!!");
                            else Console.WriteLine("Delete error!!!");
                            Console.WriteLine("==== Method ====");
                            if (employeeMethod.Delete(id)) Console.WriteLine("Delete success!!!");
                            else Console.WriteLine("Delete error!!!");
                            break;
                        case "4":
                            break;
                        default:
                            Console.WriteLine("Error option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choose!="4");
            Console.ReadLine();

        }

        
        public static void SearchEmp(EmployeeQueryRepository employeeQuery, EmployeeMethodRepository employeeMethod)
        {
            string choose;
            do
            {
                Console.WriteLine("========= Search Employee - Employee Management ========");
                Console.WriteLine("1. Search by Id");
                Console.WriteLine("2. Search by name (First name or Last name)");
                Console.WriteLine("3. Search by status");
                Console.WriteLine("4. Search top emloyee by salary");
                Console.WriteLine("5. Check if employee exist");
                Console.WriteLine("6. Exits");
                Console.Write("Enter menu option number:");
                choose = Console.ReadLine();
                Console.Clear();
                switch (choose)
                {
                    case "1":
                        Console.Write("Enter id:");
                        int id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("==== Query ====");
                        if (employeeQuery.FindEmployeeById(id)!=null)
                        Console.WriteLine(employeeQuery.FindEmployeeById(id).ToString());
                        else Console.WriteLine("Not employee have: "+id);
                        Console.WriteLine("==== Method ====");
                        if (employeeMethod.FindEmployeeById(id) != null)
                            Console.WriteLine(employeeMethod.FindEmployeeById(id).ToString());
                        else Console.WriteLine("Not employee have: " + id);
                        break;
                    case "2":
                        Console.Write("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("==== Query ====");
                        if (employeeQuery.FindEmployeesByName(name).Count()==0)
                            Console.WriteLine("Not employee have: "+name);
                       else
                            foreach (var item in employeeQuery.FindEmployeesByName(name))
                            {
                                Console.WriteLine(item.ToString());
                            }
                        Console.WriteLine("==== Method ====");
                        if (employeeMethod.FindEmployeesByName(name).Count() == 0)
                            Console.WriteLine("Not employee have: " + name);
                        else
                            foreach (var item in employeeMethod.FindEmployeesByName(name))
                            {
                                Console.WriteLine(item.ToString());
                            }
                        break;
                    case "3":
                        Console.Write("Enter status (true or false):");
                        bool status =bool.Parse(Console.ReadLine());
                        Console.WriteLine("==== Query ====");
                        if (employeeQuery.FindEmployeesByStatus(status).Count()==0)
                            Console.WriteLine("Not employee have: " + status);
                        else
                            foreach (var item in employeeQuery.FindEmployeesByStatus(status))
                            {
                                Console.WriteLine(item.ToString());
                            }
                        Console.WriteLine("==== Method ====");
                        if (employeeMethod.FindEmployeesByStatus(status).Count() == 0)
                            Console.WriteLine("Not employee have: " + status);
                        else
                            foreach (var item in employeeMethod.FindEmployeesByStatus(status))
                            {
                                Console.WriteLine(item.ToString());
                            }
                        break;
                    case "4":
                        Console.Write("Enter top:");
                        int size = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("==== Query ====");
                        foreach (var item in employeeQuery.FindTopEmployeesBySalary(size))
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine("==== Method ====");
                        foreach (var item in employeeMethod.FindTopEmployeesBySalary(size))
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case "5":
                        Console.Write("Enter id:");
                        int id1 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("==== Query ====");
                        if (employeeQuery.Exist(id1))
                        Console.WriteLine("Have employee have id: "+ employeeQuery.FindEmployeeById(id1).Id);
                        else Console.WriteLine("No employee have id: "+id1);
                        Console.WriteLine("==== Method ====");
                        if (employeeMethod.Exist(id1))
                            Console.WriteLine("Have employee have id: " + employeeMethod.FindEmployeeById(id1).Id);
                        else Console.WriteLine("No employee have id: " + id1);
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Error option!");
                        break;
                }
            } while (choose != "6");
        }
    }
}
