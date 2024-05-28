using FourAirLineFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourAirLineFinal.Controllers
{
    public class BaseController : Controller
    {
        // Thay doi chuoi ket noi voi csdl o day
        protected DataClasses1DataContext data = new DataClasses1DataContext("DATTOON\\DATER");
    }
}