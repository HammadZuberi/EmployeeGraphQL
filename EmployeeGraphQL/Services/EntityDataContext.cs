using EmployeeGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeGraphQL.Services
{
	public class EntityDataContext : DbContext
	{
		public EntityDataContext(DbContextOptions<EntityDataContext> options) : base(options)
		{


		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Review> Reviews { get; set; }
	}
}
