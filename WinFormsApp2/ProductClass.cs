using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace WinFormsApp2
{
    class ProductClass
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd,cm;
        SqlDataAdapter adpt;
        DataTable dt;

        public int id;
        public string name;
        public int price;
        public int quantity;
       // public int cat_id;

        public void add_product(int id,string name,int price,int quantity,string cat_name)
        {
            con.Open();
            cm = new SqlCommand("select max(id) from category where category_name='" + cat_name + "'", con);
            int cat_id = Convert.ToInt32(cm.ExecuteScalar());
            con.Close();
            con.Open();
            cmd = new SqlCommand("insert into product values('" +name+ "','" + price + "','" + quantity + "','" + cat_id + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your product data has been add to the database");
            con.Close();
        }
        public void update_product(int id,string name, int price, int quantity, string cat_name)
        {
            con.Open();
            cm = new SqlCommand("select max(id) from category where category_name='" + cat_name + "'", con);
            int cat_id = Convert.ToInt32(cm.ExecuteScalar());
            con.Close();
            con.Open();
            cmd = new SqlCommand("update product set product_name='" + name + "',price='" + price + "',quantity='" + quantity + "',category_id='" + cat_id + "'where id='" + id+ "'",con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your product data has been updated to the database");
            con.Close();
        }
        
        public void delete_product(int id)
        {
            con.Open();
            cmd = new SqlCommand("delete from product where id='" + id + "'" , con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your product has been deleted from database");
            con.Close();
        }
    }
}
