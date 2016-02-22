namespace SupportMe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Ticket;

    [Authorize]
    public class TicketController : BaseController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = new TicketDetailsViewModel() { Id = id };
            return this.View(model);
        }

        [HttpGet]
        public ActionResult TicketInfo(int id)
        {
            var model = this.ticketService.GetById(id)
                .To<TicketInfoViewModel>()
                .FirstOrDefault();

            return this.PartialView("_TicketInfo", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this.ticketService.GetById(id)
                   .To<TicketInfoViewModel>()
                   .FirstOrDefault();

            return this.PartialView("_TicketEditInfo", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketInfoViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                TicketType type = (TicketType)Enum.Parse(typeof(TicketType), model.Type);
                TicketPriority priority = (TicketPriority)Enum.Parse(typeof(TicketPriority), model.Priority);
                TicketState state = (TicketState)Enum.Parse(typeof(TicketState), model.State);

                if (model.LocationId == null)
                {
                    model.LocationId = this.ticketService
                        .GetById(model.Id)
                        .Select(m => m.LocationId)
                        .FirstOrDefault()
                        .ToString();
                }

                var ticketId = this.ticketService.Update(
                    model.Id,
                    model.Title,
                    type,
                    state,
                    priority,
                    int.Parse(model.LocationId)).Id;

                model = this.ticketService
                    .GetById(ticketId)
                    .To<TicketInfoViewModel>()
                    .FirstOrDefault();

                return this.PartialView("_TicketInfo", model);
            }

            return this.PartialView("_TicketEditInfo", model);
        }
    }
}
