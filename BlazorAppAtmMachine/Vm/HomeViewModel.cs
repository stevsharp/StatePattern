using BlazorAppAtmMachine.State;

namespace BlazorAppAtmMachine.Vm;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


public partial class HomeViewModel : ObservableObject, IDisposable
{
    private readonly ATM _atm;
    public string CurrentStateName => _atm.CurrentState.GetType().Name;
    public int CashInMachine => _atm.CashInMachine;

    public HomeViewModel(ATM atm)
    {
        _atm = atm;
        _atm.OnStateChanged += OnStateChanged;
    }

    [ObservableProperty]
    private int enteredPin = 0;

    // Command bindings
    [RelayCommand] private void SubmitPin() => _atm.EnterPIN(this.enteredPin);
    [RelayCommand] private void InsertCard() => _atm.InsertCard();
    [RelayCommand] private void SelectTransaction() => _atm.SelectTransaction();
    [RelayCommand] private void ProcessTransaction() => _atm.ProcessTransaction();
    [RelayCommand] private void EjectCard() => _atm.EjectCard();

    // Expose state-dependent button availability via the current state
    public bool IsEnterPinDisabled => !_atm.CurrentState.CanEnterPin;
    public bool IsInsertCardDisabled => !_atm.CurrentState.CanInsertCard;
    public bool IsSelectTransactionDisabled => !_atm.CurrentState.CanSelectTransaction;
    public bool IsProcessTransactionDisabled => !_atm.CurrentState.CanProcessTransaction;
    public bool IsEjectCardDisabled => !_atm.CurrentState.CanEjectCard;

    public event Action? StateChanged;

    private void OnStateChanged()
    {
        OnPropertyChanged(nameof(IsEnterPinDisabled));
        OnPropertyChanged(nameof(IsInsertCardDisabled));
        OnPropertyChanged(nameof(IsSelectTransactionDisabled));
        OnPropertyChanged(nameof(IsProcessTransactionDisabled));
        OnPropertyChanged(nameof(IsEjectCardDisabled));

        StateChanged?.Invoke();
    }

    public void Dispose()
    {
        _atm.OnStateChanged -= OnStateChanged;
    }
}


