using LoanCalculator.Api.Contracts;
using LoanCalculator.Api.Contracts.Repositories;
using LoanCalculator.Api.Repositories;
using LoanCalculator.Api.Services;
using LoanCalculator.Api.Services.AgeBracketLoanCalculators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<ILoanCalculatorService, LoanCalculatorService>();
builder.Services.AddSingleton<ILoanCalculationStrategyFactory, LoanCalculationStrategyFactory>();

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
