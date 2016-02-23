namespace SupportMe.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Services.Data.Contracts;
    using ViewModels.Statistics;

    public class StatisticsController : BaseController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [OutputCache(Duration = 1 * 60 * 30)]
        public ActionResult TicketStatePie()
        {
            var states = this.statisticsService.TicketsCountByState();
            var model = new List<TicketStatePieViewModel>();

            if (states.Total != 0)
            {
                model.Add(new TicketStatePieViewModel("Open", states.Open / (decimal)states.Total * 100));
                model.Add(new TicketStatePieViewModel("On Hold", states.Hold / (decimal)states.Total * 100));
                model.Add(new TicketStatePieViewModel("Closed", states.Closed / (decimal)states.Total * 100));
            }

            return this.PartialView("_TicketStatePie", model);
        }
    }
}
