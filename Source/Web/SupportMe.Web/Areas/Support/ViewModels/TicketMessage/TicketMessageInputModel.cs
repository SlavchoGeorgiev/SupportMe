namespace SupportMe.Web.Areas.Support.ViewModels.TicketMessage
{
    using System.ComponentModel.DataAnnotations;

    public class TicketMessageInputModel
    {
        [Required]
        [UIHint("BootstrapTextArea")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Pricing units")]
        [UIHint("BootstrapDecimalNumber")]
        public decimal PricingUnits { get; set; }
    }
}
