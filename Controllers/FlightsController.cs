using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourAirLineFinal.Controllers
{
    public class FlightsController : BaseController
    {
        // GET: Flights
        public ActionResult Index()
        {
            var flights = data.Flights.ToList();
            return View(flights);

        }

        public ActionResult Details(int id)
        {
            var flight = data.Flights.FirstOrDefault(f => f.FlightID == id);
            if (flight == null)
            {
                return HttpNotFound();
            }

            var airline = data.Airlines.FirstOrDefault(a => a.AirlineID == flight.AirlineID);
            if (airline == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirlineName = airline.AirlineName;

            var departureAirport = data.Airports.FirstOrDefault(a => a.AirportID == flight.DepartureAirportID);
            if (departureAirport == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartureAirportName = departureAirport.AirportName;

            var arrivalAirport = data.Airports.FirstOrDefault(a => a.AirportID == flight.ArrivalAirportID);
            if (arrivalAirport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArrivalAirportName = arrivalAirport.AirportName;

            var seats = data.Seats.Where(s => s.FlightID == id && s.IsBooked == false).ToList();
            ViewBag.Seats = seats;

            return View(flight);
        }



    }

}