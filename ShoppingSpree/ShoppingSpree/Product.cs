using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (!(string.IsNullOrEmpty(value)))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Person.Name)} cannot be empty");
                }
            }
        }

        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value >= 0)
                {
                    cost = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Person.Money)} cannot be negative");
                }
            }
        }

        public override string ToString()
        {
            return $"{this.name}";
        }
    }
}
