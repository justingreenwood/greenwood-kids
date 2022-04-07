using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineClass vendingMachine = new VendingMachineClass();
            Console.WriteLine(vendingMachine.Dispense(2.00M));
            //vendingMachine.CheckAmount(1F);
        }
    }
}
