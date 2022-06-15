using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.EmployeeAPIService.Data
{
    public class ApplicationDbContext : DbContext
    {

        private IDbContextTransaction _transaction;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        internal Task AddAsync(Func<IActionResult> rolePermissions)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                Rollback();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        internal Task DeleteAsync<T>(T model)
        {
            throw new NotImplementedException();
        }

        internal Task DeleteAsync<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
        public void Migrate()
        {
            Database.Migrate();
        }
        // public DbSet<RequestQuotation> RequestQuotations { get; set; }
        //public DbSet<RequestQuotationItem> RequestQuotationItems { get; set; }

    }
}
