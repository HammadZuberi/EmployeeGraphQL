using GraphQL.Types;

namespace EmployeeGraphQL.GraphQL.Types
{
	public class ReviewInputType :ObjectGraphType
	{

        public ReviewInputType()
        {
            Name = "ReviewInputType";
            Field<IntGraphType, int>("Rate");
            Field<StringGraphType, string>("Comment");
        }

    }
}
