using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourAirLineFinal.Models
{
    public class TransactionViewModel
    {
        public int BookingId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public string CreditCardInfo { get; set; }
    }
}