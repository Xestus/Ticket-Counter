using static TicketCounter.Models.Cart;

namespace TicketCounter.Controllers;

public class HomeController : Controller
{
    public ITicketRepository Repo;
    public readonly Cart cart;

    public HomeController(ITicketRepository repo, Cart cart)
    {
        this.Repo = repo;
        this.cart = cart;
    }

    public IActionResult Index(string distributor, string searchQuery, string sort)
    {
        var tickets = Repo.Tickets;

        if (!string.IsNullOrEmpty(distributor))
        {
            tickets = tickets.Where(p => p.Distributor == distributor);
        }

        if (!string.IsNullOrEmpty(searchQuery))
        {
            tickets = tickets.Where(p => p.Title.Contains(searchQuery) || p.Distributor.Contains(searchQuery));
        }

        if (!string.IsNullOrEmpty(sort))
        {
            var condition = sort.Split('-'); 

            if (condition.Length == 2 && 
                Enum.TryParse(condition[0], true, out SortField field) && 
                Enum.TryParse(condition[1], true, out SortOrder order))
            {
                tickets = field switch
                {
                    SortField.Price => order == SortOrder.Descending ? tickets.OrderByDescending(p => p.Price) : tickets.OrderBy(p => p.Price),
                    SortField.Date => order == SortOrder.Descending ? tickets.OrderByDescending(p => p.Date) : tickets.OrderBy(p => p.Date),
                    _ => tickets 
                };
            }
        }
        return View(tickets);
    }

    public IActionResult Cart(Ticket ticket)
    {
        Ticket tick = Repo.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
        if (tick != null)
        {
            cart.Addition(tick); 
        }
        return View(cart);
    }
}

enum SortField {  Date, Price }
enum SortOrder { Ascending, Descending }
