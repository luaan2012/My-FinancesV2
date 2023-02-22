using Finances.CrossCutting.DependencyInjection;
using Finances.CrossCutting.Helper;
using Finances.Extensions;
using Finances.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDbInjection(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(AudFilter));
});

builder.Services.AddDbContexInjectionCustom();

builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddSession();

builder.Services.KissLoggingCustom();

if (bool.Parse(builder.Configuration["Validations:Security"] ?? "true"))
    builder.Services.AddSecurityCustom();

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

if (bool.Parse(builder.Configuration["Validations:Security"] ?? "true"))
    app.UseCorsCustom();

app.UseRequestLocalization("pt-BR");

app.UseExceptionCustom(builder.Environment);

app.UseHstsCustom(builder.Environment);

app.UseSession();

app.UseWebAppCustom();

app.UseIdentityCustom();

app.UseKissLogMiddlewareCustom(builder.Configuration);

app.UseEndPointCustom("Autentication", "Login");

//app.UseGlobalizationCustom();

app.MapRazorPages();

app.Run();
