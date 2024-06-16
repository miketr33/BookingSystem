using Microsoft.EntityFrameworkCore;

namespace EventBookingApi.Models;

public partial class EventBookingDbContext : DbContext
{
    public EventBookingDbContext(DbContextOptions<EventBookingDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Attendee> Attendee { get; set; }
    public virtual DbSet<ActivityDetails> ActivityDetails { get; set; }
    public virtual DbSet<Booking> Booking { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // EventDetail configuration
        modelBuilder.Entity<ActivityDetails>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(2000);
            entity.Property(e => e.AddressLine1).IsRequired().HasMaxLength(100);
            entity.Property(e => e.AddressLine2).HasMaxLength(100);
            entity.Property(e => e.AddressLine3).HasMaxLength(100);
            entity.Property(e => e.Postcode).IsRequired().HasMaxLength(8);
            entity.Property(e => e.ActivityStart).IsRequired();
            entity.Property(e => e.ActivityEnd).IsRequired();
        });

        // Attendee configuration
        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(a => a.LastName).IsRequired().HasMaxLength(50);
            entity.Property(a => a.AddressLine1).HasMaxLength(100);
            entity.Property(a => a.AddressLine2).HasMaxLength(100);
            entity.Property(a => a.AddressLine3).HasMaxLength(100);
            entity.Property(a => a.Postcode).HasMaxLength(8);
            entity.Property(a => a.Phone).HasMaxLength(13);
            entity.Property(a => a.Email).IsRequired().HasMaxLength(200);
            entity.Property(a => a.DateOfBirth).IsRequired();
        });

        // Booking configuration
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.ActivityId).IsRequired();
            entity.Property(b => b.AttendeeId).IsRequired();
            entity.Property(b => b.Attended).IsRequired();

            // Foreign keys
            entity.HasOne(b => b.ActivityDetails)
                .WithMany()
                .HasForeignKey(b => b.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(b => b.Attendee)
                .WithMany()
                .HasForeignKey(b => b.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}