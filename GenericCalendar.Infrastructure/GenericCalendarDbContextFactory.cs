using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GenericCalendar.Infrastructure.Persistence;

public class GenericCalendarDbContextFactory : IDesignTimeDbContextFactory<GenericCalendarDbContext>
{
    public GenericCalendarDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GenericCalendarDbContext>();

        // Replace with your actual connection string
        var connectionString = "Data Source=GenericCalendar.db";

        optionsBuilder.UseSqlite(connectionString);

        return new GenericCalendarDbContext(optionsBuilder.Options);
    }
}
