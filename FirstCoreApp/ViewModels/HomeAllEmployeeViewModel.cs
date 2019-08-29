using FirstCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.ViewModels
{
    public class HomeAllEmployeeViewModel
    {
        public List<Employee> AllEmployee { get; set; }
        public string PageTitle { get; set; }
    }
}
