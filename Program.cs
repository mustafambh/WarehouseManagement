using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Application.Mappings;
using WarehouseManagement.Application.Services;
using WarehouseManagement.Application.Services.Interfaces;
using WarehouseManagement.Core.Interfaces;
using WarehouseManagement.Infrastructure;
using WarehouseManagement.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ======= DbContext =======
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

// ======= AutoMapper =======
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// ======= UnitOfWork & Services =======
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStockItemService, StockItemService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IStockTransactionServices, StockTransactionServices>();

// ======= Controllers & Swagger =======
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ======= HTTP Pipeline =======
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
