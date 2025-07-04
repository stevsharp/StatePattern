using BlazorAppAtmMachine.State;

namespace BlazorAppAtmMachine.Vm;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

/// <summary>
/// ViewModel for the Blazor ATM UI. Implements MVVM pattern using CommunityToolkit.Mvvm.
/// Delegates all logic to the ATM state machine and exposes observable properties and commands for the UI.
/// </summary>
public partial class HomeViewModel : ObservableObject, IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    private readonly ATM _atm;

    /// <summary>
    /// Gets the name of the current ATM state for debugging or display.
    /// </summary>
    public string CurrentStateName => _atm.CurrentState.GetType().Name;

    /// <summary>
    /// Gets the amount of cash remaining in the ATM.
    /// </summary>
    public int CashInMachine => _atm.CashInMachine;

    /// <summary>
    /// Initializes the ViewModel and subscribes to ATM state change notifications.
    /// </summary>
    public HomeViewModel(ATM atm)
    {
        _atm = atm;
        _atm.OnStateChanged += OnStateChanged;
    }

    /// <summary>
    /// PIN entered by the user.
    /// </summary>
    [ObservableProperty]
    private int enteredPin = 0;

    /// <summary>
    /// Transaction amount input by the user.
    /// </summary>
    [ObservableProperty]
    private decimal transactionAmount = 0m;

    // ----------------- Command Bindings -----------------

    /// <summary>
    /// Submits the entered PIN to the ATM.
    /// </summary>
    [RelayCommand]
    private void SubmitPin() => _atm.EnterPIN(this.EnteredPin);

    /// <summary>
    /// Inserts a card into the ATM.
    /// </summary>
    [RelayCommand]
    private void InsertCard() => _atm.InsertCard();

    /// <summary>
    /// Simulates selecting a transaction.
    /// </summary>
    [RelayCommand]
    private void SelectTransaction() => _atm.SelectTransaction();

    /// <summary>
    /// Processes a transaction with the specified amount.
    /// Only enabled when the amount is greater than zero.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanProcessTransaction))]
    public void ProcessTransaction()
    {
        _atm.TransactionAmount = this.TransactionAmount;
        _atm.ProcessTransaction();
    }

    /// <summary>
    /// Validates whether the transaction can be processed.
    /// </summary>
    private bool CanProcessTransaction => this.TransactionAmount > 0;

    /// <summary>
    /// Ejects the card from the ATM.
    /// </summary>
    [RelayCommand]
    private void EjectCard() => _atm.EjectCard();

    // ----------------- State-based UI Flags -----------------

    /// <summary>
    /// Whether the PIN input and submit button should be disabled.
    /// </summary>
    public bool IsEnterPinDisabled => !_atm.CurrentState.CanEnterPin;

    /// <summary>
    /// Whether the Insert Card button should be disabled.
    /// </summary>
    public bool IsInsertCardDisabled => !_atm.CurrentState.CanInsertCard;

    /// <summary>
    /// Whether the Select Transaction button should be disabled.
    /// </summary>
    public bool IsSelectTransactionDisabled => !_atm.CurrentState.CanSelectTransaction;

    /// <summary>
    /// Whether the Process Transaction button should be disabled.
    /// </summary>
    public bool IsProcessTransactionDisabled => !_atm.CurrentState.CanProcessTransaction;

    /// <summary>
    /// Whether the Eject Card button should be disabled.
    /// </summary>
    public bool IsEjectCardDisabled => !_atm.CurrentState.CanEjectCard;

    // ----------------- State Change Subscription -----------------

    /// <summary>
    /// Event used to notify the UI when the ATM state changes.
    /// </summary>
    public event Action? StateChanged;

    /// <summary>
    /// Called when the ATM state changes. Raises UI update events for all state-dependent properties.
    /// </summary>
    private void OnStateChanged()
    {
        OnPropertyChanged(nameof(IsEnterPinDisabled));
        OnPropertyChanged(nameof(IsInsertCardDisabled));
        OnPropertyChanged(nameof(IsSelectTransactionDisabled));
        OnPropertyChanged(nameof(IsProcessTransactionDisabled));
        OnPropertyChanged(nameof(IsEjectCardDisabled));

        StateChanged?.Invoke();
    }

    /// <summary>
    /// Disposes of the ViewModel and unsubscribes from ATM events.
    /// </summary>
    public void Dispose() => _atm.OnStateChanged -= OnStateChanged;
}


