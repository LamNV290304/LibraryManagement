using System.Linq;
using System.Windows.Controls;
using Library.Models;

namespace Library
{
    public partial class ManageUser : Page
    {
        private readonly LibraryContext _context;

        public ManageUser()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadUsers();
        }
        private void LoadUsers(string usernameFilter = "")
        {
            var usersQuery = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(usernameFilter))
            {
                usersQuery = usersQuery.Where(u => u.Username.Equals(usernameFilter));
            }

            dataGridUsers.ItemsSource = usersQuery
                .Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.Phone,
                    u.Address,
                    u.CreatedAt
                })
                .ToList();
        }

        private void txtSearchUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = txtSearchUsername.Text;
            LoadUsers(filter); 
        }
        private void dataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUser = dataGridUsers.SelectedItem;
            if (selectedUser != null)
            {
                int userId = (int)((dynamic)selectedUser).UserId;
                LoadBorrowedBooks(userId);
            }
        }

        private void LoadBorrowedBooks(int userId)
        {
            dataGridBorrowedBooks.ItemsSource = _context.Loans
                .Where(l => l.UserId == userId)
                .Select(l => new
                {
                    Title = l.Book.Title,
                    BorrowDate = l.LoanDate,
                    DueDate = l.DueDate,
                    ReturnDate = l.ReturnDate
                })
                .ToList();
        }
    }
}
