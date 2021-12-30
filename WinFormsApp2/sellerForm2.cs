using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace WinFormsApp2
{
    public partial class sellerForm2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int seller_id;
        public sellerForm2()
        {
            InitializeComponent();
            dataGridView1_CellContentClick();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           DialogResult result= MessageBox.Show("Are you sure to exit", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productsform productsform = new productsform();
            productsform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            categoryform categoryform = new categoryform();
            categoryform.Show();
        }
        public void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
        private void button4_Click(object sender, EventArgs e)
        {
            SellerClass s = new SellerClass();
            s.add_seller(seller_id, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            dataGridView1_CellContentClick();
            clear();
        }

        private void dataGridView1_CellContentClick()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from seller", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seller_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            SellerClass s = new SellerClass();
            s.update_seller(seller_id, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            dataGridView1_CellContentClick();
            clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellerClass s = new SellerClass();
            s.delete_seller(seller_id);
            dataGridView1_CellContentClick();
            clear();
        }

      
    }
}
