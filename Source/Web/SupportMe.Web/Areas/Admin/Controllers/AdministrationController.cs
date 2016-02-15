namespace SupportMe.Web.Areas.Admin.Controllers
{
    using System;
    using System.Web.Mvc;
    using Data.Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = UserRole.Admin)]
    public class AdministrationController : BaseController
    {
        [HttpPost]
        public ActionResult ExportToExcel(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }
    }
}
