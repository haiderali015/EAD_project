using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using EAD_project.Models;

using EAD_project.Models.Interface;

namespace EAD_project.Controllers
{
    public class adminController : Controller
    {
        [HttpGet]

        public ViewResult adminView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult adminView(adminClass admin)
        {

            if (DBClass.AdminLogin(admin.email, admin.password))
            {
                return RedirectToAction("mRoom", "manageroom");
            }
            else
            {
                return adminView();
            }



        }
    }
}
