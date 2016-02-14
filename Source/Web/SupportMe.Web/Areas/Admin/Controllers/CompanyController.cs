namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Companies;
    using Services.Data.Contracts;

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
