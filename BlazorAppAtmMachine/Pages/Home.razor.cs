
using BlazorAppAtmMachine.Vm;

using Microsoft.AspNetCore.Components;

namespace BlazorAppAtmMachine.Pages;

public partial class Home : IDisposable
{
    [Inject] 
    public HomeViewModel hViewModel { get; set; } = default!;

    protected override void OnInitialized() => hViewModel.StateChanged += RefreshUI;
    
    private void RefreshUI() => InvokeAsync(StateHasChanged);

    public void Dispose() => hViewModel.StateChanged -= RefreshUI;

}


