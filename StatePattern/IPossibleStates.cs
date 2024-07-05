// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Threading;

Console.WriteLine("Hello, World!");


public interface IPossibleStates
{
    //Users can press any of these buttons-On, Off or Mute
    void PressOnButton(TV context);
    void PressOffButton(TV context);
    void PressMuteButton(TV context);
}
