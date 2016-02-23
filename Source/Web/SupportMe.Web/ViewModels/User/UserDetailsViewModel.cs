namespace SupportMe.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using Contact;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserDetailsViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Registration Email")]
        public string Email { get; set; }

        [MaxLength(80)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [MaxLength(80)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Contact Id")]
        public int ContactId { get; set; }

        [Display(Name = "Location Id")]
        public int LocationId { get; set; }

        public ContactViewModel Contact { get; set; }
    }
}
