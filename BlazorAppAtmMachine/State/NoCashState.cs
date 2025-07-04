namespace BlazorAppAtmMachine.State;

internal class NoCashState : IATMState
{
    public bool CanInsertCard { get; }
    public bool CanEjectCard { get; }
    public bool CanEnterPin { get; }
    public bool CanSelectTransaction { get; }
    public bool CanProcessTransaction { get; }

    public void EjectCard(ATM atm)
    {
        
    }

    public void EnterPin(ATM atm, int pin)
    {

    }

    public void InsertCard(ATM atm)
    {

    }

    public void InsertPin(ATM atm, int pin)
    {

    }

    public void ProcessTransaction(ATM atm)
    {

    }

    public void RequestCash(ATM atm, int amount)
    {

    }

    public void SelectTransaction(ATM atm)
    {

    }
}