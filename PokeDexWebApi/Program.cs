using Microsoft.EntityFrameworkCore;
using PokeDex.Data.Models;
using PokeDex.Data.Repositories;
using PokeDexWebApi.Services;
using PokeDexWebApi.Services.ServiceInterface;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<PokedexDbContext>(opt => opt.UseSqlServer("Server=.;Database=PokedexDB;Integrated Security=SSPI;TrustServerCertificate=True;"));
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DP Inject.
builder.Services.AddScoped<IPokemonMoveRepository, PokemonMoveRepository>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddScoped<IAbilityService, AbilityService>();
builder.Services.AddScoped<IMoveService, MoveService>();
builder.Services.AddScoped<IPokemonMoveService, PokemonMoveService>();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonTypeService, PokemonTypeService>();

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
