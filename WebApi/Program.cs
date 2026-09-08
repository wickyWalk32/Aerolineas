using Application.Services;
using Data;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using WebApi;

/* CONFIGURACIÓN */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });
builder.Services.AddRazorPages();

// Add Entity Framework Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection") ) );

// Add Dependency Injection
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ReservaService>();

builder.Services.AddScoped<IPasajeroRepository, PasajeroRepository>();
builder.Services.AddScoped<PasajeroService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<PaisService>();
builder.Services.AddScoped<ICiudadRepository, CiudadRepository>();
builder.Services.AddScoped<CiudadService>();
//builder.Services.AddControllers();

// Add Dependency Injection

var app = builder.Build();

/* EJECUCIÓN Y RUTAS */

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map endpoints (Minimal APIs)
app.MapSwagger()/*.RequireAuthorization()*/;
app.MapUsuarioEndpoints();
app.MapReservaEndpoints();
app.MapPasajeroEndpoints();
app.MapPaisEndpoints();
app.MapCiudadEndpoints();

app.MapGet("/", () => "Hello, World!");
app.MapRazorPages();

app.Run();