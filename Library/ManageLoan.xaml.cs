using Library.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library
{
    public partial class ManageLoan : Page
    {
        private LibraryContext context = new LibraryContext();
        private int _currentPage = 1;
        private const int ItemsPerPage = 30;
        private User _loggedInUser; // Add this line to define _loggedInUser

        public ManageLoan(User loggedInUser) // Modify constructor to accept loggedInUser
        {
            InitializeComponent();
            _loggedInUser = loggedInUser; // Initialize _loggedInUser
            LoadLoanData();
        }

        private void LoadLoanData()
        {
            var loans = context.Loans
                .Join(context.Books, loan => loan.BookId, book => book.BookId, (loan, book) => new { loan, book })
                .Join(context.Users, temp => temp.loan.UserId, user => user.UserId, (temp, user) => new { temp.loan, temp.book, user })
                .Join(context.Users, temp => temp.loan.StaffId, staff => staff.UserId, (temp, staff) => new { temp.loan, temp.book, temp.user, staff })
                .Select(x => new
                {
                    x.loan.LoanId,
                    BookTitle = x.book.Title,
                    UserName = x.user.Username,
                    x.loan.LoanDate,
                    x.loan.DueDate,
                    x.loan.ReturnDate,
                    x.loan.Fine,
                    x.loan.OverdueDays,
                    StaffName = x.staff != null ? x.staff.Username : "N/A",
                    StaffVisibility = x.staff != null ? "Visible" : "Collapsed"
                }).Skip((_currentPage - 1) * ItemsPerPage).Take(ItemsPerPage).ToList();

            LoansDataGrid.ItemsSource = loans;
        }

        private void LoansDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoansDataGrid.SelectedItem != null)
            {
                var selectedLoan = (dynamic)LoansDataGrid.SelectedItem;

                LoanIdTextBox.Text = selectedLoan.LoanId.ToString();
                BookTitleTextBox.Text = selectedLoan.BookTitle;
                UserNameTextBox.Text = selectedLoan.UserName;
                LoanDateTextBox.Text = selectedLoan.LoanDate.ToString("yyyy-MM-dd");
                DueDateTextBox.Text = selectedLoan.DueDate.ToString("yyyy-MM-dd");
                ReturnDateTextBox.Text = selectedLoan.ReturnDate?.ToString("yyyy-MM-dd") ?? "N/A";
                FineTextBox.Text = selectedLoan.Fine.ToString("C");
                OverdueDaysTextBox.Text = selectedLoan.OverdueDays.ToString();
            }
        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoansDataGrid.SelectedItem != null)
            {
                var result = MessageBox.Show("Are you sure you want to return this book?", "Confirm Return", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var selectedLoan = (dynamic)LoansDataGrid.SelectedItem;
                    int selectedLoanId = selectedLoan.LoanId;

                    var loan = context.Loans.FirstOrDefault(l => l.LoanId == selectedLoanId);
                    if (loan != null)
                    {
                        loan.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
                        loan.OverdueDays = (loan.ReturnDate.Value.DayNumber - loan.DueDate.DayNumber);
                        if (loan.OverdueDays < 0)
                        {
                            loan.OverdueDays = 0;
                        }
                        loan.Fine = loan.OverdueDays * 5000;

                        // Update the available copies of the book
                        var book = context.Books.FirstOrDefault(b => b.BookId == loan.BookId);
                        if (book != null)
                        {
                            if (book.AvailableCopies < book.TotalCopies)
                            {
                                book.AvailableCopies++;
                            }
                        }

                        context.SaveChanges();
                        LoadLoanData();
                    }
                }
            }
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the user is logged in
            if (_loggedInUser != null)
            {
                // Pass the UserId (or the entire User object if needed) to the AddLoan page
                AddLoan addLoanPage = new AddLoan(_loggedInUser.UserId); // Pass UserId
                NavigationService.Navigate(addLoanPage); // Navigate to AddLoan page
            }
            else
            {
                MessageBox.Show("You must be logged in to add a loan.", "Login Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadLoanData();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            LoadLoanData();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
