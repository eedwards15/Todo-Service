using Database.interfaces;
using Database.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(TaskAutoMapperProfile));
builder.Services.AddTransient<ITodoRepository, TodoRepository>();

string connectionString = builder.Configuration.GetConnectionString("TodoDb");
string password = Environment.GetEnvironmentVariable("SQL_SERVER_PASSWORD") ;
string username = Environment.GetEnvironmentVariable("SQL_SERVER_USERNAME");
connectionString = connectionString.Replace("{password}", password);
connectionString = connectionString.Replace("{username}", username);

builder.Services.AddDbContext<TodoDatabaseContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(connectionString, sqlServerOptions =>
                    sqlServerOptions.MigrationsAssembly("Database"));
            }, ServiceLifetime.Transient);
 

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

app.Run("http://0.0.0.0:8080");
   
