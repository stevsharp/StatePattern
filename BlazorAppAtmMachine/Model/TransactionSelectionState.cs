namespace ATMState;

/// <summary>
/// Represents the state of the ATM where the user has successfully entered the correct PIN
/// and can now select a transaction (e.g., withdraw or deposit).
/// </summary>
public class TransactionSelectionState : IATMState
{
    /// <summary>
    /// Reference to the context ATM machine instance.
    /// </summary>
    private readonly ATMMachine _atmMachine;

    /// <inheritdoc/>
    public bool CanInsertCard => false;

    /// <inheritdoc/>
    public bool CanEnterPin => false;

    /// <inheritdoc/>
    public bool CanSelectTransaction => true;

    /// <inheritdoc/>
    public bool CanProcessTransaction => false;

    /// <inheritdoc/>
    public bool CanEjectCard => true;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionSelectionState"/> class.
    /// </summary>
    /// <param name="atmMachine">The ATM machine instance.</param>
    public TransactionSelectionState(ATMMachine atmMachine)
    {
        _atmMachine = atmMachine;
    }

    /// <summary>
    /// Notifies that the card is already inserted and no action is taken.
    /// </summary>
    public void InsertCard()
    {
        Console.WriteLine("Card already inserted.");
    }

    /// <summary>
    /// Notifies that the PIN has already been entered.
    /// </summary>
    public void EnterPIN(int pin)
    {
        Console.WriteLine("PIN already entered.");
    }

    /// <summary>
    /// Simulates selecting a transaction and transitions to the transaction processing state.
    /// </summary>
    public void SelectTransaction()
    {
        Console.WriteLine("Transaction selected.");
        _atmMachine.SetState(_atmMachine.GetTransactionProcessingState());
    }

    /// <summary>
    /// Notifies the user that they must select a transaction before processing.
    /// </summary>
    public void ProcessTransaction()
    {
        Console.WriteLine("Select a transaction first.");
    }

    /// <summary>
    /// Ejects the card and transitions the ATM back to the idle state.
    /// </summary>
    public void EjectCard()
    {
        Console.WriteLine("Card ejected.");
        _atmMachine.SetState(_atmMachine.GetIdleState());
    }

    /// <summary>
    /// Redundant method included for interface compliance; duplicates EnterPIN.
    /// </summary>
    public void EnterPin(int pin)
    {
        Console.WriteLine("PIN already entered.");
    }
}

