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
using System.Text.RegularExpressions;

namespace C_shap_Student_Registration
{
    public partial class Student_Registation____Skills_International : Form
    {
        // Connection string for connecting to the SQL Server database
        string connectionString = "Data Source=LAHIRU\\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";



        public Student_Registation____Skills_International()
        {
            InitializeComponent();
            this.Load += new EventHandler(Student_Registation____Skills_International_Load);
        }

        private void Student_Registation____Skills_International_Load(object sender, EventArgs e)
        {
            // Clear existing items in the ComboBox
            reg_regNo.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT regNo FROM Registration", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // Add each regNo to the ComboBox
                            reg_regNo.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during database operations
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure, Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
            // If the user clicked "No", do nothing (the application remains open)
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            // Validation for email
            string email = reg_email.Text;
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation for date of birth
            DateTime dateOfBirth = reg_dateOfBirth.Value;
            if (dateOfBirth >= DateTime.Today)
            {
                MessageBox.Show("Date of birth must be a past date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation for mobile phone number (optional)
            int? mobilePhone = null;
            if (!string.IsNullOrWhiteSpace(reg_mobilePhone.Text))
            {
                if (!int.TryParse(reg_mobilePhone.Text, out int parsedMobilePhone))
                {
                    MessageBox.Show("Please enter a valid integer value for the mobile phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                mobilePhone = parsedMobilePhone;
            }

            // Validation for home phone number (optional)
            int? homePhone = null;
            if (!string.IsNullOrWhiteSpace(reg_homePhone.Text))
            {
                if (!int.TryParse(reg_homePhone.Text, out int parsedHomePhone))
                {
                    MessageBox.Show("Please enter a valid integer value for the home phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                homePhone = parsedHomePhone;
            }

            // Validation for NIC (optional)
            string nic = reg_nic.Text;
            if (!string.IsNullOrWhiteSpace(nic) && !int.TryParse(nic, out _))
            {
                MessageBox.Show("NIC number should be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation for parent contact number (optional)
            int? contactNo = null;
            if (!string.IsNullOrWhiteSpace(reg_parentContactNum.Text))
            {
                if (!int.TryParse(reg_parentContactNum.Text, out int parsedContactNo))
                {
                    MessageBox.Show("Please enter a valid integer value for the parent contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                contactNo = parsedContactNo;
            }

            // Proceed with registration if all validations pass
            string firstName = reg_fName.Text;
            string lastName = reg_lName.Text;
            string gender = reg_male.Checked ? "Male" : reg_female.Checked ? "Female" : string.Empty;
            string address = reg_address.Text;
            string parentName = reg_parentName.Text;

            // Build SQL query with conditional fields
            string query = "INSERT INTO Registration (firstName, lastName, dateOfBirth, gender, address, email, parentName";

            if (mobilePhone.HasValue) query += ", mobilePhone";
            if (homePhone.HasValue) query += ", homePhone";
            if (!string.IsNullOrWhiteSpace(nic)) query += ", nic";
            if (contactNo.HasValue) query += ", contactNo";

            query += ") VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @Address, @Email, @ParentName";

            if (mobilePhone.HasValue) query += ", @MobilePhone";
            if (homePhone.HasValue) query += ", @HomePhone";
            if (!string.IsNullOrWhiteSpace(nic)) query += ", @NIC";
            if (contactNo.HasValue) query += ", @ContactNo";

            query += ")";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@ParentName", parentName);

                        // Add optional parameters only if they have values
                        if (mobilePhone.HasValue) command.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                        if (homePhone.HasValue) command.Parameters.AddWithValue("@HomePhone", homePhone);
                        if (!string.IsNullOrWhiteSpace(nic)) command.Parameters.AddWithValue("@NIC", nic);
                        if (contactNo.HasValue) command.Parameters.AddWithValue("@ContactNo", contactNo);

                        // Execute the command
                        command.ExecuteNonQuery();
                        MessageBox.Show("Record Added Successfully!", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateComboBox();
                        ClearAllFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            // Retrieve updated data from form controls
            string regNo = reg_regNo.SelectedItem?.ToString(); // Ensure regNo is selected
            string firstName = reg_fName.Text;
            string lastName = reg_lName.Text;
            DateTime dateOfBirth = reg_dateOfBirth.Value;
            string gender = reg_male.Checked ? "Male" : reg_female.Checked ? "Female" : string.Empty;
            string address = reg_address.Text;
            string email = reg_email.Text;
            int mobilePhone = int.TryParse(reg_mobilePhone.Text, out int mobile) ? mobile : 0;
            int homePhone = int.TryParse(reg_homePhone.Text, out int home) ? home : 0;
            string parentName = reg_parentName.Text;
            string nic = reg_nic.Text;
            int contactNo = int.TryParse(reg_parentContactNum.Text, out int contact) ? contact : 0;

            // Ensure that regNo is not null or empty
            if (string.IsNullOrEmpty(regNo))
            {
                MessageBox.Show("Please select a registration number to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL query to update data in the Registration table
            string query = "UPDATE Registration SET firstName = @FirstName, lastName = @LastName, dateOfBirth = @DateOfBirth, gender = @Gender, " +
                           "address = @Address, email = @Email, mobilePhone = @MobilePhone, homePhone = @HomePhone, parentName = @ParentName, " +
                           "nic = @NIC, contactNo = @ContactNo WHERE regNo = @RegNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                        command.Parameters.AddWithValue("@HomePhone", homePhone);
                        command.Parameters.AddWithValue("@ParentName", parentName);
                        command.Parameters.AddWithValue("@NIC", nic);
                        command.Parameters.AddWithValue("@ContactNo", contactNo);
                        command.Parameters.AddWithValue("@RegNo", regNo);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given registration number.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during database operations
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 student = new Form1();
            student.Show();
            this.Hide();
        }

        private void reg_fName_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }

        private void reg_regNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected regNo from the ComboBox
            string selectedRegNo = reg_regNo.SelectedItem.ToString();

            // SQL query to retrieve details for the selected regNo
            string query = "SELECT firstName, lastName, dateOfBirth, gender, address, email, mobilePhone, homePhone, parentName, nic, contactNo FROM Registration WHERE regNo = @RegNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the regNo parameter to the SQL query
                        command.Parameters.AddWithValue("@RegNo", selectedRegNo);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Populate the form fields with data from the database
                            reg_fName.Text = reader["firstName"].ToString();
                            reg_lName.Text = reader["lastName"].ToString();
                            reg_dateOfBirth.Value = Convert.ToDateTime(reader["dateOfBirth"]);
                            string gender = reader["gender"].ToString();
                            reg_male.Checked = (gender == "Male");
                            reg_female.Checked = (gender == "Female");
                            reg_address.Text = reader["address"].ToString();
                            reg_email.Text = reader["email"].ToString();
                            reg_mobilePhone.Text = reader["mobilePhone"].ToString();
                            reg_homePhone.Text = reader["homePhone"].ToString();
                            reg_parentName.Text = reader["parentName"].ToString();
                            reg_nic.Text = reader["nic"].ToString();
                            reg_parentContactNum.Text = reader["contactNo"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during database operations
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            // Retrieve the selected regNo from the ComboBox
            string regNo = reg_regNo.SelectedItem?.ToString();

            // Ensure that regNo is not null or empty
            if (string.IsNullOrEmpty(regNo))
            {
                MessageBox.Show("Please select a registration number to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion with the user
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected record?", " Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // SQL query to delete the record from the Registration table
                string query = "DELETE FROM Registration WHERE regNo = @RegNo";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add the regNo parameter to the SQL query
                            command.Parameters.AddWithValue("@RegNo", regNo);

                            // Execute the command
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record deleted successfully!", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Optionally, clear or refresh the ComboBox
                                reg_regNo.Items.Remove(regNo);
                                ClearAllFields();


                            }
                            else
                            {
                                MessageBox.Show("No record found with the given registration number.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during database operations
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // If the user clicks "No", do nothing (the record will not be deleted)
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {

            ClearAllFields();
        }
        // Method to clear all text fields and reset form controls
        private void ClearAllFields()
        {
            // Clear all text fields on the form
            reg_fName.Text = string.Empty;
            reg_lName.Text = string.Empty;
            reg_address.Text = string.Empty;
            reg_email.Text = string.Empty;
            reg_mobilePhone.Text = string.Empty;
            reg_homePhone.Text = string.Empty;
            reg_parentName.Text = string.Empty;
            reg_nic.Text = string.Empty;
            reg_parentContactNum.Text = string.Empty;

            // Optionally clear date fields and radio buttons
            reg_dateOfBirth.Value = DateTime.Today; // Reset date to today's date
            reg_male.Checked = false; // Uncheck male radio button
            reg_female.Checked = false; // Uncheck female radio button

            reg_regNo.Text = string.Empty;
            this.Load += new EventHandler(Student_Registation____Skills_International_Load);
        }

        private void UpdateComboBox()
        {
            // Clear existing items in the ComboBox
            reg_regNo.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT regNo FROM Registration", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            // Add each regNo to the ComboBox
                            reg_regNo.Items.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during database operations
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //-----------------------
        private void Student_Registation____Skills_International_Load_1(object sender, EventArgs e)
        {

        }
    }
}
