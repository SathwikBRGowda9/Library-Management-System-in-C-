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
    public partial class Student : Form
    {
      
        public Student()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void button1_Click(object sender, EventArgs e)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;"))
                {
                    con.Open();
                    using (SqlCommand cnn = new SqlCommand("Insert into student (id, studentname, age, roll, phone, email) values (@Id, @Studentname, @Age, @Roll, @Phone, @Email)", con))
                    {
                        cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                        cnn.Parameters.AddWithValue("@Studentname", textBox2.Text);
                        cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
                        cnn.Parameters.AddWithValue("@Roll", int.Parse(textBox4.Text));
                        cnn.Parameters.AddWithValue("@Phone", textBox5.Text);
                        cnn.Parameters.AddWithValue("@Email", textBox6.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from student", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;




        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Close", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }


        private void textBox2_KeyDown(object sender, KeyEventArgs e)

        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update student set studentname=@studentname,age=@age,roll=@roll,phone=@phone,email=@email where id=@id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Studentname", textBox2.Text);

            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));



            cnn.Parameters.AddWithValue("@Roll", int.Parse(textBox3.Text));

            cnn.Parameters.AddWithValue("@Phone", textBox5.Text);

            cnn.Parameters.AddWithValue("@Email", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");

            con.Open();

            SqlCommand cnn = new SqlCommand("Delete student where id=@id", con);

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

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
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
                textBox4.Focus();
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

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox6.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6LAVGJ6\SQLEXPRESS;Initial Catalog=library_manage;Integrated Security=True;Pooling=False;");

            con.Open();

            SqlCommand cnn = new SqlCommand("Select * from student", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            dataGridView1.DataSource = table;

        }
    }
}
