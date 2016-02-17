namespace SupportMe.Web.Areas.Admin
{
    using System.Web.Mvc;
    using Common;
    using Common.Constants;

    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return MvcArea.Admin;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_SelectContact",
                "Admin/Contact/{action}/{id}/{holder}",
                new { action = "Index", controller = "Contact", id = UrlParameter.Optional, holder = UrlParameter.Optional });

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
