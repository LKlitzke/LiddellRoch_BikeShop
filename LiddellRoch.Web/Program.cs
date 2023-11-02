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
//builder.Services.AddScoped<ICategoryService, CategoryService>();

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
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

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