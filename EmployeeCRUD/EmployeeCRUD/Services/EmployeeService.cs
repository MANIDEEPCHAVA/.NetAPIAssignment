using EmployeeCRUD.IServices;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var result = await _context.Employees.Where(x => x.Name == employee.Name).FirstOrDefaultAsync();
            if (result == null)
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var result = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            return result;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var result = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees.Where(x => x.Id == employee.Id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Name = employee.Name;
                result.Age = employee.Age;
                result.Salary = employee.Salary;

                await _context.SaveChangesAsync();
                return result;
            }
            return result;
        }
    }
}
