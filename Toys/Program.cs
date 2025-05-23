using Microsoft.EntityFrameworkCore;
using Reposirories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddDbContext<ToysContext>(option => option.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=Toys;Integrated Security=True;TrustServerCertificate=True"));


//var app = builder.Build();
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
builder.Services.AddControllers();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseHttpsRedirection();





// Configure the HTTP request pipeline.


app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
