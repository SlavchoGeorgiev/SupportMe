namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Companies;

    public class CompanyController : AdministrationController
    {
        private ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ActionName("Read")]
        [OutputCache(Duration = 10 * 60)]
        public ActionResult ReadGet([DataSourceRequest]DataSourceRequest request)
        {
            var companies = this.companyService
                .GetAll()
                .To<CompanyDropDownViewModel>()
                .ToArray();

            return this.Json(companies, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var companies = this.companyService
                .GetAll()
                .To<CompanyViewModel>();

            var result = companies.ToDataSourceResult(request);
            return this.Json(result);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CompanyViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                int id = this.companyService.Create(model.Name, model.ContactId);
                model = this.companyService
                    .GetById(id)
                    .To<CompanyViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CompanyViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                int id = this.companyService.Update(model.Id, model.Name, model.ContactId).Id;
                model = this.companyService
                    .GetById(id)
                    .To<CompanyViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, CompanyViewModel model)
        {
            this.companyService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
