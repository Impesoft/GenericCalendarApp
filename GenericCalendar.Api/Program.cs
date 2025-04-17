using GenericCalendar.Api.Endpoints;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Bookings.GetBookingsForRange;
using GenericCalendar.Domain.Messaging;
using GenericCalendar.Infrastructure;
using GenericCalendar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext
builder.Services.AddDbContext<GenericCalendarDbContext>(options =>
    options.UseSqlite("Data Source=calendar.db")); // change provider as needed

// CQRS core
builder.Services.AddInfrastructure();

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

app.Run();
