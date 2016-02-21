namespace SupportMe.Web.Areas.Admin.ViewModels.Tickets
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class TicketViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string LocationId { get; set; }

        public string Location { get; set; }

        [Display(Name = "Uathor Username")]
        public string Author { get; set; }

        [Display(Name="Created on")]
        public DateTime? CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Ticket, TicketViewModel>()
                .ForMember(vm => vm.Priority, opts => opts.MapFrom(dbm => dbm.Priority.ToString()))
                .ForMember(vm => vm.Type, opts => opts.MapFrom(dbm => dbm.Type.ToString()))
                .ForMember(vm => vm.State, opts => opts.MapFrom(dbm => dbm.State.ToString()))
                .ForMember(vm => vm.LocationId, opts => opts.MapFrom(dbm => dbm.LocationId.ToString()))
                .ForMember(vm => vm.Location, opts => opts.MapFrom(dbm => dbm.Location.Name.ToString()))
                .ForMember(vm => vm.Author, opts => opts.MapFrom(dbm => dbm.Author.UserName.ToString()));
        }
    }
}
