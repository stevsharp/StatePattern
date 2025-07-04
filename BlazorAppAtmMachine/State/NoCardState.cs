namespace BlazorAppAtmMachine.State;

internal class NoCardState : IATMState
{
    public bool CanInsertCard => true;
    public bool CanEjectCard => false;
    public bool CanEnterPin => false;
    public bool CanSelectTransaction => false;
    public bool CanProcessTransaction => false;

    public void EjectCard(ATM atm)
    {

    }

    public void EnterPin(ATM atm, int pin)
    {

    }

    public void InsertCard(ATM atm)
    {
        atm.SetState(atm.HasCardState);
    }

    public void InsertPin(ATM atm, int pin)
    {
       
    }

    public void ProcessTransaction(ATM atm)
    {
        throw new NotImplementedException();
    }

    public void RequestCash(ATM atm, int amount)
    {

    }

    public void SelectTransaction(ATM atm)
    {

    }
}