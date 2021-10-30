using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL.M.A011.EmployeeManagement
{
    class EmployeeMethodRepository : IEmployeeRepository
    {
        List<Employee> employees = new List<Employee>()
            {
               new Employee(1, "Hoang", "Mai Anh", "maianh@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(2, "Nham", "Anh", "nhamanh@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(3, "Nguyen", "Tung", "nguyentung@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(4, "Tran", "Mai", "tranmai@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(5, "Dinh", "Quy", "dinhquy@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(6, "Kim", "Son", "kimson@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(7, "Dao", "Thanh", "daothanh@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(8, "Le", "My", "lemy@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(9, "Nguyen", "Tu", "nguyentu@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(10, "Nguyen", "Cong", "nguyencong@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(11, "Nguyen", "Thinh", "nguyenthinh@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(12, "Nguyen", "Hai", "nguyenhai@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(13, "Nguyen", "Hoang", "nguyenhoang@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(14, "Tran", "Bang", "tranbang@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(15, "Hoang", "Hoa", "hoanghoa@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(16, "Tran", "Trang", "trantrang@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(17, "Dinh", "Son", "dinhson@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(18, "Tu", "Mai Anh", "tuanh@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(19, "Anh", "Ngoc", "anhngoc@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
               new Employee(20, "Tran", "Lien", "tranlien@gmmai.com", new DateTime(2000, 1, 1), true, 2000000, "1", "Software"),
            };

        List<Employee> IEmployeeRepository.employees
        { 
            get =>  employees; 
            set => employees=value; 
        }

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
            return employees.Exists(x => x.Id == id);
        }

        public Employee FindEmployeeById(int id)
        {
            var emp = employees.Where(s => s.Id==id);
            return emp.FirstOrDefault();
        }

        public IEnumerable<Employee> FindEmployeesByName(string name)
        {
            var emp = employees.Where(s => s.FirstName == name || s.LastName==name);
            return emp;
        }

        public IEnumerable<Employee> FindEmployeesByStatus(bool status)
        {
            var emp = employees.Where(s => s.Status==status);
            return emp;
        }

        public IEnumerable<Employee> FindTopEmployeesBySalary(int size)
        {
            var emp = employees.OrderByDescending(s => s.Salary);
            return emp.Take(size);
        }
        public void DisplayAll()
        {
            var emp = employees.OrderBy(s => s.FirstName);
            foreach (var item in emp)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
