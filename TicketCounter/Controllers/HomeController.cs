namespace TicketCounter.Controllers;

public class HomeController : Controller
{
    public ITicketRepository Repo;

    public HomeController(ITicketRepository repo)
    {
        this.Repo = repo;
    }

    public IActionResult Index(string distributor, string searchQuery)
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
        return View(tickets);
    }
}