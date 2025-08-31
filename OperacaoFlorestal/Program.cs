using Microsoft.EntityFrameworkCore;
using OperacaoFlorestal.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionStrings:OperacaoFlorestalConnection"];

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<OperacaoFlorestalContext>(opts =>
    opts.UseLazyLoadingProxies().UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString))
);


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
