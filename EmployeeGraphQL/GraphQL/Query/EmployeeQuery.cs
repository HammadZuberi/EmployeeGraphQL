using EmployeeGraphQL.GraphQL.Types;
using EmployeeGraphQL.Services;
using GraphQL;
using GraphQL.Types;

namespace EmployeeGraphQL.GraphQL.Query
{
	public class EmployeeQuery : ObjectGraphType
	{
		public EmployeeQuery(IEmployeeRepository employeeRepository)
		{
			//define query
			//obsolet
			//        Field<ListGraphType<EmployeeType>>("employees", "Return all the employees",
			//resolve: context => employeeRepository.GetAllEmployees());

			Field<ListGraphType<EmployeeType>>("employees").Description("Return All Employees")
				.ResolveAsync(async context => await employeeRepository.GetAllEmployeesAsync());


			Field<EmployeeType>("employee")
				.Description("Return Single Employee")
				.Argument<NonNullGraphType<IdGraphType>>("id","id of employee")
				.Resolve(context => {
					var id = context.GetArgument<int>("id");
					return employeeRepository.GetEmployeeById(id);
					});
			//or
			//Field<EmployeeType>("employee")
			//	.Description("Return Single Employee")
			//	.Arguments(new QueryArguments(
			//			new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "ID of the employee" }))
			//	.Resolve(context => {
			//		var id = context.GetArgument<int>("id");
			//		return employeeRepository.GetEmployeeById(id);
			//	});

		}
	}
}
