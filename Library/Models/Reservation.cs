using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public DateOnly ReservationDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Note { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
