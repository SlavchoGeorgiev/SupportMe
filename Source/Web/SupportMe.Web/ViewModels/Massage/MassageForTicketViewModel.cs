namespace SupportMe.Web.ViewModels.Massage
{
    using System.Collections.Generic;

    public class MassageForTicketViewModel
    {
        public int TicketId { get; set; }

        public TicketMassageViewModel Massage { get; set; }

        public IEnumerable<TicketMassageViewModel> Massages { get; set; }
    }
}
