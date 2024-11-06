using EmployeeGraphQL.GraphQL.Types;
using EmployeeGraphQL.Models;
using EmployeeGraphQL.Services;
using GraphQL;
using GraphQL.Types;

namespace EmployeeGraphQL.GraphQL.Mutation
{
	public class EmployeeMutation:ObjectGraphType
	{

        //mutation are used to modify a data in data source
        //eg post, delete,update
        public EmployeeMutation(IEmployeeRepository employeeRepository)
        {


			Field<EmployeeType>("addemployee")
				.Description("add new employee Return Single Employee")
				.Argument<NonNullGraphType<EmployeeInputType>>("employee", "object of employee")
				.Resolve(context => {
					var employee = context.GetArgument<Employee>("employee");
					if (employee != null)
					{
						return employeeRepository.AddEmployee(employee);
					}
					return null;
				});



			Field<EmployeeType>("updateemployee")
				.Description("update new employee Return Single Employee")
				.Argument<NonNullGraphType<IdGraphType>>("id", "id of employee")
				.Argument<NonNullGraphType<EmployeeInputType>>("employee", "update of employee")
				.Resolve(context => {
					var id = context.GetArgument<int>("id");	
					var employee = context.GetArgument<Employee>("employee");
					if (employee != null)
					{
						return employeeRepository.UpdateEmployee(id,employee);
					}
					return null;
				});

			Field<EmployeeType>("deleteemployee")
			.Description("delete new employee Return Single Employee")
			.Argument<NonNullGraphType<IdGraphType>>("id", "id of employee")
			.Resolve(context => {
				var id = context.GetArgument<int>("id");
				
					return employeeRepository.DeleteEmployee(id);
				
			});

		}
    }
}
