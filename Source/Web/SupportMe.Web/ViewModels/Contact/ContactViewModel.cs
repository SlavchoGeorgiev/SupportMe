namespace SupportMe.Web.ViewModels.Contact
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Address;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ContactViewModel : IMapFrom<Contact>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [MaxLength(254)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        public int AddressId { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
