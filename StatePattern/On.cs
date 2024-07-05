// See https://aka.ms/new-console-template for more information
public class On : IPossibleStates
{
    public On()
    {
        Console.WriteLine("---TV is On now.---\n");
    }
    //TV is On already, user is pressing On button again
    public void PressOnButton(TV context)
    {
        Console.WriteLine("TV is already in On state.Ignoring repeated on button press operation.");
    }
    //TV is On now, user is pressing Off button
    public void PressOffButton(TV context)
    {
        Console.WriteLine("TV was on.So,switching off the TV.");
        context.CurrentState = new Off();
    }

    //TV is On now, user is pressing Mute button
    public void PressMuteButton(TV context)
    {
        Console.WriteLine("TV was on.So,moving to silent mode.");
        context.CurrentState = new Mute();
    }
}
