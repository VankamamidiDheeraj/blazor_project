using EmployeeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary.Repository
{
    public interface IEmployeeRepository
    {
        Task InsertEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(int eid, Employee employee);
        Task DeleteEmployeeAsync(int eid);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int eid);
    }
}
