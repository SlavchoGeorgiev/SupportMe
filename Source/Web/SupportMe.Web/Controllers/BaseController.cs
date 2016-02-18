namespace SupportMe.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using Services.Web.Contracts;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        public IUserService UserService { get; set; }

        protected User CurrentUser { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.CurrentUser = this.UserService.GetByUsername(filterContext.HttpContext.User.Identity.Name).FirstOrDefault();

            base.OnActionExecuting(filterContext);
        }
    }
}
