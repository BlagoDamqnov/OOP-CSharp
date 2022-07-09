using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProduct;

        private IReadOnlyCollection <Product> BagOfProduct
        {
            get { return bagOfProduct;}
        }
        private Person()
        {
            bagOfProduct = new List<Product>();
        }
        public Person(string name, decimal money)
            :this()
        {
            this.Name=name;
            this.Money = money;
            
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

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value>=0)
                {
                    money = value;
                }
                else
                {
                  throw new ArgumentException($"{nameof(Person.Money)} cannot be negative");
                }
            }
        }
        public void AddProduct(Product product)
        {
            if (product.Cost<=this.Money)
            {
                 bagOfProduct.Add(product);
                Money-=product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                throw new ArgumentException($"{Name} can't afford {product.Name}");
            }
            
        }

        public override string ToString()
        {
            if (bagOfProduct.Count==0)
            {
                return $"{this.Name} - Nothing bought";
             }

             return $"{Name} - {string.Join(", ", BagOfProduct)}";
        }
    }
}
