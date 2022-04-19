using Common_Entities;
using Employee_Entity;
using Employee_Interface;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EntryController : Controller
    {
        private readonly IEmployee _employee;
        public EntryController(IEmployee employee)
        {
            _employee = employee; 
        }
        public IActionResult Index()
        {
            return View();
        }
     
        public JsonResponse AddEmployee() 
        {
            ATTEmployee employee= new ATTEmployee();
            return _employee.AddEmployee(employee);
        }

    }
}
