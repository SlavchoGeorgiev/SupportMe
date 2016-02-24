namespace SupportMe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Message;

    [Authorize]
    public class MessageController : BaseController
    {
        private readonly ITicketMessageService ticketMessageService;

        public MessageController(ITicketMessageService ticketMessageService)
        {
            this.ticketMessageService = ticketMessageService;
        }

        [HttpGet]
        public ActionResult ForTicket(int id)
        {
            var model = new MessageForTicketViewModel();
            model.TicketId = id;
            model.Messages = this.ticketMessageService
                .GetAllForTicket(id)
                .To<TicketMessageViewModel>()
                .ToList();

            return this.PartialView("_MessagesForTicket", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToTicket(MessageForTicketViewModel model)
        {
            if (this.ModelState.IsValid && model.Message != null)
            {
                this.ticketMessageService.Create(
                    model.Message.Content,
                    model.Message.PricingUnits,
                    model.TicketId,
                    this.CurrentUser.Id);

                model.Message = null;
                model.Messages = this.ticketMessageService
                    .GetAllForTicket(model.TicketId)
                    .To<TicketMessageViewModel>()
                    .ToList();

                return this.PartialView("_MessagesForTicket", model);
            }

            model.Messages = this.ticketMessageService
                .GetAllForTicket(model.TicketId)
                .To<TicketMessageViewModel>()
                .ToList();

            return this.PartialView("_MessagesForTicket", model);
        }
    }
}
