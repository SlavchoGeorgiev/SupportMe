namespace SupportMe.Web.ViewModels.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using SupportMe.Web.ViewModels.Massage;

    public class CreateTicketViewModel
    {
        [Required]
        public TicketInputModel Ticket { get; set; }

        [Required]
        public TicketMassageInputModel Massage { get; set; }
    }
}
