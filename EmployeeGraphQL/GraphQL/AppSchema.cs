using EmployeeGraphQL.GraphQL.Mutation;
using EmployeeGraphQL.GraphQL.Query;
using GraphQL.Types;

namespace EmployeeGraphQL.GraphQL
{
	public class AppSchema : Schema
	{
        //public AppSchema(IServiceProvider serviceProvider) :base(serviceProvider)
        //{
        //    Query = serviceProvider.GetRequiredService<EmployeeQuery>();
            
        //}
		public AppSchema(EmployeeQuery query,EmployeeMutation mutation)
		{
			this.Query = query;
			this.Mutation = mutation;
		}
		


	}
}
