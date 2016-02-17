namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Contacts;
    using Services.Data.Contracts;

    public class ContactController : AdministrationController
    {
        private readonly string[] contactHolders = new[] { "Company", "Location", "User" };

        private IContactService contactService;

        private IAddressService addressService;

        public ContactController(IContactService contactService, IAddressService addressService)
        {
            this.contactService = contactService;
            this.addressService = addressService;
        }

        [HttpGet]
        public ActionResult Index(int? id, string holder)
        {
            var model = new ContactIndexViewModel() { Selectable = false };
            if (id != null && this.contactHolders.Contains(holder))
            {
                model.Selectable = true;
                model.Holder = holder;
                model.HolderId = (int)id;
            }

            this.ViewBag.Addresses = this.addressService
                .GetAll()
                .Select(a => new
                {
                    Value = a.Id.ToString(),
                    Text = a.Country + ", " + a.City + ", " + a.Street
                })
                .ToList();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult SetTo(int? id, string holder, int contactId)
        {
            string massage = "Invalid request";
            if (id != null && this.contactHolders.Contains(holder))
            {
                massage = this.contactService.SetTo((int)id, holder, contactId);
            }

            return this.PartialView("_SetMassage", massage);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var contacts = this.contactService
                .GetAll()
                .To<ContactViewModel>();

            var result = contacts.ToDataSourceResult(request);
            return this.Json(result);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                int id = this.contactService
                    .Create(model.PhoneNumber, model.Email, model.AddressId)
                    .Id;

                model = this.contactService
                    .GetById(id)
                    .To<ContactViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                int id = this.contactService
                    .Update(model.Id, model.PhoneNumber, model.Email, model.AddressId)
                    .Id;
                model = this.contactService
                    .GetById(id)
                    .To<ContactViewModel>()
                    .FirstOrDefault();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
        {
            this.contactService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
