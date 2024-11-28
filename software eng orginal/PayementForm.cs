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
            textBox8.KeyPress += textBox8_KeyPress;
            button1.Click += button1_Click;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

            private void SubscribeForm_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'mainDatabase1DataSet.Main_database' table. You can move, or remove it, as needed.
                this.main_databaseTableAdapter.Fill(this.mainDatabase1DataSet.Main_database);
                // TODO: This line of code loads data into the 'mainDatabase1DataSet.Main_database' table. You can move, or remove it, as needed.
                this.main_databaseTableAdapter.Fill(this.mainDatabase1DataSet.Main_database);
            }
            catch (Exception ex)
    {
        MessageBox.Show($"Error loading data: {ex.Message}");
    }

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
            if (textBox4.Text.Length > 4)
            {
                textBox4.Text = textBox4.Text.Substring(0, 4);
                textBox4.SelectionStart = textBox4.Text.Length;
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string cardNumber = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(cardNumber))

            {
                MessageBox.Show("Payment sucessfull .");
                return;
            }
           
                InsertNameIntoDatabase(userName, cardNumber);
        }
        private void InsertNameIntoDatabase(string userName, string cardNumber)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devna\source\repos\software eng orginal\software eng orginal\Database1.mdf;Integrated Security=True";
        
            

            using (SqlConnection connection = new SqlConnection(connectionString))
                
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(1) FROM [Main database] WHERE [Card Number] = @CardNumber";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.Add("@CardNumber", SqlDbType.NVarChar).Value = cardNumber;

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("card number cannot be empty");
                            return;
                        }
                    }
                   

                    string query = "INSERT INTO [Main database] ([Name on the card], [Card Number], [Email address], [Billing address], [Country], [Membership type]) " + "VALUES (@Name, @CardNumber, @Email, @BillingAddress, @Country, @MembershipType)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters and link textboxes to their respective fields
                        command.Parameters.AddWithValue("@Name", textBox1.Text);
                        command.Parameters.AddWithValue("@CardNumber", textBox2.Text);
                        command.Parameters.AddWithValue("@Email", textBox3.Text);
                        command.Parameters.AddWithValue("@BillingAddress", textBox5.Text);
                        command.Parameters.AddWithValue("@Country", textBox6.Text);
                        command.Parameters.AddWithValue("@MembershipType", comboBox1.Text);


                        command.ExecuteNonQuery();

                        MessageBox.Show("Congratulations your a member now !");

                        ClearFields();
                    }
                }

                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database error: {sqlEx.Message}");
                }

                catch (Exception ex)
                { MessageBox.Show($"Database error: {ex.Message}"); }
            }
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

        private void main_databaseBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.main_databaseBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mainDatabase1DataSet);

        }

        private void main_databaseBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.main_databaseBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mainDatabase1DataSet);

        }
        private void ClearFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            comboBox1.Text = string.Empty;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 3)
            {
                textBox8.Text = textBox8.Text.Substring(0, 4);
                textBox8.SelectionStart = textBox8.Text.Length;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          


        }

        private void lblError2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
