namespace SupportMe.Web.ViewModels.Location
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LocationDropDownViewModel : IMapFrom<Location>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Location, LocationDropDownViewModel>()
                .ForMember(vm => vm.Id, opts => opts.MapFrom(dbm => dbm.Id.ToString()));
        }
    }
}
