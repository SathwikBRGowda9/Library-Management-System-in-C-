using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_Admin.PAL.Forms
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Books b=new Books();
            b.Show();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student f=new Student();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Student f = new Student();
            f.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Books f=new Books();    
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Borrowing f=new Borrowing();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            librian f=new librian();    
            f.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Prevent the form from closing if the user clicked "No"
                Application.Exit();
            }
        }
    }
}
