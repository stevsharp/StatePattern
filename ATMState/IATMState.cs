namespace ATMState;


public interface IATMState
{
    void InsertCard();
    void EnterPIN(int pin);
    void SelectTransaction();
    void ProcessTransaction();
    void EjectCard();
}
