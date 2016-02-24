namespace SupportMe.Web.ViewModels.Message
{
    using System.Collections.Generic;

    public class MessageForTicketViewModel
    {
        public int TicketId { get; set; }

        public TicketMessageViewModel Message { get; set; }

        public IEnumerable<TicketMessageViewModel> Messages { get; set; }
    }
}
