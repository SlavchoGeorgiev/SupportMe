namespace SupportMe.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class TicketController : BaseController
    {
        public ActionResult Details(int id)
        {
            // TODO
            return this.View();
        }
    }
}
