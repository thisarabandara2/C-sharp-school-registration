using System.Data.SqlClient;

namespace C_shap_Student_Registration
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure, Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
            // If the user clicked "No", do nothing (the application remains open)
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear the username and password fields
            login_name.Text = string.Empty;
            login_password.Text = string.Empty;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = login_name.Text.Trim();
            string password = login_password.Text.Trim();

            // Check if username and password fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and Password are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Connection string for SQL Server
            string connectionString = "Data Source=LAHIRU\\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";

            // SQL query to check if the username and password exist in the login_users table
            string query = "SELECT COUNT(1) FROM login_users WHERE username = @Username AND password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the query and check if any row matches
                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // If credentials are correct, hide the login form and show the registration form
                            Student_Registation____Skills_International registrationForm = new Student_Registation____Skills_International();
                            registrationForm.Show();
                            this.Hide();
                        }
                        else
                        {

                            MessageBox.Show("Invalid login credentials, Please check Username and Password", "Invalid login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Invalid login credentials, Please check Username and Password", "Invalid login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void login_name_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if(login_showPass.Checked)
            {
                login_password.UseSystemPasswordChar = false;
            }
            else
            {
                login_password.UseSystemPasswordChar = true;
            }
        }

    }
}
