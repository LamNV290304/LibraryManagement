using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Controls;

namespace Library
{
    public partial class ManageReservation : Page
    {
        private readonly LibraryContext _context;

        public ManageReservation()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadReservations();
        }

        private void LoadReservations()
        {
            var reservations = _context.Reservations
                .Include(r => r.Book)
                .Include(r => r.User)
                .Select(r => new
                {
                    r.ReservationId,
                    BookTitle = r.Book.Title,
                    Username = r.User.Username,
                    r.ReservationDate,
                    r.Status,
                    r.Note
                })
                .ToList();

            ReservationsDataGrid.ItemsSource = reservations;
        }
    }
}
