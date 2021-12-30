using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace WinFormsApp2
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PCQ62AN;Initial Catalog=supermarket;Integrated Security=True");
        SqlCommand cmd, cm;
        SqlDataAdapter adpt;
        DataTable dt;
        public login()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //chick admin by password
                if (comboBox1.Text == "ADMIN")
                {
                    if (textBox2.Text == "rokaya112001" && textBox1.Text == "rokaya")
                    {
                        sellerForm2 seller = new sellerForm2();
                        seller.Show();
                    }
                    else
                        MessageBox.Show("try again", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //chick seller by password
                else if (comboBox1.Text == "SELLER")
                {
                    string pass = "";
                    con.Open();
                    cmd = new SqlCommand("select isnull( max(password),'') from seller where seller_name= '" + textBox1.Text + "'", con);
                    // if (cmd.ExecuteScalar().ToString() !='')

                    pass = cmd.ExecuteScalar().ToString().Trim();


                    if (pass == textBox2.Text)
                    {
                        Sellingform sellingform = new Sellingform();
                        sellingform.Show();

                    }
                    else
                        MessageBox.Show("try again", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("select user");
                con.Close();
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure to exit", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


    }

}
