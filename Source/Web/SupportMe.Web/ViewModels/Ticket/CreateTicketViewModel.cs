namespace SupportMe.Web.ViewModels.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using Message;

    public class CreateTicketViewModel
    {
        [Required]
        public TicketInputModel Ticket { get; set; }

        [Required]
        public TicketMessageInputModel Message { get; set; }
    }
}
