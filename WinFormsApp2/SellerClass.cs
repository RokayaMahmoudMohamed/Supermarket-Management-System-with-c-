using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace WinFormsApp2
{
    class SellerClass
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        
        public int id;
        public string ssn;
        public string name;
        public string phone;
        public string password;

        public void add_seller(int id, string ssn, string name, string phone, string password)
        {
            con.Open();
            cmd = new SqlCommand("insert into seller values('" + name + "','" + phone + "','" + ssn + "','" + password + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your seller data has been add to the database");
            con.Close();

        }

        public void update_seller(int id,string ssn,string name,string phone,string password)
        {
            con.Open();
            cmd =new SqlCommand("update seller set seller_name='" + name + "',phone='" + phone + "',ssn='" + ssn + "',password='" + password + "'where id='"+id+"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your seller data has been updated to the database");
            con.Close();
        }

        public void delete_seller(int id)
        {
            con.Open();
            cmd = new SqlCommand("delete from seller where id='"+id+"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("your seller data has been deleted to the database");
            con.Close();
        }

    }
}
