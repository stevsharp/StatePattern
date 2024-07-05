namespace ATMState
{
    public class TransactionSelectionState : IATMState
    {
        private ATMMachine _atmMachine;

        public TransactionSelectionState(ATMMachine atmMachine)
        {
            _atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            Console.WriteLine("Card already inserted.");
        }

        public void EnterPIN(int pin)
        {
            Console.WriteLine("PIN already entered.");
        }

        public void SelectTransaction()
        {
            Console.WriteLine("Transaction selected.");
            _atmMachine.SetState(_atmMachine.GetTransactionProcessingState());
        }

        public void ProcessTransaction()
        {
            Console.WriteLine("Select a transaction first.");
        }

        public void EjectCard()
        {
            Console.WriteLine("Card ejected.");
            _atmMachine.SetState(_atmMachine.GetIdleState());
        }
    }
}
