namespace TicketCounter.Models;
public class Cart
{
    public List<Information> InfoList { get; set; } = new List<Information?>();
    public void Addition(Ticket ticket)
    {

        Information? info = InfoList.FirstOrDefault(p => p.Tickets.Id == ticket.Id);

        if (info == null)
        {
            InfoList.Add(new Information { Tickets = ticket, Quantity = 1 });
        }
        else
        {
            info.Quantity += 1;
        }
    }

    public void Remove(Ticket ticket)
    {
        Information? info = InfoList.FirstOrDefault(p => p.Tickets.Id == ticket.Id);

        if (info != null)
        {
            InfoList.Remove(info);
        }
    }
    
    public decimal TotalPrice()
    {
        return InfoList.Sum(e => e.Tickets.Price * e.Quantity);
    }
}

public class Information
{
    public Ticket Tickets { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price => Tickets.Price * Quantity;
}