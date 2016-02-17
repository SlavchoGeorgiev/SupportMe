namespace SupportMe.Web.Areas.Admin.Models.Companies
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CompanyDropDownViewModel : IMapFrom<Company>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Company, CompanyDropDownViewModel>()
                .ForMember(vm => vm.Id, opts => opts.MapFrom(dbm => dbm.Id.ToString()));
        }
    }
}
