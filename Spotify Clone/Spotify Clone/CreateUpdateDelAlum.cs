using Spotify_Clone.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Clone
{
    public partial class CreateUpdateDelAlum : Form
    {

        public CreateUpdateDelAlum()
        {
            InitializeComponent();
            string sharedData = SharedDataSingleton.Instance.SharedData;

        }
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True";
        private List<string> selectedFilePaths = new List<string>();
        private List<string> musicNames = new List<string>();

        private int aI;
        

        private void CreateUpdateDelAlum_Load(object sender, EventArgs e)
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

        private void browseButton_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to display only MP3 files
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3";

            // Allow selecting multiple files
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Retrieve the selected file paths
                string[] filePaths = openFileDialog.FileNames;
             
                string[] fileNames = openFileDialog.FileNames;
                                
                foreach (string fileName in fileNames)
                {
                    string fileNameOnly = Path.GetFileName(fileName);
                    if (fileNameOnly.Count()>50)
                    {
                        fileNameOnly = fileNameOnly.Substring(0, 50);
                    }
                    
                    musicNames.Add(fileNameOnly);
                }
                // Process the selected files
                foreach (string filePath in filePaths)
                {
                    // Your code to handle each selected MP3 file
                    // e.g., play the MP3, read its metadata, etc.
                  
                    selectedFilePaths.Add(filePath);
                    songsListBox.Items.Add(filePath);   
                    
                }

            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string albumName = selectedRow.Cells["albumName"].Value.ToString();
                string albumId = selectedRow.Cells["albumId"].Value.ToString();
                if (albumId != "" && albumName != "")
                {
                    albumNametxt.Text = albumName;
                    aI = Convert.ToInt32(albumId);
                   
                }
                
                
            }
        }
     

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //string uIDf = LogIn.Instance.userIdentity.Text;
            string uID = SharedDataSingleton.Instance.SharedData;
                       
            string aName = albumNametxt.Text;

            if (albumNametxt.Text == "" || selectedFilePaths == null)
            {
                MessageBox.Show("Please fill the fields!");
            }
            else if (IsAlbumNameExists(aName))
            {
                MessageBox.Show("The album Name already exists. Select a new one!");
            }
            else
            {
                insertDataToAlbumTable(uID,aName);
                insertMusicToMusicTable();
                fillGrid();
                selectedFilePaths.Clear();
                musicNames.Clear(); 
                songsListBox.Items.Clear();
                albumNametxt.Clear();
            }
        }

        private bool IsAlbumNameExists(string albumName)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM albumTable WHERE albumName = @albumName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@albumName", albumName);
                    int count = (int)command.ExecuteScalar();

                    exists = (count > 0);
                }

                connection.Close();
            }

            return exists;
        }

        private void insertDataToAlbumTable(string uID, string aName)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO albumTable (albumName, userId) VALUES (@albumName, @userId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@albumName", aName);
                        command.Parameters.AddWithValue("@userId", uID);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Album Created Successfully");
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while inserting data into albumTable: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void insertMusicToMusicTable()
        {
              

            int lk = 0; 
            int aID = retrieveInsertedAlbumId(albumNametxt.Text); 
            if (aID ==-1)
            {
                MessageBox.Show("Album Not Found");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO albumMusicTable (musicName, path, likes, albumId) VALUES (@musicName, @path, @likes, @albumId)";

                        for (int i = 0; i < selectedFilePaths.Count; i++)
                        {
                            string filePath = selectedFilePaths[i];
                            string musicName = (i < musicNames.Count) ? musicNames[i] : string.Empty;

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@musicName", musicName);
                                command.Parameters.AddWithValue("@path", filePath);
                                command.Parameters.AddWithValue("@likes", lk);
                                command.Parameters.AddWithValue("@albumId", aID);

                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Music files stored Successfully.");

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
            

        }

        private int retrieveInsertedAlbumId(string albumName)
        {
            
            int albumID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT albumId FROM albumTable WHERE albumName = @albumName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@albumName", albumName);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        albumID = Convert.ToInt32(result);
                    }
                }

                connection.Close();
            }

            if (albumID != -1)
            {
                return albumID;
            }
            else
            {
                MessageBox.Show("Album not found in albumTable.");
                return -1;
            }

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (IsAlbumNameExists(albumNametxt.Text))
            {
                MessageBox.Show("Album Name already exist. Try new one!");
            }
            else
            {
                updateAlbumName();
                if (selectedFilePaths.Count != 0)
                {
                    insertMusicToMusicTable();
                }
                fillGrid();
                selectedFilePaths.Clear();
                musicNames.Clear();
                songsListBox.Items.Clear();
                albumNametxt.Clear();

            }
            
        }

        private void fillGrid()
        {
            string uID = SharedDataSingleton.Instance.SharedData;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT albumId, albumName FROM albumTable WHERE userId = @userId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", uID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    // Assign the DataTable as the DataSource for the DataGridView
                    dataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }


        private void updateAlbumName()
        {

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "UPDATE albumTable SET albumName = @AlbumName WHERE albumId = @AlbumId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@AlbumName", albumNametxt.Text);
                            command.Parameters.AddWithValue("@AlbumId", aI);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Album name updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Album ID not found or no changes made.");
                            }
                        }

                        connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while updating the album name: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            

        }

        private void delBtn_Click(object sender, EventArgs e)
        {
           
            delFromCommentsTable();
            delFromPlaylistMusicTable();    
            delFromAlbumMusicTable();
            delFromAlbumTable();
            fillGrid();
        }
        private void delFromAlbumTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM albumTable WHERE albumId = @albumId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@albumId", aI);

                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show(rowsAffected + " row(s) deleted from album table");
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
        private void delFromAlbumMusicTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM albumMusicTable WHERE albumId = @albumId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@albumId", aI);

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
        private void delFromPlaylistMusicTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM playlistMusicTable WHERE albumId = @albumId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@albumId", aI);

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
        private void delFromCommentsTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM commentsTable WHERE albumId = @AlbumId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AlbumId", aI);

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

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            ProducerDashboard pd = new ProducerDashboard();
            pd.Show();
        }
    }
}
