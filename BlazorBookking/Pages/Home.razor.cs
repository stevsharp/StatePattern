using BlazorBookking.Model;

namespace BlazorBookking.Pages
{
    public partial class Home
    {
        public string CurrentState { get; set; }

        public int TicketCount { get; set; }

        public string Attendee { get; set; }

        public int BookingID { get; set; }


        private BookingContext booking;


        private bool displayEntryPage = false;

        public string DisplayStatus { get; set; }

        public AttendeModel Attende { get; set; } = new AttendeModel();

        public void ShowError(string errorText, string caption = "Error")
        {
            //MessageBox.Show(this, errorText, caption);

        }

        public void ShowEntryPage()
        {
            displayEntryPage = true;
        }

        public void ShowProcessingError() 
        { 

        }

        public void ShowStatusPage(string message) 
        {
            this.DisplayStatus = message;

            this.displayEntryPage = false;

            this.StateHasChanged();
        }

        private void NewBooking() 
        {
            booking = new BookingContext(this);
        }

        private void Submit() 
        {
            FormService.RequestSubmit();
        }

        private void Cancel() 
        {
            booking?.Cancel();
        }

        private void DatePassed() 
        {
            booking?.DatePassed();
        }
    }
}
    