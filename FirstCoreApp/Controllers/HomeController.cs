using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public String Index() {
            return _employeeRepository.GetEmployee(2).Name;
        }

        //public JsonResult Details()
        //{
        //    Employee models = _employeeRepository.GetEmployee(1);
        //    return Json(models);
        //}

        public ViewResult Details()
        {
            Employee models = _employeeRepository.GetEmployee(1);
            ViewData["PageTitle"] = "Employee Detail";
            ViewData["Employee"] = models;
            return View();
        }

        // For View
        public ViewResult AllEmployee()
        {
           List<Employee> allemp = _employeeRepository.GetAllEmployee();
            ViewData["AllEmployee"] = allemp;
            return View();
        }

        // For Json Result
        public JsonResult AllEmployeeJ()
        {
            List<Employee> allemp = _employeeRepository.GetAllEmployee();
            return Json(allemp);
        }

        // For XML/Object Result
        public ObjectResult AllEmployeeXML()
        {
            Employee models = _employeeRepository.GetEmployee(1);
            return new ObjectResult(models);
        }
    }
}
