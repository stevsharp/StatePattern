using Microsoft.AspNetCore.Components.Web;

namespace BlazorBookking.Pages
{
    public partial class EntryPage
    {
        public string attendeeName { get; set; }
        public int ticketCount { get; set; }

        private void ValidateNumber(KeyboardEventArgs e)
        {
            if (!char.IsDigit((char)e.Key[0]) && e.Key != "Backspace" && e.Key != "Delete")
            {
                //e.PreventDefault();
            }
        }
    }
}
