using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using LiddellRoch.Utility;
using LiddellRoch.DataAccess.Data;
using Stripe;
using LiddellRoch.DataAccess.Repository.Interfaces;
using LiddellRoch.DataAccess.Repository;
using LiddellRoch.DataAccess.DbInitializer;
using LiddellRoch.Application.Services.Interfaces;
using LiddellRoch.Application.Services;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Microsoft.AspNetCore.Localization;

// Globalization
var cultureInfo = new CultureInfo("pt-BR");
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
cultureInfo.NumberFormat.CurrencyDecimalSeparator = ",";
cultureInfo.NumberFormat.NumberDecimalDigits = 2;
cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
Thread.CurrentThread.CurrentCulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

/*if (builder.Environment.IsProduction())
{
    using var x509Store = new X509Store(StoreLocation.CurrentUser);

    x509Store.Open(OpenFlags.ReadOnly);

    var x509Certificate = x509Store.Certificates
        .Find(
            X509FindType.FindByThumbprint,
            builder.Configuration["AzureADCertThumbprint"],
            validOnly: false)
        .OfType<X509Certificate2>()
        .Single();

    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new ClientCertificateCredential(
            builder.Configuration["AzureADDirectoryId"],
            builder.Configuration["AzureADApplicationId"],
            x509Certificate));
}*/

// --------------------------- BUIDER ---------------------------
//builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

// Stripe
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// Social Sign-In
builder.Services.AddAuthentication().AddFacebook(option =>
{
    var fbSettings = builder.Configuration.GetSection("Facebook");
    option.AppId = fbSettings["AppId"];
    option.AppSecret = fbSettings["AppSecret"];
});

builder.Services.AddAuthentication().AddMicrosoftAccount(option =>
{
    var msSettings = builder.Configuration.GetSection("Microsoft");
    option.ClientId = msSettings["ClientId"];
    option.ClientSecret = msSettings["ClientSecret"];
});

builder.Services.AddAuthentication().AddGoogle(option =>
{
    var msSettings = builder.Configuration.GetSection("Google");
    option.ClientId = msSettings["ClientId"];
    option.ClientSecret = msSettings["ClientSecret"];
});

builder.Services.AddDistributedMemoryCache();

// Session
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Services Injection
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();

// RazorPages
builder.Services.AddRazorPages();

// --------------------------- APP ---------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
SeedDatabase();

app.MapRazorPages();
app.UseRequestLocalization("pt-BR");
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}");

app.Run();


// --------------------------- CUSTOM ---------------------------
void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}