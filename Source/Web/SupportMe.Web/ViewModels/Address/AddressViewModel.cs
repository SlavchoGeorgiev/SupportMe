namespace SupportMe.Web.ViewModels.Address
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class AddressViewModel : IMapFrom<Address>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        [DisplayName("ZIP Code")]
        public string ZipCode { get; set; }
    }
}
