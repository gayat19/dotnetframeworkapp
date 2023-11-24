using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart 
    {
        public int CartId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
       
    }
}
