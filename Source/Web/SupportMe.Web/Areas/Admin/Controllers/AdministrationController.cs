namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = UserRole.Admin)]
    public class AdministrationController : BaseController
    {
    }
}
