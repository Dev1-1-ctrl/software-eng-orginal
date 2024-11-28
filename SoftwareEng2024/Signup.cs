using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

namespace SoftwareEng2024
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                Label label = this.Controls["lbl" + textBox.Name.Substring(3)] as Label;
                if (label != null)
                {
                    label.Visible = false;
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                Label label = this.Controls["lbl" + textBox.Name.Substring(3)] as Label;
                if (label != null)
                {
                    label.Visible = true;
                }
            }
        }

        private void PlaceholderLabel_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                TextBox textBox = this.Controls["txt" + label.Name.Substring(3)] as TextBox;
                if (textBox != null)
                {
                    textBox.Focus();
                }
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must have:\n- Minimum 8 characters\n- At least 1 uppercase letter\n- At least 1 lowercase letter\n- At least 1 number\n- At least 1 special character\n- No spaces",
                    "Password Requirements", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SaveUserToDatabase(name, username, email, password))
            {
                MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var loginForm = new login();
                loginForm.Show();
                this.Hide();
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordPattern) && !password.Contains(" ");
        }

        private bool SaveUserToDatabase(string name, string username, string email, string password)
        {
            try
            {
                // Get the connection string
                string connectionString = ConfigurationManager.ConnectionStrings["UserDatabaseConnection"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageBox.Show("The connection string 'UserDatabase' is missing or incorrect.",
                                    "Connection Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return false;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Name, Username, Email, Password) VALUES (@Name, @Username, @Email, @Password)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error saving user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                btnTogglePassword.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnTogglePassword.Text = "Show";
            }
        }

        private void btnToggleConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '*')
            {
                txtConfirmPassword.PasswordChar = '\0';
                btnToggleConfirmPassword.Text = "Hide";
            }
            else
            {
                txtConfirmPassword.PasswordChar = '*';
                btnToggleConfirmPassword.Text = "Show";
            }
        }

        private void lnkReturnToMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }
    }
}
