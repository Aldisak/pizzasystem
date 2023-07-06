using PizzaSystem.Application;
using PizzaSystem.Core;
using PizzaSystem.Persistence;
using PizzaSystem.Persistence.DataStorage.Databases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<SqLite>();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => options.AddErrorHandling());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.MapControllers();

app.Run();