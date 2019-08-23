using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeelist;

        public MockEmployeeRepository()
        {
            _employeelist = new List<Employee>()
            {
                new Employee() { Id = 1, Name="Employee 1", Email="Email 1", Department="IT"},
                new Employee() { Id = 2, Name="Employee 2", Email="Email 2", Department="AC"},
                new Employee() { Id = 3, Name="Employee 3", Email="Email 3", Department="HR"}

            };

        }
        public Employee GetEmployee(int Id)
        {
            return _employeelist.FirstOrDefault(e => e.Id == Id);
            //return _employeelist.Find(e => e.Id == Id);
        }

        public List<Employee> GetAllEmployee() {
            return _employeelist;
        }

    }
}
