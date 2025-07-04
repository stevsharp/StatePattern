
using BlazorAppAtmMachine.Vm;

using Microsoft.AspNetCore.Components;

namespace BlazorAppAtmMachine.Pages;

//public partial class Home
//{

//    private int enteredPin = 1234;

//    private void SubmitPin()
//    {
//        AtmMachine.EnterPIN(enteredPin);
//    }

//    protected override void OnInitialized()
//    {
//        AtmMachine.OnStateChanged += StateHasChanged;
//    }

//    public void Dispose()
//    {
//        AtmMachine.OnStateChanged -= StateHasChanged;
//    }
//}

public partial class Home : IDisposable
{
    [Inject] 
    public HomeViewModel hViewModel { get; set; } = default!;



    protected override void OnInitialized()
    {
        hViewModel.StateChanged += RefreshUI;
    }

    private void RefreshUI() => InvokeAsync(StateHasChanged);

    public void Dispose()
    {
        hViewModel.StateChanged -= RefreshUI;
    }
}


