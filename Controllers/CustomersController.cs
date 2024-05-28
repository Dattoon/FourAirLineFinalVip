using FourAirLineFinal.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FourAirLineFinal.Controllers
{
    public class CustomersController : BaseController
    {
        // GET: Customers/Create
        public ActionResult Create(int bookingId)
        {
            var model = new CustomerInfoViewModel
            {
                BookingId = bookingId
            };
            return View(model);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CustomerInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = data.Users.FirstOrDefault(u => u.UserID == model.BookingId);
                if (user != null)
                {
                    user.UserName = model.Name;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                }
                else
                {
                    user = new User
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber
                    };
                    data.Users.InsertOnSubmit(user);
                }
                data.SubmitChanges();
                return RedirectToAction("Review", "Bookings", new { bookingId = model.BookingId });
            }
            return View(model);
        }
    }
}
