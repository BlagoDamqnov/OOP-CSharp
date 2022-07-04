using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, cakePrice, grams, calories)
        {
            
        }
        private const double grams = 350;
        private const double calories = 1000;
        private const decimal cakePrice = 5;

    }
}
