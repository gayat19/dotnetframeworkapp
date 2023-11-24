using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public class ProductRepositoryDb:ProductRepository
    {
        SqlConnection connection;
        public ProductRepositoryDb()
        {
            this.connection = new SqlConnection("Data Source=DESKTOP-1C1EU5R\\SQLSERVER2019G3;user id=sa;password=P@ssw0rd;Initial Catalog=dbShopping24Nov23;");
        }
        public override Product Add(Product product)
        {
            SqlCommand cmdInsert = new SqlCommand("proc_AddProduct", connection);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.Parameters.AddWithValue("@pname", product.Name);
            cmdInsert.Parameters.AddWithValue("@pprice", product.Price);
            cmdInsert.Parameters.AddWithValue("@pquantity", product.Quantity);
            cmdInsert.Parameters.AddWithValue("@pdecription", product.Description);
            connection.Open();
            var result = cmdInsert.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
                return product;
            return null;
        }
        public override List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            SqlCommand cmdSelect = new SqlCommand("Select * from products", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);//open connection pull the data using teh query close the connection
            //for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            //{
            //    Product product = new Product();
            //    product.Id = Convert.ToInt32(dataSet.Tables[0].Rows[i][0]);//unboxing
            //    product.Name = dataSet.Tables[0].Rows[i][1].ToString();
            //    product.Price = Convert.ToSingle(dataSet.Tables[0].Rows[i][2]);
            //    product.Quantity = Convert.ToInt32(dataSet.Tables[0].Rows[i][3]);
            //    product.Description = dataSet.Tables[0].Rows[i][4].ToString();
            //    products.Add(product);
            //}
             foreach(DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(dataRow[0]);//unboxing
                product.Name = dataRow[1].ToString();
                product.Price = Convert.ToSingle(dataRow[2]);
                product.Quantity = Convert.ToInt32(dataRow[3]);
                product.Description = dataRow[4].ToString();
                products.Add(product);
            }
            return products;
        }
        public override Product Update(Product product)
        {
            SqlCommand cmdUpdate = new SqlCommand("proc_updateProduct", connection);
            cmdUpdate.CommandType = CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@pid", product.Id);
            cmdUpdate.Parameters.AddWithValue("@pname", product.Name);
            cmdUpdate.Parameters.AddWithValue("@pprice", product.Price);
            cmdUpdate.Parameters.AddWithValue("@pquantity", product.Quantity);
            cmdUpdate.Parameters.AddWithValue("@pdecription", product.Description);
            connection.Open();
            var result = cmdUpdate.ExecuteNonQuery();//DML query
            connection.Close();
            if (result > 0)
                return product;
            return null;
        }
    }
}
