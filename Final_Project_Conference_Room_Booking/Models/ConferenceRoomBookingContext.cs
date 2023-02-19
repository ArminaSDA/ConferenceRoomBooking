using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Final_Project_Conference_Room_Booking.Models
{
    public partial class ConferenceRoomBookingContext : DbContext
    {
        public ConferenceRoomBookingContext()
        {
        }

        public ConferenceRoomBookingContext(DbContextOptions<ConferenceRoomBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<ConferenceRoom> ConferenceRooms { get; set; } = null!;
        public virtual DbSet<ReservationHolder> ReservationHolders { get; set; } = null!;
        public virtual DbSet<UnavailabilityPeriod> UnavailabilityPeriods { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.ConfirmedFrom)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ConfirmedFromId)
                    .HasConstraintName("FK_Bookings_User");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_ConferenceRooms");
            });

            modelBuilder.Entity<ConferenceRoom>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(4);
            });

            modelBuilder.Entity<ReservationHolder>(entity =>
            {
                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.ReservationHolders)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationHolders_Bookings");
            });

            modelBuilder.Entity<UnavailabilityPeriod>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.ConferenceRoom)
                    .WithMany(p => p.UnavailabilityPeriods)
                    .HasForeignKey(d => d.ConferenceRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnavailabilityPeriods_ConferenceRooms");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
