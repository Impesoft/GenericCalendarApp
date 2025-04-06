using GenericCalendar.Domain.Entities;
using GenericCalendar.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GenericCalendar.Infrastructure.Persistence;

public class GenericCalendarDbContext : DbContext
{
    public GenericCalendarDbContext(DbContextOptions<GenericCalendarDbContext> options)
        : base(options) { }

    public DbSet<BookingEntity> Bookings => Set<BookingEntity>();
    public DbSet<BookableItemEntity> BookableItems => Set<BookableItemEntity>();
    public DbSet<RoomEntity> Rooms => Set<RoomEntity>();
    public DbSet<SeatEntity> Seats => Set<SeatEntity>();
    public DbSet<TeamMeetingEntity> TeamMeetings => Set<TeamMeetingEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoomEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SeatEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TeamMeetingEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
    }
}
