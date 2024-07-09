using BlazorBookking.Pages;
using BlazorBookking.States;

namespace BlazorBookking;

public class BookingContext
{
    public Home View { get; set; }
    public string Attendee { get; set; }
    public int TicketCount { get; set; }
    public int BookingID { get; set; }

    private BookingState currentState;

    public int DisplayStatus { get; set; }

    public void TransitionToState(BookingState state)
    {
        currentState = state;

        currentState.EnterState(this);
    }

    public BookingContext(Home view)
    {
        View = view ?? throw new ArgumentNullException(nameof(view));

        TransitionToState(new NewState());
    }

    public void SubmitDetails(string attendee, int ticketCount)
    {
        currentState.EnterDetails(this, attendee, ticketCount);
    }

    public void Cancel()
    {
        currentState.Cancel(this);
    }

    public void DatePassed()
    {
        currentState.DatePassed(this);
    }

    public void ShowState(string stateName)
    {
        //View.grdDetails.Visibility = System.Windows.Visibility.Visible;
        View.CurrentState = stateName;
        View.TicketCount = TicketCount;
        View.Attendee = Attendee;
        View.BookingID = BookingID;
    }

}