namespace SupportMe.Web.Filters
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    public class LogAttribute : BaseActionFilterAttribute
    {
        public ILogService LogService { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var method = filterContext.HttpContext.Request.HttpMethod;
            var url = filterContext.HttpContext.Request.RawUrl;
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            this.LogService.LogRequest(userId, ip, url, method);

            base.OnActionExecuting(filterContext);
        }
    }
}
