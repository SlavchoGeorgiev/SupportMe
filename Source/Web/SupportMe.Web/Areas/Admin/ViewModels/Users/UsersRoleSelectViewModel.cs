namespace SupportMe.Web.Areas.Admin.ViewModels.Users
{
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UsersRoleSelectViewModel : IMapFrom<IdentityRole>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
