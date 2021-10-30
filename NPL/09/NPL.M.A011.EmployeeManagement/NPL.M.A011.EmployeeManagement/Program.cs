using System;

namespace NPL.M.A011.EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeQueryRepository employeeQueryRepository = new EmployeeQueryRepository();
            EmployeeMethodRepository employeeMethodRepository = new EmployeeMethodRepository();
            int pick;

            do
            {
                Console.WriteLine("==================================== Assignment 14 - Employee Management ===============================");
                Console.WriteLine("1. Display All");
                Console.WriteLine("2. Search Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Exit");
                Console.Write("Enter menu option number: ");
                pick = Int32.Parse(Console.ReadLine());

                switch (pick)
                {
                    case 1:
                        {
                            Console.WriteLine("=> Employee: ");
                            employeeQueryRepository.DisplayAll();
                            Console.WriteLine("=> Employee Method: ");
                            employeeMethodRepository.DisplayAll();
                            break;
                        } 
                    case 2:
                        {
                            SearchEmp(employeeQueryRepository, employeeMethodRepository);
                            break;
                        } 
                    case 3:
                        {
                            Console.Write("Enter Employee id: ");
                            int id = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("=> Employee: ");
                            if (employeeQueryRepository.Delete(id))
                            {
                                Console.WriteLine("Delete successfully");
                            }
                            else
                            {
                                Console.WriteLine("Cant to delete this employee");
                            }

                            Console.WriteLine("=> Employee Method: ");
                            if (employeeMethodRepository.Delete(id))
                            {
                                Console.WriteLine("Delete success!!!");
                            }
                            else
                            {
                                Console.WriteLine("Cant to delete this employee!!!");
                            }
                            break;
                        }
                    case 4:
                        return;
                    default:
                        {
                            Console.WriteLine("Pick number: 1->4");
                            break;
                        }       
                }
            } while (true);

        }
        private static void SearchEmp(EmployeeQueryRepository employeeQueryRepository, EmployeeMethodRepository employeeMethodRepository)
        {
            int pick;

            do
            {
                Console.WriteLine("====================================  Search Employee - Employee Management ==================================== ");
                Console.WriteLine("1. Search by Id");
                Console.WriteLine("2. Search by name (First name or Last name)");
                Console.WriteLine("3. Search by status");
                Console.WriteLine("4. Search top emloyee by salary");
                Console.WriteLine("5. Check if employee exist");
                Console.WriteLine("6. Exits");
                Console.Write("Enter menu option number: ");
                pick = Int32.Parse(Console.ReadLine());

                switch(pick)
                {
                    case 1:
                        {
                            Console.Write("Enter id: ");
                            int id = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("=> Employee Query: ");
                            if (employeeQueryRepository.FindEmployeeById(id) != null)
                            {
                                Console.WriteLine(employeeQueryRepository.FindEmployeeById(id).ToString());
                            }
                            else
                            {
                                Console.WriteLine("Cant find employee: " + id);
                            }

                            Console.WriteLine("=> Employee Method: ");
                            if (employeeMethodRepository.FindEmployeeById(id) != null)
                            {
                                Console.WriteLine(employeeMethodRepository.FindEmployeeById(id).ToString());
                            }
                            else
                            {
                                Console.WriteLine("Cant find employee: " + id);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter first name or last name: ");

                            string strName = Console.ReadLine();
                            Console.WriteLine("=> Employee Query: ");
                            var listEmployee = employeeQueryRepository.FindEmployeesByName(strName);
                            if (listEmployee!=null)
                            {
                                foreach (var item in listEmployee)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }  
                            else
                            {
                                Console.WriteLine("Cant find any employee with: " + strName);
                            }


                            Console.WriteLine("=> Employee Method: ");
                            listEmployee = employeeMethodRepository.FindEmployeesByName(strName);
                            if (listEmployee != null)
                            {
                                foreach (var item in listEmployee)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cant find any employee with: " + strName);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter status (true or false only): ");

                            bool status = Boolean.Parse(Console.ReadLine());
                            Console.WriteLine("=> Employee Query : ");
                            var listEmployee = employeeQueryRepository.FindEmployeesByStatus(status);
                            if (listEmployee != null)
                            {
                                foreach (var item in listEmployee)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cant find any employee with: " + status);
                            }


                            Console.WriteLine("=> Employee Method: ");
                            listEmployee = employeeMethodRepository.FindEmployeesByStatus(status);
                            if (listEmployee != null)
                            {
                                foreach (var item in listEmployee)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cant find any employee with: " + status);
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Enter size of top: ");

                            int top = int.Parse(Console.ReadLine());
                            Console.WriteLine("=> Employee Query: ");
                            var listEmployee = employeeQueryRepository.FindTopEmployeesBySalary(top);
                            if (listEmployee!=null)
                            {
                                foreach (var item in listEmployee)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cant find any employee with: " + top);
                            }


                            Console.WriteLine("=> Employee Method: ");
                            listEmployee = employeeMethodRepository.FindTopEmployeesBySalary(top);
                            if (listEmployee != null)
                            {
                                foreach (var item in listEmployee)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cant find any employee with: " + top);
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Enter id: ");
                            int id = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("=> Employee Query: ");
                            if (employeeQueryRepository.Exist(id))
                            {
                                Console.WriteLine("Employee" + id + "exist");
                            }
                            else
                            {
                                Console.WriteLine("Not Exist employee: " + id);
                            }

                            Console.WriteLine("=> Employee Method: ");
                            if (employeeQueryRepository.Exist(id))
                            {
                                Console.WriteLine("Employee Exist");
                            }
                            else
                            {
                                Console.WriteLine("Not Exist employee: " + id);
                            }
                            break;
                        }
                    case 6:
                        return;
                    default:
                        {
                            Console.WriteLine("Pick number: 1->6");
                            break;
                        }
                }
            } while (true);
        }
    }
}
