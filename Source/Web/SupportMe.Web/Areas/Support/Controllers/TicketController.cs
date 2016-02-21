namespace SupportMe.Web.Areas.Support.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data.Contracts;
    using ViewModels.Ticket;

    public class TicketController : SupportController
    {
        private readonly ITicketService ticketService;
        private readonly ITicketMassageService ticketMassageService;

        public TicketController(ITicketService ticketService, ITicketMassageService ticketMassageService)
        {
            this.ticketService = ticketService;
            this.ticketMassageService = ticketMassageService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTicketViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                var authorId = this.CurrentUser.Id;
                TicketType type = (TicketType)Enum.Parse(typeof(TicketType), model.Ticket.Type);
                TicketPriority priority = (TicketPriority)Enum.Parse(typeof(TicketPriority), model.Ticket.Priority);
                TicketState state = (TicketState)Enum.Parse(typeof(TicketState), model.Ticket.State);
                var ticketId = this.ticketService.Create(
                    model.Ticket.Title,
                    type,
                    state,
                    priority,
                    int.Parse(model.Ticket.LocationId),
                    authorId).Id;

                this.ticketMassageService.Create(
                    model.Massage.Content,
                    model.Massage.PricingUnits,
                    ticketId,
                    authorId);

                return this.RedirectToAction("Details", "Ticket", new { area = string.Empty, id = ticketId });
            }

            return this.View(model);
        }
    }
}
