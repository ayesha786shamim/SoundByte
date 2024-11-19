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
    public partial class viewPlaylists : Form
    {
        private int aId, mId;
        public viewPlaylists(int musicId, int albumId)
        {
            InitializeComponent();
            mId = musicId;
            aId = albumId;
        }
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True";
        private int pId;
        private string pName;
        private void viewPlaylists_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string playlistId = selectedRow.Cells["playlistId"].Value.ToString();
                string playlistName = selectedRow.Cells["name"].Value.ToString();

                if (playlistId != "" && playlistName != "")
                {
                    pId = Convert.ToInt32(playlistId);
                    pName = playlistName;
                }
                
  
            }
        }

        private void fillGrid()
        {
            string uID = SharedDataSingleton.Instance.SharedData;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT playlistId, name FROM playlistTable WHERE userId = @userId";

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

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();

            consumerDashboard cd = new consumerDashboard();
            cd.Show();
        }

        //The buttn below is the select button
        private void button1_Click(object sender, EventArgs e)
        {
            if (aId != -1 && mId != -1 && dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    string query = "INSERT INTO playlistMusicTable (playlistId, musicId, albumId) VALUES (@pId, @mId, @aId)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@pId", pId);
                            command.Parameters.AddWithValue("@mId", mId);
                            command.Parameters.AddWithValue("@aId", aId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("song inserted successfully into playlistMusicTable.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to insert song into playlistMusicTable.");
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
            else
            {
                MessageBox.Show("This button is only used for inseting music to a playlist.");
            }
        }
    }
}
