﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourAirLineFinal.Models
{
    public class CustomerInfoViewModel
    {

        public int BookingId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}