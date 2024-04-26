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
            // If the "Show Password" checkbox is checked
            if (ShowPassLog.Checked)
            {
                // Display the actual text in the PassLogBox
                PassLogBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Mask the text in the PassLogBox
                PassLogBox.UseSystemPasswordChar = true;
            }
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            DashboardUI dashboard = new DashboardUI();
            this.Hide();
            dashboard.Show();
        }
    }
}
