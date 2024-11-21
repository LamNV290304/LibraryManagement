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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for AddAuthor.xaml
    /// </summary>
    public partial class ManageAuthor : Page
    {
        private Author _currentAuthor;
        private readonly LibraryContext _context;
        public ManageAuthor()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadAuthor();
        }

        private void LoadAuthor()
        {
            var authors = _context.Authors.ToList();
            AuthorDataGrid.ItemsSource = authors;
        }

        private void LoansDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var author = AuthorDataGrid.SelectedItem as Author;
            if (author != null)
            {
                _currentAuthor = author;
                AuthorNameTextBox.Text = author.Name;
                string birthdateString = author.Birthdate.ToString();
                DateTime birthDateTime = DateTime.Parse(birthdateString);
                AuthorBirthdatePicker.SelectedDate = birthDateTime;
                AuthorNationalityTextBox.Text = author.Nationality;
                AddButton.Content = "Update Author";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = AuthorNameTextBox.Text;
            var birthdate = AuthorBirthdatePicker.SelectedDate;
            string nationality = AuthorNationalityTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || birthdate == null || string.IsNullOrWhiteSpace(nationality))
            {
                MessageBox.Show("Điền tất cả các trường", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateOnly birthDateOnly = DateOnly.FromDateTime(birthdate.Value);

            if (_currentAuthor == null)
            {
                var newAuthor = new Author
                {
                    Name = name,
                    Birthdate = birthDateOnly,
                    Nationality = nationality
                };

                _context.Authors.Add(newAuthor);
                _context.SaveChanges();

                MessageBox.Show("Tác giả được cập nhập thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                AuthorNameTextBox.Text = null;
                AuthorBirthdatePicker.SelectedDate = null;
                AuthorNationalityTextBox.Text = null;
            }
            else
            {
                _currentAuthor.Name = name;
                _currentAuthor.Birthdate = birthDateOnly;
                _currentAuthor.Nationality = nationality;

                _context.Authors.Update(_currentAuthor);
                _context.SaveChanges();

                
                MessageBox.Show("Thông tin tác giả đã được cập nhật!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                AddButton.Content = "Add Author";
            }

            LoadAuthor();
            _currentAuthor = null;
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadAuthor();
            }
            else
            {
                var searchResults = _context.Authors
                    .Where(a => a.Name.ToLower().Contains(searchTerm))
                    .ToList();
                AuthorDataGrid.ItemsSource = searchResults;
            }
        }
    }
}
