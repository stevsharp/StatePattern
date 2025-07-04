namespace BlazorAppAtmMachine.State;

public interface IATMState
{
    void InsertCard(ATM atm);
    void EjectCard(ATM atm);
    void EnterPin(ATM atm, int pin);
    void SelectTransaction(ATM atm);
    void ProcessTransaction(ATM atm);

    bool CanInsertCard { get; }
    bool CanEjectCard { get; }
    bool CanEnterPin { get; }
    bool CanSelectTransaction { get; }
    bool CanProcessTransaction { get; }
}