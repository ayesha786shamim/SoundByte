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

namespace Spotify_Clone
{
    public partial class createPlaylist : Form
    {
        public createPlaylist()
        {
            InitializeComponent();
        }
        private int pId;
        private string pName;
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True";
        private void createPlaylist_Load(object sender, EventArgs e)
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
                    pNameTxtBox.Text = playlistName;
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            string uID = SharedDataSingleton.Instance.SharedData;

            string newPname = pNameTxtBox.Text;

            if (pNameTxtBox.Text == "")
            {
                MessageBox.Show("Please fill the field!");
            }
            else if (IsPlaylistNameExists(newPname))
            {
                MessageBox.Show("The playlist Name already exists. Select a new one!");
            }
            else
            {
                insertDataToPlaylistTable(uID, newPname);
                fillGrid();
                
                pNameTxtBox.Clear();
            }
        }
        private bool IsPlaylistNameExists(string newPlaylistName)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM playlistTable WHERE name = @name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", newPlaylistName);
                    int count = (int)command.ExecuteScalar();

                    exists = (count > 0);
                }

                connection.Close();
            }

            return exists;
        }
        private void insertDataToPlaylistTable(string uID, string newPlaylistName)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO playlistTable (name, userId) VALUES (@name, @userId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", newPlaylistName);
                        command.Parameters.AddWithValue("@userId", uID);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Playlist Created Successfully");
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (IsPlaylistNameExists(pNameTxtBox.Text))
            {
                MessageBox.Show("Playlist Name already exist. Try new one!");
            }
            else if (dataGridView1.SelectedRows.Count<=0)
            {
                MessageBox.Show("No Rows exist or selected");
            }
            else
            {
                updatePlaylistName();                
                fillGrid();
                pNameTxtBox.Clear();
            }
        }
        private void updatePlaylistName()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE playlistTable SET name = @name WHERE playlistId = @playlistId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", pNameTxtBox.Text);
                        command.Parameters.AddWithValue("@playlistId", pId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Playlist name updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Playlist ID not found or no changes made.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while updating the playlist name: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }


        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                delFromPlaylistTable();
                fillGrid();
            }
            else
            {
                MessageBox.Show("No Rows exist or selected");
            }

        }
        private void delFromPlaylistTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM playlistTable WHERE playlistId = @playlistId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@playlistId", pId);

                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show(rowsAffected + " row(s) deleted from playlistTable");
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while deleting rows from the paylistTable: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();

            consumerDashboard cd = new consumerDashboard();
            cd.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
