using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private LibraryContext context = new LibraryContext();

        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve input values
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;
            string gender = rbMale.IsChecked.HasValue && rbMale.IsChecked.Value ? "Nam" : "Nữ"; // Adjusted for Gender selection

            // Validate inputs
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Bạn phải nhập tất cả thông tin.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu không khớp.");
                return;
            }

            // Check for existing username or email
            if (context.Users.Any(u => u.Username == username))
            {
                MessageBox.Show("Username đã tồn tại. Hãy chọn username khác.");
                return;
            }

            if (context.Users.Any(u => u.Email == email))
            {
                MessageBox.Show("Email đã tồn tại. Hãy chọn email khác.");
                return;
            }

            // Create and add new user
            User newUser = new User
            {
                Username = username,
                Password = password, // Consider hashing this in production
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address,
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                Role = "User",
                Sex = gender
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            MessageBox.Show("Đăng kí thành công!");

            // Close the registration window
            this.Close();
        }
    }
}
