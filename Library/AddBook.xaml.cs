using Library.Models;
using System;
using System.Linq;
using System.Windows;

namespace Library
{
    public partial class AddBook : Window
    {
        private readonly LibraryContext _context;

        public AddBook()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            cbAuthor.ItemsSource = _context.Authors.ToList();
            cbCategory.ItemsSource = _context.Categories.ToList();
            cbPublisher.ItemsSource = _context.Publishers.ToList();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                cbAuthor.SelectedItem == null ||
                cbCategory.SelectedItem == null ||
                cbPublisher.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtPublicationYear.Text) ||
                string.IsNullOrWhiteSpace(txtTotalCopy.Text) ||
                string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            if (!int.TryParse(txtPublicationYear.Text, out int publicationYear) || publicationYear > DateTime.Now.Year)
            {
                MessageBox.Show("Please enter a valid publication year (not later than the current year).", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

       
            if (!int.TryParse(txtTotalCopy.Text, out int totalCopies) || totalCopies < 0)
            {
                MessageBox.Show("Please enter a valid total copies number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

      
            var newBook = new Book
            {
                Title = txtTitle.Text,
                Isbn = txtISBN.Text,
                AuthorId = (int)cbAuthor.SelectedValue,
                CategoryId = (int)cbCategory.SelectedValue,
                PublisherId = (int)cbPublisher.SelectedValue,
                PublicationYear = publicationYear,
                TotalCopies = totalCopies,
                AvailableCopies = totalCopies,
                Price = price
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            MessageBox.Show("Book added successfully!");
            DialogResult = true;
            Close();
        }
    }
}
