using Library.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Library
{
    public partial class ManageBook : Page
    {
        private readonly LibraryContext _context;

        public ManageBook()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void CategoryComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = _context.Categories.ToList();
            categories.Insert(0, new Category { CategoryId = 0, Name = "All" });
            CategoryComboBox.ItemsSource = categories;
            CategoryComboBox.SelectedIndex = 0;
        }

        private void AuthorComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var authors = _context.Authors.ToList();
            authors.Insert(0, new Author { AuthorId = 0, Name = "All" });
            AuthorComboBox.ItemsSource = authors;
            AuthorComboBox.SelectedIndex = 0;
        }

        private void YearComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var years = _context.Books.Select(b => b.PublicationYear).Distinct().ToList();
            years.Insert(0, 0); 
            YearComboBox.ItemsSource = years;
            YearComboBox.SelectedIndex = 0;
        }

        private void LoadBooks()
        {
            var books = from b in _context.Books
                        join a in _context.Authors on b.AuthorId equals a.AuthorId
                        join c in _context.Categories on b.CategoryId equals c.CategoryId
                        join p in _context.Publishers on b.PublisherId equals p.PublisherId
                        select new
                        {
                            b.BookId,
                            b.Title,
                            b.Isbn,
                            Publisher = p.Name,
                            b.TotalCopies,
                            b.AvailableCopies,
                            b.Price,
                            AuthorName = a.Name,
                            CategoryName = c.Name,
                            b.PublicationYear
                        };

            BooksDataGrid.ItemsSource = books.ToList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterBooks();
        }

        private void Filter_Changed(object sender, SelectionChangedEventArgs e)
        {
            FilterBooks();
        }

        private void FilterBooks()
        {
            if (_context == null)
            {
               
                return;
            }

            var query = from b in _context.Books
                        join a in _context.Authors on b.AuthorId equals a.AuthorId
                        join c in _context.Categories on b.CategoryId equals c.CategoryId
                        join p in _context.Publishers on b.PublisherId equals p.PublisherId
                        select new
                        {
                            b.BookId,
                            b.Title,
                            b.Isbn,
                            Publisher = p.Name,
                            b.TotalCopies,
                            b.AvailableCopies,
                            b.Price,
                            AuthorName = a.Name,
                            CategoryName = c.Name,
                            b.PublicationYear,
                            b.CategoryId, 
                            b.AuthorId   
                        };

        
            if (!string.IsNullOrEmpty(SearchTextBox.Text) && SearchTextBox.Text != "Search by Title")
            {
                query = query.Where(b => b.Title.Contains(SearchTextBox.Text));
            }

           
            if (CategoryComboBox.SelectedValue != null && (int)CategoryComboBox.SelectedValue != 0)
            {
                var selectedCategoryId = (int)CategoryComboBox.SelectedValue;
                query = query.Where(b => b.CategoryId == selectedCategoryId);
            }

            if (AuthorComboBox.SelectedValue != null && (int)AuthorComboBox.SelectedValue != 0)
            {
                var selectedAuthorId = (int)AuthorComboBox.SelectedValue;
                query = query.Where(b => b.AuthorId == selectedAuthorId);
            }

         
            if (YearComboBox.SelectedItem != null && (int)YearComboBox.SelectedItem != 0)
            {
                var selectedYear = (int)YearComboBox.SelectedItem;
                query = query.Where(b => b.PublicationYear == selectedYear);
            }

         
            BooksDataGrid.ItemsSource = query.ToList();
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Search by Title")
            {
                SearchTextBox.Text = "";
                SearchTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Search by Title";
                SearchTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void BooksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem != null)
            {
                var selectedBook = BooksDataGrid.SelectedItem as dynamic; 
                int bookId = selectedBook.BookId;

               
                var updateBookPage = new UpdateBook(bookId);
                NavigationService.Navigate(updateBookPage);
            }
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
          
            var addBookWindow = new AddBook();

          
            if (addBookWindow.ShowDialog() == true)
            {
              
                LoadBooks();
            }
        }

        private void ManageCategoryButton_Click(object sender, RoutedEventArgs e)
        {
          
            var manageCategoryPage = new ManageCategory();

            
            NavigationService.Navigate(manageCategoryPage);
        }

    }
}
