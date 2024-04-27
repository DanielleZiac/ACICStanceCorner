using System;
using System.Drawing;
using System.Windows.Forms;

namespace aCICSistanceCorner
{
    public partial class StartingPage : Form
    {

        public StartingPage()
        {
            InitializeComponent();
            this.Width = 408;
            this.Height = 891;

            // Set form border style to prevent resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.bg_start;

            // Set the background image layout to prevent stretching
            this.BackgroundImageLayout = ImageLayout.Center; // Or ImageLayout.Center

            // Initialize buttons
            InitializeButtons();

        }


        private void InitializeButtons()
        {
            // Create SignIn button
            CreateImageButton(Properties.Resources.SignIn, Properties.Resources.SignIn_, new Point(70, 750), SignInButton_Click);

            // Create Create Account button
            CreateImageButton(Properties.Resources.CreateAcc, Properties.Resources.CreateAcc_, new Point(70, 670), CreateAccButton_Click);
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

        private void SignInButton_Click(object sender, MouseEventArgs e)
        {
            // Perform SignIn action
            // Example: Call a method to handle SignIn functionality
            // PerformSignIn();

            // Hide or close the current form (optional)
            this.Hide(); // Hide the current form

            // Show the homepage form
            HomePage homePage = new HomePage();
            homePage.Show();
        }
        private void startingPage(object sender, EventArgs e)
        {

        }
        private void CreateAccButton_Click(object sender, MouseEventArgs e)
        {
            // Perform Create Account action
            // Example: Call a method to handle Create Account functionality
            // PerformCreateAccount();
        }

        //username textbox
        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        //for password
        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartingPage_Load(object sender, EventArgs e)
        {

        }
    }
}
