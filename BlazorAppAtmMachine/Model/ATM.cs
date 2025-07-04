namespace ATMState;

public class ATMMachine
{
    private IATMState _idleState;
    private IATMState _authenticationState;
    private IATMState _transactionSelectionState;
    private IATMState _transactionProcessingState;

    private IATMState _currentState;
    public event Action? OnStateChanged;

    public string CurrentStateName => _currentState.GetType().Name;
    public string LastMessage { get; private set; } = string.Empty;

    public ATMMachine()
    {
        _idleState = new IdleState(this);
        _authenticationState = new AuthenticationState(this);
        _transactionSelectionState = new TransactionSelectionState(this);
        _transactionProcessingState = new TransactionProcessingState(this);

        _currentState = _idleState;

    }
    public void SetState(IATMState state)
    {
        _currentState = state;
        NotifyStateChanged();
    }

    public void InsertCard()
    {
        CaptureOutput(() => _currentState.InsertCard());
    }

    public void EnterPIN(int pin)
    {
        CaptureOutput(() => _currentState.EnterPin(pin));
    }

    public void SelectTransaction()
    {
        CaptureOutput(() => _currentState.SelectTransaction());
    }

    public void ProcessTransaction()
    {
        CaptureOutput(() => _currentState.ProcessTransaction());
    }

    public void EjectCard()
    {
        CaptureOutput(() => _currentState.EjectCard());
    }

    public IATMState GetIdleState() => _idleState;
    public IATMState GetAuthenticationState() => _authenticationState;
    public IATMState GetTransactionSelectionState() => _transactionSelectionState;
    public IATMState GetTransactionProcessingState() => _transactionProcessingState;

    private void NotifyStateChanged() => OnStateChanged?.Invoke();

    private void CaptureOutput(Action action)
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);
        action();
        LastMessage = sw.ToString();
        NotifyStateChanged();
    }

    public bool IsInsertCardDisabled => _currentState is AuthenticationState || _currentState is TransactionSelectionState || _currentState is TransactionProcessingState;
    public bool IsEjectCardDisabled => _currentState is IdleState;
    public bool IsEnterPinDisabled => _currentState is IdleState || _currentState is TransactionSelectionState || _currentState is TransactionProcessingState;
    public bool IsSelectTransactionDisabled => _currentState is IdleState || _currentState is AuthenticationState || _currentState is TransactionProcessingState;
    public bool IsProcessTransactionDisabled => _currentState is not TransactionProcessingState;
}

