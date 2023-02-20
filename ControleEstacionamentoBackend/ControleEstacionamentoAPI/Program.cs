using ControleEstacionamento.Application.Mappers.Profiles;
using ControleEstacionamento.Application.Services;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Domain.Interfaces.Services;
using ControleEstacionamento.Infra.Data;
using ControleEstacionamento.Infra.Data.Context;
using ControleEstacionamento.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(RegistroProfile));

// Dependency Injection

builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(ICarroRepository), typeof(CarroRepository));
builder.Services.AddTransient(typeof(IBaseAppService<,>), typeof(BaseAppService<,>));
builder.Services.AddTransient(typeof(IRegistroAppService), typeof(RegistroAppService));

builder.Services.AddDbContext<ControleEstacionamentoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        assembly => assembly.MigrationsAssembly(typeof(ControleEstacionamentoDbContext).Assembly.FullName));
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
