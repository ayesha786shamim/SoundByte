using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Clone
{
    public partial class ProducerDashboard : Form
    {
        public ProducerDashboard()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProducerDashboard_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 800;
            this.Height = 450;
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
        }

        private void createAlbumButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Create an instance of the next form
            CreateUpdateDelAlum cUD = new CreateUpdateDelAlum();

            // Show the next form
            cUD.Show();
        }

        private void viewAlbumButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Create an instance of the next form
            ViewAlbums vA = new ViewAlbums();

            // Show the next form
            vA.Show();
        }

        private void addMusicButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Create an instance of the next form
            ViewAlbums musicAdd = new ViewAlbums();

            // Show the next form
            musicAdd.Show();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Create an instance of the next form
            LogIn lg = new LogIn();

            // Show the next form
            lg.Show();
        }
    }
}
