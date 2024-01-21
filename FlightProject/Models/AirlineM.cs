using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Models;

public partial class AirlineM
{
    public int AirlineId { get; set; }
    [Display(Name ="Airline Name")]
    public string? AirlineName { get; set; }

    public virtual ICollection<FlightsDetailM> FlightsDetailMs { get; set; } = new List<FlightsDetailM>();
}
