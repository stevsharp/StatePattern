// See https://aka.ms/new-console-template for more information
public class TV
{
    protected IPossibleStates currentState;

    public IPossibleStates CurrentState
    {
        get => currentState;
        set => currentState = value;
    }

    public TV()
    {
        currentState = new Off();
    }

    public void ExecuteOffButton()
    {
        Console.WriteLine("You pressed Off button.");
        //Delegating the state behavior
        currentState.PressOffButton(this);
    }
    public void ExecuteOnButton()
    {
        Console.WriteLine("You pressed On button.");
        //Delegating the state behavior
        currentState.PressOnButton(this);
    }

    public void ExecuteMuteButton()
    {
        Console.WriteLine("You pressed Mute button.");
        //Delegating the state behavior
        currentState.PressMuteButton(this);
    }
}
