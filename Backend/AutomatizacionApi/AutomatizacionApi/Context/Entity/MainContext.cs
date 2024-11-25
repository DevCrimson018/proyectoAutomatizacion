using AutomatizacionApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi.Context.Entity
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserTicket> UserTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTicket>()
                .HasKey(ut => new { ut.UserId, ut.TicketId });

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.UserTicket)
                .WithOne(ut => ut.Ticket)
                .HasForeignKey(ut => ut.TicketId);

            modelBuilder.Entity<UserTicket>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTickets)
                .HasForeignKey(ut => ut.UserId);
        }
    }
}
