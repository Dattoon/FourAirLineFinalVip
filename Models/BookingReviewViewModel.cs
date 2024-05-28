using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourAirLineFinal.Models
{
    public class BookingReviewViewModel
    {
        public Booking Booking { get; set; }
        public Flight Flight { get; set; }
        public User User { get; set; }
        public Seat Seat { get; set; }
        public Ticket Ticket { get; set; }

        public string AirlineName { get; set; }
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }
    }
}
