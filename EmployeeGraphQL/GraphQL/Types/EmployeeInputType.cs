using GraphQL.Types;

namespace EmployeeGraphQL.GraphQL.Types
{
	public class EmployeeInputType :InputObjectGraphType

	{
        public EmployeeInputType()
        {
			Name = "EmployeeInputType";
			Field<StringGraphType>("FirstName");
			Field<StringGraphType>("LastName");
			Field<StringGraphType>("Email");
			Field<StringGraphType>("Title");

			//adding review for em
			Field<ListGraphType<ReviewInputType>>("Reviews");
		}

    }
}
