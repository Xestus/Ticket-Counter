using Microsoft.AspNetCore.Mvc;

namespace TicketCounter.Controllers;

public class HomeController : Controller
{
    public ITicketRepository repo;

    public HomeController(ITicketRepository repo)
    {
        this.repo = repo;
    }

    public IActionResult Index(string distributor)
    {
        var tickets = repo.Tickets;

        if (!string.IsNullOrEmpty(distributor))
        {
            tickets = tickets.Where(p => p.Distributor == distributor);
        }

        return View(tickets);
    }
}