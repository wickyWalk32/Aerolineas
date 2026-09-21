using Application.Services;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi;
using WebApi.Services;



/* -------------
 * CONFIGURACIÓN
 */
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

builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<PaisService>();

builder.Services.AddScoped<ICiudadRepository, CiudadRepository>();
builder.Services.AddScoped<CiudadService>();

builder.Services.AddScoped<IPasajeroRepository, PasajeroRepository>();
builder.Services.AddScoped<PasajeroService>();

builder.Services.AddScoped<IAvionRepository, AvionRepository>();
builder.Services.AddScoped<AvionService>();

builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<ServicioService>();

builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<ReservaService>();

/* ----------------------------------
 * CONFIGURACIÓN DE AUTENTICACIÓN JWT
 */

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"] ?? throw new InvalidOperationException("JwtSettings:Secret no está configurado.");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddAuthorization();

// Registrar tu servicio de tokens para poder inyectarlo en los endpoints
builder.Services.AddScoped<JwtTokenService>();



/* --------------------
 * CONSTRUIR APLICACIÓN
 */

var app = builder.Build();



/* ----------------------------------
 * INICIALIZACIÓN DE LA BASE DE DATOS
 */

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated(); // Crea la BD y aplica configuraciones iniciales
}



/* ----------------------------------
 * EJECUCIÓN Y RUTAS
 */

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

// Orden de middlewares (Importante!) 
app.UseAuthentication(); // 1. Primero autenticamos (¿Quién sos?)
app.UseAuthorization();  // 2. Después autorizamos (¿Tenés permiso?)

// Map endpoints (Minimal APIs)

app.MapUsuarioEndpoints();
app.MapPaisEndpoints();
app.MapCiudadEndpoints();
app.MapPasajeroEndpoints();
app.MapServicioEndpoints();
app.MapReservaEndpoints();

//app.MapGet("/", () => "Hello, World!");       //?
app.MapSwagger()/*.RequireAuthorization()*/;    //Ver que es
app.MapRazorPages();

app.Run();