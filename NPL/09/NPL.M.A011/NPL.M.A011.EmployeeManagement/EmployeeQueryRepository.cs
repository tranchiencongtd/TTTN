using System;
using System.Collections.Generic;
using System.Linq;

namespace NPL.M.A011.EmployeeManagement
{
    internal class EmployeeQueryRepository : IEmployeeRepository
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

        List<Employee> IEmployeeRepository.employees
        {
            get => employees;
            set => employees = value;
        }
       
        public bool Delete(int id)
        {
            var empDel = FindEmployeeById(id);
            if (empDel != null)
            {
                employees.Remove(empDel);
                return true;
            }
            return false;
        }

        public bool Exist(int id)
        {
            var empEx = FindEmployeeById(id);
            if (empEx != null) return true;
            else return false;
        }

        public Employee FindEmployeeById(int id)
        {
            var emp = from s in employees where s.Id == id select s;
            return emp.FirstOrDefault();
        }

        public IEnumerable<Employee> FindEmployeesByName(string name)
        {
            var empName = from s in employees where s.FirstName == name || s.LastName == name select s;
            return empName;
        }

        public IEnumerable<Employee> FindEmployeesByStatus(bool status)
        {
            var empStatus = from s in employees where s.Status==status select s;
            return empStatus;
        }

        public IEnumerable<Employee> FindTopEmployeesBySalary(int size)
        {
            var empSalary = from s in employees orderby s.Salary descending select s;
            return empSalary.Take(size);
        }

        public void DisplayAll()
        {
            var emp = from s in employees orderby s.FirstName select s;
            foreach (var item in emp)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}