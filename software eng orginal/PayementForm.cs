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

namespace software_eng_orginal
{
    public partial class PayementForm : Form
    {
        public PayementForm()
        {
            InitializeComponent();
            textBox4.KeyPress += textBox4_KeyPress;
            textBox4.TextChanged += textBox4_TextChanged;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

            private void SubscribeForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidateNumberInput(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ValidateNumberInput(textBox3.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            ValidateNumberInput(textBox3.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 3)
            {
                textBox4.Text = textBox4.Text.Substring(0, 3);
                textBox4.SelectionStart = textBox4.Text.Length;
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void ValidateNumberInput(string input)
        {
            
            int number;
            bool isSuccess = int.TryParse(input, out number);

            if (isSuccess)
            {
               
                lblError.Text = string.Empty;

            }
            else
            { 
                
                lblError.Text = "Please enter a correct number.";

            }

            if (isSuccess)
            {

                label11.Text = string.Empty;

            }
            else
            {

                label11.Text = "Please enter a correct number.";

            }
            
        }          
        private void label11_Click(object sender, EventArgs e)
        {

        }

  

        private void label11_Click_2(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
