using Library.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library
{
    /// <summary>
    /// Interaction logic for AddLoan.xaml
    /// </summary>
    public partial class AddLoan : Page
    {
        private LibraryContext context = new LibraryContext();
        private int _userId;

        // Constructor accepts UserId as parameter
        public AddLoan(int userId)
        {
            InitializeComponent();
            _userId = userId;  // Store the UserId passed from the MainWindow

            if (_userId <= 0)
            {
                MessageBox.Show("Invalid user ID. Please log in again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit if UserId is invalid
            }
        }

        // Event handler for the Loan button click
        private void LoanButton_Click(object sender, RoutedEventArgs e)
        {
            var bookIdText = txtBookId.Text.Trim();
            var dueDate = dpPublicationDate.SelectedDate;

            // Validate inputs
            if (string.IsNullOrEmpty(bookIdText) || !dueDate.HasValue)
            {
                MessageBox.Show("Please fill in all fields.", "Input Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate due date
            if (dueDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Due date must be after the current date.", "Input Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Try to parse Book ID from text box
                if (!int.TryParse(bookIdText, out var bookId))
                {
                    MessageBox.Show("Invalid Book ID. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Check if the book exists in the database
                var book = context.Books.FirstOrDefault(b => b.BookId == bookId);

                if (book == null)
                {
                    MessageBox.Show("The book with the specified ID was not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Check if there are available copies
                if (book.AvailableCopies <= 0)
                {
                    MessageBox.Show("The book is out of stock.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Find the user using the _userId (which was passed during construction)
                var user = context.Users.FirstOrDefault(u => u.UserId == _userId);

                if (user == null)
                {
                    MessageBox.Show("The user with the specified ID was not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Create the new loan entry
                var newLoan = new Loan
                {
                    BookId = book.BookId,
                    UserId = user.UserId,
                    LoanDate = DateOnly.FromDateTime(DateTime.Now),
                    DueDate = DateOnly.FromDateTime(dueDate.Value),
                    Fine = 0.00m,  // Default fine
                    OverdueDays = 0,  // Default overdue days
                    StaffId = _userId  // Set StaffId to _userId (the logged-in user)
                };

                // Decrease the available copies
                book.AvailableCopies--;

                // Add the new loan to the database and save changes
                context.Loans.Add(newLoan);
                context.SaveChanges();

                // Provide feedback to the user
                MessageBox.Show("Loan has been successfully created.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear the input fields for the next entry
                txtBookId.Clear();
                dpPublicationDate.SelectedDate = null;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    }
