using HRMS.EmployeeAPIService.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Test.Booking;

namespace HRMS.Tests
{
    public class SharedDatabaseFixture
    {
        private static bool _databaseInitialized;
        public ApplicationDbContext? Context { get; set; }

        public SharedDatabaseFixture()
        {
            if (!_databaseInitialized)
            {
                using var context = CreateContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.AddRange(EmployeeData.MockCreateEmployeeCommand());
                context.SaveChanges();

                _databaseInitialized = true;
            }
        }

        public static ApplicationDbContext CreateContext() => new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("EmployeeMemoryDB").Options);
    }
}