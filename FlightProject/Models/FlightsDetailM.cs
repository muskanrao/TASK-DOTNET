using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Models;

public partial class FlightsDetailM
{
    public int FlightId { get; set; }
    [Display(Name ="Airlines")]
    public int? AirlineId { get; set; }
    [Display(Name ="From")]
    public int? SourceAirportId { get; set; }
    [Display(Name="To")]
    public int? DestAirportId { get; set; }
    [Display(Name ="Departure Date")]
    public DateOnly? FlightDate { get; set; }
    [Display(Name ="Departure Time")]
    public DateTime? Atime { get; set; }
    [Display(Name ="Arrival Time")]
    public DateTime? Dtime { get; set; }
    [Display(Name ="Total Fare")]
    public decimal Price { get; set; }

    public virtual AirlineM? Airline { get; set; }

    public virtual ICollection<BookingsDetailM> BookingsDetailMs { get; set; } = new List<BookingsDetailM>();

    public virtual AirportM? DestAirport { get; set; }

    public virtual AirportM? SourceAirport { get; set; }
}
