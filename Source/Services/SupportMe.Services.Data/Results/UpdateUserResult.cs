namespace SupportMe.Services.Data.Results
{
    using Microsoft.AspNet.Identity;
    using SupportMe.Data.Models;

    public class UpdateUserResult
    {
        public User user { get; set; }

        public IdentityResult result { get; set; }
    }
}
