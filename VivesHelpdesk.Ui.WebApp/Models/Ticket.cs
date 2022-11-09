using System.ComponentModel.DataAnnotations;

namespace VivesHelpdesk.Ui.WebApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required] 
        public string Title { get; set; } = null!;

        [Required] 
        public string Description { get; set; } = null!;

        [Required] 
        public string Author { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
    }
}
