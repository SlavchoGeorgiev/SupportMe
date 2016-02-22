namespace SupportMe.Web.ViewModels.Massage
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using ViewModels.User;

    public class TicketMassageViewModel : IMapFrom<TicketMassage>
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
