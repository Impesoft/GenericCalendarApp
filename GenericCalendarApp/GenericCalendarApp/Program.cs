using GenericCalendar.Application.Shared;
using GenericCalendarApp.Client;
using GenericCalendarApp.Components;
using GenericCalendarApp.Services;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5000";
builder.Services.AddHttpClient<IBookingApiClient, BookingApiClient>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GenericCalendarApp.Client.Pages.Counter).Assembly);

app.MapStaticAssets();

app.Run();
