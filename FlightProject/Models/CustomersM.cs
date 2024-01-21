using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightProject.Models;

public partial class CustomersM
{
    public int Cid { get; set; }
    [Display(Name ="Username")]
     [Required(ErrorMessage ="Entering UserName is Mandatory")]
    public string Cname { get; set; } = null!;
    [Display(Name ="Email")]
    [Required(ErrorMessage ="Please Enter an Email")]
    [DataType(DataType.EmailAddress,ErrorMessage ="Please Enter a valid Email Address")]
    public string Cemail { get; set; } = null!;
    [Display(Name ="Password")]
    [Required(ErrorMessage ="Password is Required")]
    public string? Cpassword { get; set; }

    public virtual ICollection<BookingsDetailM> BookingsDetailMs { get; set; } = new List<BookingsDetailM>();
}
