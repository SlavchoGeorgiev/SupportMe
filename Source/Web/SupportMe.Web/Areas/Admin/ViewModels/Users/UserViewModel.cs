namespace SupportMe.Web.Areas.Admin.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Registration Email")]
        public string Email { get; set; }

        [MaxLength(80)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [MaxLength(80)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Contact Id")]
        public string ContactId { get; set; }

        [Display(Name = "Location Id")]
        public string LocationId { get; set; }

        [Display(Name = "Location name")]
        public string LocationName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserViewModel>()
                .ForMember(vm => vm.ContactId, opts => opts.MapFrom(dbm => dbm.ContactId.ToString()))
                .ForMember(vm => vm.LocationId, opts => opts.MapFrom(dbm => dbm.LocationId.ToString()))
                .ForMember(vm => vm.LocationName, opts => opts.MapFrom(dbm => dbm.Location.Name.ToString()));
        }
    }
}
