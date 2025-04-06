# GenericCalendarApp

A flexible, extensible calendar booking system built with .NET 9 (or .NET 10 preview), using Clean Architecture, CQRS, and vertical slicing.

---

## 📐 Project Structure

```
BookingApp.sln
│
├── src/
│   ├── BookingApp.Api/                # Minimal API endpoints and program bootstrap
│   ├── BookingApp.Blazor/             # Blazor UI frontend
│   ├── BookingApp.Application/        # Feature-based vertical slices (CQRS handlers)
│   ├── BookingApp.Domain/             # Core domain entities, contracts, enums
│   └── BookingApp.Infrastructure/     # EF Core DbContext, persistence services, seeding
│
├── tests/
│   └── BookingApp.UnitTests/          # Unit tests
```

---


---

## 📁 Key Concepts

### Domain (Pure Business Logic)
- `IBookableItem`: Interface abstraction for anything that can be booked
- `BookableItemEntity`: Abstract base class
- `RoomEntity`, `SeatEntity`, `TeamMeetingEntity`: Concrete bookable items
- `BookingEntity`: Generic booking record
- `BookingType`: Enum to classify booking types
- `IRequest<T>`, `INotification`: Lightweight replacements for MediatR-style messaging

### Application (Use Cases & Vertical Slices)
- Each feature lives in its own folder (e.g. `BookItem/`, `GetBookingsForRange/`)
- Handlers use our custom `IDispatcher` pattern
- `BookingDto`: UI-friendly projection

### Infrastructure (EF Core)
- `AppDbContext`: Entity Framework database context using TPT (Table-per-Type)
- `AvailabilityService`: Enforces no-overlap booking rules
- `DataSeeder`: Seeds test data on app start

### API (Minimal)
- `/api/bookings?from=...&to=...`: Exposes bookings for calendar display
- Uses `IDispatcher` to send queries

### Blazor (UI)
- Renders calendar using `BookingDto`s from API
- Separated components by responsibility
- Communicates with API via `HttpClient`

---

## 🚀 Getting Started

1. **Run Database Migration (if EF Core Migrations used)**
```bash
dotnet ef database update --project BookingApp.Infrastructure --startup-project BookingApp.Api
```

2. **Start the API**
```bash
cd src/BookingApp.Api
dotnet run
```

3. **Start the Blazor UI**
```bash
cd src/BookingApp.Blazor
dotnet run
```

4. **Visit the calendar UI**
```
http://localhost:5000 (or whatever port Blazor binds to)
```

---

## 📦 Future Ideas

- Recurring bookings
- Multi-resource bookings
- User roles & access control
- External data source integration

---

## 🙌 Contributing

This project uses vertical slicing and single-responsibility design. Keep new features self-contained and avoid cross-layer leakage. Use the `IDispatcher` and `IRequest<T>` model for all app interactions.

---
