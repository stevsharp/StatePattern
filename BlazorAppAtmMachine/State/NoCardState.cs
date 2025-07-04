using BlazorAppAtmMachine.State;

/// <summary>
/// Represents the ATM state when no card has been inserted.
/// In this state, only card insertion is allowed.
/// </summary>
internal class NoCardState : IATMState
{
    /// <inheritdoc/>
    public bool CanInsertCard => true;

    /// <inheritdoc/>
    public bool CanEjectCard => false;

    /// <inheritdoc/>
    public bool CanEnterPin => false;

    /// <inheritdoc/>
    public bool CanSelectTransaction => false;

    /// <inheritdoc/>
    public bool CanProcessTransaction => false;

    /// <summary>
    /// Called when an attempt is made to eject a card while none is inserted.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void EjectCard(ATM atm)
    {
        // No card to eject
    }

    /// <summary>
    /// Called when an attempt is made to enter a PIN without a card.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    /// <param name="pin">The PIN input.</param>
    public void EnterPin(ATM atm, int pin)
    {
        // Cannot enter PIN without a card
    }

    /// <summary>
    /// Handles card insertion, transitioning ATM to HasCardState.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void InsertCard(ATM atm)
    {
        Console.WriteLine("Card inserted.");
        atm.SetState(atm.HasCardState);
    }

    /// <summary>
    /// Possibly redundant method for PIN entry (if EnterPin already exists).
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    /// <param name="pin">The PIN input.</param>
    public void InsertPin(ATM atm, int pin)
    {
        // Not allowed without card
    }

    /// <summary>
    /// Throws an exception if transaction processing is attempted in this state.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void ProcessTransaction(ATM atm)
    {
        throw new NotImplementedException("Cannot process transaction without a card.");
    }

    /// <summary>
    /// Called when an attempt is made to request cash while no card is present.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    /// <param name="amount">The requested cash amount.</param>
    public void RequestCash(ATM atm, int amount)
    {
        // Cash request not allowed
    }

    /// <summary>
    /// Called when an attempt is made to select a transaction without a card.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void SelectTransaction(ATM atm)
    {
        // Transaction selection not allowed
    }
}