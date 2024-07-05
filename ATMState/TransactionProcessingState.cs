namespace ATMState
{
    public class TransactionProcessingState : IATMState
    {
        private ATMMachine _atmMachine;

        public TransactionProcessingState(ATMMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            Console.WriteLine("Transaction in progress. Please wait.");
        }

        public void EnterPIN(int pin)
        {
            Console.WriteLine("Transaction in progress. Please wait.");
        }

        public void SelectTransaction()
        {
            Console.WriteLine("Transaction in progress. Please wait.");
        }

        public void ProcessTransaction()
        {
            Console.WriteLine("Transaction completed.");
            _atmMachine.SetState(_atmMachine.GetIdleState());
        }

        public void EjectCard()
        {
            Console.WriteLine("Transaction in progress. Please wait.");
        }
    }
}
