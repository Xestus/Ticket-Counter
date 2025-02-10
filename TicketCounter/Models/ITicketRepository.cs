namespace TicketCounter.Models;

public interface ITicketRepository
{ 
    IQueryable<Ticket> Tickets { get; }
}