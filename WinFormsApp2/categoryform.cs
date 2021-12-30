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
    public partial class categoryform : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int category_id;
        public categoryform()
        {
            InitializeComponent();
            dataGridView1_CellContentClick();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to exit", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sellerForm2 sellerForm = new sellerForm2();
            sellerForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productsform productsform = new productsform();
            productsform.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            productsform productsform = new productsform();
            productsform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryClass cat = new CategoryClass();
            cat.add_category(category_id, textBox2.Text);
            dataGridView1_CellContentClick();
            clear();
        }

        private void dataGridView1_CellContentClick()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from category", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public void clear()
        {
            textBox2.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            category_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CategoryClass cat = new CategoryClass();
            cat.update_category(category_id, textBox2.Text);
            dataGridView1_CellContentClick();
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CategoryClass cat = new CategoryClass();
            cat.delete_category(category_id);
            dataGridView1_CellContentClick();
            clear();
        }
    }
}
