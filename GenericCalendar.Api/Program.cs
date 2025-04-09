﻿using GenericCalendar.Api.Endpoints;
using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Bookings.GetBookingsForRange;
using GenericCalendar.Application.Shared;
using GenericCalendar.Domain.Interfaces;
using GenericCalendar.Domain.Messaging;
using GenericCalendar.Infrastructure.Persistence;
using GenericCalendar.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext
builder.Services.AddDbContext<GenericCalendarDbContext>(options =>
    options.UseSqlite("Data Source=calendar.db")); // change provider as needed

// CQRS core
builder.Services.AddScoped<IDispatcher, Dispatcher>();
builder.Services.AddScoped<IBookingWriter, BookingWriter>();
builder.Services.AddScoped<IBookingReader, BookingReader>();
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();

// Handler registration (if using reflection-free DI)
builder.Services.AddScoped<IRequestHandler<BookItemRequest, BookingResult>, BookItemHandler>();
builder.Services.AddScoped<IRequestHandler<GetBookingsForRangeQuery, List<BookingDto>>, GetBookingsForRangeHandler>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// CORS, JSON options, etc.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<GenericCalendarDbContext>();
db.Database.Migrate();
//db.Database.EnsureCreated();        // ✅ ← Add this if missing
//DataSeeder.Seed(db);               // ✅ ← Optional

app.MapBookingsApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
