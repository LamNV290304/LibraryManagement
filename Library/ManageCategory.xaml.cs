using Library.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Library
{
    public partial class ManageCategory : Page
    {
        private readonly LibraryContext _context;
        private Category _selectedCategory;

        public ManageCategory()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadCategories();
        }

        private void LoadCategories()
        {
            CategoriesDataGrid.ItemsSource = _context.Categories.ToList();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var category = new Category
            {
                Name = CategoryNameTextBox.Text,
                Description = CategoryDescriptionTextBox.Text
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            LoadCategories();
            ClearInputs();
        }

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCategory != null)
            {
                _selectedCategory.Name = CategoryNameTextBox.Text;
                _selectedCategory.Description = CategoryDescriptionTextBox.Text;

                _context.SaveChanges();
                LoadCategories();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a category to edit.");
            }
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCategory != null)
            {
                _context.Categories.Remove(_selectedCategory);
                _context.SaveChanges();
                LoadCategories();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a category to delete.");
            }
        }

        private void CategoriesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoriesDataGrid.SelectedItem is Category category)
            {
                _selectedCategory = category;
                CategoryNameTextBox.Text = _selectedCategory.Name;
                CategoryDescriptionTextBox.Text = _selectedCategory.Description;
            }
        }

        private void ClearInputs()
        {
            CategoryNameTextBox.Text = string.Empty;
            CategoryDescriptionTextBox.Text = string.Empty;
            _selectedCategory = null;
        }
    }
}
