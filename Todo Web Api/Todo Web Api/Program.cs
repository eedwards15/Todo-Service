using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(TaskAutoMapperProfile));


string connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");
string password = Environment.GetEnvironmentVariable("SQL_SERVER_PASSWORD");
string username = Environment.GetEnvironmentVariable("SQL_SERVER_USERNAME");
connectionString = connectionString.Replace("{password}", password);
connectionString = connectionString.Replace("{usernme}", username);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));


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

app.Run();
