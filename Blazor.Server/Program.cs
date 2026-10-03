using Blazor.Server.Auth;
using Blazor.Server.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container ( Registrar servicios de Blazor Server )
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Extensión del proyecto Blazor.Server.Auth
builder.Services.AddBlazorServerAuth();

// 1. Configuración de autorización y estado en cascada para Blazor
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

// 2. Registrar nuestro proveedor de autenticación personalizado (desde la librería Blazor.Server.Auth)
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>(sp =>
    (CustomAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());

// Registrar ProtectedLocalStorage para manejo de sesión
builder.Services.AddScoped<ProtectedLocalStorage>();

// Registrar HttpClient apuntando a la dirección base de la Web API (puerto 7099)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7099/")
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<Blazor.Server.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();