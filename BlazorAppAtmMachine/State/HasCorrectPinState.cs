namespace BlazorAppAtmMachine.State;

/// <summary>
/// Represents the state of the ATM when a card has been inserted
/// and the correct PIN has been entered.
/// </summary>
public class HasCorrectPinState : IATMState
{
    /// <inheritdoc/>
    public bool CanInsertCard => false;

    /// <inheritdoc/>
    public bool CanEjectCard => true;

    /// <inheritdoc/>
    public bool CanEnterPin => false;

    /// <inheritdoc/>
    public bool CanSelectTransaction => true;

    /// <inheritdoc/>
    public bool CanProcessTransaction => true;

    /// <summary>
    /// Card insertion is not allowed in this state.
    /// </summary>
    public void InsertCard(ATM atm) { }

    /// <summary>
    /// Ejects the card and transitions the ATM to the NoCardState.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    public void EjectCard(ATM atm)
    {
        atm.SetState(atm.NoCardState);
        atm.RaiseStateChanged();
    }

    /// <summary>
    /// PIN entry is not allowed in this state, as it has already been entered.
    /// </summary>
    public void EnterPin(ATM atm, int pin) { }

    /// <summary>
    /// Simulates transaction selection. Remains in the same state
    /// but triggers a UI update via state notification.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    public void SelectTransaction(ATM atm) => atm.RaiseStateChanged();
 
    /// <summary>
    /// Processes a transaction by dispensing $100 if sufficient funds exist.
    /// Transitions to NoCardState or NoCashState depending on balance.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    public void ProcessTransaction(ATM atm)
    {
        if (atm.CashInMachine >= 100)
        {
            atm.CashInMachine -= 100;
            Console.WriteLine("Processed transaction: Dispensed $100");
            atm.SetState(atm.NoCardState);
        }
        else
        {
            Console.WriteLine("ATM has no cash!");
            atm.SetState(atm.NoCashState);
        }

        atm.RaiseStateChanged(); // Notify UI or subscribers of state change
    }
}