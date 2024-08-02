using Azure;
using BackEndBookingTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBookingTravel.Infrastructure.SQL.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Rooms");

                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .HasMaxLength(50);

                entity.Property(e => e.BasePrice);

                entity.Property(e => e.Tax);

                entity.Property(e => e.IdRoomType);

                entity.Property(e => e.IsActive);

                entity.Property(e => e.CreateUser);
                entity.HasOne(b => b.RoomType)
                                  .WithMany(b => b.Rooms)
                                  .HasForeignKey(b => b.IdRoomType);

                entity.HasMany(e => e.Hotels)
                        .WithMany(e => e.Rooms)
                        .UsingEntity<HotelRoom>(
                    l => l.HasOne<Hotel>().WithMany().HasForeignKey(e => e.IdHotel),
                    r => r.HasOne<Room>().WithMany().HasForeignKey(e => e.IdRoom));
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("RoomTypes");

                entity.Property(e => e.Code)
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("DocumentTypes");

                entity.Property(e => e.Code)
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Genders");

                entity.Property(e => e.Code)
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Hotels");

                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive);

                entity.Property(e => e.CreateUser);

                entity.HasMany(e => e.Rooms)
                        .WithMany(e => e.Hotels)
                        .UsingEntity<HotelRoom>(
                    l => l.HasOne<Room>().WithMany().HasForeignKey(e => e.IdRoom),
                    r => r.HasOne<Hotel>().WithMany().HasForeignKey(e => e.IdHotel));
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Customers");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50);

                entity.Property(e => e.BirthDate);

                entity.Property(e => e.PhoneNumber)
                 .HasMaxLength(20);

                entity.Property(e => e.Email)
                 .HasMaxLength(50);

                entity.Property(e => e.DocumentNumber)
                 .HasMaxLength(20);

                entity.Property(e => e.IdGender);

                entity.Property(e => e.IdDocumentType);

                entity.HasOne(b => b.DocumentType)
                                  .WithMany(b => b.Customers)
                                  .HasForeignKey(b => b.IdDocumentType);

                entity.HasOne(b => b.Gender)
                                  .WithMany(b => b.Customers)
                                  .HasForeignKey(b => b.IdGender);
                entity.HasMany(e => e.Bookings)
                        .WithMany(e => e.Customers)
                        .UsingEntity<BookingCustomer>(
                    l => l.HasOne<Booking>().WithMany().HasForeignKey(e => e.IdBooking),
                    r => r.HasOne<Customer>().WithMany().HasForeignKey(e => e.IdCustomer));
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Bookings");

                entity.Property(e => e.StartDate);

                entity.Property(e => e.EndDate);

                entity.Property(e => e.EmergencyContactName)
                 .HasMaxLength(50);

                entity.Property(e => e.EmergencyPhoneNumber)
                 .HasMaxLength(20);

                entity.Property(e => e.IdRoom);

                entity.HasOne(b => b.Room)
                                  .WithMany(b => b.Bookings)
                                  .HasForeignKey(b => b.IdRoom);

                entity.HasMany(e => e.Customers)
                        .WithMany(e => e.Bookings)
                        .UsingEntity<BookingCustomer>(
                    l => l.HasOne<Customer>().WithMany().HasForeignKey(e => e.IdCustomer),
                    r => r.HasOne<Booking>().WithMany().HasForeignKey(e => e.IdBooking));

            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Users");

                entity.Property(e => e.Name)
                .HasMaxLength(50);

                entity.Property(e => e.LastName)
                .HasMaxLength(50);

                entity.Property(e => e.UserName)
                 .HasMaxLength(50);

                entity.Property(e => e.Password)
                 .HasMaxLength(400);
            });

            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.HasKey(hr => new { hr.IdHotel, hr.IdRoom });
            });


            modelBuilder.Entity<DocumentType>().HasData(
                   new DocumentType { Id = 1, Code = "CC", Description = "Cedula de Ciudadania" },
                   new DocumentType { Id = 2, Code = "TP", Description = "Pasaporte" },
                   new DocumentType { Id = 3, Code = "PA", Description = "Tarjeta de Identidad" }
                     );

            modelBuilder.Entity<Gender>().HasData(
                  new Gender { Id = 1, Code = "F", Description = "Femenino" },
                  new Gender { Id = 2, Code = "M", Description = "Masculino" },
                  new Gender { Id = 3, Code = "O", Description = "Otro" }
                    );

            modelBuilder.Entity<RoomType>().HasData(
                  new RoomType { Id = 1, Code = "Parejas", Description = "Habitacion doble" },
                  new RoomType { Id = 2, Code = "Individual", Description = "Habitacion Sencilla" },
                  new RoomType { Id = 3, Code = "Matrimonial", Description = "Suite" },
                  new RoomType { Id = 4, Code = "Familiar", Description = "Habitacion multiple" }
                    );
        }
    }
}
