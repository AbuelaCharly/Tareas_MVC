using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using TareasMVC;
using Microsoft.AspNetCore.Mvc.Razor;
using TareasMVC.Servicios;

var builder = WebApplication.CreateBuilder(args);

//FILTRO QUE SOLO ACEPTA USUARIOS AUTENTICADOS
var politicaUsuariosAutenticados = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();


// ADD SERVICES TO THE CONTAINER.
builder.Services.AddControllersWithViews(opciones =>
{
    //pasamos la politica creada a la aplicacion
    opciones.Filters.Add(new AuthorizeFilter(politicaUsuariosAutenticados));
}).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);


//Servicio de DbContext
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name = DefaultConnection"));

//Servicios de IdentityDbContext
builder.Services.AddAuthentication();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opciones =>
{
    //de esta forma no es necesario activar una cuenta para registrarse
    opciones.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


//No vamos a usar las vistas por defecto de pagina de login y signin
//Vamos a usar autenticacion basada en cookies
builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
    opciones =>
    {
        opciones.LoginPath = "/usuarios/login";
        opciones.AccessDeniedPath = "/usuarios/login";
    });

//LOCALIZACION - IDIOMAS - CULTURA
//Con esto podemos utilizar IStringLocalizer
builder.Services.AddLocalization(opciones =>
{
    opciones.ResourcesPath = "Recursos"; //nombre de la carpeta de los archivos de recursos
});


//SERVICIO USUARIOS
builder.Services.AddTransient<IServicioUsuarios, ServicioUsuarios>();

//////////////////////////////
/////////////////////////////



var app = builder.Build();

//Esto está relacionado con el IDIOMA de la aplicacion
var culturasUISoportadas = new[] { "es", "en" };
//localiza la peticion del usuario
app.UseRequestLocalization(opciones =>
{
    opciones.DefaultRequestCulture = new RequestCulture("es");
    opciones.SupportedUICultures = culturasUISoportadas
        .Select(cultura => new CultureInfo(cultura)).ToList();
});
    

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //Parte de la configuracion de authenticatin options. Permite optener la data el usuario autenticado
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

