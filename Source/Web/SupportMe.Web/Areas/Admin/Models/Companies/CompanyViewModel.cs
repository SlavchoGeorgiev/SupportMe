namespace SupportMe.Web.Areas.Admin.Models.Companies
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CompanyViewModel : IMapFrom<Company>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? ContactId { get; set; }
    }
}
