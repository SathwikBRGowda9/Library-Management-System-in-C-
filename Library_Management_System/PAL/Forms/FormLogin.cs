using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library_Management_System_Admin.PAL.Forms
{
    public partial class FormLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM library_user WHERE username=@username AND password=@password";
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int count = dt.Rows.Count;

                if (count == 0)
                {
                    MessageBox.Show("Username or password does not match.");
                }
                else
                {
                    MessageBox.Show("Login successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Homepage f=new Homepage(); 
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            signup f=new signup();
            f.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.Focus();
            }
        }
    }
}
