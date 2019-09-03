using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreApp.Models;
using FirstCoreApp.ViewModels;
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

        [HttpGet]
        [Produces("application/xml")]
        public List<Employee> Get()
        {
            return new List<Employee> { new Employee { Id = 1, Name = "Omar", Email = "Maher" },
                                new Employee { Id = 2, Name = "Ahmed", Email = "Ali" }};
        }

        public String Index() {
            return _employeeRepository.GetEmployee(2).Name;
        }

        //public JsonResult Details()
        //{
        //    Employee models = _employeeRepository.GetEmployee(1);
        //    return Json(models);
        //}

        // ViewData Example
        public ViewResult Details()
        {
            Employee models = _employeeRepository.GetEmployee(1);
            ViewData["PageTitle"] = "Employee Detail";
            ViewData["Employee"] = models;
            return View();
        }

        //ViewBag Example
        public ViewResult DetailsViewBag()
        {
            Employee models = _employeeRepository.GetEmployee(1);
            ViewBag.Employee = models;
            ViewBag.Title = "EmployeeDetail";
            return View();
        }

        //Strongly Typed View Example
        public ViewResult DetailsStrolyTyped() {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.PageTitle = "Employee Detail";
            return View(model);
        }

        //ViewModel Example
        public ViewResult DetailsViewModel()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Detail"
            };

            return View(homeDetailsViewModel);
        }

        //All Employee using ViewModel
        public ViewResult AllEmployeeViewModal()
        {
            HomeAllEmployeeViewModel homeAllEmployeeViewModel = new HomeAllEmployeeViewModel()
            {
                AllEmployee = _employeeRepository.GetAllEmployee(),
                PageTitle = "Employee Detail ViewModal"
            };
           
            return View(homeAllEmployeeViewModel);
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
        [HttpGet]
        [Produces("application/xml")]
        public ObjectResult AllEmployeeXML()
        {
            Employee models = _employeeRepository.GetEmployee(1);
            return new ObjectResult(models);
        }
    }
}
