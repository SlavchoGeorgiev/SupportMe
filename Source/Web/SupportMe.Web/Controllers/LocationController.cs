namespace SupportMe.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using SupportMe.Web.ViewModels.Location;

    public class LocationController : BaseController
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        [Authorize]
        [OutputCache(Duration = 1 * 60)]
        public ActionResult GetDropDown([DataSourceRequest]DataSourceRequest request)
        {
            var locations = this.locationService
                .GetAll()
                .To<LocationDropDownViewModel>()
                .ToArray();

            return this.Json(locations, JsonRequestBehavior.AllowGet);
        }
    }
}
