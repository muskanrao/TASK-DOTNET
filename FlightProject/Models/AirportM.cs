using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Models;

public partial class AirportM
{
    public int AirportId { get; set; }
    [Display(Name ="Airport Name")]
    public string? AirportName { get; set; }

    public virtual ICollection<FlightsDetailM> FlightsDetailMDestAirports { get; set; } = new List<FlightsDetailM>();

    public virtual ICollection<FlightsDetailM> FlightsDetailMSourceAirports { get; set; } = new List<FlightsDetailM>();
}
