namespace TicketCounter.Models;

public static class SeedData
{
    public static void Initialize(IApplicationBuilder app)
    {
        TicketDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<TicketDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        if (!context.Tickets.Any())
        {
            context.AddRange
            (
                new Ticket
                {
                    Title = "Uefa Champions League",
                    Distributor = "UEFA",
                    Price = 499.49m,
                    Date = new DateTime(2025, 08, 21)
                },
                new Ticket
                {
                    Title = "CLASH OF CLANS ESPORTS",
                    Distributor = " Supercell",
                    Price = 59.49m,

                    Date = new DateTime(2027, 05, 22)
                },
                new Ticket
                {
                    Title = "Wrestlemania 41",
                    Distributor = "WWE",
                    Price = 999.49m,
                    Date = new DateTime(2025, 04, 21)
                },
                new Ticket()
                {
                    Title = "ICC Champions Trophy",
                    Distributor = "ICC",
                    Price = 199.49m,
                    Date = new DateTime(2025, 4, 5)
                }
            );

            context.SaveChanges();
        }
    }
}