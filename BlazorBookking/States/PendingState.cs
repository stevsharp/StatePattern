using BlazorBookking.Model;
using BlazorBookking.States;

namespace BlazorBookking;

internal class PendingState : BookingState
{
    CancellationTokenSource cancelToken;

    public override void Cancel(BookingContext booking)
    {

    }

    public override void DatePassed(BookingContext booking)
    {

    }

    public override async void EnterDetails(BookingContext booking, string attendee, int ticketCount)
    {
        cancelToken = new CancellationTokenSource();

        booking.ShowState("Pending");

        booking.View.ShowStatusPage("Processing Booking");

        await ProcessBooking(booking, ProcessingComplete, cancelToken);

    }

    public void ProcessingComplete(BookingContext booking, ProcessingResult result)
    {
        switch (result)
        {
            case ProcessingResult.Sucess:
                booking.TransitionToState(new BookedState());
                break;
            case ProcessingResult.Fail:
                booking.View.ShowProcessingError();

                booking.TransitionToState(new NewState());
                break;
            case ProcessingResult.Cancel:
                booking.TransitionToState(new ClosedState("Processing Canceled"));
                break;
        }
    }

    public override async void EnterState(BookingContext booking)
    {
        cancelToken = new CancellationTokenSource();

        booking.ShowState("Pending");

        booking.View.ShowStatusPage("Processing Booking");

        await ProcessBooking(booking, ProcessingComplete, cancelToken);
    }

    public static async Task ProcessBooking(BookingContext booking, Action<BookingContext, ProcessingResult> callback, CancellationTokenSource token)
    {

        try
        {
            await Task.Run(async delegate
            {
                await Task.Delay(new TimeSpan(0, 0, 3), token.Token);
            });
        }
        catch (OperationCanceledException)
        {
            callback(booking, ProcessingResult.Cancel);
            return;
        }

        ProcessingResult result = new Random().Next(0, 2) == 0 ? ProcessingResult.Sucess : ProcessingResult.Fail;

        callback(booking, result);
    }
}