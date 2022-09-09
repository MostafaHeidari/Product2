
using API.DTOs;
using AutoMapper;
using Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlite(

    //we put the connection string SQLite, but her the file is on our pc witch has name db.db
    "Data source=db.db"
));


builder.Services.AddDbContext<CategoryDbContext>(options => options.UseSqlite(

    //we put the connection string SQLite, but her the file is on our pc witch has name db.db
    "Data source=db.db"
));

builder.Services.AddScoped<ProductRepository>();

// make new mapper configruamtion her 
var config = new MapperConfiguration(conf =>
{
    conf.CreateMap<PostProductDTO, Product>();
});

// make new mapper configruamtion her 
var config2 = new MapperConfiguration(conf =>
{
    conf.CreateMap<PostCategoryDTO, Product>();
});

var mapper2 = config2.CreateMapper();
builder.Services.AddSingleton(mapper2);

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

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
