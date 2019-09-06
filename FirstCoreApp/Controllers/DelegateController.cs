using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    public class DelegateController : Controller
    {
        public delegate string Print(int iValue);
        static string strVal;
        public IActionResult Index()
        {
            Print DelPrint = Number;
           string str1 = DelPrint(10000);
           string str2 = DelPrint(200);
            ViewData["Print1"] = str1;
            ViewData["Print2"] = str2;
            return View();
        }

        public static string Number(int iVal) {
            strVal = string.Format("Number : {0, -12:N0}", iVal);
            return strVal;
        }

        public static string Money(int iVal) {
            strVal = string.Format("Money: {0:C}", iVal);
            return strVal;
        }
    }
}