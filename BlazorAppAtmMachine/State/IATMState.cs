namespace BlazorAppAtmMachine.State;

public interface IATMState
{
    void InsertCard(ATM atm);
    void EjectCard(ATM atm);
    void InsertPin(ATM atm, int pin);
    void RequestCash(ATM atm, int amount);
}
