using Microsoft.AspNetCore.Mvc;
using VivesHelpdesk.Ui.WebApp.Data;
using VivesHelpdesk.Ui.WebApp.Models;

namespace VivesHelpdesk.Ui.WebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly VivesHelpdeskDatabase _database;

        public TicketController(VivesHelpdeskDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tickets = _database.Tickets;
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]Ticket ticket)
        {
            //Validate
            if (!ModelState.IsValid)
            {
                return View(ticket);
            }

            //Execute
            var maxId = _database.Tickets.Max(t => t.Id);
            ticket.Id = maxId + 1;
            ticket.CreatedDate = DateTime.UtcNow;

            _database.Tickets.Add(ticket);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int id)
        {
            var ticket = _database.Tickets
                .SingleOrDefault(t => t.Id == id);

            if(ticket is null)
            {
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, [FromForm]Ticket ticket)
        {
            //Validate
            if (!ModelState.IsValid)
            {
                return View(ticket);
            }

            var dbTicket = _database.Tickets
                .SingleOrDefault(t => t.Id == id);

            if(dbTicket is null)
            {
                return RedirectToAction("Index");
            }

            dbTicket.Title = ticket.Title;
            dbTicket.Description = ticket.Description;
            dbTicket.Author = ticket.Author;

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ticket = _database.Tickets
                .SingleOrDefault(t => t.Id == id);

            return View(ticket);
        }

        [HttpPost]
        [Route("[controller]/Delete/{id:int}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var ticket = _database.Tickets
                .SingleOrDefault(t => t.Id == id);

            if(ticket is null)
            {
                return RedirectToAction("Index");
            }

            _database.Tickets.Remove(ticket);


            return RedirectToAction("Index");
        }
    }
}
