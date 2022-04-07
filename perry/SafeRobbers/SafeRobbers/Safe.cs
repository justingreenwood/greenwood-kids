using System;
using System.Collections.Generic;
using System.Text;

namespace SafeRobbers
{
    class Safe
    {

        private string contents = "precious jewels";
        private string safeCombination = "12345";

        public string Open(string combination)
        {
            if (combination == safeCombination) return contents;
            return "";
        }

        public void PickLock(Locksmith lockpicker)
        {
            lockpicker.Combination = safeCombination;
        }

    }

    class SafeOwner
    {

        private string valuables = "";
        public void ReceiveContents(string safeContents)
        {
            valuables = safeContents;
            Console.WriteLine($"Thank you for returning my {valuables}!");
        }

    }

    class Locksmith
    {

        public void OpenSafe(Safe safe, SafeOwner owner)
        {
            safe.PickLock(this);
            string safeContents = safe.Open(Combination);
            ReturnContents(safeContents, owner);
        }

        public string Combination { private get; set; }

        protected virtual void ReturnContents(string safeContents, SafeOwner owner)
        {
            owner.ReceiveContents(safeContents);
        }

    }

    class JewelThief : Locksmith
    {

        private string stolenJewels;
        protected override void ReturnContents(string safeContents, SafeOwner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
        }

    }





}
