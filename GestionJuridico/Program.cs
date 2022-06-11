using System.Net.Http.Headers;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Services;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.Graph;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

var scopes = new[] { "https://graph.microsoft.com/.default" };
// Agragando el servicio de autenticación de Azure
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(options =>
    {
        builder.Configuration.Bind("AzureAd", options);
        options.Events.OnTokenValidated = async context =>
        {
            var tokenAcquisition = context.HttpContext.RequestServices
                 .GetRequiredService<ITokenAcquisition>();
            var graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(async (request) =>
                {
                    var token = await tokenAcquisition
                        .GetAccessTokenForUserAsync(scopes, user: context.Principal);

                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);
                })
            );
            // Obteniendo información desde Graph del usuario autenticado
            var user = await graphClient.Me.Request()
                .Select(u => new
                {
                    u.Id,
                    u.DisplayName,
                    u.Department,
                    u.Mail,
                    u.UserPrincipalName
                })
                .GetAsync();
            context.Principal.AddUserGraphInfo(user);
            try
            {
                var photo = await graphClient.Me
                    .Photos["96x96"]
                    .Content
                    .Request()
                    .GetAsync();
                context.Principal.AddUserGraphPhoto(photo);
            }
            catch (ServiceException ex)
            {
                context.Principal.AddUserGraphPhoto(null);
            }

        };
    })
    .EnableTokenAcquisitionToCallDownstreamApi(scopes)
    .AddMicrosoftGraph()
    .AddInMemoryTokenCaches();
// Servicio de base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Servicios
builder.Services.AddSingleton<IMenuService, MenuService>();
builder.Services.AddScoped<ISolicitudService, SolicitudService>();
builder.Services.AddScoped<ICasoService, CasoService>();

// Add services to the container.
builder.Services.AddControllersWithViews()
    // 
    .AddMicrosoftIdentityUI();
// Agregando las directivas de autorización
builder.Services.AddAuthorization(StartupConfigurations.ConfigurePoliciesOptions);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();