using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BadAssDogTreats_Website.Data;
using Microsoft.AspNetCore.Authentication.Certificate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("productionDb") ?? throw new InvalidOperationException("Connection string 'WebContext' not found.")));

var kestralSection = builder.Configuration.GetSection("kestrel");
builder.WebHost.ConfigureKestrel(options =>
{
    options.Configure(kestralSection).Endpoint("HTTPS", listenOptions =>
    {

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
