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

    private IDisposable? _subscription;

    private EditContext? CurrentEditContext;

    protected override async Task OnInitializedAsync()
    {

        CurrentEditContext = new EditContext(this);

        _subscription = FormService.SubmitRequested.Subscribe(_ => HandleValidSubmit());

        await base.OnInitializedAsync();
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
    private void Submit()
    {
        //var error = string.Join(". ", editContext.GetValidationMessages());

        Console.WriteLine("Form submitted successfully!");
    }

    private void HandleValidSubmit()
    {
        InvokeAsync(() =>
        {
            CurrentEditContext?.Validate();

            if (CurrentEditContext.Validate())
            {
                Submit();
            }
        });
    }

    public void Dispose()
    {
        _subscription?.Dispose();
    }
}
