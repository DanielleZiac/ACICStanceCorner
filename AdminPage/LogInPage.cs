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
using BCrypt;

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

            if (enteredSRCode.Length != 8)
            {
                MessageBox.Show("SR code must be 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if validation fails
            }
            try
            {
                string connectionString = "datasource=localhost;database=Acicstance_corner;username=root;password=navi#7oaaK6";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Admin_Name, Admin_SRCode, Admin_Password FROM Admin WHERE Admin_SRCode = @SRCode";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SRCode", enteredSRCode);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashedPasswordFromDatabase = reader.GetString("Admin_Password");

                                if (BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPasswordFromDatabase))
                                {
                                    string adminName = reader.GetString("Admin_Name");
                                    string srCode = reader.GetString("Admin_SRCode");

                                    // Close the reader before executing another query
                                    reader.Close();

                                    string updateQuery = "UPDATE Admin SET LastLoginDate = NOW() WHERE Admin_SRCode = @SRCode";
                                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@SRCode", enteredSRCode);
                                        updateCmd.ExecuteNonQuery();
                                    }

                                    DashboardUI dashboard = new DashboardUI(adminName, srCode);
                                    this.Hide();
                                    dashboard.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid SR code. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logging in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
