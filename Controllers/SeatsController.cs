using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourAirLineFinal.Controllers
{
    public class SeatsController : BaseController
    {
        // GET: Seats
        public ActionResult Index(int flightId)
        {
            var seats = data.Seats.Where(s => s.FlightID == flightId && s.IsBooked == false).ToList();
            return View(seats);
        }

        [HttpPost]
        public ActionResult ConfirmSeatChoice(int seatId)
        {
            var seat = data.Seats.FirstOrDefault(s => s.SeatID == seatId);
            if (seat == null)
            {
                return HttpNotFound();
            }
            if (seat.IsBooked.GetValueOrDefault())
            {
                ModelState.AddModelError("", "Ghế này đã được đặt. Vui lòng chọn ghế khác.");
                return RedirectToAction("Index", new { flightId = seat.FlightID });
            }

            // Đặt ghế và lưu thay đổi
            seat.IsBooked = true;
           

            return RedirectToAction("Create", "Customers", new { bookingId = seat.FlightID });
        }
    }
}