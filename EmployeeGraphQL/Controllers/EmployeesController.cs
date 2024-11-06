using EmployeeGraphQL.Models;
using EmployeeGraphQL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeGraphQL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{

		private readonly IEmployeeRepository _employeeRepository;
		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;

		}
		// GET: api/<EmployeesController>
		[HttpGet]
		public IActionResult Get()
		{
			var employees = _employeeRepository.GetAllEmployees();

			return Ok(employees);
		}

		// GET api/<EmployeesController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var employee = _employeeRepository.GetEmployeeById(id);
			return Ok(employee);
		}

		// POST api/<EmployeesController>
		[HttpPost]
		public IActionResult AddEmployee([FromBody] Employee employee)
		{
			var addEmployee = _employeeRepository.AddEmployee(employee);
			return Ok(addEmployee);

		}

		// PUT api/<EmployeesController>/5
		[HttpPut("{id}")]
		public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
		{
			var updateEmployee = _employeeRepository.UpdateEmployee(employee);
			return Ok(updateEmployee);
		}

		// DELETE api/<EmployeesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_employeeRepository.DeleteEmployee(id);
		}
	}
}
