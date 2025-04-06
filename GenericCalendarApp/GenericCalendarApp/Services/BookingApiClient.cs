using System.Net.Http.Json;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Bookings.GetBookingsForRange;

namespace GenericCalendarApp.Services;

public class BookingApiClient : IBookingApiClient
{
    private readonly HttpClient _http;

    public BookingApiClient(HttpClient http)
    {
        _http = http;
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
