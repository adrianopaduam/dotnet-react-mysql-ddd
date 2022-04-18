using ProductSeller.Domain.Entities;
using ProductSeller.Domain.Interfaces;
using ProductSeller.Service.Services;
using ProductSeller.Infrastructure.Data.Query;
using ProductSeller.Infrastructure.Data.Context;
using ProductSeller.Infrastructure.Data.Repository;
using ProductSeller.Infrastructure.Data.Mapping;

var builder = WebApplication.CreateBuilder(args);

DatabaseContext databaseContext = new DatabaseContext();
builder.Configuration.GetSection(DatabaseContext.SectionName).Bind(databaseContext);
builder.Services.AddSingleton<IDatabaseContext>(databaseContext);

builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();
builder.Services.AddScoped<IBaseService<Product>, BaseService<Product>>();
builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
builder.Services.AddScoped<IQueryBuilder<User>, UserQueryBuilder<User>>();
builder.Services.AddScoped<IQueryBuilder<Product>, ProductQueryBuilder<Product>>();
builder.Services.AddScoped<IEntityMapper<User>, UserEntityMapper<User>>();
builder.Services.AddScoped<IEntityMapper<Product>, ProductEntityMapper<Product>>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
