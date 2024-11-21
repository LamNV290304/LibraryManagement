using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public decimal? Fine { get; set; }

    public int? OverdueDays { get; set; }

    public int? StaffId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? Staff { get; set; }

    public virtual User? User { get; set; }
}
