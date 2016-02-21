namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Results;
    using ViewModels.Users;

    public class UserController : AdministrationController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult ManageRoles(string id)
        {
            var model = new ManageRoleInputModel();
            model.User = this.UserService.GetById(id).To<UserShortInfoViewModel>().FirstOrDefault();
            model.SelectedRoles = this.UserService.GetUserRoles(id);
            model.Roles = this.Cache.Get(
                "UserRoles",
                () => this.UserService.GetAllRoles().To<UsersRoleSelectViewModel>().ToList(),
                10 * 60 * 60);
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageRoles(string id, ManageRoleInputModel model)
        {
            if (id == null)
            {
                this.TempData[GlobalMessages.Danger] = "User id is required!";
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            if (this.ModelState.IsValid && model != null)
            {
                this.UserService.UpdateRoles(id, model.SelectedRoles);
                this.TempData[GlobalMessages.Success] =
                    $"User roles updated with {string.Join(", ", model.SelectedRoles)}!";
                return this.RedirectToAction("Index");
            }

            model.User = this.UserService.GetById(id).To<UserShortInfoViewModel>().FirstOrDefault();
            model.SelectedRoles = this.UserService.GetUserRoles(id);
            model.Roles = this.Cache.Get(
                "UserRoles",
                () => this.UserService.GetAllRoles().To<UsersRoleSelectViewModel>().ToList(),
                10 * 60 * 60);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var companies = this.UserService
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
                UpdateUserResult result = this.UserService.Update(
                    model.Id,
                    model.FirstName,
                    model.LastName,
                    model.UserName,
                    model.Email,
                    int.Parse(model.LocationId));

                if (result.Result.Succeeded)
                {
                    model = this.UserService
                        .GetById(result.User.Id)
                        .To<UserViewModel>()
                        .FirstOrDefault();
                }
                else
                {
                    foreach (var error in result.Result.Errors)
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
            this.UserService.Delete(model.Id);

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
