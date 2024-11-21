using Library.Dto;
using Library.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Interaction logic for SearchBook.xaml
    /// </summary>
    public partial class SearchBook : Page
    {
        private readonly LibraryContext _context;
        private User? _loggedInUser;
        public SearchBook(User loggedInUser)
        {
            InitializeComponent();
            _context = new LibraryContext();
            _loggedInUser = loggedInUser;
            LoadCategories();
            LoadData();
        }

        private void LoadData()
        {
            var books = _context.Books
        .Select(b => new BookViewModel
        {
            CategoryName = b.Category.Name,  
            Title = b.Title,
            AuthorName = b.Author.Name     
        })
        .ToList();

            dgResults.ItemsSource = books;
        }

        private void LoadCategories()
        {
            cbCategory.Items.Clear();
            var categories = _context.Categories.ToList();
            categories.Insert(0, new Category { CategoryId = 0, Name = "Tất cả các thể loại" });

            cbCategory.ItemsSource = categories;
            cbCategory.SelectedIndex = 0; // Tùy chọn mặc định là "Tất cả các thể loại"
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = cbCategory.SelectedItem as Category;
            var keyWord = txtSearch.Text;

            if (selectedCategory != null)
            {
                List<BookViewModel> books;

                if (selectedCategory.CategoryId == 0)
                {
                    // Nếu chọn "Tất cả thể loại", hiển thị tất cả sách
                    books = _context.Books
                        .Select(b => new BookViewModel
                        {
                            CategoryName = b.Category.Name,
                            Title = b.Title,
                            AuthorName = b.Author.Name
                        })
                        .ToList();
                }
                else
                {
                    // Chỉ hiển thị sách thuộc thể loại được chọn
                    books = _context.Books
                        .Where(b => b.CategoryId == selectedCategory.CategoryId)
                        .Select(b => new BookViewModel
                        {
                            CategoryName = b.Category.Name,
                            Title = b.Title,
                            AuthorName = b.Author.Name
                        })
                        .ToList();
                }

                // Áp dụng tìm kiếm nếu có từ khóa
                if (!string.IsNullOrEmpty(keyWord))
                {
                    books = books
                        .Where(b => b.Title.Contains(keyWord, StringComparison.CurrentCultureIgnoreCase))
                        .ToList();
                }

                // Gán danh sách kết quả cho dgResults
                dgResults.ItemsSource = books;
            }

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = cbCategory.SelectedItem as Category;
            var keyWord = txtSearch.Text;

            if (selectedCategory != null)
            {
                List<BookViewModel> books;

                if (selectedCategory.CategoryId == 0)
                {
                    // Nếu chọn "Tất cả thể loại", hiển thị tất cả sách
                    books = _context.Books
                        .Select(b => new BookViewModel
                        {
                            CategoryName = b.Category.Name,  // Giả sử b.Category là navigation property
                            Title = b.Title,
                            AuthorName = b.Author.Name       // Giả sử b.Author là navigation property
                        })
                        .ToList();
                }
                else
                {
                    // Chỉ hiển thị sách thuộc thể loại được chọn
                    books = _context.Books
                        .Where(b => b.CategoryId == selectedCategory.CategoryId)
                        .Select(b => new BookViewModel
                        {
                            CategoryName = b.Category.Name,
                            Title = b.Title,
                            AuthorName = b.Author.Name
                        })
                        .ToList();
                }

                // Áp dụng tìm kiếm theo từ khóa nếu có
                if (!string.IsNullOrEmpty(keyWord))
                {
                    books = books
                        .Where(b => b.Title.Contains(keyWord, StringComparison.CurrentCultureIgnoreCase))
                        .ToList();
                    if (books.Count <= 0)
                    {
                        MessageBox.Show("Không có cuốn sách nào được tìm kiếm");
                    }
                }

                // Gán danh sách kết quả cho DataGrid
                dgResults.ItemsSource = books;
            }
        }

        private void dgResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBook = dgResults.SelectedItem as BookViewModel;

            if (selectedBook != null)
            {
                // Mở cửa sổ hoặc trang mới để hiển thị chi tiết sách
                NavigationService.Navigate(new BookInformation(selectedBook, _loggedInUser));
            }
        }
    }
}
