using Employee_Interface;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EntryController : Controller
    {
        private readonly IEmployee _employee;
        public EntryController(IEmployee Employee)
        {
            _employee = Employee; 
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
