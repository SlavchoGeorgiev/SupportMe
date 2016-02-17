namespace SupportMe.Web.Areas.Admin.Models.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ContactViewModel : IMapFrom<Contact>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [MaxLength(254)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Address")]
        public string AddressId { get; set; }

        [Display(Name = "Address")]
        public string AddressName { get; set; }

        public IEnumerable<SelectListItem> Addresses { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Contact, ContactViewModel>()
                .ForMember(
                    vm => vm.AddressName,
                    opts => opts.MapFrom(
                        dbm => dbm.Address != null ? dbm.Address.Country.ToString() + ", " + dbm.Address.City.ToString() + ", " + dbm.Address.Street.ToString() : "No Address"))
                .ForMember(vm => vm.AddressId, opt => opt.MapFrom(dbm => dbm.AddressId.ToString()));
        }
    }
}
