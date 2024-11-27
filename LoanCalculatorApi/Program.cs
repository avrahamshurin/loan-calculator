using LoanCalculatorApi.Contracts;
using LoanCalculatorApi.Contracts.Repositories;
using LoanCalculatorApi.Repositories;
using LoanCalculatorApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<ILoanCalculator, LoanCalculator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
