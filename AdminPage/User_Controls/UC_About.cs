using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AdminPage.User_Controls
{
    public partial class UC_About : UserControl
    {
        public UC_About()
        {
            InitializeComponent();
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            // Replace the URL below with the GitHub repository URL
            string githubRepoUrl = "https://github.com/DanielleZiac/ACICStanceCorner";

            // Display a message box asking the user to confirm redirection to GitHub
            DialogResult result = MessageBox.Show("You will be directed to GitHub. Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Process.Start(githubRepoUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while opening GitHub repository: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
