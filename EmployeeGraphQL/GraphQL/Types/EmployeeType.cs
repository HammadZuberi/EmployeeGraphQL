using EmployeeGraphQL.Models;
using GraphQL.Types;

namespace EmployeeGraphQL.GraphQL.Types
{
	public class EmployeeType : ObjectGraphType<Employee>
	{
		public EmployeeType()
		{
			Field(e => e.Id, typeof(IdGraphType)).Description("Id Property of Employee");
			Field(e => e.Email, typeof(StringGraphType)).Description("Email Property of Employee");
			Field(e => e.FirstName, typeof(StringGraphType)).Description("Firstname Property of Employee");
			Field(e => e.LastName, typeof(StringGraphType)).Description("Lastname Property of Employee");
			Field(e => e.Title, typeof(StringGraphType)).Description("Title Property of Employee");

			//one to many relationship
			Field(e => e.Reviews, typeof(ListGraphType<ReviewType>)).Description("list of review for Employee");


		}
	}
}
