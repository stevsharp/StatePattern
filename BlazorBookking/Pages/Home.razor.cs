namespace BlazorBookking.Pages
{
    public partial class Home
    {
        public string CurrentState { get; set; }

        public int TicketCount { get; set; }

        public string Attendee { get; set; }

        public int BookingID { get; set; }


        private BookingContext booking;

        private EntryPage entryPage = new EntryPage();

        public void ShowError(string errorText, string caption = "Error")
        {
            //MessageBox.Show(this, errorText, caption);

        }

        public void ShowEntryPage()
        {

        }

        public void ShowProcessingError() { }

        public void ShowStatusPage(string message) { }

        private void NewBooking() 
        {
            booking = new BookingContext(this);
        }

        private void Submit() 
        {
            string attendee = entryPage.txtAttendee;
            
            booking?.SubmitDetails(attendee, entryPage.txtTicketCont);

        }

        private void Cancel() { }

        private void DatePassed() { }
    }
}
    