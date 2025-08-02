using ECommerceBackend.Helper;
using ECommerceBackend.Interceptors;
using ECommerceBackend.Models;
using ECommerceBackend.Repositories;
using ECommerceBackend.Repositories.ProductService.IRepositories;
using ECommerceBackend.Repositories.ProductService.Rep;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<AuditInterceptor>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Đăng ký DbContext
builder.Services.AddDbContext<ECommerceMicroserviceContext>((serviceProvider, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.AddInterceptors(serviceProvider.GetRequiredService<AuditInterceptor>());
});


// Đăng ký Repository
builder.Services.AddScoped<IProductCategoryRep, ProductCategoryRep>();
builder.Services.AddScoped<IProductDescriptionRep, ProductDescriptionRep>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductsRep, ProductsRep>();
builder.Services.AddScoped<ICategoryRep, CategoryRep>();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Mở Swagger cho tất cả môi trường (bạn có thể giữ nguyên điều kiện Development nếu muốn bảo mật)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
