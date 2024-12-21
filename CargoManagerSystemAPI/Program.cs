using CargoBusiness.Services;
using CargoData.DataContext;
using CargoData.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//read coonection string from appsetting.json file
string conStr = builder.Configuration.GetConnectionString("sqlcon");

//add connection string
builder.Services.AddDbContext<CargoDbContext>(obj => obj.UseSqlServer(conStr));

builder.Services.AddScoped<AdminService, AdminService>();
builder.Services.AddScoped<IAdminRepo, AdminRepository>();

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepository>();
builder.Services.AddScoped<EmployeeService, EmployeeService>();

builder.Services.AddScoped<ICustomerRepo, CustomerRepository>();
builder.Services.AddScoped<CustomerService,CustomerService>();


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors((setup) =>

{
    setup.AddPolicy("default",(options)=>
    {
                options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();
