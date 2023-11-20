using Camioneros.Data;
using Camioneros.Data.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQLConecction"));
builder.Services.AddSingleton(mySQLConfiguration);
builder.Services.AddScoped<InterfaceCamionero, RepositorioCamionero>();
builder.Services.AddScoped<InterfaceCamion, RepositorioCamion>();

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
