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

// Add CORS Service
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        // All Web Clients are able to Access the API
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
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

// COnfigure CORS Middleware
app.UseCors("CORS");

app.UseAuthorization();

// The Custom Middleware
app.UseCustomException();


// 3. Map the Incomming request to API Controller
app.MapControllers();
// Run the App in Hosting Env
app.Run();
