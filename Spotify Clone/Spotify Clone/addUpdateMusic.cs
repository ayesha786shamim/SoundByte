using Spotify_Clone.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Spotify_Clone
{
    public partial class addUpdateMusic : Form
    {
        string albumName;
        int albumId;
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True";
        private int mId;
        private string mName;
        private string mPath;
        public addUpdateMusic(string albumName, int albumId)
        {
            InitializeComponent();
            this.albumName = albumName;
            this.albumId = albumId;
        }

        private void addUpdateMusic_Load(object sender, EventArgs e)
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
            albumNameLbl.Text = "[" + albumName + "] Songs List";
            fillGrid();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ViewAlbums vA = new ViewAlbums();
            vA.Show();
        }

        private void fillGrid()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT musicId, musicName, path, likes FROM albumMusicTable WHERE albumId = @albumId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@albumId", albumId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    // Assign the DataTable as the DataSource for the DataGridView
                    dataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string musicId = selectedRow.Cells["musicId"].Value.ToString();
                string musicName = selectedRow.Cells["musicName"].Value.ToString();
                string musicPath = selectedRow.Cells["path"].Value.ToString();

                if (musicId != "" && musicName != "")
                {
                    mId = Convert.ToInt32(musicId);
                    mName = musicName;
                    mPath = musicPath;
                    songNameTextBox.Text = musicName;
                    songPath.Items.Add(mPath);
                }
                
                
       
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to display only MP3 files
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mName = Path.GetFileName(openFileDialog1.FileName);
                mPath = Path.GetFullPath(openFileDialog1.FileName);

                // Trim the file name to 50 characters if it is greater than 50 characters.
                if (mName.Length > 50)
                {
                    mName = mName.Substring(0, 50);
                }

                songNameTextBox.Text=mName;
                songPath.Items.Add(mPath);
                               
            }
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (songNameTextBox.Text == "" || songPath.Items == null)
            {
                MessageBox.Show("Please fill the fields!");
            }
            else if (IsMusicNameExists(songNameTextBox.Text))
            {
                MessageBox.Show("The song name already exists. Select a new one!");
            }
            else
            {
                insertDataToAlbumMusicTable(songNameTextBox.Text, mPath);
                fillGrid();
                
                songPath.Items.Clear();
                songNameTextBox.Clear();
            }
        }

        private bool IsMusicNameExists(string songName)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM albumMusicTable WHERE musicName = @musicName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@musicName", songName);
                    int count = (int)command.ExecuteScalar();

                    exists = (count > 0);
                }

                connection.Close();
            }

            return exists;
        }

        private void insertDataToAlbumMusicTable(string musicName, string musicPath)
        {
            int like = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO albumMusicTable (musicName, path, likes, albumId) VALUES (@musicName, @path, @likes, @albumId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@musicName", musicName);
                        command.Parameters.AddWithValue("@path", musicPath);
                        command.Parameters.AddWithValue("@likes", like);
                        command.Parameters.AddWithValue("@albumId", albumId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Song added Successfully");
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while inserting data into albumMusicTable: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (songNameTextBox.Text == null || songPath.Items == null)
            {
                MessageBox.Show("Fill the Fields please.");
            }
            else
            {
                updateMusicName();
                updateMusicPath();
                fillGrid();

                songPath.Items.Clear();
                songNameTextBox.Clear();
            }
        }
        private void updateMusicName()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE albumMusicTable SET musicName = @musicName WHERE musicId = @musicId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@musicName", songNameTextBox.Text);
                        command.Parameters.AddWithValue("@musicId", mId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Song name updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Song ID not found or no changes made.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while updating the song name: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void updateMusicPath()
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE albumMusicTable SET path = @path WHERE musicId = @musicId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@path", mPath);
                        command.Parameters.AddWithValue("@musicId", mId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Song path updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Song ID not found or no changes made.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while updating the song path: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            delFromCommentsTable();
            delFromPlaylistMusicTable();
            delFromAlbumMusicTable();
            fillGrid();
        }

        private void delFromAlbumMusicTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM albumMusicTable WHERE musicId = @musicId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@musicId", mId);

                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show(rowsAffected + " row(s) deleted from album music table");
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while deleting rows from the albumMusicTable: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void delFromCommentsTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM commentsTable WHERE musicId = @musicId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@musicId", mId);

                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show(rowsAffected + " row(s) deleted from album music's comments table");
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while deleting rows from the commentsTable: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void delFromPlaylistMusicTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM playlistMusicTable WHERE musicId = @musicId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@musicId", mId);

                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show(rowsAffected + " row(s) deleted from playlist music table");
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while deleting rows from the playlistMusicTable: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }
    }
}
