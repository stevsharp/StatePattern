using Newtonsoft.Json;


namespace BlazorAppAtmMachine.State;

public class ATM
{
    public IATMState HasCardState { get; set; }
    public IATMState NoCardState { get; set; }
    public IATMState HasCorrectPinState { get; set; }
    public IATMState NoCashState { get; set; }
    public IATMState CurrentState { get; set; }

    public int CashInMachine { get; set; }
    public bool CorrectPinEntered { get; set; }

    public event Action? OnStateChanged;

    public void RaiseStateChanged()
    {
        OnStateChanged?.Invoke();
    }

    public ATM(int initialCash)
    {
        HasCardState = new HasCardState();

        NoCardState = new NoCardState();

        HasCorrectPinState = new HasCorrectPinState();

        NoCashState = new NoCashState();

        CurrentState = initialCash > 0 ? NoCardState : NoCashState;
    }

    public void SetState(IATMState newState)
    {
        CurrentState = newState;

    }

    public void InsertCard() => CurrentState.InsertCard(this);
    public void EjectCard() => CurrentState.EjectCard(this);
    public void SelectTransaction() => CurrentState.SelectTransaction(this);
    public void ProcessTransaction() => CurrentState.ProcessTransaction(this);

    // PIN method is likely already present
    public void EnterPIN(int pin) {
        CurrentState.EnterPin(this, pin);
        OnStateChanged?.Invoke();
    }

    // Button state flags
    public bool CanInsertCard => CurrentState.CanInsertCard;
    public bool CanEjectCard => CurrentState.CanEjectCard;
    public bool CanEnterPin => CurrentState.CanEnterPin;
    public bool CanSelectTransaction => CurrentState.CanSelectTransaction;
    public bool CanProcessTransaction => CurrentState.CanProcessTransaction;
}
