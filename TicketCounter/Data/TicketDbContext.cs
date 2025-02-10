using TicketCounter.Models;

namespace TicketCounter.Data;

public class TicketDbContext : DbContext
{
    public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
    {
    }
    
    public DbSet<Ticket> Tickets => Set<Ticket>();
    
}