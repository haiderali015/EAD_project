using Microsoft.AspNetCore.Mvc;
using EAD_project.Models;
using EAD_project.Models.Interface;
using Newtonsoft.Json;

namespace EAD_project.Controllers

{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ICustomer customer;

        public LoginController(ILogger<LoginController> logger, ICustomer c)
        {
            _logger = logger;
            customer = c;
        }
        [HttpGet]

        public IActionResult signin()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("loginUser"))
            { return View(); 
            }
            return RedirectToAction("homepage", "Home");
        }



        [HttpPost]
        public IActionResult signin(loginForm loginForm)
        {
            if (customer.matchData(loginForm.email,loginForm.password) != null)
            {
                string user = JsonConvert.SerializeObject(customer.matchData(loginForm.email, loginForm.password));
                HttpContext.Response.Cookies.Append("LoginUser", user,
                    new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1)
                    });
                return RedirectToAction("homepage", "Home");
            }
            return View();

            /*if (customer.matchData(loginForm.email, loginForm.password))
            {
                return RedirectToAction("homepage", "Home");
            }
            else
            {
                return signin();
            }*/



        }
    }
}
