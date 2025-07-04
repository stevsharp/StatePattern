namespace ATMState;

/// <summary>
/// Defines the interface for ATM machine states.
/// Each state represents a specific stage in the ATM's operation and controls
/// which actions are allowed and how they behave.
/// </summary>
public interface IATMState
{
    /// <summary>
    /// Indicates whether the current state allows the user to insert a card.
    /// </summary>
    bool CanInsertCard { get; }

    /// <summary>
    /// Indicates whether the current state allows the user to enter a PIN.
    /// </summary>
    bool CanEnterPin { get; }

    /// <summary>
    /// Indicates whether the current state allows the user to select a transaction type.
    /// </summary>
    bool CanSelectTransaction { get; }

    /// <summary>
    /// Indicates whether the current state allows the user to process a transaction.
    /// </summary>
    bool CanProcessTransaction { get; }

    /// <summary>
    /// Indicates whether the current state allows the user to eject the card.
    /// </summary>
    bool CanEjectCard { get; }

    /// <summary>
    /// Performs the action of inserting a card.
    /// </summary>
    void InsertCard();

    /// <summary>
    /// Performs the action of ejecting the card from the ATM.
    /// </summary>
    void EjectCard();

    /// <summary>
    /// Allows the user to enter their PIN for authentication.
    /// </summary>
    /// <param name="pin">The PIN entered by the user.</param>
    void EnterPin(int pin);

    /// <summary>
    /// Allows the user to select a transaction type (e.g., withdraw, deposit).
    /// </summary>
    void SelectTransaction();

    /// <summary>
    /// Performs the actual processing of the selected transaction.
    /// </summary>
    void ProcessTransaction();
}

