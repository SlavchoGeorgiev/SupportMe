namespace SupportMe.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data.Contracts;

    [Authorize]
    public class TicketController : BaseController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public ActionResult Details(int id)
        {
            // TODO
            return this.View();
        }
    }
}
