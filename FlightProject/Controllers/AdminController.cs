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
    public class AdminController : Controller{
        private readonly  Ace52024Context db; 
        public AdminController(Ace52024Context _db )
        {
            db = _db;
        }

        public IActionResult AddFlightDetails()
        {
            ViewBag.AirlineId = new SelectList(db.AirlineMs,"AirlineId","AirlineName","DefaultSourceAirlineId");
            ViewBag.SourceAirportId = new SelectList(db.AirportMs,"AirportId","AirportName","DefaultSourceAirportId");
            ViewBag.DestAirportId = new SelectList(db.AirportMs,"AirportId","AirportName","DefaultDestAirportId");
            return View();
        }
        [HttpPost]
        public IActionResult AddFlightDetails(FlightsDetailM flight)
        {
            // var flights = db.FlightsDetailMs.Where(x => x.SourceAirportId == model.SourceAirportId&& x.DestAirportId == model.DestAirportId&& x.FlightDate == model.FlightDate ).ToList();
            db.FlightsDetailMs.Add(flight);
            db.SaveChanges();
            return RedirectToAction("GetAllFlights");
        }

        public IActionResult GetAllFlights()
        {
            List<FlightsDetailM> l = new List<FlightsDetailM>();
            foreach(var item in db.FlightsDetailMs)
            {
                l.Add(item);
            }
            l = db.FlightsDetailMs.Include(x=>x.Airline).Include(x=>x.SourceAirport).Include(x=>x.DestAirport).ToList();
            return View(l);
        }


        public IActionResult AddAirlines()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAirlines(AirlineM airline)
        {
            db.AirlineMs.Add(airline);
            db.SaveChanges();
            return RedirectToAction("GetAllFlights");
        }
         public IActionResult AddAirports()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAirports(AirportM airport)
        {
            db.AirportMs.Add(airport);
            db.SaveChanges();
            return RedirectToAction("GetAllFlights");
        }

        //curd - for flights
       
        public ActionResult Edit(int id)
        {
             ViewBag.AirlineId = new SelectList(db.AirlineMs,"AirlineId","AirlineName","DefaultSourceAirlineId");
            ViewBag.SourceAirportId = new SelectList(db.AirportMs,"AirportId","AirportName","DefaultSourceAirportId");
            ViewBag.DestAirportId = new SelectList(db.AirportMs,"AirportId","AirportName","DefaultDestAirportId");
           FlightsDetailM flight = db.FlightsDetailMs.Where(x=>x.FlightId == id).SingleOrDefault();
            return View(flight);
        }

        [HttpPost]
        public ActionResult Edit(FlightsDetailM flight)
        {
            db.FlightsDetailMs.Attach(flight);
            db.Entry(flight).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("GetAllFlights"); 
        }
        public ActionResult Delete(int id)
        {
           FlightsDetailM flight = db.FlightsDetailMs.Where(x=>x.FlightId == id).SingleOrDefault();
            return View(flight);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            FlightsDetailM flight = db.FlightsDetailMs.Where(x=>x.FlightId == id).SingleOrDefault();
           
            db.FlightsDetailMs.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("GetAllFlights");
        }


    }
}