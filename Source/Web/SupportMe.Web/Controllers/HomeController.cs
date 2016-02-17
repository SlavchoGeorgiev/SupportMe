namespace SupportMe.Web.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            this.TempData[GlobalMessages.Success] = $"Hello {this.CurrentUser.FirstName} {this.CurrentUser.LastName} {this.CurrentUser.UserName}";
            return this.View();
        }
    }
}
