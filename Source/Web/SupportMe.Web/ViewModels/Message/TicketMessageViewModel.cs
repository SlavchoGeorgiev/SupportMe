namespace SupportMe.Web.ViewModels.Message
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using User;

    public class TicketMessageViewModel : IMapFrom<TicketMassage>
    {
        public int? Id { get; set; }

        [Required]
        [UIHint("BootstrapTextArea")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Pricing units")]
        [UIHint("BootstrapDecimalNumber")]
        public decimal PricingUnits { get; set; }

        public int TicketId { get; set; }

        public UserInfoViewModel Author { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
