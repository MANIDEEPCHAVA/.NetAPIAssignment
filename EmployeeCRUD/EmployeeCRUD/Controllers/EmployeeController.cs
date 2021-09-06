using EmployeeCRUD.IServices;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeservice)
        {
            employeeService = employeeservice;
        }

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await employeeService.GetAllEmployees();
        }

        [HttpPost("create")]
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await employeeService.CreateEmployee(employee);
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await employeeService.GetEmployeeById(id);
        }

        [HttpPut]
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await employeeService.UpdateEmployee(employee);
        }


        [HttpDelete("{id}")]
        public async Task<Employee> DeleteEmployee(int id)
        {
            return await employeeService.DeleteEmployee(id);
        }
    }
}
