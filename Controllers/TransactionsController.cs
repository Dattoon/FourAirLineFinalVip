using FourAirLineFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourAirLineFinal.Controllers
{
    public class TransactionsController : BaseController
    {
        // GET: Transactions
        public ActionResult Create(int bookingId)
        {
            var model = new TransactionViewModel
            {
                BookingId = bookingId
            };

            // Tạo danh sách các phương thức thanh toán
            ViewBag.PaymentMethodId = data.PaymentMethods.Select(p => new SelectListItem
            {
                Value = p.PaymentMethodID.ToString(),
                Text = p.PaymentMethodName
            }).ToList();

            return View(model);
        }

        // POST: Transactions/Create
        [HttpPost]
        public ActionResult Create(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction
                {
                    BookingID = model.BookingId,
                    PaymentMethodID = model.PaymentMethodId,
                    TransactionDate = DateTime.Now,
                    Amount = model.Amount,
                    TransactionStatus = "Pending",
                    CreditCardInfo = model.CreditCardInfo
                };
                data.Transactions.InsertOnSubmit(transaction);
                data.SubmitChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}