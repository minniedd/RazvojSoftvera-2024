using eProdaja.Services;
using eProdaja.Services.Database;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<IProizvodiServices, ProizvodiService>();
builder.Services.AddTransient<IProizvodiServices, ProizvodiService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();


var connectionString = builder.Configuration.GetConnectionString("eProdajaConnection");
builder.Services.AddDbContext<EProdajaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddMapster();

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
