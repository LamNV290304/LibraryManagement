using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library
{
    public partial class UpdateBook : Page
    {
        private readonly LibraryContext _context;
        private int _bookId;

        public UpdateBook(int bookId)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _bookId = bookId;
            LoadComboBoxData();
            LoadBookDetails();
        }

        private void LoadComboBoxData()
        {
            cbGenre.ItemsSource = _context.Categories.ToList();
            cbGenre.DisplayMemberPath = "Name";
            cbGenre.SelectedValuePath = "CategoryId";

            cbPublisher.ItemsSource = _context.Publishers.ToList();
            cbPublisher.DisplayMemberPath = "Name";
            cbPublisher.SelectedValuePath = "PublisherId";
        }

        private void LoadBookDetails()
        {
            var book = _context.Books

                               .Where(b => b.BookId == _bookId)
                               .Include(b => b.Author)
                               .FirstOrDefault();

            if (book != null)
            {
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author?.Name ?? "N/A";
                cbGenre.SelectedValue = book.CategoryId;
                cbPublisher.SelectedValue = book.PublisherId;
                txtPublicationYear.Text = book.PublicationYear?.ToString() ?? "N/A";
                txtTotalCopies.Text = book.TotalCopies.ToString();
                txtPrice.Text = book.Price?.ToString("F2") ?? "0.00";
            }
            else
            {
                MessageBox.Show("Book not found!");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtPublicationYear.Text, out int publicationYear) || publicationYear > DateTime.Now.Year)
            {
                MessageBox.Show("Publication year must be a valid year and less than or equal to the current year.");
                return;
            }

            if (!int.TryParse(txtTotalCopies.Text, out int totalCopies))
            {
                MessageBox.Show("Total copies must be a valid number.");
                return;
            }

            var book = _context.Books
                               .Where(b => b.BookId == _bookId)
                               .FirstOrDefault();

            if (book != null)
            {
                int availableCopies = book.AvailableCopies;

                if (totalCopies < availableCopies)
                {
                    MessageBox.Show("Total copies must be greater than or equal to available copies.");
                    return;
                }

                book.Title = txtTitle.Text;

                
                if (book.Author != null && !string.IsNullOrEmpty(txtAuthor.Text))
                {
                    book.Author.Name = txtAuthor.Text;
                }

       
                if (book.Category != null && cbGenre.SelectedValue != null)
                {
                    book.CategoryId = (int)cbGenre.SelectedValue;
                }

           
                if (book.Publisher != null && cbPublisher.SelectedValue != null)
                {
                    book.PublisherId = (int)cbPublisher.SelectedValue;
                }

                book.PublicationYear = publicationYear;
                book.TotalCopies = totalCopies;
                book.Price = decimal.Parse(txtPrice.Text);

                _context.SaveChanges();
                MessageBox.Show("Book details updated successfully!");

  
                NavigationService?.Navigate(new ManageBook());
            }
            else
            {
                MessageBox.Show("Book not found!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var book = _context.Books
                               .Where(b => b.BookId == _bookId)
                               .FirstOrDefault();

            if (book != null)
            {
  
                var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _context.Books.Remove(book);
                        _context.SaveChanges();
                        MessageBox.Show("Book deleted successfully!");

            
                        NavigationService?.Navigate(new ManageBook());
                    }
                    catch (DbUpdateException ex)
                    {
      
                        if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 547)
                        {
                            MessageBox.Show("Cannot delete the book because it is referenced by other records.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while deleting the book. Please try again.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Book not found!");
            }
        }


    }
}
