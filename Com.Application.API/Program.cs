using Com.Application.API.CustomMiddlewares;
using Com.Application.DataAccess.Models;
using Com.Application.Entities;
using Com.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. REgister the EF COre in DI COntainer as Service
builder.Services.AddDbContext<CompanyContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr"));
});




// Accept Request for API Controllers
builder.Services.AddControllers()
        .AddJsonOptions(options=> {
            // suressing the Camel-Casing
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Service REgisteration for Exposting the Swagger Page for API Testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Custom Services
                        // INterface                , Class Implementing interface
builder.Services.AddScoped<IDbAccess<Department,int>, DepartmentDbAccess>();


var app = builder.Build();
// 2. Configura Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// The Custom Middleware
app.UseCustomException();


// 3. Map the Incomming request to API Controller
app.MapControllers();
// Run the App in Hosting Env
app.Run();
