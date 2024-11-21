using Library.Models;
using System;
using System.Linq;
using System.Windows;

namespace Library
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LibraryContext context = new LibraryContext();

        // Property to return the full User object after a successful login
        public User? LoggedInUser { get; private set; } // Changed to nullable

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Validate that the inputs are not null or empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username và mật khẩu không được để trống.");
                return;
            }

            // Validate user against the database
            var user = ValidateUser(username, password);

            if (user != null)
            {
                // Set the LoggedInUser to the User object
                LoggedInUser = user;
                DialogResult = true;  // Indicate successful login
                Close();
            }
            else
            {
                MessageBox.Show("Username hoặc mật khẩu sai.");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Register form as a dialog
            Register registerWindow = new Register();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
        }

        private User? ValidateUser(string username, string password)
        {
            // Replace with actual database check
            return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
