using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace software_eng_orginal
{
    public partial class Communitymemeber : Form
    {
        private Form _previousForm;
        public Communitymemeber(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void Communitymemeber_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            _previousForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PayementForm payementForm = new PayementForm();
            payementForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PayementForm payementForm = new PayementForm();
            payementForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PayementForm payementForm = new PayementForm();
            payementForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
