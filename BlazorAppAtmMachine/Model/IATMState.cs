namespace ATMState;


public interface IATMState
{
    bool CanInsertCard { get; }
    bool CanEnterPin { get; }
    bool CanSelectTransaction { get; }
    bool CanProcessTransaction { get; }
    bool CanEjectCard { get; }

    void InsertCard();
    void EjectCard();
    void EnterPin(int pin);
    void SelectTransaction();
    void ProcessTransaction();
}

