using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class VendingMachineClass
    {

        public virtual string Item { get; }
        protected virtual bool CheckAmount(decimal money)
        {
            return false;
        }

        public string Dispense(decimal money)
        {
            if (CheckAmount(money)) return Item;
            else return "Please enter the right amount";
        }

    }

    class AnimalFeedVendingMachine : VendingMachineClass
    {
        
        public override string Item
        {
            get { return "a handful of animal feed"; }
        }

        protected override bool CheckAmount(decimal money)
        {
            return money >= 1.25M;
        }

    }



}
