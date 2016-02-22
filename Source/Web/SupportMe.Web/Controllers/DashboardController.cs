namespace SupportMe.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
