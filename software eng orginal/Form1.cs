using System;
using System.Drawing;
using System.Windows.Forms;

namespace software_eng_orginal
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void ShowForm1()
        {
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_leave(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
           
            }

        private void opensideclick_Click(object sender, EventArgs e)
        {
            closesidebar.Visible = true;
            opensidebar.Visible = true; 
        }

        private void Closesideclick_Click(object sender, EventArgs e)
        {
            closesidebar.Visible = false;
            opensidebar.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
   
            Communitymemeber communitymemeber = new Communitymemeber(this);
            communitymemeber.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Communitymemeber communitymemeber = new Communitymemeber(this);
            communitymemeber.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Communitymemeber communitymemeber = new Communitymemeber(this);
            communitymemeber.Show();
            this.Hide();
        }
    }
    }


