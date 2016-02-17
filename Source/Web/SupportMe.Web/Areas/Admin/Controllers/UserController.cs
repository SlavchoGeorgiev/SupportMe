namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Models.Users;
    using Services.Data.Contracts;
    using Services.Data.Results;

    public class UserController : AdministrationController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var companies = this.userService
                .GetAll()
                .To<UserViewModel>();

            var result = companies.ToDataSourceResult(request);
            return this.Json(result);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, UserViewModel model)
        {
            if (this.ModelState.IsValid && model != null)
            {
                UpdateUserResult result = this.userService.Update(
                    model.Id,
                    model.FirstName,
                    model.LastName,
                    model.UserName,
                    model.Email,
                    int.Parse(model.LocationId));

                if (result.result.Succeeded)
                {
                    model = this.userService
                        .GetById(result.user.Id)
                        .To<UserViewModel>()
                        .FirstOrDefault();
                }
                else
                {
                    foreach (var error in result.result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error);
                    }
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, UserViewModel model)
        {
            this.userService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}