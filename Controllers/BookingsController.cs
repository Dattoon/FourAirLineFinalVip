using FourAirLineFinal.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FourAirLineFinal.Controllers
{
    public class BookingsController : BaseController
    {
        // GET: Bookings/Review
        public ActionResult Review(int bookingId)
        {
            var booking = data.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
            if (booking == null)
            {
                return HttpNotFound();
            }

            var ticket = data.Tickets.FirstOrDefault(t => t.TicketID == booking.TicketID);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            var flight = data.Flights.FirstOrDefault(f => f.FlightID == ticket.FlightID);
            var user = data.Users.FirstOrDefault(u => u.UserID == booking.UserID);

            // Lấy thông tin về hãng hàng không và sân bay từ các khóa ngoại trong Flight
            var airline = data.Airlines.FirstOrDefault(a => a.AirlineID == flight.AirlineID);
            var departureAirport = data.Airports.FirstOrDefault(a => a.AirportID == flight.DepartureAirportID);
            var arrivalAirport = data.Airports.FirstOrDefault(a => a.AirportID == flight.ArrivalAirportID);

            // Lấy thông tin về ghế từ khóa ngoại trong BookingDetails
            var bookingDetail = data.BookingDetails.FirstOrDefault(bd => bd.BookingID == booking.BookingID);
            var seat = bookingDetail != null ? data.Seats.FirstOrDefault(s => s.SeatID == bookingDetail.SeatID) : null;

            // Tạo một ViewModel để chứa tất cả thông tin cần thiết
            var model = new BookingReviewViewModel
            {
                Booking = booking,
                Flight = flight,
                User = user,
                Ticket = ticket,
                AirlineName = airline?.AirlineName,
                DepartureAirportName = departureAirport?.AirportName,
                ArrivalAirportName = arrivalAirport?.AirportName,
                Seat = seat
            };

            return View(model);
        }



        // GET: Bookings/Confirm
        public ActionResult Confirm(int bookingId)
        {
            var booking = data.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
            if (booking == null)
            {
                return HttpNotFound();
            }

            var ticket = data.Tickets.FirstOrDefault(t => t.TicketID == booking.TicketID);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            var flight = data.Flights.FirstOrDefault(f => f.FlightID == ticket.FlightID);
            var user = data.Users.FirstOrDefault(u => u.UserID == booking.UserID);

            // Tạo một ViewModel để chứa tất cả thông tin cần thiết
            var model = new BookingReviewViewModel
            {
                Booking = booking,
                Flight = flight,
                User = user,
                Ticket = ticket
            };

            return View(model);
        }

        // POST: Bookings/Confirm
        [HttpPost]
        public ActionResult Confirm(BookingReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = data.Bookings.FirstOrDefault(b => b.BookingID == model.Booking.BookingID);
                if (booking != null)
                {
                    // Cập nhật thông tin đặt chỗ eos duoc de lam sao h met roi



                    // Cập nhật thông tin về ghế từ khóa ngoại trong BookingDetails
                    var bookingDetail = data.BookingDetails.FirstOrDefault(bd => bd.BookingID == booking.BookingID);
                    if (bookingDetail != null)
                    {
                        var seat = data.Seats.FirstOrDefault(s => s.SeatID == bookingDetail.SeatID);
                        if (seat != null)
                        {
                            seat.IsBooked = true;
                        }
                    }

                    data.SubmitChanges();
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

    }
}
