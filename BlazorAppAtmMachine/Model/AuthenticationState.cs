namespace ATMState
{
    public class AuthenticationState : IATMState
    {
        private ATMMachine _atmMachine;

        public AuthenticationState(ATMMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            Console.WriteLine("Card already inserted.");
        }

        public void EnterPIN(int pin)
        {
            if (pin == 1234) // Example PIN check
            {
                Console.WriteLine("PIN correct.");
                _atmMachine.SetState(_atmMachine.GetTransactionSelectionState());
            }
            else
            {
                Console.WriteLine("PIN incorrect. Try again.");
            }
        }

        public void SelectTransaction()
        {
            Console.WriteLine("Enter PIN first.");
        }

        public void ProcessTransaction()
        {
            Console.WriteLine("Enter PIN first.");
        }

        public void EjectCard()
        {
            Console.WriteLine("Card ejected.");
            _atmMachine.SetState(_atmMachine.GetIdleState());
        }
    }
}
