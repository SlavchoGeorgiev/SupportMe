namespace SupportMe.Web.ViewModels.Message
{
    using System.ComponentModel.DataAnnotations;

    public class TicketMessageInputModel
    {
        [Required]
        [UIHint("BootstrapTextArea")]
        public string Content { get; set; }
    }
}
