using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingApp
{
    internal class Program
    {
       void TestDAL()
        {
            ProductRepository repo = new ProductRepositoryEF();
            //repo.Add(new Product { Name = "Pencil", Price = 2.3f, Quantity = 5, Description = "Used for writing and drawing" });
            //repo.Add(new Product { Name = "Pen", Price = 5.5f, Quantity = 3, Description = "Write and sign" });
            var products = repo.GetProducts();
            foreach (var product in products)
            {
                product.DisplayProduct();
                Console.WriteLine("_______________________________________");
            }
            Product newProduct = new Product { Id = 1, Name = "Gel Pen", Price = 5.8f, Quantity = 9, Description = "Write and sign real smooth" };
            repo.Update(newProduct);
            Console.WriteLine("After Updation");
            foreach (var product in products)
            {

                product.DisplayProduct();
                Console.WriteLine("_______________________________________");
            }
            var result = repo.Delete(2);
            if(result==null)
                Console.WriteLine("Product not found for deleting");
            Console.WriteLine("After Delete");
            foreach (var product in products)
            {

                product.DisplayProduct();
                Console.WriteLine("_______________________________________");
            }

        }
        static void Main(string[] args)
        {
            new Program().TestDAL();    
            Console.ReadKey();
        }
    }
}
