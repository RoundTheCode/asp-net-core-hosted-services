using RoundTheCode.HostedServiceExample.HostedServices;
using RoundTheCode.HostedServiceExample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMySingletonService, MySingletonService>();
builder.Services.AddScoped<IMyScopedService, MyScopedService>();
builder.Services.AddTransient<IMyTransientService, MyTransientService>();

builder.Services.AddHostedService<MyBackgroundService>();
builder.Services.AddHostedService<MyHostedService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
