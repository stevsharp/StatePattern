namespace BlazorAppAtmMachine.State;

/// <summary>
/// Represents the state of the ATM when it has no cash available to dispense.
/// In this state, most operations are disabled.
/// </summary>
internal class NoCashState : IATMState
{
    /// <inheritdoc/>
    public bool CanInsertCard => false;

    /// <inheritdoc/>
    public bool CanEjectCard => true;

    /// <inheritdoc/>
    public bool CanEnterPin => false;

    /// <inheritdoc/>
    public bool CanSelectTransaction => false;

    /// <inheritdoc/>
    public bool CanProcessTransaction => false;

    /// <summary>
    /// Handles the card ejection request when ATM is out of cash.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void EjectCard(ATM atm)
    {
        // Typically used to allow card removal
    }

    /// <summary>
    /// Handles the PIN entry attempt when ATM is out of cash.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    /// <param name="pin">The entered PIN.</param>
    public void EnterPin(ATM atm, int pin)
    {
        // No PIN entry allowed
    }

    /// <summary>
    /// Handles the card insertion attempt when ATM is out of cash.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void InsertCard(ATM atm)
    {
        // Reject insertion since there's no cash
    }

    /// <summary>
    /// Handles PIN insertion attempt (duplicate method – may be deprecated or erroneous).
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    /// <param name="pin">The entered PIN.</param>
    public void InsertPin(ATM atm, int pin)
    {
        // Likely duplicate of EnterPin
    }

    /// <summary>
    /// Handles transaction processing attempt when ATM is out of cash.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void ProcessTransaction(ATM atm)
    {
        // No transactions can be processed
    }

    /// <summary>
    /// Handles request for cash when ATM is empty.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    /// <param name="amount">Requested cash amount.</param>
    public void RequestCash(ATM atm, int amount)
    {
        // Reject all cash requests
    }

    /// <summary>
    /// Handles transaction selection attempt when ATM is out of cash.
    /// </summary>
    /// <param name="atm">The ATM instance.</param>
    public void SelectTransaction(ATM atm)
    {
        // Prevent transaction selection
    }
}