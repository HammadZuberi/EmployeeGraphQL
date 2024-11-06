using EmployeeGraphQL.Models;
using GraphQL.Types;

namespace EmployeeGraphQL.GraphQL.Types
{
	public class ReviewType : ObjectGraphType<Review>
	{
		public ReviewType()
		{
			Field(e => e.Id, typeof(IdGraphType)).Description("Id Property of Review");
			Field(e => e.Rate, typeof(StringGraphType)).Description("Email Property of Review");
			Field(e => e.Comments, typeof(StringGraphType)).Description("Firstname Property of Review");

		}
	}
}
