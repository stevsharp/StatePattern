using BlazorBookking.States;

namespace BlazorBookking;

internal class NewState : BookingState
{
    public override void Cancel(BookingContext booking)
    {
        booking.TransitionToState(new ClosedState("Booking Canceled"));
    }

    public override void DatePassed(BookingContext booking)
    {
        booking.TransitionToState(new ClosedState("Booking Expired"));
    }

    public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
    {
        booking.Attendee = attendee;
        booking.TicketCount = ticketCount;

        booking.TransitionToState(new PendingState());
    }

    public override void EnterState(BookingContext booking)
    {
        booking.BookingID = new Random().Next();
        booking.ShowState("New");
        NewMethod(booking);
    }

    private static void NewMethod(BookingContext booking)
    {
        booking.View.ShowEntryPage();
    }
}