namespace SupportMe.Web.Areas.Support.ViewModels.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using TicketMessage;

    public class CreateTicketViewModel
    {
        [Required]
        public TicketInputModel Ticket { get; set; }

        [Required]
        public TicketMessageInputModel Message { get; set; }
    }
}
