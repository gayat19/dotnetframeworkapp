using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepositoryEF:ProductRepository
    {
        ShoppingContext context;
        public ProductRepositoryEF()
        {
            context = new ShoppingContext();
        }
        public override Product Add(Product product)
        {
            context.Products.Add(product);//adds the object to the local collection of dbSet
            //Console.WriteLine("The current state of the object after adding to dbset before save chages "+context.Entry(product).State);
            context.SaveChanges();//Saves the change in thi case inserts a new row in table to database
           // Console.WriteLine("The current state of the object after save chages " + context.Entry(product).State);
            return product;
        }
        public override List<Product> GetProducts()
        {
            var products = context.Products.ToList();
            return products;
        }
        public override Product Update(Product product)
        {
            var myProduct = context.Products.FirstOrDefault(p => p.Id == product.Id);
            myProduct.Name = product.Name;
            myProduct.Description=product.Description;
            myProduct.Price = product.Price;
            myProduct.Quantity = product.Quantity;

            context.SaveChanges();
            return product;
        }
        public override Product Delete(int id)
        {
            var myProduct = context.Products.FirstOrDefault(p=>p.Id == id);
            if (myProduct != null)
            {
                context.Products.Remove(myProduct);
                context.SaveChanges();
                return myProduct;
            }
            return null;
        }
    }
}
