namespace BlazorAppAtmMachine.State;

/// <summary>
/// Defines the interface for ATM states in a state pattern architecture.
/// Each method corresponds to an action that can be performed on the ATM.
/// Boolean properties expose UI capabilities for the current state.
/// </summary>
public interface IATMState
{
    /// <summary>
    /// Attempts to insert a card into the ATM.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    void InsertCard(ATM atm);

    /// <summary>
    /// Attempts to eject the card from the ATM.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    void EjectCard(ATM atm);

    /// <summary>
    /// Attempts to enter a PIN into the ATM.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    /// <param name="pin">The PIN entered by the user.</param>
    void EnterPin(ATM atm, int pin);

    /// <summary>
    /// Attempts to select a transaction after successful authentication.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    void SelectTransaction(ATM atm);

    /// <summary>
    /// Attempts to process the currently selected transaction.
    /// </summary>
    /// <param name="atm">The ATM context instance.</param>
    void ProcessTransaction(ATM atm);

    /// <summary>
    /// Indicates whether the user can insert a card in the current state.
    /// </summary>
    bool CanInsertCard { get; }

    /// <summary>
    /// Indicates whether the user can eject the card in the current state.
    /// </summary>
    bool CanEjectCard { get; }

    /// <summary>
    /// Indicates whether the user can enter a PIN in the current state.
    /// </summary>
    bool CanEnterPin { get; }

    /// <summary>
    /// Indicates whether the user can select a transaction in the current state.
    /// </summary>
    bool CanSelectTransaction { get; }

    /// <summary>
    /// Indicates whether the user can process a transaction in the current state.
    /// </summary>
    bool CanProcessTransaction { get; }
}
