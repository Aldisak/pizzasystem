using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using PizzaSystem.Application;
using PizzaSystem.Core;
using PizzaSystem.Core.Middleware;
using PizzaSystem.Persistence;
using PizzaSystem.Persistence.DataStorage.Databases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<SqLite>();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.AddErrorHandling());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Validators
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies()
                                                    .First(x => x.GetName().Name == "PizzaSystem.Core"));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddMediatR(
    cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()
                                                       .First(x => x.GetName().Name == "PizzaSystem.Core")));

builder.Services.AddCoreServices();
builder.Services.AddPersistenceServices();

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