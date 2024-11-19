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
    public partial class ViewAlbums : Form
    {
        public ViewAlbums()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True";
        private int aI;
        private string aN;

        private void ViewAlbums_Load(object sender, EventArgs e)
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
                string albumName = selectedRow.Cells["albumName"].Value.ToString();
                string albumId = selectedRow.Cells["albumId"].Value.ToString();
                if (albumId != "" && albumName != "")
                {
                    aI = Convert.ToInt32(albumId);
                    aN = albumName;
                }
                
                
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


        private void selectButton_Click(object sender, EventArgs e)
        {
            
            this.Close();

            addUpdateMusic aum = new addUpdateMusic(aN, aI);

            aum.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ProducerDashboard pd = new ProducerDashboard();
            pd.Show();
        }
    }
}
