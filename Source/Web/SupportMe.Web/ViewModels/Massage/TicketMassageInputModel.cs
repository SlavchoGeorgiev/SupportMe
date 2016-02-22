namespace SupportMe.Web.ViewModels.Massage
{
    using System.ComponentModel.DataAnnotations;

    public class TicketMassageInputModel
    {
        [Required]
        [UIHint("BootstrapTextArea")]
        public string Content { get; set; }
    }
}
