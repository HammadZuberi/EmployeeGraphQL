using EmployeeGraphQL.Services;
using Microsoft.EntityFrameworkCore;
using GraphQL;
using EmployeeGraphQL.GraphQL;
using EmployeeGraphQL.GraphQL.Query;
using GraphiQl;
using EmployeeGraphQL.GraphQL.Mutation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeQuery>();
//builder.Services.AddScoped<ISchema,AppSchema>();
builder.Services.AddScoped<EmployeeMutation>();


builder.Services.AddGraphQL(builder => builder
	.AddSystemTextJson()
	.AddSchema<AppSchema>(GraphQL.DI.ServiceLifetime.Scoped)
		.AddGraphTypes(typeof(AppSchema).Assembly)
	);

var conn = builder.Configuration.GetConnectionString("DbConnection");



builder.Services.AddDbContext<EntityDataContext>(
	opt => opt.UseSqlServer(conn,
	sqlServerOptions => sqlServerOptions.CommandTimeout(60))
	//, ServiceLifetime.Transient
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//schema
app.UseGraphQL<AppSchema>();
app.UseGraphiQl("/ui/graphql");
app.Run();
