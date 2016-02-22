namespace SupportMe.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserInfoViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        [MaxLength(80)]
        public string FirstName { get; set; }

        [MaxLength(80)]
        public string LastName { get; set; }
    }
}
