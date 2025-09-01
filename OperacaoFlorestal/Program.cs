using Microsoft.EntityFrameworkCore;
using OperacaoFlorestal.Data;
using OperacaoFlorestal.Profiles;
using OperacaoFlorestal.Repositories;
using OperacaoFlorestal.Repositories.Interfaces;
using OperacaoFlorestal.Services;
using OperacaoFlorestal.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("OperacaoFlorestalConnection");

// Add services to the container.
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra serviços
builder.Services.AddScoped<IMaquinarioRepository, MaquinarioRepository>();
builder.Services.AddScoped<IVooVantRepository, VooVantRepository>();

builder.Services.AddScoped<IMaquinarioService, MaquinarioService>();
builder.Services.AddScoped<IVooVantService, VooVantService>();

builder.Services.AddScoped<IColetaDadosService, ColetaDadosService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ColetaDadosProfile>();
    cfg.AddProfile<MaquinarioProfile>();
    cfg.AddProfile<VooVantProfile>();
});

builder.Services.AddDbContext<OperacaoFlorestalContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        x => x.UseNetTopologySuite())
);

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
