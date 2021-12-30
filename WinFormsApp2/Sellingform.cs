using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
struct selling_product
{
    string pro_name;
    int pro_price;
    int pro_quantity;
    int selling_total;
}
namespace WinFormsApp2
{
    public partial class Sellingform : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd,cm,cmd2;
        SqlDataAdapter adpt, adpt2,adpt3;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        public Sellingform()
        {
            InitializeComponent();
            adpt = new SqlDataAdapter("select * from category", con);
            adpt.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "category_name";
            comboBox1.ValueMember = "id";
            
            DataColumn dc1 = new DataColumn("Name");
            DataColumn dc2 = new DataColumn("Price");
            DataColumn dc3 = new DataColumn("Quantity");
            DataColumn dc4 = new DataColumn("Total");
            dt3.Columns.Add(dc1);
            dt3.Columns.Add(dc2);
            dt3.Columns.Add(dc3);
            dt3.Columns.Add(dc4);
            // dataGridView1_CellContentClick();
        }

        // form show product
        private void dataGridView2_CellContentClick()
        {
            con.Open();
            cmd = new SqlCommand("select max(id) from category where category_name='" + comboBox1.Text + "'", con);
            int cat_id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            con.Open();
            adpt2 = new SqlDataAdapter("select product.product_name,quantity from product where product.category_id='" + cat_id+"'", con);
            dt2 = new DataTable();
            adpt2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2_CellContentClick();
        }

        // to choise product
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            con.Open();
            cm = new SqlCommand("select price from product where product.product_name='" + textBox2.Text + "'", con);
            textBox3.Text = cm.ExecuteScalar().ToString();
            con.Close();
        
        }

        // show product data to the view data form
        private void dataGridView1_CellContentClick()
        {
            con.Open();
            cmd = new SqlCommand("select max(id) from product where product_name='" + textBox2.Text + "'", con);
            int pro_id = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new SqlCommand("select quantity from product where id='" + pro_id + "'", con);
            int main_quantity= Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if(main_quantity-Convert.ToInt32(textBox4.Text)>0)
            {
                ProductClass p = new ProductClass();
                p.update_product(pro_id, textBox2.Text, Convert.ToInt32(textBox3.Text), main_quantity - Convert.ToInt32(textBox4.Text), comboBox1.Text);
            }
            else
            {
                ProductClass p = new ProductClass();
                p.delete_product(pro_id);
            }
            
            
 
            DataRow dr = dt3.NewRow();
            dr[0] = textBox2.Text;
            dr[1] =textBox3.Text;
            dr[2] = textBox4.Text;
            dr[3] = Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox3.Text);
            dt3.Rows.Add(dr);
            dataGridView1.DataSource = dt3;
            clear();
        }

        // to add product data to the view data form
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to exit", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dataGridView2.DataSource = "";
        }
        
    }
}
