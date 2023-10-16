using Microsoft.EntityFrameworkCore;
using MyShopApi.Middlewares;
using MyShopApi.Repositories;
using MyShopApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// repository
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

// persistence
builder.Services.AddTransient<IPersistence, DbPersistence>();

// service
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPurchaseService, PurchaseService>();

// exception middleware
builder.Services.AddTransient<HandleExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<HandleExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();