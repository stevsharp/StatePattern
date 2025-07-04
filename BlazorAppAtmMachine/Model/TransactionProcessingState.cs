namespace ATMState;

/// <summary>
/// Represents the ATM state during a transaction process.
/// All user actions are blocked until the transaction completes.
/// </summary>
public class TransactionProcessingState(ATMMachine atmMachine) : IATMState
{
    /// <summary>
    /// Reference to the context ATM machine.
    /// </summary>
    private readonly ATMMachine _atmMachine = atmMachine;

    /// <inheritdoc/>
    public bool CanInsertCard => false;

    /// <inheritdoc/>
    public bool CanEnterPin => false;

    /// <inheritdoc/>
    public bool CanSelectTransaction => false;

    /// <inheritdoc/>
    public bool CanProcessTransaction => false;

    /// <inheritdoc/>
    public bool CanEjectCard => false;

    /// <summary>
    /// Notifies the user that a card cannot be inserted during a transaction.
    /// </summary>
    public void InsertCard()
    {
        Console.WriteLine("Transaction in progress. Please wait.");
    }

    /// <summary>
    /// Notifies the user that entering a PIN is not allowed during a transaction.
    /// </summary>
    public void EnterPIN(int pin)
    {
        Console.WriteLine("Transaction in progress. Please wait.");
    }

    /// <summary>
    /// Notifies the user that transaction selection is blocked during processing.
    /// </summary>
    public void SelectTransaction()
    {
        Console.WriteLine("Transaction in progress. Please wait.");
    }

    /// <summary>
    /// Processes the transaction, notifies the user, and transitions to the Idle state.
    /// </summary>
    public void ProcessTransaction()
    {
        Console.WriteLine("Transaction completed.");
        _atmMachine.SetState(_atmMachine.GetIdleState());
    }

    /// <summary>
    /// Notifies the user that card ejection is not possible during a transaction.
    /// </summary>
    public void EjectCard()
    {
        Console.WriteLine("Transaction in progress. Please wait.");
    }

    /// <summary>
    /// Extra method implementation to conform to IATMState.
    /// This is redundant with EnterPIN and could be cleaned up if not used elsewhere.
    /// </summary>
    public void EnterPin(int pin)
    {
        Console.WriteLine("Entering PIN is not allowed during transaction processing.");
    }
}