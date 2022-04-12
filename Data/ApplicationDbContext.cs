using BankingManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VSFBankingSystem.Models;

namespace BankingManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<Admin>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Registration> registrations { get; set; }

        public DbSet<AddPayee> AddPayees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AddPayee>()
                .HasKey(c => new { c.AccountNumber, c.BeneficiaryAccountNumber });
        }
    }
}