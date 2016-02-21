namespace SupportMe.Web.Areas.Support.ViewModels.Ticket
{
    using System.ComponentModel.DataAnnotations;

    public class TicketInputModel
    {
        [Required]
        [MaxLength(200)]
        [UIHint("BootstrapTextBox")]
        public string Title { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string LocationId { get; set; }
    }
}
