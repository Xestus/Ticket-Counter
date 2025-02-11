namespace TicketCounter.Components;

public class NavBarViewComponent : ViewComponent
{
    public ITicketRepository Repo { get; set; }

    public NavBarViewComponent(ITicketRepository repo)
    {
        this.Repo = repo;
    }

    public IViewComponentResult Invoke()
    {
        var q = new Parameters
        {
            Distributor = Repo.Tickets
                .Select(x => x.Distributor)
                .Distinct(),
            
        };
        return View(q);
    }
}

public class Parameters
{
    public IQueryable<string>? Distributor { get; set; }

}

