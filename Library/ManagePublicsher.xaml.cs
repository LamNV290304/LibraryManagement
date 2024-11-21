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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for ManagePublicsher.xaml
    /// </summary>
    public partial class ManagePublicsher : Page
    {
        private Publisher _currentPublisher;
        private readonly LibraryContext _context;
        public ManagePublicsher()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadPublicsher();
        }

        private void LoadPublicsher()
        {
            var publishers = _context.Publishers.ToList();
            PublicsherDataGrid.ItemsSource = publishers;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string address = AddressTextBox.Text;
            string contact = ContactTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Điền tất cả các trường", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_currentPublisher == null)
            {
                var newPublisher = new Publisher
                {
                    Name = name,
                    Address = address,
                    Contact = contact
                };

                _context.Publishers.Add(newPublisher);
                _context.SaveChanges();

                MessageBox.Show("Tác giả được nhập thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                NameTextBox.Text = null;
                AddressTextBox.Text = null;
                ContactTextBox.Text = null;
            }
            else
            {
                _currentPublisher.Name = name;
                _currentPublisher.Address = address;
                _currentPublisher.Contact = contact;

                _context.Publishers.Update(_currentPublisher);
                _context.SaveChanges();


                MessageBox.Show("Thông tin tác giả đã được cập nhật!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                AddButton.Content = "Add Author";
            }

            LoadPublicsher();
            _currentPublisher = null;

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadPublicsher();
            }
            else
            {
                var searchResults = _context.Publishers
                    .Where(a => a.Name.ToLower().Contains(searchTerm))
                    .ToList();
                PublicsherDataGrid.ItemsSource = searchResults;
            }
        }

        private void PublicsherDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var publisher = PublicsherDataGrid.SelectedItem as Publisher;
            if (publisher != null)
            {
                _currentPublisher = publisher;
                NameTextBox.Text = publisher.Name;
                AddressTextBox.Text = publisher.Address;
                ContactTextBox.Text = publisher.Contact;
                AddButton.Content = "Update publisher";
            }
        }
    }
}

