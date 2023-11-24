using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Product : IComparable<Product>
    {
        //public int Id;//variable
        int Number1;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, int quantity, float price, string description)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Description = description;
        }

        public void DisplayProduct()
        {
            Console.WriteLine("Product Id " + Id);
            Console.WriteLine("Product Name " + Name);
            Console.WriteLine("Poduct Price ${0}\nProduct Quantity {1}", Price, Quantity);
            Console.WriteLine("Product Description : " + Description);
        }

        public bool IsAvailable()
        {
            return Quantity > 0 ? true : false;
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
