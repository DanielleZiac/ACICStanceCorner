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

        private void button2_Click(object sender, EventArgs e)
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
    }
    
}
