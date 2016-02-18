namespace SupportMe.Web.Areas.Support.Controllers
{
    using System.Web.Mvc;
    using Data.Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = UserRole.Admin + ", " + UserRole.Support)]
    public abstract class SupportController : BaseController
    {
    }
}
