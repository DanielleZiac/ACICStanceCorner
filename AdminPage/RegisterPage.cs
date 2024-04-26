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
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

  

        private void BackLog_Click(object sender, EventArgs e)
        {
            LogInFrm loginPage = new LogInFrm();
            this.Hide();
            loginPage.Show();
        }

        private void PassRegBox_TextChanged(object sender, EventArgs e)
        {
            if (ShowPassReg.Checked)
            {
                // Display the actual text in the PassLogBox
                PassRegBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Mask the text in the PassLogBox
                PassRegBox.UseSystemPasswordChar = true;
            }
        }

        private void ShowPassReg_CheckedChanged(object sender, EventArgs e)
        {
            PassRegBox_TextChanged(sender, e);
        }

        private void Reg_Btn_Click(object sender, EventArgs e)
        {
            string adminName = NameRegBox.Text.Replace("'", "''"); // Sanitize input by escaping single quotes
            string adminSRCode = SRRegBox.Text;
            string adminPassword = PassRegBox.Text;

            // Perform validation if necessary
            if (String.IsNullOrEmpty(adminName) || String.IsNullOrEmpty(adminSRCode) || String.IsNullOrEmpty(adminPassword))
            {
                MessageBox.Show("All fields are required.", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string ConString = "datasource=localhost;database=ACICStance_Corner;username=root;password=navi#7oaaK6";
                    string Query = $"INSERT INTO Admin (Admin_Name, Admin_SRCode, Admin_Password) VALUES ('{adminName}', '{adminSRCode}', '{adminPassword}')";
                    MySqlConnection conn = new MySqlConnection(ConString);
                    MySqlCommand cmd = new MySqlCommand(Query, conn);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the query
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registered Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Registration failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while connecting: " + ex.Message, "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
    
}
