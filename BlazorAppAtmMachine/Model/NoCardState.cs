namespace ATMState;

public class NoCardState : IATMState
{
    public bool CanInsertCard => true;
    public bool CanEjectCard => false;
    public bool CanEnterPin => false;
    public bool CanSelectTransaction => false;
    public bool CanProcessTransaction => false;

    public void InsertCard() { /* logic */ }
    public void EjectCard() { /* logic */ }
    public void EnterPin(int pin) { /* logic */ }
    public void SelectTransaction() { /* logic */ }
    public void ProcessTransaction() { /* logic */ }
}