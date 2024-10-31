using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using utsfrontend72220586.Data;
using utsfrontend72220586.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<CourseService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddHttpClient("BackendApi", client => 
{
    client.BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net");
});

builder.Services.AddHttpClient<CategoryService>(client =>
{
    client.BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net/");
});

builder.Services.AddHttpClient<CourseService>(client =>
{
    client.BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net/");
});


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
