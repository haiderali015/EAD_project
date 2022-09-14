using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using EAD_project.Models;
using System.Reflection.Emit;

namespace EAD_project.Controllers
{

    public class HomeController : Controller
    {


        /*public ViewResult ListMembers()
        {
            List<members> l = new List<members>();
            l = DBClass.displayMembers();
            ViewBag.list = l;
            return View(DBClass.displayMembers());
        }*/
        public IActionResult homepage()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loginUser"))
            {
                return View();
            }
            return RedirectToAction("signin", "Login");
        }


        /*public ViewResult home()
        {
            return View();
        }*/

       
        public IActionResult contact()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loginUser"))
            {
                return View();
            }
            return RedirectToAction("signin", "Login");
        }
        public IActionResult Branches()
        {
            if (HttpContext.Request.Cookies.ContainsKey("loginUser"))
            {
                return View();
            }
            return RedirectToAction("signin", "Login");
        }

        public PartialViewResult NewsView()
        {

            return PartialView("myPartialView");
        }
        public IActionResult reviews()
        {


            if (HttpContext.Request.Cookies.ContainsKey("loginUser"))
            {
                return View();
            }
            return RedirectToAction("signin", "Login");
        }

        public IActionResult Signout()
        {
            HttpContext.Response.Cookies.Delete("LoginUser");
            return RedirectToAction("signin", "Login");
        }

    }
}
