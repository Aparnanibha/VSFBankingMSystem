using System;
using System.Collections.Generic;
using BankingManagementSystem.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BankingManagementSystem.Models;

namespace BankingManagementSystem.Models
{
    public partial class BankingManagementContext : DbContext
    {
        public BankingManagementContext()
        {
        }

        public BankingManagementContext(DbContextOptions<BankingManagementContext> options)
            : base(options)
        {
        }


        public virtual DbSet<AddPayee> AddPayees { get; set; } = null!;
        public virtual DbSet<AddPayee1> AddPayees1 { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAcc> CustomerAccs { get; set; } = null!;
        public virtual DbSet<RegisterNetBanking> RegisterNetBankings { get; set; } = null!;
        public virtual DbSet<Registration> Registrations { get; set; } = null!;
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-J7OGSDO\\SQLEXPRESS;Database=BankingManagement;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddPayee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AddPayee");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.BeneficiaryAccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.BeneficiaryName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("fk_AccNum_AddPay");
            });

            modelBuilder.Entity<AddPayee1>(entity =>
            {
                entity.HasKey(e => new { e.AccountNumber, e.BeneficiaryAccountNumber });

                entity.ToTable("AddPayees");

                entity.Property(e => e.AccountNumber).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BeneficiaryAccountNumber).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AadharNumber).HasColumnType("numeric(16, 0)");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EnableNetBanking)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FathersName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAnnualIncome).HasColumnType("numeric(12, 2)");

                entity.Property(e => e.IsDebitCardRequired)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("isDebitCardRequired");

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.OccupationType)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SourceOfIncome)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerAcc>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__Customer__BE2ACD6EC7DC61E5");

                entity.ToTable("CustomerAcc");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAccs)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_cust_ID");
            });

            modelBuilder.Entity<RegisterNetBanking>(entity =>
            {
                entity.HasKey(e => new { e.AccountNumber, e.CustomerId })
                    .HasName("PK__Register__24602B23768E2252");

                entity.ToTable("RegisterNetBanking");

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.CustomerId).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.Passwordd)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.RegisterNetBankings)
                    .HasForeignKey(d => d.AccountNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccNum");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("registrations");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Transact__55433A6B6EBAA246");

                entity.ToTable("TransactionDetail");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.Maturityinstruct)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ToAccountNumber).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("fk_AccNum_Tr");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<BankingManagementSystem.Models.LoginVM> LoginVM { get; set; }
    }
}
