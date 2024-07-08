namespace BlazorAppAtmMachine.State
{
    public class ATM
    {
        public IATMState HasCardState { get; set; }
        public IATMState NoCardState { get; set; }
        public IATMState HasCorrectPinState { get; set; }
        public IATMState NoCashState { get; set; }
        public IATMState CurrentState { get; set; }

        public int CashInMachine { get; set; }
        public bool CorrectPinEntered { get; set; }

        public ATM(int initialCash)
        {
            HasCardState = new HasCardState();

            NoCardState = new NoCardState();

            HasCorrectPinState = new HasCorrectPinState();

            NoCashState = new NoCashState();

            CashInMachine = initialCash;

            CurrentState = initialCash > 0 ? NoCardState : NoCashState;
        }

        public void SetState(IATMState newState)
        {
            CurrentState = newState;
        }
    }
}
