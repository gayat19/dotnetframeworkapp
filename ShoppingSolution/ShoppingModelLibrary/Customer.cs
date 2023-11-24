using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Customer:IComparable
    {
        //Object obj;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string  Phone { get; set; }

        public int CompareTo(object obj)
        {
            Customer customer = obj as Customer;//casts the obj to CUstomer type
            return this.Name.CompareTo(customer.Name);//using string's implementation of IComparable
        }

        public override string ToString()
        {
            return "Customer Id : " + Id
                + "\nCustomer Name : " + Name
                + "\nCustomer Phone : " + Phone
                + "\nCustomer Age : " + Age;
        }
    }
}
