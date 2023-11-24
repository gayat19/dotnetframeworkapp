using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public  class ProductRepository
    {
        List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>();
        }
        int GenerateProductId()
        {
            if( products.Count > 0 )
            {
                return (products[products.Count-1].Id+1);
            }
            return 101;
        }
        public virtual Product Add(Product product)
        {
            product.Id = GenerateProductId();
            products.Add(product);
            return product;
        }
        public virtual List<Product> GetProducts()
        {
            return products;
        }
        public virtual Product GetProductById(int id)
        {
            //foreach (var item in products)
            //{
            //    if(item.Id==id)
            //    {
            //        return item;
            //    }
            //}
            //return null;
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }
        public virtual Product Update(Product product) 
        { 
            Product myProduct = GetProductById(product.Id);
            if (myProduct!=null)
            {
                myProduct.Name = product.Name;
                myProduct.Description = product.Description;
                myProduct.Price = product.Price;
                myProduct.Quantity = product.Quantity;
                return myProduct;
            }
            return null;
        }
        public virtual Product Delete(int id)
        {
            Product myProduct = GetProductById(id);
            if (myProduct != null)
            {
                products.Remove(myProduct);
                return myProduct;
            }
            return null;
        }
    }
}
