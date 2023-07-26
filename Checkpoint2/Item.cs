using System;
namespace Checkpoint2
{
    public class Item
    {
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Product { get; set; }

        public Item(string category, string product, decimal amount)
        {
            Category = category;
            Product = product;
            Amount = amount;
        }
    }
}

