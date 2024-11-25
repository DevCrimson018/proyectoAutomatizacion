using AutomatizacionApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutomatizacionApi.Context.Identity
{
    public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserTicket> UserTickets { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>().ToTable("ApplicationUser"); ;

            builder.Entity<UserTicket>()
                .HasKey(ut => new { ut.UserId, ut.TicketId });

            builder.Entity<UserTicket>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTickets)
                .HasForeignKey(ut => ut.UserId);

            builder.Entity<UserTicket>()
           .HasKey(ut => new { ut.UserId, ut.TicketId });

            builder.Entity<Ticket>()
                .HasMany(t => t.UserTicket)
                .WithOne(ut => ut.Ticket)
                .HasForeignKey(ut => ut.TicketId);

            builder.Entity<UserTicket>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTickets)
                .HasForeignKey(ut => ut.UserId);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
