namespace ATMState;

/// <summary>
/// Represents the state of the ATM when a card has been inserted and the user must enter their PIN.
/// </summary>
/// <param name="atmMachine">The ATM machine context used for state transitions.</param>
public class AuthenticationState(ATMMachine atmMachine) : IATMState
{
    /// <summary>
    /// Reference to the ATM machine context.
    /// </summary>
    private readonly ATMMachine _atmMachine = atmMachine;

    /// <summary>
    /// Indicates whether the user can insert a card in this state.
    /// Always false since a card is already inserted.
    /// </summary>
    public bool CanInsertCard => false;

    /// <summary>
    /// Indicates whether the user can enter their PIN in this state.
    /// </summary>
    public bool CanEnterPin => true;

    /// <summary>
    /// Indicates whether the user can select a transaction in this state.
    /// </summary>
    public bool CanSelectTransaction => false;

    /// <summary>
    /// Indicates whether the user can process a transaction in this state.
    /// </summary>
    public bool CanProcessTransaction => false;

    /// <summary>
    /// Indicates whether the user can eject their card in this state.
    /// </summary>
    public bool CanEjectCard => true;

    /// <summary>
    /// Handles the action of inserting a card while already in the authentication state.
    /// </summary>
    public void InsertCard()
    {
        Console.WriteLine("Card already inserted.");
    }

    /// <summary>
    /// Handles the PIN input by the user. If the PIN is correct, transitions to the transaction selection state.
    /// </summary>
    /// <param name="pin">The entered PIN.</param>
    public void EnterPIN(int pin)
    {
        if (pin == 1234) // Replace with secure check in production
        {
            Console.WriteLine("PIN correct.");
            _atmMachine.SetState(_atmMachine.GetTransactionSelectionState());
        }
        else
        {
            Console.WriteLine("PIN incorrect. Try again.");
        }
    }

    /// <summary>
    /// Prevents selecting a transaction before entering a valid PIN.
    /// </summary>
    public void SelectTransaction()
    {
        Console.WriteLine("Enter PIN first.");
    }

    /// <summary>
    /// Prevents processing a transaction before entering a valid PIN.
    /// </summary>
    public void ProcessTransaction()
    {
        Console.WriteLine("Enter PIN first.");
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
    /// (Not implemented) Use <see cref="EnterPIN(int)"/> instead.
    /// </summary>
    /// <param name="pin">The entered PIN.</param>
    /// <exception cref="NotImplementedException">Always thrown.</exception>
    public void EnterPin(int pin)
    {
       Console.WriteLine("Use EnterPIN method instead.");
    }
}
