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
            var condition = sort.Split('-');

            if (condition.Length == 2 && 
                Enum.TryParse(condition[0], true, out SortField result) &&
                Enum.TryParse(condition[1], true,out SortOrder sortResult))
            {
                tickets = sortResult switch
                {
                    SortOrder.Ascending => result == SortField.Date ? tickets.OrderBy(p => p.Date) : tickets.OrderBy(p => p.Price),
                    SortOrder.Descending => result == SortField.Date ? tickets.OrderByDescending(p => p.Date) : tickets.OrderByDescending(p => p.Price),
                };
            }
        }

        return View(tickets);
    }
}

enum SortField { Price, Date }
enum SortOrder { Ascending, Descending }
