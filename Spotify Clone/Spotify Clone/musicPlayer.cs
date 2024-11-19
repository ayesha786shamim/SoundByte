using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Clone
{
    public partial class musicPlayer : Form
    {
        private string path;
        public musicPlayer(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer1.URL = path;
        }

        private void musicPlayer_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 400;
            this.Height = 250;
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
        }
    }
}
