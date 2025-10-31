using EmployeeLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary.Repository
{
    public class EFEmployeeRepository:IEmployeeRepository
    {
        ZelisEmployeeDBContext ctx = new ZelisEmployeeDBContext();
        public async Task InsertEmployeeAsync(Employee employee)
        {
            try
            {
                ctx.Employees.AddAsync(employee);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new EmployeeException(ex.Message);
            }
        }

        public async Task UpdateEmployeeAsync(int eid, Employee employee)
        {
            Employee employee2up = await GetEmployeeAsync(eid);
            try
            {
                employee2up.EmpName = employee.EmpName;
                employee2up.Designation = employee.Designation;
                employee2up.Email = employee.Email;
                employee2up.Phone = employee.Phone;

                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new EmployeeException(ex.Message);
            }
        }
        public async Task DeleteEmployeeAsync(int eid)
        {
            Employee employee2del = await GetEmployeeAsync(eid);
            try
            {
                ctx.Employees.Remove(employee2del);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new EmployeeException(ex.Message);
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await ctx.Employees.ToListAsync();

        }

        public async Task<Employee> GetEmployeeAsync(int eid)
        {
            try
            {
                Employee employee = await (from e in ctx.Employees
                                           where e.EmpId == eid
                                           select e).FirstAsync();
                return employee;


            }
            catch (Exception ex)
            {
                throw new EmployeeException("Employee Not Found!");
            }
        }

    }
}

   
