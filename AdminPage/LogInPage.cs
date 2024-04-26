using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPage
{
    public partial class LogInFrm : Form
    {
        public LogInFrm()
        {
            InitializeComponent();
        }

        private void PassLogBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            RegisterPage registerpage = new RegisterPage();
            this.Hide();
            registerpage.Show();
        }

        private void PassLogBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowPassLog_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassLog.Checked)
            {
                // Display the actual text in the password textbox
                PassLogBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Mask the text in the password textbox
                PassLogBox.UseSystemPasswordChar = true;
            }
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            string enteredSRCode = SRLogBox.Text;
            string enteredPassword = PassLogBox.Text;

            try
            {
                // Establish connection to the database
                string connectionString = "datasource=localhost;database=Acicstance_corner;username=root;password=navi#7oaaK6";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                // Query to check if the entered SR code and password exist in the database
                string query = "SELECT Admin_Name, Admin_SRCode FROM Admin WHERE Admin_SRCode = @SRCode AND Admin_Password = @Password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SRCode", enteredSRCode);
                cmd.Parameters.AddWithValue("@Password", enteredPassword);

                // Execute the query and retrieve the results
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // If the reader has rows, the SR code and password match a record in the database
                    // Get the admin name and SR code from the database
                    string adminName = reader.GetString("Admin_Name");
                    string srCode = reader.GetString("Admin_SRCode");



                    // Show the dashboard
                    DashboardUI dashboard = new DashboardUI(adminName, srCode);
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    // If the reader has no rows, the SR code and/or password do not match any record in the database
                    MessageBox.Show("Invalid SR code or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close(); // Close the data reader
                conn.Close(); // Close the database connection
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database access
                MessageBox.Show("An error occurred while logging in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
