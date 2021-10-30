using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPL.M.A011.EmployeeManagement
{
    interface IEmployeeRepository
    {
        List<Employee> employees { get; set; }
        Employee FindEmployeeById(int id);
        IEnumerable<Employee> FindEmployeesByName(string name);
        IEnumerable<Employee> FindTopEmployeesBySalary(int size);
        IEnumerable<Employee> FindEmployeesByStatus(bool status);
        bool Exist(int id);
        bool Delete(int id);
    }
}
