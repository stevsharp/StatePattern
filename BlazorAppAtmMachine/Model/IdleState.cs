namespace ATMState;

/// <summary>
/// Represents the ATM's Idle state where no card has been inserted.
/// </summary>
public class IdleState(ATMMachine atmMachine) : IATMState
{
    // Reference to the context (ATMMachine)
    private ATMMachine _atmMachine = atmMachine;

    /// <inheritdoc/>
    public bool CanInsertCard { get; } = true;

    /// <inheritdoc/>
    public bool CanEnterPin { get; } = false;

    /// <inheritdoc/>
    public bool CanSelectTransaction { get; } = false;

    /// <inheritdoc/>
    public bool CanProcessTransaction { get; } = false;

    /// <inheritdoc/>
    public bool CanEjectCard { get; } = false;

    /// <summary>
    /// Handles inserting a card. Transitions the ATM to the Authentication state.
    /// </summary>
    public void InsertCard()
    {
        Console.WriteLine("Card inserted.");
        _atmMachine.SetState(_atmMachine.GetAuthenticationState());
    }

    /// <summary>
    /// Warns the user that a card must be inserted before entering a PIN.
    /// </summary>
    public void EnterPIN(int pin)
    {
        Console.WriteLine("Insert card first.");
    }

    /// <summary>
    /// Warns the user that a card must be inserted before selecting a transaction.
    /// </summary>
    public void SelectTransaction()
    {
        Console.WriteLine("Insert card first.");
    }

    /// <summary>
    /// Warns the user that a card must be inserted before processing a transaction.
    /// </summary>
    public void ProcessTransaction()
    {
        Console.WriteLine("Insert card first.");
    }

    /// <summary>
    /// Informs the user that there is no card to eject.
    /// </summary>
    public void EjectCard()
    {
        Console.WriteLine("No card to eject.");
    }

    /// <summary>
    /// Fallback method if EnterPin is called. Redirects to EnterPIN with a warning.
    /// </summary>
    public void EnterPin(int pin)
    {
        Console.WriteLine("Insert card first.");
    }
}
