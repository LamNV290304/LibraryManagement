using System.Windows;
using System.Windows.Navigation;
using Library;
using Library.Models;

namespace Library
{
    public partial class MainWindow : Window
    {

        private bool isLoggedIn = false;
        private User? _loggedInUser;

        public MainWindow()
        {
            InitializeComponent();
            UpdateButtonVisibility();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Owner = this;
            loginWindow.ShowDialog();

            if (loginWindow.DialogResult == true && loginWindow.LoggedInUser != null)
            {
                _loggedInUser = loginWindow.LoggedInUser;
                UpdateButtonVisibility();

                if (_loggedInUser.Role == "User")
                {
                    MainContentFrame.Navigate(new SearchBook(_loggedInUser));
                }
                else
                {
                    btnManageBook.Visibility = Visibility.Visible;
                    btnManageLoan.Visibility = Visibility.Visible;
                    btnManageReservation.Visibility = Visibility.Visible;
                    btnManageUser.Visibility = Visibility.Visible;
                }
            }
        }

        private void UpdateButtonVisibility()
        {
            if (_loggedInUser != null)
            {
                btnLogin.Visibility = Visibility.Collapsed;
                btnRegister.Visibility = Visibility.Collapsed;
                btnLogout.Visibility = Visibility.Visible;
                WelcomeTextBlock.Text = $"Welcome, {_loggedInUser.Username}!";

                if (_loggedInUser.Role.Equals("User"))
                {
                    btnManageBook.Visibility = Visibility.Collapsed;
                    btnManageLoan.Visibility = Visibility.Collapsed;
                    btnManageReservation.Visibility = Visibility.Collapsed;
                    btnManageUser.Visibility = Visibility.Collapsed;
                    btnLoaned.Visibility = Visibility.Visible;
                    btnViewReservation.Visibility = Visibility.Visible;
                    btnUserManageLoan.Visibility = Visibility.Collapsed;
                    btnHomePage.Visibility = Visibility.Visible;
                }
                else
                {
                    btnManageBook.Visibility = Visibility.Visible;
                    btnManageLoan.Visibility = Visibility.Visible;
                    btnManageReservation.Visibility = Visibility.Visible;
                    btnManageUser.Visibility = Visibility.Visible;
                    btnManageAuthor.Visibility = Visibility.Visible;
                    btnManagePublisher.Visibility = Visibility.Visible;
                    btnViewReservation.Visibility = Visibility.Collapsed;
                    btnUserManageLoan.Visibility = Visibility.Collapsed;

                }
            }
            else
            {
                btnLogin.Visibility = Visibility.Visible;
                btnRegister.Visibility = Visibility.Visible;
                btnLogout.Visibility = Visibility.Collapsed;
                WelcomeTextBlock.Text = "Welcome, Guest!";
                MainContentFrame.Content = null;
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
        }




        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            _loggedInUser = null;
            MainContentFrame.Content = null;
            btnManageBook.Visibility = Visibility.Collapsed;
            btnManageLoan.Visibility = Visibility.Collapsed;
            btnManageReservation.Visibility = Visibility.Collapsed;
            btnManageUser.Visibility = Visibility.Collapsed;
            btnLoaned.Visibility = Visibility.Collapsed;
            btnViewReservation.Visibility = Visibility.Collapsed;
            btnUserManageLoan.Visibility = Visibility.Collapsed;
            btnManageAuthor.Visibility = Visibility.Collapsed;
            btnManagePublisher.Visibility = Visibility.Collapsed;
            btnHomePage.Visibility = Visibility.Collapsed;

            UpdateButtonVisibility();
        }

        private void btnManageLoan_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                // Pass the UserId to ManageLoan page
                ManageLoan manageLoanPage = new ManageLoan(_loggedInUser);
                MainContentFrame.Navigate(manageLoanPage);  // Navigate to the ManageLoan page
            }
            else
            {
                MessageBox.Show("You must be logged in to manage loans.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnLoaned_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                // Pass the UserId to ManageLoan page
                BookLoaned manageLoanPage = new BookLoaned(_loggedInUser);
                MainContentFrame.Navigate(manageLoanPage);  // Navigate to the ManageLoan page
            }
            else
            {
                MessageBox.Show("You must be logged in to see loans.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnManageAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                // Pass the UserId to ManageLoan page
                ManageAuthor manageAuthor = new ManageAuthor();
                MainContentFrame.Navigate(manageAuthor);
            }
            else
            {
                MessageBox.Show("You must be logged in to see loans.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnManagePublisher_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                // Pass the UserId to ManageLoan page
                ManagePublicsher managePublicsher = new ManagePublicsher();
                MainContentFrame.Navigate(managePublicsher);
            }
            else
            {
                MessageBox.Show("You must be logged in to see loans.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnUserManageLoan_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {

                var manageLoanPage = new BookLoaned(_loggedInUser);
                MainContentFrame.Navigate(manageLoanPage);
            }
            else
            {
                MessageBox.Show("You must be logged in to view your loans.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnManageBook_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                var manageBookPage = new ManageBook();
                MainContentFrame.Navigate(manageBookPage);

            }
            else
            {
                MessageBox.Show("You must be logged in to manage books.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnManageUser_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                var manageUser = new ManageUser();
                MainContentFrame.Navigate(manageUser);

            }
            else
            {
                MessageBox.Show("You must be logged in to manage user.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnViewReservation_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                var manageReservation = new ViewReservation(_loggedInUser);
                MainContentFrame.Navigate(manageReservation);

            }
            else
            {
                MessageBox.Show("You must be logged in to view your reservation.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnManageReservation_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
                var manageReservation = new ManageReservation();
                MainContentFrame.Navigate(manageReservation);

            }
            else
            {
                MessageBox.Show("You must be logged in to manage reservation.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInUser != null)
            {
 
                MainContentFrame.Navigate(new SearchBook(_loggedInUser));

            }
            else
            {
                MessageBox.Show("You must be logged in to manage reservation.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

