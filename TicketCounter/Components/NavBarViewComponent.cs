namespace TicketCounter.Components;

public class NavBarViewComponent : ViewComponent
{
    public ITicketRepository repo { get; set; }

    public NavBarViewComponent(ITicketRepository repo)
    {
        this.repo = repo;
    }

    public IViewComponentResult Invoke()
    {
        return View(repo.Tickets);
    }
}