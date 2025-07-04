namespace BlazorAppAtmMachine.State;

public class HasCorrectPinState : IATMState
{
    public bool CanInsertCard => false;
    public bool CanEjectCard => true;
    public bool CanEnterPin => false;
    public bool CanSelectTransaction => true;
    public bool CanProcessTransaction => true;

    public void InsertCard(ATM atm) { }

    public void EjectCard(ATM atm)
    {
        atm.SetState(atm.NoCardState);
        atm.RaiseStateChanged();
    }

    public void EnterPin(ATM atm, int pin) { }

    public void SelectTransaction(ATM atm)
    {
        // Here you could simulate selecting options
        atm.RaiseStateChanged();
    }

    public void ProcessTransaction(ATM atm)
    {
        if (atm.CashInMachine >= 100)
        {
            atm.CashInMachine -= 100;
            Console.WriteLine("Processed transaction: Dispensed $100");

            // Optional: set state to another "AfterTransactionState"
            atm.SetState(atm.NoCardState); // Reset ATM to initial
        }
        else
        {
            Console.WriteLine("ATM has no cash!");
            atm.SetState(atm.NoCashState); // Trigger out-of-service state
        }

        atm.RaiseStateChanged(); // 🔁 Critical for UI update
    }
}