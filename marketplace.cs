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
    public partial class marketplace : Form
    {
        public marketplace()
        {
            InitializeComponent();

            this.Width = 408;
            this.Height = 891;

            // Set form border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.SCHOOL_SUPPLIES_MAIN;

            SSpanel.BackColor = Color.Transparent;

            // Initialize buttons
            InitializeButtons();

        }

        private void InitializeButtons()
        {
            // Create SignIn button
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(16, 765), logo_Click);
            CreateImageButton(Properties.Resources.pencil, Properties.Resources.pencil_, new Point(90, 765), pencil_Click);
            CreateImageButton(Properties.Resources.basketball, Properties.Resources.basketball_, new Point(160, 765), basketball_Click);
            CreateImageButton(Properties.Resources.paper, Properties.Resources.paper_, new Point(240, 765), paper_Click);
            CreateImageButton(Properties.Resources.account, Properties.Resources.account_, new Point(315, 765), account_Click);
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(5, 40), tabLogo_Click);
            CreateImageButton(Properties.Resources.addtocart, Properties.Resources.addtocart_, new Point(320, 130), cart_Click);
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
            button.BringToFront(); 
        }
        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void pencil_Click(object sender, EventArgs e)
        {

        }

        private void basketball_Click(object sender, EventArgs e)
        {

        }

        private void paper_Click(object sender, EventArgs e)
        {

        }

        private void account_Click(object sender, EventArgs e)
        {

        }
        private void tabLogo_Click(object sender, EventArgs e)
        {

        }
        private void cart_Click(object sender, EventArgs e)
        {

        }
        private bool isClicked = false;

        private void pen_Click(object sender, EventArgs e)
        {
            // Change the image to the clicked state
            pen.Image = Properties.Resources.pen_;

            // Start a Windows Forms timer to revert back to the original state after a delay
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // Adjust the delay time (in milliseconds) as needed
            timer.Tick += (s, args) =>
            {
                // Revert back to the original state
                pen.Image = Properties.Resources.pen;

                // Stop and dispose the timer
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

        }

        private void eraser_Click(object sender, EventArgs e)
        {
            // Change the image to the clicked state
            eraser.Image = Properties.Resources.eraser_;

            // Start a Windows Forms timer to revert back to the original state after a delay
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // Adjust the delay time (in milliseconds) as needed
            timer.Tick += (s, args) =>
            {
                // Revert back to the original state
                eraser.Image = Properties.Resources.eraser;

                // Stop and dispose the timer
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void quantityCounter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addcart_Click(object sender, EventArgs e)
        {
            // Change the image to the clicked state
            addcart.Image = Properties.Resources.addcart_;

            // Start a Windows Forms timer to revert back to the original state after a delay
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // Adjust the delay time (in milliseconds) as needed
            timer.Tick += (s, args) =>
            {
                // Revert back to the original state
                addcart.Image = Properties.Resources.addcart;

                // Stop and dispose the timer
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

        }

        private void getnow_Click(object sender, EventArgs e)
        {
            // Change the image to the clicked state
            getnow.Image = Properties.Resources.getnow_;

            // Start a Windows Forms timer to revert back to the original state after a delay
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; // Adjust the delay time (in milliseconds) as needed
            timer.Tick += (s, args) =>
            {
                // Revert back to the original state
                getnow.Image = Properties.Resources.getnow;

                // Stop and dispose the timer
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
