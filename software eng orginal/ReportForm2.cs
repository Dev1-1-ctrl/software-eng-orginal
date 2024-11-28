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
using System.Xml.Linq;
using System.Windows.Forms.VisualStyles;

namespace software_eng_orginal
{
    public partial class ReportForm2 : Form



    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devna\source\repos\software eng orginal\software eng orginal\Database1.mdf;Integrated Security=True";




        public ReportForm2()
        {
            InitializeComponent();
            InitializePlaceholders();
        }

        private void InitializePlaceholders()
        {
            SetPlaceholder(textboxUserID, " Please Enter User ID");
            SetPlaceholder(textboxDate, "Please Enter Date like this 12345");
            SetPlaceholder(textboxComment, "Enter your comment here");
        }

        private void SetPlaceholder(TextBox txtBox, string placeholderText)
        {
            txtBox.Text = placeholderText;
            txtBox.ForeColor = Color.Gray;

            txtBox.Enter += (sender, e) => RemovePlaceholder(sender as TextBox, placeholderText);
            txtBox.Leave += (sender, e) => AddPlaceholder(sender as TextBox, placeholderText);
        }
        private void RemovePlaceholder(TextBox txtBox, string placeholderText)
        {
            if (txtBox.Text == placeholderText)
            {
                txtBox.Text = "";
                txtBox.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholder(TextBox txtBox, string placeholderText)
        {
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                txtBox.Text = placeholderText;
                txtBox.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
            this.Hide();
        }

        private void ReportForm2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userID = textboxUserID.Text;
            string date = textboxDate.Text; // Make sure the date format is correct
            string comment = textboxComment.Text;

            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(date) || string.IsNullOrEmpty(comment))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                // Convert the string date to DateTime type
                int dateInt = int.Parse(date);

                // Create SQL query to insert data into the database
                string query = "INSERT INTO Report ([User id], [Date], [Comments]) VALUES (@UserID, @Date, @Comment)";

                // Create and open the connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the SqlCommand with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@Date", dateInt);
                        command.Parameters.AddWithValue("@Comment", comment);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while inserting data.");
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
