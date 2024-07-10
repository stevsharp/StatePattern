using BlazorBookking.Model;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBookking.Pages;
public partial class EntryPage
{

    [CascadingParameter]
    public AttendeModel Attende { get; set; } = new AttendeModel();

    [Parameter]
    public bool Show { get; set; }

    [Parameter]
    public BookingContext Booking { get; set; }

    private IDisposable? _subscription;

    private EditContext? editContext;

    private ValidationMessageStore? messageStore;

    protected override async Task OnInitializedAsync()
    {

        editContext = new(Attende);

        editContext.OnValidationRequested += HandleValidationRequested;

        messageStore = new(editContext);

        _subscription = FormService.SubmitRequested.Subscribe(_ => HandleValidSubmit());

        await base.OnInitializedAsync();
    }

    private void HandleValidationRequested(object? sender, ValidationRequestedEventArgs args)
    {
        messageStore?.Clear();

        // Custom validation logic
        //if (!Model!.Options)
        //{
        //    messageStore?.Add(() => Model.Options, "Select at least one.");
        //}
    }

    private void ValidateNumber(KeyboardEventArgs e)
    {
        if (!char.IsDigit((char)e.Key[0]) && e.Key != "Backspace" && e.Key != "Delete")
        {
            //e.PreventDefault();
        }
    }
    /// <summary>   
    /// Context="CurrentEditContext"
    /// </summary>
    private void Submit(EditContext editContext)
    {
        string attendee = Attende.attendeeName;

        Booking?.SubmitDetails(attendee, Attende.ticketCount);
    }

    private void HandleValidSubmit()
    {
        InvokeAsync(() =>
        {
            bool formIsValid = editContext.Validate();

            if (formIsValid)
            {
                Submit(this.editContext);
            }
        });
    }

    public void Dispose()
    {
        _subscription?.Dispose();

        if (editContext is not null)
        {
            editContext.OnValidationRequested -= HandleValidationRequested;
        }
    }
}
