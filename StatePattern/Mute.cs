// See https://aka.ms/new-console-template for more information
public class Mute : IPossibleStates
{
    public Mute()
    {
        Console.WriteLine("---TV is in Mute mode now.---\n");
    }
    /*
    Users can press any of these buttons at this state-On, Off or Mute.
    TV is in mute, user is pressing On button.
    */
    public void PressOnButton(TV context)
    {
        Console.WriteLine("TV was in mute mode.So, moving to normal state.");
        context.CurrentState = new On();
    }

    public void PressOffButton(TV context)
    {
        Console.WriteLine("TV was in mute mode. So, switching off the TV.");
        context.CurrentState = new Off();
    }

    public void PressMuteButton(TV context)
    {
        Console.WriteLine(" TV is already in Mute mode, so, ignoring this operation.");
    }

}