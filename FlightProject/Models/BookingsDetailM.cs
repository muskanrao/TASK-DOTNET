using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Models;

public partial class BookingsDetailM
{
    public int BookingId { get; set; }
    [Display(Name ="Booking Date")]
    public DateOnly? BookingDate { get; set; }
    [Display(Name ="Passenger")]
    public int? Cid { get; set; }
    [Display(Name ="Flight Detail")]
    public int? FlightId { get; set; }

    public virtual CustomersM? CidNavigation { get; set; }

    public virtual FlightsDetailM? Flight { get; set; }
}
