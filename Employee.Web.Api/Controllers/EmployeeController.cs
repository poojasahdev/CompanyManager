using Company.Core.Models;
using Company.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _employeeService.GetAllEmployees();
            return Ok(response);
        }


        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post(AddEmployeeRequest request)
        {
            var response = await _employeeService.AddEmployee(request);
            return Ok(response);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateEmployeeRequest request)
        {
            await _employeeService.UpdateEmployee(id, request);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
