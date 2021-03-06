    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL.M.A011.EmployeeManagement
{
    class EmployeeMethodRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>()
        {
               new Employee(1, "Nguyen", " Anh", "na@gmmai.com", new DateTime(200, 12, 12), true, 1000, "1", "FA"),
               new Employee(2, "Mai", "Anh", "ma@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(3, "Hai", "Anh", "ha@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(4, "Tuan", "Anh", "ta@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(5, "Do", "Anh", "da@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(6, "Nguyen", "Binh", "nb@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(7, "Mai", "Binh", "mb@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(8, "Le", "Binh", "lb@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(9, "Do", "Binh", "db@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(10, "Tran", "Cong", "tc@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(11, "Nguyen", "Cong", "nc@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(12, "Tuan", "Cong", "tc@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(13, "Nguyen", "Doanh", "nd@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(14, "Tran", "Doanh", "td@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(15, "Hoang", "Doanh", "hd@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(16, "Tran", "Giang", "tg@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(17, "Nguyen", "Giang", "ng@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(18, "Do", "Giang", "dg@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(19, "Do", "Ngoc", "dn@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
               new Employee(20, "Tran", "Ngoc", "tn@gmmai.com", new DateTime(2000,12,12), true, 1000, "1", "FA"),
        };

        List<Employee> IEmployeeRepository.employees { get => employees; set => employees = value; }

        public bool Delete(int id)
        {
            var employee = FindEmployeeById(id);
            if (employee!=null)
            {
                employees.Remove(employee);
                return true;
            }
            return false;
        }

        public bool Exist(int id)
        {
            if (FindEmployeeById(id)!=null)
            {
                return true;
            }
            return false;
        }

        public Employee FindEmployeeById(int id)
        {
            var employee = employees.Where(s => s.Id == id);
            return employee.FirstOrDefault();
        }

        public IEnumerable<Employee> FindEmployeesByName(string name)
        {
            var employee = employees.Where(s => s.LastName == name || s.FirstName == name);
            if (employee.Count() == 0) return null;
            return employee;
        }

        public IEnumerable<Employee> FindEmployeesByStatus(bool status)
        {
            var employee = employees.Where(s => s.Status == status);
            if (employee.Count() == 0) return null;
            return employee;
        }

        public IEnumerable<Employee> FindTopEmployeesBySalary(int size)
        {
            var employee = employees.OrderByDescending(s => s.Salary);
            return employee.Take(size);
        }
        public void DisplayAll()
        {
            var listEmployee = employees.OrderBy(s => s.FirstName);

            foreach (var item in listEmployee)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
