using Microsoft.AspNetCore.Components;

namespace BlazorAppAtmMachine.Pages;

public partial class ModalDialog : ComponentBase
{
    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string Text { get; set; }

    [Parameter]
    public bool ShowCancel { get; set; } = false;

    [Parameter]
    public bool ShowOk { get; set; }

    [Parameter]
    public EventCallback<bool> OnClose { get; set; }
    /// <summary>
    /// Cancel is pressed
    /// </summary>
    /// <returns></returns>
    private Task ModalCancel()
    {
        return OnClose.InvokeAsync(false);
    }
    /// <summary>
    /// Ok is pressed
    /// </summary>
    /// <returns></returns>
    private Task ModalOk()
    {
        return OnClose.InvokeAsync(true);
    }
}
