namespace SupportMe.Web.ViewModels.Statistics
{
    public class TicketStatePieViewModel
    {
        public TicketStatePieViewModel()
        {
        }

        public TicketStatePieViewModel(string source, decimal percentage)
        {
            this.Source = source;
            this.Percentage = percentage;
        }

        public string Source { get; set; }

        public decimal Percentage { get; set; }

        public bool Explode { get; set; }
    }
}
