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
using MySql.Data.MySqlClient;

namespace AdminPage
{
    public partial class DashboardUI : Form
    {
        public DashboardUI()
        {
            InitializeComponent();
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void DashboardUI_Load(object sender, EventArgs e)
        {

        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();

        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void TransactBtn_Click_1(object sender, EventArgs e)
        {
            UC_Transaction uc = new UC_Transaction();
            addUserControl(uc);
        }

        private void ServicesBtn_Click_1(object sender, EventArgs e)
        {
            UC_Services uc = new UC_Services();
            addUserControl(uc);
        }

        private void AccBtn_Click(object sender, EventArgs e)
        {
            UC_Account uc = new UC_Account();
            addUserControl(uc);
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            UC_About uc = new UC_About();
            addUserControl(uc);
        }
    }
}
