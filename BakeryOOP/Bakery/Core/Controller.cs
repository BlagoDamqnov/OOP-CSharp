using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> bakedFoods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;

        private decimal TotalRestaurantIncome;


        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.TotalRestaurantIncome = 0;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            var message = string.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);

            return message;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            bakedFoods.Add(food);

            var message = string.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);

            return message;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            var message = string.Format(OutputMessages.TableAdded, table.TableNumber);

            return message;
        }

        public string GetFreeTablesInfo()
        {
            var notReservedTables = tables
                .Where(t => t.IsReserved == false)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in notReservedTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, TotalRestaurantIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                throw new ArgumentException(string.Format(OutputMessages.WrongTableNumber, tableNumber));
            }
            else
            {
                var totalTableSum = table.GetBill();

                this.TotalRestaurantIncome += totalTableSum;

                table.Clear();

                var sb = new StringBuilder();
                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {Math.Round(totalTableSum, 2)}");

                return sb.ToString().Trim();
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            IBakedFood bakedFood = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (bakedFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(bakedFood);

            return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, bakedFood.Name);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);

                return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
