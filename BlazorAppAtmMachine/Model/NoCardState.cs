namespace ATMState;

/// <summary>
/// Represents the state of the ATM when no card has been inserted.
/// </summary>
public class NoCardState : IATMState
{
    /// <summary>
    /// Indicates whether a card can be inserted in this state.
    /// </summary>
    public bool CanInsertCard => true;

    /// <summary>
    /// Indicates whether a card can be ejected in this state.
    /// </summary>
    public bool CanEjectCard => false;

    /// <summary>
    /// Indicates whether a PIN can be entered in this state.
    /// </summary>
    public bool CanEnterPin => false;

    /// <summary>
    /// Indicates whether a transaction can be selected in this state.
    /// </summary>
    public bool CanSelectTransaction => false;

    /// <summary>
    /// Indicates whether a transaction can be processed in this state.
    /// </summary>
    public bool CanProcessTransaction => false;

    /// <summary>
    /// Handles the logic for inserting a card. Transitions the ATM to the appropriate next state.
    /// </summary>
    public void InsertCard()
    {
        // Logic for handling card insertion (e.g., set ATM state to AuthenticationState)
    }

    /// <summary>
    /// Handles the logic for attempting to eject a card when none is inserted.
    /// Typically does nothing or shows a warning.
    /// </summary>
    public void EjectCard()
    {
        // Logic for when user tries to eject a non-existent card
    }

    /// <summary>
    /// Handles an invalid attempt to enter a PIN without a card.
    /// </summary>
    public void EnterPin(int pin)
    {
        // Logic for invalid PIN entry attempt
    }

    /// <summary>
    /// Handles an invalid attempt to select a transaction without a card.
    /// </summary>
    public void SelectTransaction()
    {
        // Logic for invalid transaction selection attempt
    }

    /// <summary>
    /// Handles an invalid attempt to process a transaction without a card.
    /// </summary>
    public void ProcessTransaction()
    {
        // Logic for invalid transaction processing attempt
    }
}