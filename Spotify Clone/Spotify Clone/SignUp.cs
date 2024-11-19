using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Clone
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True"; 


        private void SignUp_Load(object sender, EventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            string Id = userIdTextBox.Text;
            //bool validateExistance = IsUserIdExists(Id);
            if (roleComboBox.SelectedItem == null || nameTextBox.Text == ""|| userIdTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Please Fill the Fields");
  
            }
            else if(IsUserIdExists(Id))
            {
                MessageBox.Show("User Name already exists. Try New One!");
                
            }
            else
            {
                insertSignUpDetails();
            }
        }
        bool IsUserIdExists(string userId)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM accountsTable WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    int count = (int)command.ExecuteScalar();

                    exists = (count > 0);
                }

                connection.Close();
            }

            return exists;
        }

        private void insertSignUpDetails()
        {
            string role = roleComboBox.GetItemText(this.roleComboBox.SelectedItem); 
            string name = nameTextBox.Text;
            string userId = userIdTextBox.Text;
            string password = passwordTextBox.Text;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    
                    string query = "INSERT INTO accountsTable (userId, name, pass, role) " +
                        "VALUES (@userId, @name, @pass, @role)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@pass", password);
                        command.Parameters.AddWithValue("@role", role);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Data stored successfully.");
                    }

                    connection.Close();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            //this.Close();
            this.Close();

            // Create an instance of the next form
            LogIn lgIn = new LogIn();

            // Show the next form
            lgIn.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }
    }
}
