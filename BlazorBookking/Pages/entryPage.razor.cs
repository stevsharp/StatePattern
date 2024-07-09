using BlazorBookking.Model;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBookking.Pages;
public partial class EntryPage
{

    [CascadingParameter]
    public AttendeModel Attende { get; set; } = new AttendeModel();

    [Parameter]
    public bool Show { get; set; }
    private void ValidateNumber(KeyboardEventArgs e)
    {
        if (!char.IsDigit((char)e.Key[0]) && e.Key != "Backspace" && e.Key != "Delete")
        {
            //e.PreventDefault();
        }
    }
}
