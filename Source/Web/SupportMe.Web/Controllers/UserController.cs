namespace SupportMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using ViewModels.User;

    [Authorize]
    public class UserController : BaseController
    {
        private const string AvatarPath = "/App_Data/avatars/";

        public const string DefaultAvatar = "avatar.jpg";

        private const int MaxAvatarSize = 1024000;

        public ActionResult Details(string id)
        {
            var model = new DetailsViewModel();
            model.User = this.Mapper.Map<UserDetailsViewModel>(this.CurrentUser);
            return this.View(model);
        }

        [HttpGet]
        public ActionResult AvatarUpload()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AvatarUpload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                var file = files.FirstOrDefault();
                if (file != null)
                {
                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (fileExtension != ".jpg" && fileExtension != ".jpeg")
                    {
                        this.TempData[GlobalMessages.Danger] = "Image must be with extension .jpg or .jpeg";
                        return this.RedirectToAction("AvatarUpload");
                    }

                    if (file.ContentLength > MaxAvatarSize)
                    {
                        this.TempData[GlobalMessages.Danger] = "Image must be smaller than 1MB";
                        return this.RedirectToAction("AvatarUpload");
                    }

                    var fileName = this.CurrentUser.Id;
                    var path = Path.Combine(Server.MapPath("~/App_Data/avatars"), $"{fileName}{fileExtension}");
                    file.SaveAs(path);
                    this.UserService.AddAvatar(this.CurrentUser.Id, fileName, fileExtension);
                    this.TempData[GlobalMessages.Success] = "Avarat updated!";
                    return this.RedirectToAction("AvatarUpload");
                }
            }

            this.TempData[GlobalMessages.Danger] = "Please select file uploaded!";
            return this.RedirectToAction("AvatarUpload");
        }

        public ActionResult AvatarUploadForm()
        {
            return this.PartialView("_AvatarUploadForm", this.CurrentUser.Id);
        }

        public ActionResult GetAvatar(string id)
        {
            string filename;
            if (id == null)
            {
                filename = DefaultAvatar;
            }
            else
            {
                var user = this.UserService.GetById(id).FirstOrDefault();
                filename = user?.AvatarFileName != null ? user.AvatarFileName + user.AvatarFileExtension : DefaultAvatar;
            }

            string filepath = AppDomain.CurrentDomain.BaseDirectory + AvatarPath + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            // this.Response.AppendHeader("Content-Disposition", cd.ToString());
            return this.File(filedata, contentType);
        }
    }
}
