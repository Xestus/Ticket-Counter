namespace TicketCounter.Models;

// Total ticket number count
// Total ticket price count
// Ticket Addition
// Ticket Removing

// Make another cart inherit you which performs all logical operation.

public class Cart
{
    public List<Information> infoList { get; set; }
}

public class Information
{
    public Ticket tickets { get; set; }
    public int quantity { get; set; }
    public decimal price { get; set; }
}