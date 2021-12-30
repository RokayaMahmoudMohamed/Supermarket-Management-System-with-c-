using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WinFormsApp2
{
    public partial class productsform : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt,adpt2;
        DataTable dt=new DataTable();
        DataTable dt2 = new DataTable();
        int pro_id;
        int cat_id;
        public productsform()
        {
            InitializeComponent();
            dataGridView1_CellContentClick();
            adpt = new SqlDataAdapter("select * from category", con);
            adpt.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "category_name";
            comboBox1.ValueMember = "id";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to exit", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            categoryform categoryform = new categoryform();
            categoryform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sellerForm2 sellerForm = new sellerForm2();
            sellerForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductClass pro = new ProductClass();
            //CategoryClass cat = new CategoryClass();
            
            pro.add_product(pro_id,textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text),comboBox1.Text);
            dataGridView1_CellContentClick();
            clear();

        }
        public void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pro_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductClass pro = new ProductClass();
            pro.update_product(pro_id,textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), comboBox1.Text);
            dataGridView1_CellContentClick();
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProductClass pro = new ProductClass();
            pro.delete_product(pro_id);
            dataGridView1_CellContentClick();
            clear();
        }


        private void dataGridView1_CellContentClick()
        {
            con.Open();
            adpt2 = new SqlDataAdapter("select product.id,product.product_name,price,quantity,category.category_name from product inner join category on product.category_id=category.id", con);
            dt2 = new DataTable();
            adpt2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }
    }
}
