namespace SupportMe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Ticket;

    [Authorize]
    public class TicketController : BaseController
    {
        private readonly ITicketService ticketService;
        private readonly ITicketMassageService ticketMassageService;

        public TicketController(ITicketService ticketService, ITicketMassageService ticketMassageService)
        {
            this.ticketService = ticketService;
            this.ticketMassageService = ticketMassageService;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = new TicketDetailsViewModel() { Id = id };

            if (!this.ticketService.GetById(id).Any())
            {
                this.TempData[GlobalMessages.Warning] = "Ticket not found!";
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });
            }

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

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTicketViewModel model)
        {
            if (this.CurrentUser.LocationId == null)
            {
                this.TempData[GlobalMessages.Danger] = "You must have company location to create tickets";
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            if (this.ModelState.IsValid && model != null)
            {
                var authorId = this.CurrentUser.Id;
                TicketType type = (TicketType)Enum.Parse(typeof(TicketType), model.Ticket.Type);
                TicketPriority priority = (TicketPriority)Enum.Parse(typeof(TicketPriority), model.Ticket.Priority);
                var ticketId = this.ticketService.Create(
                    model.Ticket.Title,
                    type,
                    TicketState.Open,
                    priority,
                    (int)this.CurrentUser.LocationId,
                    authorId).Id;

                this.ticketMassageService.Create(
                    model.Massage.Content,
                    decimal.Zero,
                    ticketId,
                    authorId);

                return this.RedirectToAction("Details", "Ticket", new { area = string.Empty, id = ticketId });
            }

            return this.View(model);
        }
    }
}
