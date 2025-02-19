using AppServices.Products.Services;
using AppServices.Users.Services;
using DataAccess.Data;
using DataAccess.Repositories;
using Domain;
using Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddSingleton(typeof(IRepository<User>), (sp) =>
new InMemoryRepository<User>(FakeDataFactory.Users));
builder.Services.AddSingleton(typeof(IRepository<Product>), (sp) =>
new InMemoryRepository<Product>( new List<Product>()));


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
