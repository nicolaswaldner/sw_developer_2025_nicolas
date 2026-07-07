using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SD.Application.Extensions;
using SD.Application.Services;
using SD.Persistence.Extensions;
using SD.Persistence.Repositories.DBContext;
using SD.Web.Data;
using System.Globalization;



var builder = WebApplication.CreateBuilder(args);

/* Add services to the container. */
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


/* Möglichkeit für Speichern von benutzer-spezifischen Daten in Sessions */
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

});

/* Möglichkeit den MemoryCache zu nutzern, um Stammdaten in Memory zwischen zu speichern */
builder.Services.AddMemoryCache();


/* Auslesen der Sprachen des Clients (Browser Request) */
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new("de"),
        new("en")
    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

});

//Auto compile of Razor pages in development mode
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

/* DBContext registrieren */
var movieDbConnectionString = builder.Configuration.GetConnectionString("MovieDbContext");
builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(movieDbConnectionString));


/* Registrierung der Repository und Handler Klassen */
builder.Services.RegisterRepositories();
builder.Services.RegisterApplicationServices();

/* Registrierung Mediator -> Extension erforder Referenz auf Nuget Package */
builder.Services.AddMediator(cfg => cfg.ServiceLifetime = ServiceLifetime.Scoped);

/* Adding ApplicationCacheService */


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseHttpMethodOverride(new HttpMethodOverrideOptions { FormFieldName = "_method"} );


app.UseRouting();

app.UseAuthorization();

/* Sessions aktivieren */
app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

/* Browser-Culture Ermittlung aktivieren */
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.Run();
