using Spotify_Clone.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Spotify_Clone
{
    public partial class consumerDashboard : Form
    {
        public consumerDashboard()
        {
            InitializeComponent();
        }
        private int mId;
        private string mName;
        private string mPath;
        private int aI = -1; 
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True";
        private void consumerDashboard_Load(object sender, EventArgs e)
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
            fillGrid();
        }

        private void fillGrid()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT musicId, musicName, likes FROM albumMusicTable";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    // Assign the DataTable as the DataSource for the DataGridView
                    dataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                musicPlayer mp = new musicPlayer(mPath);
                mp.Show();
            }
            else
            {
                MessageBox.Show("select a row to play the song");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string musicId = selectedRow.Cells["musicId"].Value.ToString();
                string musicName = selectedRow.Cells["musicName"].Value.ToString();
                if (musicId != "" && musicName != "")
                {
                    mId = Convert.ToInt32(musicId);
                    mName = musicName;
                    retrieveMusicPath();
                    retrieveAlbumId();
                }
                
            }
        }

        private void retrieveMusicPath()
        {

            try
            {
                             
                string query = "SELECT path FROM albumMusicTable WHERE musicId = @mId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mId", mId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mPath = reader["path"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception according to your needs
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

        private void likeBtn_Click(object sender, EventArgs e)
        {
            IncrementLikeCount();
            fillGrid();
        }

        private void IncrementLikeCount()
        {
            try
            {
             
                string query = "UPDATE albumMusicTable SET likes = likes + 1 WHERE musicId = @mId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mId", mId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Like count incremented successfully.");
                        }
                        else
                        {
                            Console.WriteLine("MusicId not found in the table.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception according to your needs
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void addCommentBtn_Click(object sender, EventArgs e)
        {
            string comment = commentTxtBox.Text;
            if (comment == "" )
            {
                MessageBox.Show("Please write the comment first!");
            }
            else if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a song row to comment on it!");
            }
            else
            {
                int aId = aI;
                addComment(aId, comment);
            }
            

        }

        private void addComment(int aI, string comment)
        {
            try
            {
                string query = "INSERT INTO commentsTable (musicId, albumId, comment) VALUES (@mId, @aI, @comment)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mId", mId);
                        command.Parameters.AddWithValue("@aI", aI);
                        command.Parameters.AddWithValue("@comment", comment);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Comment added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add comment.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception according to your needs
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private int retrieveAlbumId()
        {
            

            try
            {
                string query = "SELECT albumId FROM albumMusicTable WHERE musicId = @mId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mId", mId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                aI = Convert.ToInt32(reader["albumId"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception according to your needs
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return aI;
        }

        private void addToPlaylistbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a song row to add it to playlist!");
            }
            else
            {
                this.Close();
                viewPlaylists vP = new viewPlaylists(mId, aI);
                vP.Show();
            }
            
        }

        private void viewPlaylistBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            viewPlaylists vp = new viewPlaylists(-1, -1);
            vp.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {

            this.Close();
            LogIn lg = new LogIn();
            lg.Show();
        }

        private void createPlaylistBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            createPlaylist cp = new createPlaylist();
            cp.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
