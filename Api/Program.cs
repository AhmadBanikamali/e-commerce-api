using Application.Common;
using Application.Common.Mapper;
using Application.ProductService.Category.Command;
using Application.ProductService.Category.Command.Dto;
using Application.ProductService.Category.Query;
using Application.ProductService.Product.Command.Create;
using Application.ProductService.Product.Query.Single;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqlServerDbContext>(optionsAction: optionsBuilder =>
{ 
    optionsBuilder.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("ecommerce")); 
});

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<SqlServerDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAutoMapper(typeof(ProductMapper));


builder.Services.AddTransient<IDatabaseContext,SqlServerDbContext>();
builder.Services.AddTransient<CreateProductService>();
builder.Services.AddTransient<CreateCategoryService>();
builder.Services.AddTransient<GetCategoriesService>();
builder.Services.AddTransient<GetSingleProductService>();

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