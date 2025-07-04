
namespace BlazorAppAtmMachine.State;

public class HasCardState : IATMState
{
    public bool CanInsertCard => false;
    public bool CanEjectCard => true;
    public bool CanEnterPin => true;
    public bool CanSelectTransaction => false;
    public bool CanProcessTransaction => false;

    public void InsertCard(ATM atm)
    {
        // Already has a card inserted — maybe show error/log if needed
    }

    public void EjectCard(ATM atm)
    {
        atm.SetState(atm.NoCardState);
        atm.RaiseStateChanged();
    }

    public void EnterPin(ATM atm, int pin)
    {
        if (pin == 1234)
        {
            atm.CorrectPinEntered = true;
            atm.SetState(atm.HasCorrectPinState);
        }
        else
        {
            atm.CorrectPinEntered = false;
            // maybe eject card or keep same state
        }

        atm.RaiseStateChanged(); // ✅ this must be present!
    }


    public void SelectTransaction(ATM atm)
    {
        // Not allowed in this state — maybe show error
    }

    public void ProcessTransaction(ATM atm)
    {
        // Not allowed in this state — maybe show error
    }
}

//public class HasCardState : IATMState
//{
//    public bool CanInsertCard { get; }
//    public bool CanEjectCard { get; }
//    public bool CanEnterPin { get; }
//    public bool CanSelectTransaction { get; }
//    public bool CanProcessTransaction { get; }

//    public void InsertCard(ATM atm)
//    {

//    }

//    public void EjectCard(ATM atm)
//    {
//        atm.SetState(atm.NoCardState);
//    }

//    public void InsertPin(ATM atm, int pin)
//    {
//        ArgumentNullException.ThrowIfNull(atm);

//        switch (pin)
//        {
//            case 1234:
//                atm.CorrectPinEntered = true;

//                atm.SetState(atm.HasCorrectPinState);
//                break;
//            default:
//                atm.CorrectPinEntered = false;
//                break;
//        }
//    }

//    public void RequestCash(ATM atm, int amount)
//    {

//    }

//    public void EnterPin(ATM atm, int pin)
//    {
//        InsertPin(atm, pin);
//    }

//    public void SelectTransaction(ATM atm)
//    {
//        throw new NotImplementedException();
//    }

//    public void ProcessTransaction(ATM atm)
//    {
//        throw new NotImplementedException();
//    }
//}
