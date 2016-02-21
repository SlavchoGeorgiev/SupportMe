namespace SupportMe.Web.Areas.Support.ViewModels.TicketMassage
{
    using System.ComponentModel.DataAnnotations;

    public class TicketMassageInputModel
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
