using FlightProject.Controllers;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FlightProject
{
    public class LoginController : Controller
    {
        private readonly ISession session;
        public int cid_session;
        private readonly  Ace52024Context db; 
        public LoginController(Ace52024Context _db , IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CustomersM m)
        {
            db.CustomersMs.Add(m);
            db.SaveChanges();
            return RedirectToAction("Login","Login");
        }
        public IActionResult Login()
        {
            return View();
            //it will expect login.cshtml on returning view
        }
        [HttpPost]
        //after we press on login
        public IActionResult Login(CustomersM u)
        {
            var result = (from i in db.CustomersMs where i.Cemail == u.Cemail&& i.Cpassword ==u.Cpassword select i ).SingleOrDefault();
            if(result != null)
            {
                TempData["Cid"] = result.Cid;
                HttpContext.Session.SetString("uname",result.Cname);
                return RedirectToAction("SearchFlights","Flight");
            }else{
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Login");
        }
    }
}
/*public int Cid { get; set; }
    [Display(Name ="Username")]
    public string Cname { get; set; } = null!;
    [Display(Name ="Email")]
    public string Cemail { get; set; } = null!;
    [Display(Name ="Password")]


    [Display(Name ="Booking ID")]
    public int BookingId { get; set; }
    [Display(Name ="Passenger Detail")]
    public int? Cid { get; set; }
    [Display(Name ="Booking Date")]
        public int FlightId { get; set; }
    [Display(Name ="Airline")]
    public int? AirlineId { get; set; }
    [Display(Name ="From")]
    public int? SourceAirportId { get; set; }
    [Display(Name ="To")]
    public int? DestAirportId { get; set; }
    [Display(Name ="Departure Time")]
    public DateTime? Dtime { get; set; }
    [Display(Name ="Arrival Time")]
    public DateTime? Atime { get; set; }
    [Display(Name ="Departure Date")]
    public DateOnly? FlightDate { get; set; }
    
    
    */