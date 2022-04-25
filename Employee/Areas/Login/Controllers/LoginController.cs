using Common_Entities;
using Login_Entity;
using Login_Interface;
using Microsoft.AspNetCore.Mvc;


namespace Employee.Areas.Login.Controllers
{
    [Area("Login")]
    public class LoginController : Controller
    {
        private readonly ILogin _login;

        public LoginController(ILogin login)
        { 
            _login = login;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResponse GetUserCredentials()
        {
            ATTLogin login = new ATTLogin();
            return _login.GetUserCredentials(login);
        }

    }
}
