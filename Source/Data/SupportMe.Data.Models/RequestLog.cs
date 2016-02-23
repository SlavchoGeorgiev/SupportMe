namespace SupportMe.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class RequestLog : BaseModel<int>
    {
        [MaxLength(10)]
        public string Method { get; set; }

        [MaxLength(2048)]
        public string Url { get; set; }

        [MaxLength(40)]
        public string Ip { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
