using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateChefs
{
    class Adrian
    {
        public GetSecretIngredient MySecretIngredientMethod { get { return AddAdriansSecretIngredient; }}
        private string AddAdriansSecretIngredient(int amount)
        {
            return $"{amount} ounces of cloves";
        }

    }

    class Harper
    {
        public GetSecretIngredient HarpersSecretIngredientMethod { get { return AddHarpersSecretIngredient; } }

        private int cans = 20;

        private string AddHarpersSecretIngredient(int amount)
        {
            if (cans < amount)
            {
                return $"I do not have {amount} cans of sardines!";
            }
            else
            {
                cans -= amount;
                return $"{amount} cans of sardines";
            }

        }

    }

}
