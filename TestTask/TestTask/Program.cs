

using Microsoft.EntityFrameworkCore;
using TestTask.DataBase;
using TestTask.Mapping;
using TestTask.Models;
using TestTask.Services;
using TestTask.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICrudService<Account>, AccountService>();
builder.Services.AddTransient<ICrudService<Contact>, ContactService>();
builder.Services.AddTransient<ICrudService<Incident>, IncidentService>();
builder.Services.AddAutoMapper(typeof(Program), typeof(AccountToAccountViewModelProfile), typeof(ContactToContactViewModelProfile), typeof(IncidentToIncidentViewModelProfile),typeof(ContactToContactDTOProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConString"));
});

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
