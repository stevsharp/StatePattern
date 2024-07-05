// See https://aka.ms/new-console-template for more information
public class Off : IPossibleStates
{
    public Off()
    {
        Console.WriteLine("---TV is Off now.---\n");
    }
    //TV is Off now, user is pressing On button
    public void PressOnButton(TV context)
    {
        Console.WriteLine("TV was Off.Going from Off to On state.");
        context.CurrentState = new On();
    }

    //TV is Off already, user is pressing Off button again
    public void PressOffButton(TV context)
    {
        Console.WriteLine("TV was already in Off state.So, ignoring this opeation.");
    }
    //TV is Off now, user is pressing Mute button
    public void PressMuteButton(TV context)
    {
        Console.WriteLine("TV was already off.So, ignoring this operation.");
    }
}
