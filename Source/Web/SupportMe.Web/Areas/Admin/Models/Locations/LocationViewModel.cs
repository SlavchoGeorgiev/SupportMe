namespace SupportMe.Web.Areas.Admin.Models.Locations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;
    using AutoMapper;
    using Contacts;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Location>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string CompanyId { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact Id")]
        public int? ContactId { get; set; }

        public ContactViewModel Contact { get; set; }

        public IEnumerable<SelectListItem> Companies { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Location, LocationViewModel>()
                .ForMember(vm => vm.CompanyName, opt => opt.MapFrom(dbm => dbm.Company.Name))
                .ForMember(vm => vm.CompanyId, opt => opt.MapFrom(dbm => dbm.CompanyId.ToString()));
        }
    }
}
