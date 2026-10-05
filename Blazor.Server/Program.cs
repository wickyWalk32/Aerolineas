using Blazor.Server.Auth;
using Blazor.Server.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 1. Invocamos de forma limpia la extensión de autenticación
builder.Services.AddBlazorServerAuth();

// 2. Registramos el handler personalizado para que el sistema maneje su ciclo de vida
builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

// 3. Registramos el HttpClient configurando la BaseAddress y enlazándole automáticamente el Handler
// Esto soluciona el error "The inner handler has not been assigned" y permite usar [Inject] HttpClient Http en las páginas.
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<CustomAuthorizationMessageHandler>();
    // Asignamos el manejador HTTP predeterminado del sistema como el inner handler final de la cadena
    handler.InnerHandler = new HttpClientHandler();

    return new HttpClient(handler)
    {
        BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7099/")
    };
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