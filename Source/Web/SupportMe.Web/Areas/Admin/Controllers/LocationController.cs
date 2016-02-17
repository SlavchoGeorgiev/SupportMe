namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Locations;
    using Services.Data.Contracts;

    public class LocationController : AdministrationController
    {
        private readonly ILocationService locationService;
        private readonly ICompanyService companyService;

        public LocationController(ILocationService locationService, ICompanyService companyService)
        {
            this.locationService = locationService;
            this.companyService = companyService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var locations = this.locationService
                .GetAll()
                .To<LocationViewModel>();

            var result = locations.ToDataSourceResult(request);
            return this.Json(result);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, LocationViewModel model)
        {
            if (this.locationService.ContainsName(model.Name))
            {
                this.ModelState.AddModelError("Name", $"Database already contains Location with name {model.Name}");
            }

            if (this.ModelState.IsValid && model != null)
            {
                int id = this.locationService.Create(model.Name, int.Parse(model.CompanyId)).Id;
                model = this.locationService
                    .GetById(id)
                    .To<LocationViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, LocationViewModel model)
        {
            if (this.locationService.ContainsName(model.Name, exceptId: model.Id))
            {
                this.ModelState.AddModelError("Name", $"Database already contains Location with name {model.Name}");
            }

            if (this.ModelState.IsValid && model != null)
            {
                int id = this.locationService.Update(model.Id, model.Name, int.Parse(model.CompanyId)).Id;
                model = this.locationService
                    .GetById(id)
                    .To<LocationViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, LocationViewModel model)
        {
            this.locationService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
