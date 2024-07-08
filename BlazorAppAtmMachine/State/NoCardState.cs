namespace BlazorAppAtmMachine.State;

internal class NoCardState : IATMState
{
    public void EjectCard(ATM atm)
    {

    }

    public void InsertCard(ATM atm)
    {
        atm.SetState(atm.HasCardState);
    }

    public void InsertPin(ATM atm, int pin)
    {
       
    }

    public void RequestCash(ATM atm, int amount)
    {

    }
}