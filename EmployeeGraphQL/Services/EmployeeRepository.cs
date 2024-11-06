using EmployeeGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeGraphQL.Services
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly EntityDataContext _dbContext;

		public EmployeeRepository(EntityDataContext dbContext)
		{
			this._dbContext = dbContext;
		}


		public async Task<List<Employee>> GetAllEmployeesAsync()
		{

			return await _dbContext.Employees.Include(r=> r.Reviews).ToListAsync();

		}

		public List<Employee> GetAllEmployees()
		{

			return _dbContext.Employees.Include(r => r.Reviews).ToList();
		}

		public Employee GetEmployeeById(int id)
		{


			var employee = _dbContext.Employees.SingleOrDefault(e => e.Id == id);

			if (employee == null)
				throw new ArgumentNullException("Employee not found");

			return employee;
		}


		public Employee GetEmployeeByName(string name)
		{


			var employee = _dbContext.Employees.SingleOrDefault(e => e.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase));

			if (employee == null)
				throw new ArgumentNullException("Employee not found");

			return employee;
		}


		public Employee AddEmployee(Employee employee)
		{
			_dbContext.Employees.Add(employee);
			_dbContext.SaveChanges();
			return employee;

		}

		public Employee? UpdateEmployee(int id, Employee employee)
		{

			var _employee = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

			if (_employee != null)
			{
				_employee.Title = employee.Title;
				_employee.FirstName = employee.FirstName;
				_employee.LastName = employee.LastName;
				_employee.Email = employee.Email;


			}
			_dbContext.SaveChanges();
			return _employee;

		}

		public bool DeleteEmployee(int employeeId)
		{
			var _employee = _dbContext.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

			if (_employee != null)
			{
				_dbContext.Remove(_employee);
				_dbContext.SaveChanges();
			}

			return true;

		}

	}
}
