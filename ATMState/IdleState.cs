namespace ATMState
{
    public class IdleState : IATMState
    {
        private ATMMachine _atmMachine;

        public IdleState(ATMMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

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
    }
}
