using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Data.SqlClient;

namespace Library_Management_System_Admin.PAL.Forms
{
    public partial class Borrowing : Form
    {
        public Borrowing()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;"))
                {
                    con.Open();
                    using (SqlCommand cnn = new SqlCommand("Insert into borrowing (id,studentname,book,dateborrowed,datereturn) values (@Id, @Studentname, @Book, @Dateborrowed,@Datereturn)", con))
                    {
                        cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                        cnn.Parameters.AddWithValue("@Studentname", textBox2.Text);

                        cnn.Parameters.AddWithValue("@Book", textBox3.Text);
                        cnn.Parameters.AddWithValue("@Dateborrowed",DateTime.Parse(dateTimePicker1.Text));
                        cnn.Parameters.AddWithValue("@Datereturn",DateTime.Parse(textBox5.Text));
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from borrowing", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update borrowing set studentname=@studentname,book=@book,dateborrowed=@dateborrowed,datereturn=@datereturn where id=@id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Studentname", textBox2.Text);

            cnn.Parameters.AddWithValue("@Book", textBox3.Text);
            cnn.Parameters.AddWithValue("@Dateborrowed", DateTime.Parse(dateTimePicker1.Text));
            cnn.Parameters.AddWithValue("@Datereturn", DateTime.Parse(textBox5.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete borrowing where id=@id", con);

            cnn.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted");
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
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                dateTimePicker1.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox5.Focus();
            }
        }
    }
    }
    

