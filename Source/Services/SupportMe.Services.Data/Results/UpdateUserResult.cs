namespace SupportMe.Services.Data.Results
{
    using Microsoft.AspNet.Identity;
    using SupportMe.Data.Models;

    public class UpdateUserResult
    {
        public User User { get; set; }

        public IdentityResult Result { get; set; }
    }
}
