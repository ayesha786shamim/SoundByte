using Spotify_Clone.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Spotify_Clone
{

    public partial class LogIn : Form
    {
        //public static LogIn Instance = new LogIn();
        //public TextBox userIdentity;
        public LogIn()
        {
            InitializeComponent();
            //Instance = this;
            //userIdentity = userIdTextBox;
        }
        private const string connectionString = "Data Source=Ayeshazeem31;Initial Catalog=SoundByte;Integrated Security=True";
        private void LogIn_Load(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Hide();

            // Create an instance of the next form
            SignUp sgnUp = new SignUp();

            // Show the next form
            sgnUp.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string userId = userIdTextBox.Text;
            string password = passTextBox.Text;
            string role = roleComboBox.GetItemText(this.roleComboBox.SelectedItem);
           // bool validateCredentials = IsUserIdAndPasswordValid(userId, password, role);
            if (roleComboBox.SelectedItem == null || userIdTextBox.Text == "" || passTextBox.Text == "")
            {
                MessageBox.Show("Please Fill the Fields");

            }
            else if (IsUserIdAndPasswordValid(userId, password, role))
            {
                //Note:
                //Change the switching to the ConsumersDashboard once you create it
                if (role == "Consumer")
                {
                    SharedDataSingleton.Instance.SharedData = userIdTextBox.Text;
                    // Close the current form
                    this.Hide();

                    // Create an instance of the next form
                    consumerDashboard cd = new consumerDashboard();

                    // Show the next form
                    cd.Show();
                }
                else
                {
                    SharedDataSingleton.Instance.SharedData = userIdTextBox.Text;
                    
                    // Close the current form
                    this.Hide();

                    // Create an instance of the next form
                    ProducerDashboard pd = new ProducerDashboard();

                    // Show the next form
                    pd.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid Credentials Entered");
            }
        }

        bool IsUserIdAndPasswordValid(string userId, string password, string userRole)
        {
            bool isValid = false;
            string query = "SELECT COUNT(*) FROM accountsTable WHERE userId = @userId AND pass = @password AND role = @userRole";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@userRole", userRole);

                    int count = (int)command.ExecuteScalar();

                    isValid = (count > 0);
                }

                connection.Close();
            }

            return isValid;
        }

    }
}
