




using Application.Services;
using Microsoft.EntityFrameworkCore;
using WebApi.Controller;
using Microsoft.AspNetCore.OpenApi;
using Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });
// Add services to the container.
builder.Services.AddRazorPages();



// Add Entity Framework Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Dependency Injection
//builder.Services.AddScoped<UsuariosController, UsuariosController>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService, UsuarioService>();
builder.Services.AddControllers();
// Add Dependency Injection

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapSwagger().RequireAuthorization();
app.MapGet("/", () => "Hello, World!");
app.MapControllers();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
