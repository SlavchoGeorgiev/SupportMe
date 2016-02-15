namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Addresses;
    using Services.Data.Contracts;

    public class AddressController : AdministrationController
    {
        private IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var addresses = this.addressService
                .GetAll()
                .To<AddressViewModel>();

            var result = addresses.ToDataSourceResult(request);
            return this.Json(result);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, AddressViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                int id = this.addressService
                    .Create(model.Country, model.City, model.Street, model.State, model.ZipCode)
                    .Id;
                model = this.addressService
                    .GetById(id)
                    .To<AddressViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, AddressViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                int id = this.addressService
                    .Update(model.Id, model.Country, model.City, model.Street, model.State, model.ZipCode)
                    .Id;
                model = this.addressService
                    .GetById(id)
                    .To<AddressViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, AddressViewModel model)
        {
            this.addressService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
