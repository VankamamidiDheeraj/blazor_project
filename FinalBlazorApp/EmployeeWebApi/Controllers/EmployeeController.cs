using EmployeeLibrary.Models;
using EmployeeLibrary.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository EmployeeRepository;
        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            this.EmployeeRepository = EmployeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Employee> employees = await EmployeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{eid}")]
        public async Task<ActionResult> Get(int eid)
        {
            try
            {
                Employee employee = await EmployeeRepository.GetEmployeeAsync(eid);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token,Employee employee)
        {
            try
            {
                await EmployeeRepository.InsertEmployeeAsync(employee);  
                HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5170/api/Trainee/") };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                await client.PostAsJsonAsync("Employee", new { employee.EmpId });
                return Created($"api/Employee/{employee.EmpId}", employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{eid}")]
        public async Task<ActionResult> Put(int eid ,Employee employee)
        {
            try
            {
                await EmployeeRepository.UpdateEmployeeAsync(eid,employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{eid}")]
        public async Task<ActionResult> Delete(int eid)
        {
            try
            {
                await EmployeeRepository.DeleteEmployeeAsync(eid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
