namespace BlazorAppAtmMachine.State
{
    internal class HasCorrectPinState : IATMState
    {
        public void EjectCard(ATM atm)
        {
            atm.SetState(atm.NoCardState);
        }

        public void InsertCard(ATM atm)
        {

        }

        public void InsertPin(ATM atm, int pin)
        {
            
        }

        public void RequestCash(ATM atm, int amount)
        {
            ArgumentNullException.ThrowIfNull(atm);

            if (amount <= atm.CashInMachine)
            {
                atm.CashInMachine -= amount;

                if (atm.CashInMachine > 0)
                {
                    return;
                }

                atm.SetState(atm.NoCashState);

                return;
            }

            atm.SetState(atm.NoCashState);
            
        }
    }
}