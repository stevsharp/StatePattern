namespace ATMState;

public class IdleState(ATMMachine atmMachine) : IATMState
{
    private ATMMachine _atmMachine = atmMachine;

    public bool CanInsertCard { get; }
    public bool CanEnterPin { get; }
    public bool CanSelectTransaction { get; }
    public bool CanProcessTransaction { get; }
    public bool CanEjectCard { get; }

    public void InsertCard()
    {
        Console.WriteLine("Card inserted.");
        _atmMachine.SetState(_atmMachine.GetAuthenticationState());
    }

    public void EnterPIN(int pin)
    {
        Console.WriteLine("Insert card first.");
    }

    public void SelectTransaction()
    {
        Console.WriteLine("Insert card first.");
    }

    public void ProcessTransaction()
    {
        Console.WriteLine("Insert card first.");
    }

    public void EjectCard()
    {
        Console.WriteLine("No card to eject.");
    }

    public void EnterPin(int pin)
    {
        throw new NotImplementedException();
    }
}
