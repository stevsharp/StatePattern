namespace ATMState
{
    public class TransactionProcessingState : IATMState
    {
        private ATMMachine _atmMachine;

        public bool CanInsertCard { get; }
        public bool CanEnterPin { get; }
        public bool CanSelectTransaction { get; }
        public bool CanProcessTransaction { get; }
        public bool CanEjectCard { get; }

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

        public void EnterPin(int pin)
        {
            throw new NotImplementedException();
        }
    }
}
