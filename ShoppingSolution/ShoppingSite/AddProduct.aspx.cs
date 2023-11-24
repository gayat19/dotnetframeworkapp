using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductRepository repo = new ProductRepositoryEF();
            Product product = new Product();
            product.Name = txtName.Text;
            product.Price = Convert.ToSingle(txtPrice.Text);
            product.Quantity = Convert.ToInt32(txtQuantity.Text);
            product.Description = txtDescription.Text;
            var result = repo.Add(product);
            if (result != null)
                lblMessage.Text = "Product Added!!!";
            else
                lblMessage.Text = "Unable to add product";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            lblMessage.Text = "";
        }
    }
}