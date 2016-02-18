namespace SupportMe.Web.Areas.Support.Controllers
{
    using System.Web.Mvc;

    public class TicketController : SupportController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}