using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using CombinedAPI.Repositories;
using CombinedAPI.Services;
using CombinedAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Repositories and pass the connection string via IConfiguration
builder.Services.AddScoped<IProductRepository>(provider =>
    new ProductRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICartRepository>(provider =>
    new CartRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository>(provider =>
    new UserRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISaleRepository>(provider =>
    new SaleRepository(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Accessors
builder.Services.AddScoped<ICartAccessor, CartAccessor>();
builder.Services.AddScoped<IProductAccessor, ProductAccessor>();
builder.Services.AddScoped<IUserAccessor, UserAccessor>();

// Register Services
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IProductEngine, ProductEngine>();
builder.Services.AddScoped<ICartManager, CartManager>();
builder.Services.AddScoped<ICartEngine, CartEngine>();
builder.Services.AddScoped<ISaleEngine, SaleEngine>();

// Add Swagger and OpenAPI documentation
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

app.MapControllers();

app.Run();
