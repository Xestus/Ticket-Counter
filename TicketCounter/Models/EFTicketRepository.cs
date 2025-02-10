namespace TicketCounter.Models;

public class EFTicketRepository : ITicketRepository
{
    private TicketDbContext context;

    public EFTicketRepository(TicketDbContext context)
    {
        this.context = context;
    }
    public IQueryable<Ticket> Tickets => context.Tickets;
}