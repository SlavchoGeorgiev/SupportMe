﻿namespace SupportMe.Web.Areas.Support
{
    using System.Web.Mvc;

    public class SupportAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Support";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Support_default",
                "Support/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SupportMe.Web.Areas.Support.Controllers" });
        }
    }
}
