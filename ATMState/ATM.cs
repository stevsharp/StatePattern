namespace ATMState;

public class ATMMachine
{
    private IATMState _idleState;
    private IATMState _authenticationState;
    private IATMState _transactionSelectionState;
    private IATMState _transactionProcessingState;

    private IATMState _currentState;

    public ATMMachine()
    {
        _idleState = new IdleState(this);
        _authenticationState = new AuthenticationState(this);
        _transactionSelectionState = new TransactionSelectionState(this);
        _transactionProcessingState = new TransactionProcessingState(this);

        _currentState = _idleState;
    }

    public void SetState(IATMState newState)
    {
        _currentState = newState;
    }

    public IATMState GetIdleState() => _idleState;
    public IATMState GetAuthenticationState() => _authenticationState;
    public IATMState GetTransactionSelectionState() => _transactionSelectionState;
    public IATMState GetTransactionProcessingState() => _transactionProcessingState;

    public void InsertCard() => _currentState.InsertCard();
    public void EnterPIN(int pin) => _currentState.EnterPIN(pin);
    public void SelectTransaction() => _currentState.SelectTransaction();
    public void ProcessTransaction() => _currentState.ProcessTransaction();
    public void EjectCard() => _currentState.EjectCard();
}

