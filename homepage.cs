using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aCICSistanceCorner
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            this.Width = 408;
            this.Height = 891;

            // Set form border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.homepage;

            // Initialize buttons
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            // Create SignIn button
            CreateImageButton(Properties.Resources.getStarted, Properties.Resources.getStarted_, new Point(35,670), getStarted_Click);
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(16, 765), logo_Click);
            CreateImageButton(Properties.Resources.pencil, Properties.Resources.pencil_, new Point(90, 765), pencil_Click);
            CreateImageButton(Properties.Resources.basketball, Properties.Resources.basketball_, new Point(160, 765), basketball_Click);
            CreateImageButton(Properties.Resources.paper, Properties.Resources.paper_, new Point(240, 765), paper_Click);
            CreateImageButton(Properties.Resources.account, Properties.Resources.account_, new Point(315, 765), account_Click);
        }

        private void CreateImageButton(Image originalImage, Image clickedImage, Point location, MouseEventHandler clickEventHandler)
        {
            PictureBox button = new PictureBox();
            button.Image = originalImage;
            button.Size = originalImage.Size;
            button.Location = location;
            button.SizeMode = PictureBoxSizeMode.AutoSize;
            button.MouseDown += (sender, e) => { button.Image = clickedImage; };
            button.MouseUp += (sender, e) => { button.Image = originalImage; clickEventHandler(sender, e); };
            button.BackColor = Color.Transparent;
            this.Controls.Add(button);
        }


        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void pencil_Click(object sender, EventArgs e)
        {
            this.Hide();
            marketplace marketPlace = new marketplace();
            marketPlace.Show();
        }

        private void basketball_Click(object sender, EventArgs e)
        {

        }

        private void paper_Click(object sender, EventArgs e)
        {

        }

        private void account_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current form

            // Show the homepage form
            Profile profile = new Profile();
            profile.Show();
        }

        private void getStarted_Click(object sender, EventArgs e)
        {

        }
    }
}
