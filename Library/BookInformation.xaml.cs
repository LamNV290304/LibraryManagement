using Library.Dto;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library
{
    public partial class BookInformation : Page
    {
        private readonly LibraryContext _context;
        private User? _loggedInUser;

        public BookInformation(BookViewModel selectionBook, User loggined)
        {
            InitializeComponent();
            _loggedInUser = loggined;
            _context = new LibraryContext();
            BookSelection(selectionBook.Title);
        }

        private void BookSelection(string selectionBookTitle)
        {
            var book = _context.Books
        .Include(b => b.Publisher)
        .Include(b => b.Category)
        .Include(b => b.Author)
        .FirstOrDefault(b => b.Title.ToLower() == selectionBookTitle.ToLower());
            if (book == null)
            {
                // Handle the case where the book is not found
                MessageBox.Show("Book not found.");
                return;
            }

            txtTitle.Text = book.Title ?? "N/A";
            txtPublisher.Text = book.Publisher?.Name;
            txtAuthor.Text = book.Author?.Name;
            txtPublicationYear.Text = book.PublicationYear.ToString() ?? "N/A";
            txtCategory.Text = book.Category?.Name;
            txtTotalCopies.Text = book.TotalCopies.ToString();
            txtAvailableCopies.Text = book.AvailableCopies.ToString();
            txtPrice.Text = book.Price.ToString();

            if (book.AvailableCopies == 0)
            {
                btnNotifyOutOfStock.Visibility = Visibility.Visible;
            }
            else
            {
                btnNotifyOutOfStock.Visibility = Visibility.Collapsed;
            }
        }

        private void btnNotifyOutOfStock_Click(object sender, RoutedEventArgs e)
        {
            var bookTitle = txtTitle.Text;
            var book = _context.Books.FirstOrDefault(b => b.Title.ToLower() == bookTitle.ToLower());

            if (book == null)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            int userId = _loggedInUser.UserId;
            var reservation = new Reservation
            {
                BookId = book.BookId,
                UserId = userId,
                ReservationDate = DateOnly.FromDateTime(DateTime.Now),
                Status = "Processing",
            };

            // Add reservation to context and save
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            MessageBox.Show("Đặt trước thành công!");
            NavigationService.GoBack();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
