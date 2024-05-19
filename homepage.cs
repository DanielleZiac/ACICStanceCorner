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
        private string[] imageNames = { "pencilpage", "borrowingpage", "paperpage" };
        private int currentIndex = 0;
        public HomePage()
        {
            InitializeComponent();
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.homepage;
            SetPictureBoxImage();
            InitializeButtons();
        }
        private void InitializeButtons()
        {
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
            this.Close();
            HomePage home = new HomePage();
            home.Show();
        }
        private void pencil_Click(object sender, EventArgs e)
        {
            this.Close();
            marketplace marketPlace = new marketplace();
            marketPlace.Show();
        }
        private void basketball_Click(object sender, EventArgs e)
        {
            this.Close();
            BorrowItems borrow = new BorrowItems();
            borrow.Show();
        }
        private void paper_Click(object sender, EventArgs e)
        {
            this.Close();
            PrintingSerivces print = new PrintingSerivces();
            print.Show();
        }
        private void account_Click(object sender, EventArgs e)
        {
            this.Close();
            Profile profile = new Profile();
            profile.Show();
        }
        private void SetPictureBoxImage()
        {
            if (currentIndex >= 0 && currentIndex < imageNames.Length)
            {
                string imageName = imageNames[currentIndex];
                imagechanger.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            }
        }
        private void right_Click(object sender, EventArgs e)
        {
            right.Image = Properties.Resources.next_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                right.Image = Properties.Resources.next;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            currentIndex = (currentIndex + 1) % imageNames.Length;
            SetPictureBoxImage();
        }
        private void left_Click(object sender, EventArgs e)
        {
            left.Image = Properties.Resources.previous_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                left.Image = Properties.Resources.Previous;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            currentIndex = (currentIndex - 1 + imageNames.Length) % imageNames.Length;
            SetPictureBoxImage();
        }
    }
}
