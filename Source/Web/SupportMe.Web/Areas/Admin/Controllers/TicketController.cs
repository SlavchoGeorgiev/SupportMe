namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Tickets;

    public class TicketController : AdministrationController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var locations = this.ticketService
                .GetAll()
                .To<TicketViewModel>();

            var result = locations.ToDataSourceResult(request);
            return this.Json(result);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, TicketViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                string fieldName = "CreatedOn";
                var m = this.ViewData.ModelState[fieldName];

                if (m != null && m.Errors.Count > 0)
                {
                    this.ViewData.ModelState.Remove(fieldName);
                }
            }

            if (this.ModelState.IsValid && model != null)
            {
                var authorId = this.CurrentUser.Id;
                TicketType type = (TicketType)Enum.Parse(typeof(TicketType), model.Type);
                TicketPriority priority = (TicketPriority)Enum.Parse(typeof(TicketPriority), model.Priority);
                TicketState state = (TicketState)Enum.Parse(typeof(TicketState), model.State);

                var ticketId = this.ticketService.Update(
                    model.Id,
                    model.Title,
                    type,
                    state,
                    priority,
                    int.Parse(model.LocationId)).Id;

                model = this.ticketService
                    .GetById(ticketId)
                    .To<TicketViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, TicketViewModel model)
        {
            this.ticketService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
