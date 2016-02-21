namespace SupportMe.Web.Areas.Admin.ViewModels.Users
{
    using System.Collections.Generic;

    public class ManageRoleInputModel
    {
        public UserShortInfoViewModel User { get; set; }

        public IEnumerable<string> SelectedRoles { get; set; }

        public IEnumerable<UsersRoleSelectViewModel> Roles { get; set; }
    }
}
