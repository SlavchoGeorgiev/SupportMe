namespace SupportMe.Web.Areas.Support.ViewModels.Ticket
{
    using System.ComponentModel.DataAnnotations;
    using TicketMassage;

    public class CreateTicketViewModel
    {
        [Required]
        public TicketInputModel Ticket { get; set; }

        [Required]
        public TicketMassageInputModel Massage { get; set; }
    }
}
