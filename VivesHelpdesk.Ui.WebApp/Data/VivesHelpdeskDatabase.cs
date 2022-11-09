using VivesHelpdesk.Ui.WebApp.Models;

namespace VivesHelpdesk.Ui.WebApp.Data
{
    public class VivesHelpdeskDatabase
    {
        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();

        public void Seed()
        {
            Tickets.Add(
                new Ticket
                {
                    Id = 1,
                    Title = "Ticket1: This is the first ticket.",
                    Description = "Description of the ticket",
                    Author = "Bavo Ketels",
                    CreatedDate = DateTime.UtcNow
                });
            Tickets.Add(
                new Ticket
                {
                    Id = 2,
                    Title = "Ticket2: This is the second ticket.",
                    Description = "Description of the ticket",
                    Author = "Bavo Ketels",
                    CreatedDate = DateTime.UtcNow
                });
            Tickets.Add(
                new Ticket
                {
                    Id = 3,
                    Title = "Ticket3: This is the third ticket.",
                    Description = "Description of the ticket",
                    Author = "Bavo Ketels",
                    CreatedDate = DateTime.UtcNow
                });
        }
    }
}

