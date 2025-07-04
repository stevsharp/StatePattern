
namespace BlazorAppAtmMachine.State;

public class HasCardState : IATMState
{
    public bool CanInsertCard => false;
    public bool CanEjectCard => true;
    public bool CanEnterPin => true;
    public bool CanSelectTransaction => false;
    public bool CanProcessTransaction => false;

    public void InsertCard(ATM atm)
    {
        // Already has a card inserted — maybe show error/log if needed
    }

    public void EjectCard(ATM atm)
    {
        atm.SetState(atm.NoCardState);
        atm.RaiseStateChanged();
    }

    public void EnterPin(ATM atm, int pin)
    {
        if (pin == 1234)
        {
            atm.CorrectPinEntered = true;
            atm.SetState(atm.HasCorrectPinState);
        }
        else
        {
            atm.CorrectPinEntered = false;
            // maybe eject card or keep same state
        }

        atm.RaiseStateChanged(); // ✅ this must be present!
    }


    public void SelectTransaction(ATM atm)
    {
        // Not allowed in this state — maybe show error
    }

    public void ProcessTransaction(ATM atm)
    {
        // Not allowed in this state — maybe show error
    }
}

