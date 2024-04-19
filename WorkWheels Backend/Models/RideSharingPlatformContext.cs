using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RideSharingPlatform.Models
{
    public partial class RideSharingPlatformContext : DbContext
    {
        public RideSharingPlatformContext()
        {
        }

        public RideSharingPlatformContext(DbContextOptions<RideSharingPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<DrivingLicence> DrivingLicences { get; set; } = null!;
        public virtual DbSet<UserApplication> UserApplications { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityHelpDeskNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityInchargeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DrivingLicence>(entity =>
            {
                entity.ToTable("DrivingLicence");

                entity.Property(e => e.AllowedVehicle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.LicenseNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RTO");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DrivingLicences)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__DrivingLi__UserI__5070F446");
            });

            modelBuilder.Entity<UserApplication>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserAppl__1788CC4C7C7D9459");

                entity.ToTable("UserApplication");

                entity.HasIndex(e => e.OfficialEmail, "UQ__UserAppl__426A6DFCC9CE50AE")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__UserAppl__536C85E494D83D2C")
                    .IsUnique();

                entity.Property(e => e.AadharNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OfficialEmail)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserApplications)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__UserAppli__Compa__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
