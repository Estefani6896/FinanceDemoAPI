using FinanceDemo.Application.Interfaces.Repositories;
using FinanceDemo.Application.Interfaces.Services;
using FinanceDemo.Application.UseCases.ExchangeRate;
using FinanceDemo.Application.UseCases.Income;
using FinanceDemo.Application.UseCases.Reports;
using FinanceDemo.Infrastructure.Persistence;
using FinanceDemo.Infrastructure.Repositories;
using FinanceDemo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region Database

builder.Services.AddDbContext<FinanceDemoDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion

#region Dependency Injection

builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();

builder.Services.AddHttpClient<IExchangeRateService, HexaRateService>();

builder.Services.AddScoped<CreateIncomeUseCase>();
builder.Services.AddScoped<GetAllIncomeUseCase>();
builder.Services.AddScoped<GetIncomeByIdUseCase>();
builder.Services.AddScoped<GetExchangeRateUseCase>();
builder.Services.AddScoped<GetConsolidatedBalanceUseCase>();

#endregion

#region Controllers

builder.Services.AddControllers();

#endregion

#region Swagger

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FinanceDemo API",
        Version = "v1",
        Description = "Personal Financial Management API"
    });

    var xmlFile =
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath =
        Path.Combine(AppContext.BaseDirectory, xmlFile);

    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

#endregion

#region CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

#endregion

var app = builder.Build();

#region Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "FinanceDemo API v1");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();