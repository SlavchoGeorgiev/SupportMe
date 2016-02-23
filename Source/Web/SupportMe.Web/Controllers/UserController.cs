namespace SupportMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Data.Contracts;
    using ViewModels.Address;
    using ViewModels.Location;
    using ViewModels.User;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly ILocationService locationService;

        private readonly IContactService contactService;

        private readonly IAddressService addressService;

        private const string AvatarPath = "/App_Data/avatars/";

        private const string DefaultAvatar = "avatar.jpg";

        private const int MaxAvatarSize = 1024000;

        public UserController(
            ILocationService locationService,
            IContactService contactService,
            IAddressService addressService)
        {
            this.locationService = locationService;
            this.contactService = contactService;
            this.addressService = addressService;
        }

        public ActionResult Details(string id)
        {
            var model = new DetailsViewModel();
            var user = this.UserService.GetById(id).FirstOrDefault();

            if (user == null)
            {
                this.TempData[GlobalMessages.Warning] = "User not found";
                return this.RedirectToAction("Index", "Home", new {area = string.Empty});
            }

            model.User = this.Mapper.Map<UserDetailsViewModel>(user);
            var userAddress = this.addressService.GetById(model.User.Contact.AddressId).FirstOrDefault();
            if (userAddress != null && model.User.Contact != null)
            {
                model.User.Contact.Address = this.Mapper.Map<AddressViewModel>(userAddress);
            }

            var userLocation = this.locationService.GetById(model.User.LocationId).FirstOrDefault();
            if (userLocation != null)
            {
                model.Location = this.Mapper.Map<LocationViewModel>(userLocation);
                var locationAddress = this.addressService.GetById(model.Location.Contact.AddressId).FirstOrDefault();
                if (locationAddress != null)
                {
                    model.Location.Contact.Address = this.Mapper.Map<AddressViewModel>(locationAddress);
                }
            }

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
            var file = files?.FirstOrDefault();
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
                var path = Path.Combine(this.Server.MapPath("~/App_Data/avatars"), $"{fileName}{fileExtension}");
                file.SaveAs(path);
                this.UserService.AddAvatar(this.CurrentUser.Id, fileName, fileExtension);
                this.TempData[GlobalMessages.Success] = "Avarat updated!";
                return this.RedirectToAction("AvatarUpload");
            }

            this.TempData[GlobalMessages.Danger] = "Please select file!";
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
