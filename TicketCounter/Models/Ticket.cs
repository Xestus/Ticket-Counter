namespace TicketCounter.Models;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Distributor { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
}