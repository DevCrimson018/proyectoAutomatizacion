using AutomatizacionApi.Domain.Entities;
using AutomatizacionApi.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutomatizacionApi.Persistence.Context.Identity
{
    public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<TicketsCode> TicketsCodes { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<BusStatus> BusStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>().ToTable("ApplicationUser")
                // This is the discriminator that will be used to determine the type of the user
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Customer>("Customer")
                .HasValue<Admin>("Admin")
                .HasValue<Driver>("Driver");




            // Override default schema for specific entities
            builder.Entity<Reservation>().ToTable("Reservations", "dbo");
            builder.Entity<Ticket>().ToTable("Tickets", "dbo");
            builder.Entity<Location>().ToTable("Locations", "dbo");
            builder.Entity<TicketsCode>().ToTable("TicketCodes", "dbo");
            builder.Entity<Bus>().ToTable("Buses", "dbo");
            builder.Entity<BusStatus>().ToTable("BusStatuses", "dbo");

            // Primary key for Reservation
            builder.Entity<Reservation>()
                .HasKey(x => x.Id);

            //Relationship between Reservation and Customer
            builder.Entity<Reservation>()
                .HasOne(ut => ut.Customer)
                .WithMany(u => u.Reservations)
                .HasForeignKey(ut => ut.CustomerId);

            //Relationship between Reservation and Ticket
            builder.Entity<Ticket>()
                .HasMany(t => t.Reservations)
                .WithOne(ut => ut.Ticket)
                .HasForeignKey(ut => ut.TicketId);

            //Relationship between BusStatus and Bus
            builder.Entity<BusStatus>()
                .HasMany(t => t.Bus)
                .WithOne(ut => ut.Status)
                .HasForeignKey(ut => ut.StatusId);


            //Relationship between Ticket and Location
            builder.Entity<Ticket>()
                .HasOne(t => t.Location)
                .WithMany(l => l.Tickets)
                .HasForeignKey(t => t.LocationId);

            //Relationship between Reservation and TicketCode
            builder.Entity<Reservation>()
                .HasMany(t => t.TicketsCodes)
                .WithOne(l => l.Reservation)
                .HasForeignKey(t => t.ReservationId);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
