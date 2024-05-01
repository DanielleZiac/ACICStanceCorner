using AdminPage.User_Controls;
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
    public partial class DashboardUI : Form
    {
        private string adminName;
        private string srCode;
        private UserControl currentUC = null;
        public DashboardUI(string adminName, string srCode)
        {
            InitializeComponent();
            load_UC(new UC_Home());
            this.adminName = adminName;
            this.srCode = srCode;
        }

        private void DashboardUI_Load(object sender, EventArgs e)
        {
            AdminLabel.Text = adminName; // Update the admin label with the admin name
            SRLabel.Text = srCode; // Update the SR label with the SR code
        }
      
        private void exitBtn_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void Home_Btn_Click(object sender, EventArgs e)
        {
           load_UC(new UC_Home());
        }

        private void Transact_Btn_Click(object sender, EventArgs e)
        {
           load_UC(new UC_Transaction());
        }

        private void Services_Btn_Click(object sender, EventArgs e)
        {
           load_UC(new UC_Services());
        }

        private void Acc_Btn_Click(object sender, EventArgs e)
        {
            load_UC(new UC_Account());
        }

        private void About_Btn_Click(object sender, EventArgs e)
        {
            load_UC(new UC_About());
        }

        private void load_UC(UserControl uc)
        {
            // Check if the clicked button corresponds to the currently loaded user control
            if (currentUC != null && currentUC.GetType() == uc.GetType())
            {
                return; // Do nothing if the same user control is already loaded
            }

            // Clear existing control
            panelContainer.Controls.Clear();

            // Add new user control
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            uc.BringToFront();

            // Update currentUC reference
            currentUC = uc;
        }

        private void adminLogout_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // If the user confirms the logout
                // Show a message box indicating successful logout
                MessageBox.Show("Logged out successfully.", "Log Out", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Show the login form
                LogInFrm loginForm = new LogInFrm();
                loginForm.Show();

                // Close the current dashboard form
                this.Close();
            }
            // If the user selects No, do nothing (keep the dashboard open)
        }
    }
}
