namespace SupportMe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Massage;

    [Authorize]
    public class MassageController : BaseController
    {
        private readonly ITicketMassageService ticketMassageService;

        public MassageController(ITicketMassageService ticketMassageService)
        {
            this.ticketMassageService = ticketMassageService;
        }

        [HttpGet]
        public ActionResult ForTicket(int id)
        {
            var model = new MassageForTicketViewModel();
            model.TicketId = id;
            model.Massages = this.ticketMassageService
                .GetAllForTicket(id)
                .To<TicketMassageViewModel>()
                .ToList();

            return this.PartialView("_MassagesForTicket", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToTicket(MassageForTicketViewModel model)
        {
            if (this.ModelState.IsValid && model.Massage != null)
            {
                this.ticketMassageService.Create(
                    model.Massage.Content,
                    model.Massage.PricingUnits,
                    model.TicketId,
                    this.CurrentUser.Id);

                model.Massage = null;
                model.Massages = this.ticketMassageService
                    .GetAllForTicket(model.TicketId)
                    .To<TicketMassageViewModel>()
                    .ToList();

                return this.PartialView("_MassagesForTicket", model);
            }

            model.Massages = this.ticketMassageService
                .GetAllForTicket(model.TicketId)
                .To<TicketMassageViewModel>()
                .ToList();

            return this.PartialView("_MassagesForTicket", model);
        }
    }
}
