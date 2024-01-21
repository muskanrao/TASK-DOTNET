using FlightProject.Controllers;
using FlightProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Common;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FlightProject
{
    public class FlightController : Controller
    {
        private readonly Ace52024Context db;
        private readonly ISession session;
        
        public FlightController(Ace52024Context _db)
        {
            db = _db;
        }

     
        [HttpGet]
        public IActionResult SearchFlights()
        {
             ViewBag.Username = HttpContext.Session.GetString("uname");
            ViewBag.SourceAirportId = new SelectList(db.AirportMs,"AirportId","AirportName","DefaultSourceAirportId");
            ViewBag.DestAirportId = new SelectList(db.AirportMs,"AirportId","AirportName","DefaultDestAirportId");
   

           return View();
           
        }

        
        [HttpPost]
        public IActionResult SearchFlights(FlightsDetailM model)
        {  
            var flights = db.FlightsDetailMs.Include(x=>x.Airline).Include(x=>x.SourceAirport).Include(x=>x.DestAirport).Where(x => x.SourceAirportId == model.SourceAirportId&& x.DestAirportId == model.DestAirportId && x.FlightDate == model.FlightDate ).ToList();
          
            TempData["SourceAirportId"] = model.SourceAirportId;
            TempData["DestAirportId"] = model.DestAirportId;
            TempData["FightDate"] = model.FlightDate;

            return RedirectToAction("ShowFlightDetails");
           
        }
        [HttpGet]

        public IActionResult ShowFlightDetails()//(List<FlightM> flight)
        {
           
           
            int sid = Convert.ToInt32(TempData["SourceAirportId"]);
            int did =Convert.ToInt32(TempData["DestAirportId"]);
            
            DateOnly fdate = DateOnly.FromDateTime(Convert.ToDateTime(TempData["FightDate"]));
            var flights = db.FlightsDetailMs.Include(x=>x.Airline).Include(x=>x.SourceAirport).Include(x=>x.DestAirport).Where(x => x.SourceAirportId == sid && x.DestAirportId == did && x.FlightDate == fdate ).ToList();
            
            ViewBag.SourceAirportId = sid;
            ViewBag.DestAirportId= did;
            
            return View(flights);
          
        }


        public IActionResult BookFlight(int flightId)
        {
           
            var flights = db.FlightsDetailMs.Include(x=>x.Airline).Include(x=>x.SourceAirport).Include(x=>x.DestAirport).Where(x => x.FlightId ==flightId ).SingleOrDefault();
            int cid = Convert.ToInt32(TempData["Cid"]);
            var custom = db.CustomersMs.Where(x=>x.Cid == cid).SingleOrDefault();
            if(flights == null)
            {
                return View("Sorry stock out , Please check flight's availabilty");
            }
           
           
           
           // var booking = db.BookingsMs.Include(x=>x.Flight).Include(x=>x.CidNavigation);
           var booking = new BookingsDetailM {
                Flight = flights,
                CidNavigation = custom,
                BookingDate = DateOnly.FromDateTime(DateTime.Now)
            };
            TempData["BookingId"] = booking.BookingId;
            db.BookingsDetailMs.Add(booking);
            db.SaveChanges();
            var bookingList = new List<BookingsDetailM> {booking};
            
           // var result = db.BookingsMs.Include(x=>x.Flight).Include(x=>x.CidNavigation).Where(x=>x.FlightId == flightId).SingleOrDefault();
            

            return View(bookingList);
        }
        public IActionResult PaymentGateways()
        {
            return View();
        }

        public IActionResult ShowBookings()
        {
            
            int cid = Convert.ToInt32(TempData["Cid"]);
            var b = db.BookingsDetailMs
            .Include(x=>x.Flight.SourceAirport)
            .Include(x=>x.Flight.DestAirport)
            .Include(x=>x.CidNavigation)
            .Where(x=>x.Cid == cid)
            .ToList();
            return View(b);
        }
      
    }

    
}