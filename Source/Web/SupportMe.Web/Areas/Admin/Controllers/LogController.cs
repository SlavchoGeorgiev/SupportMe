namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Log;

    public class LogController : AdministrationController
    {
        private readonly ILogService logService;

        public LogController(ILogService logService)
        {
            this.logService = logService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var logs = this.logService
                .GetAll()
                .To<LogViewModel>();

            var result = logs.ToDataSourceResult(request);
            return this.Json(result);
        }
    }
}
