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
        UC_Home uc_home = new UC_Home();
        UC_Services uc_services = new UC_Services();
        UC_Transaction uc_transaction = new UC_Transaction();
        UC_Account uc_account = new UC_Account();
        UC_About uc_About = new UC_About();
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
           load_UC(uc_services);
        }
        private void Acc_Btn_Click(object sender, EventArgs e)
        {
            load_UC(uc_account);
        }
        private void About_Btn_Click(object sender, EventArgs e)
        {
            load_UC(uc_About);
        }
        private void load_UC(UserControl uc)
        {
            if (currentUC != null && currentUC.GetType() == uc.GetType())
            {
                return; 
            }
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
            currentUC = uc;
        }

        private void adminLogout_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
            
                MessageBox.Show("Logged out successfully.", "Log Out", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LogInFrm loginForm = new LogInFrm();
                loginForm.Show();

                this.Close();
            }
        }
    }
}
