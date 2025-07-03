
using BlazorAppAtmMachine.State;

namespace BlazorAppAtmMachine.Pages;

public partial class Home
{

    private int enteredPin = 1234;

    private void SubmitPin()
    {
        AtmMachine.EnterPIN(enteredPin);
    }

    protected override void OnInitialized()
    {
        AtmMachine.OnStateChanged += StateHasChanged;
    }

    public void Dispose()
    {
        AtmMachine.OnStateChanged -= StateHasChanged;
    }
}

//private string statusMessage;

//private ATM _atm;

//private bool isInsertCardDisabled;
//private bool isEjectCardDisabled;
//private bool isEnterPinDisabled;
//private bool isRequestCashDisabled;
//private int enteredPin = 1234;

//private void SubmitPin()
//{
//    AtmMachine.EnterPIN(enteredPin);
//}

//protected override void OnInitialized()
//{
//    _atm = new ATM(500);            // Initialize ATM with some cash
//    AtmMachine.OnStateChanged += StateHasChanged;
//    UpdateStatus();
//}

//private void InsertCard()
//{
//    _atm.CurrentState.InsertCard(_atm);

//    UpdateStatus();
//}

//private void EjectCard()
//{
//    _atm.CurrentState.EjectCard(_atm);

//    UpdateStatus();
//}

//private void EnterPin()
//{
//    _atm.CurrentState.InsertPin(_atm, 1234); // Example PIN

//    UpdateStatus();
//}

//private void RequestCash()
//{
//    _atm.CurrentState.RequestCash(_atm, 100); // Example cash amount

//    UpdateStatus();
//}

//private void UpdateStatus()
//{
//    statusMessage = $"ATM current state: {_atm.CurrentState.GetType().Name} - Money {_atm.CashInMachine}";

//    isInsertCardDisabled = _atm.CurrentState is HasCardState || _atm.CurrentState is HasCorrectPinState || _atm.CurrentState is NoCashState;
//    isEjectCardDisabled = _atm.CurrentState is NoCardState || _atm.CurrentState is NoCashState;
//    isEnterPinDisabled = _atm.CurrentState is NoCardState || _atm.CurrentState is HasCorrectPinState || _atm.CurrentState is NoCashState;
//    isRequestCashDisabled = _atm.CurrentState is NoCardState || _atm.CurrentState is HasCardState || _atm.CurrentState is NoCashState || !_atm.CorrectPinEntered;
//}

//public void Dispose()
//{
//    AtmMachine.OnStateChanged -= StateHasChanged;
//}
