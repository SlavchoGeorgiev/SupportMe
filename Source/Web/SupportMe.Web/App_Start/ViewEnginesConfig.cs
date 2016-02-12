namespace SupportMe.Web
{
    using System;
    using System.Web.Mvc;

    public static class ViewEnginesConfig
    {
        public static void Register()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}