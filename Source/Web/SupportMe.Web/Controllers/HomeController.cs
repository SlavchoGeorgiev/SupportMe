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
            this.TempData[GlobalMessages.Success] = "Hello message";
            return this.View();
        }
    }
}
