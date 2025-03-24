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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Management_System_Admin.PAL.Forms
{
    public partial class librian : Form
    {
        public librian()
        {
            InitializeComponent();
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;"))
                {
                    con.Open();
                    using (SqlCommand cnn = new SqlCommand("Insert into librian (id,name,age,addres) values (@Id, @name, @Age, @Addres)", con))
                    {
                        cnn.Parameters.AddWithValue("@Id", int.Parse(textBox5.Text));
                        cnn.Parameters.AddWithValue("@name", textBox6.Text);
                        cnn.Parameters.AddWithValue("@Age", int.Parse(textBox7.Text));
                        cnn.Parameters.AddWithValue("@Addres", textBox8.Text);
                        cnn.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data saved Sucesefully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input format: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from librian", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView2.DataSource = table;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update librian set name=@name,age=@age,addres=@Addres where id=@id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox5.Text));
            cnn.Parameters.AddWithValue("@name", textBox6.Text);
            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox7.Text));
            cnn.Parameters.AddWithValue("@Addres", textBox8.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete librian where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox5.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox8.Focus();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
