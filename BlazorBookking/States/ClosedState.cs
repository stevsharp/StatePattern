using BlazorBookking.States;

namespace BlazorBookking
{
    class ClosedState : BookingState
    {
        private string reasonClosed;

        public ClosedState(string reason)
        {
            reasonClosed = reason;
        }

        public override void Cancel(BookingContext booking)
        {
            booking.View.ShowError("Invalid action for this state", "Closed Booking Error");
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.View.ShowError("Invalid action for this state", "Closed Booking Error");
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action for this state", "Closed Booking Error");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(reasonClosed);
        }
    }
}