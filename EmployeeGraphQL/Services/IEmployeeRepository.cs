using EmployeeGraphQL.Models;

namespace EmployeeGraphQL.Services
{
	public interface IEmployeeRepository
	{
		Employee AddEmployee(Employee employee);
		bool DeleteEmployee(int employeeId);
		List<Employee> GetAllEmployees();
		Task<List<Employee>> GetAllEmployeesAsync();
		Employee GetEmployeeById(int id);
		Employee GetEmployeeByName(string name);
		Employee? UpdateEmployee(int id,Employee employee);
	}
}