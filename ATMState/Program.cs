// See https://aka.ms/new-console-template for more information
using ATMState;


try
{

    ATMMachine atmMachine = new();

    // Test the ATM states
    atmMachine.InsertCard();
    atmMachine.EnterPIN(1234);

    atmMachine.SelectTransaction();
    atmMachine.ProcessTransaction();

    atmMachine.EjectCard();

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}


Console.ReadLine();
