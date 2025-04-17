using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Bookings.RoomBookings;
using GenericCalendar.Application.Bookings.SeatBookings;
using GenericCalendar.Application.Bookings.TeamsMeetings;
using GenericCalendar.Domain.Enums;
using System.Net.Http.Json;
using System.Text.Json;

namespace GenericCalendarApp.Services;

public class BookingApiClient : IBookingApiClient
{
    private readonly HttpClient _http;

    public BookingApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<BookingDto?> GetBookingByIdAsync(Guid id)
    {
        var response = await _http.GetAsync($"/api/bookings/{id}");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var content = await response.Content.ReadAsStringAsync();

        var baseDto = JsonSerializer.Deserialize<BookingDto>(content, options);

        return baseDto?.Type switch
        {
            BookingType.Meeting => JsonSerializer.Deserialize<MeetingBookingDto>(content, options),
            BookingType.Seat => JsonSerializer.Deserialize<SeatBookingDto>(content, options),
            BookingType.Room => JsonSerializer.Deserialize<RoomBookingDto>(content, options),
            _ => baseDto
        };
    }

    public async Task<List<BookingDto>> GetBookingsAsync(DateTime from, DateTime to)
    {
        var url = $"/api/bookings?from={from:s}&to={to:s}";
        return await _http.GetFromJsonAsync<List<BookingDto>>(url) ?? new();
    }

    public async Task<bool> BookAsync(BookItemRequest request)
    {
        var response = await _http.PostAsJsonAsync("/api/bookings", request);
        return response.IsSuccessStatusCode;
    }
}
