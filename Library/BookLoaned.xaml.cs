using Library.Dto;
using Library.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for BookLoaned.xaml
    /// </summary>
    public partial class BookLoaned : Page
    {
        private readonly LibraryContext _context;
        private User? _loggedInUser;
        public BookLoaned(User loggin)
        {
            InitializeComponent();
            _loggedInUser = loggin;
            _context = new LibraryContext();
            LoadLoanedBooks();
        }

        private void LoadLoanedBooks()
        {
            int userId = _loggedInUser.UserId;

            var loanedBooks = _context.Loans
                                .Include(l => l.Book)
                                .Include(l => l.Book.Author)
                                .Include(l => l.Book.Category)
                                .Where(l => l.User.UserId == userId && l.ReturnDate == null)
                                .Select(l => new LoanedBookModel
                                {
                                    Title = l.Book.Title,
                                    AuthorName = l.Book.Author.Name,
                                    CategoryName = l.Book.Category.Name,
                                    DueDate = l.DueDate
                                }).ToList();

            dgLoanedBooks.ItemsSource = loanedBooks;
        }

        private void dgLoanedBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
