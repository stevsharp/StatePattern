
namespace BlazorAppAtmMachine.State
{
    public class HasCardState : IATMState
    {
        public void InsertCard(ATM atm)
        {

        }

        public void EjectCard(ATM atm)
        {
            atm.SetState(atm.NoCardState);
        }

        public void InsertPin(ATM atm, int pin)
        {
            ArgumentNullException.ThrowIfNull(atm);

            switch (pin)
            {
                case 1234:
                    atm.CorrectPinEntered = true;

                    atm.SetState(atm.HasCorrectPinState);
                    break;
                default:
                    atm.CorrectPinEntered = false;
                    break;
            }
        }

        public void RequestCash(ATM atm, int amount)
        {

        }
    }
}