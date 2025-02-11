namespace TicketCounter.Controllers;

public class HomeController : Controller
{
    public ITicketRepository Repo;

    public HomeController(ITicketRepository repo)
    {
        this.Repo = repo;
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
            string[] condition = sort.Split('-');

            if (condition[0].ToLower() == "price")
            {
                if (condition[1].ToLower() == "descending")
                {
                    tickets = tickets.OrderByDescending(p => p.Price);
                }

                else
                {
                    tickets = tickets.OrderBy(p => p.Price);
                }
            }

            else
            {
                if (condition[1].ToLower() == "descending")
                {
                    tickets = tickets.OrderByDescending(p => p.Date);
                }

                else
                {
                    tickets = tickets.OrderBy(p => p.Date);
                }
            }
        }

        return View(tickets);
    }
}