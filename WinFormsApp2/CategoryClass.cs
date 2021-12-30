using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    class CategoryClass
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        public int id;
        public string name;

        public void add_category(int id,string name)
        {
            con.Open();
            cmd = new SqlCommand("insert into category values('" + name + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your category data has been added to database");
            con.Close();

        }
        public void update_category(int id,string name)
        {
            con.Open();
            cmd = new SqlCommand("update category set category_name='" + name + "'where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your category data has been updated in database");
            con.Close();
        }

        public void delete_category(int id)
        {
            con.Open();
            
            cmd=new SqlCommand("delete from product where category_id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("delete from category where id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your category data has been deleted from database");
            con.Close();
        }

    }
}
