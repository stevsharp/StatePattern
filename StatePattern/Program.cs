namespace helloworld;

 public class Program
{
    static void Main()
    {
        Console.WriteLine("***State Pattern Demo***\n");
        //TV is initialized with Off state.
        TV tv = new TV();
        Console.WriteLine("User is pressing buttons in the following sequence: ");
        Console.WriteLine("Off->Mute->On->On->Mute->Mute->Off\n");
        //TV is already in Off state
        tv.ExecuteOffButton();

        //TV is already in Off state, still pressing the Mute button
        tv.ExecuteMuteButton();
        //Making the TV on
        tv.ExecuteOnButton();
        //TV is already in On state, pressing On button again
        tv.ExecuteOnButton();
        //Putting the TV in Mute mode
        tv.ExecuteMuteButton();
        //TV is already in Mute, pressing Mute button again
        tv.ExecuteMuteButton();
        //Making the TV off
        tv.ExecuteOffButton();
        // Wait for user
        Console.Read();
    }
}
