namespace SupportMe.Web.Areas.Admin.ViewModels.Log
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LogViewModel : IMapFrom<RequestLog>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Method { get; set; }

        [MaxLength(2048)]
        public string Url { get; set; }

        [MaxLength(40)]
        public string Ip { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RequestLog, LogViewModel>()
                .ForMember(vm => vm.Username, opts => opts.MapFrom(dbm => dbm.User.UserName));
        }
    }
}
