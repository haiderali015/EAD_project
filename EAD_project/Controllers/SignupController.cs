using Microsoft.AspNetCore.Mvc;
using EAD_project.Models;
using System.Diagnostics;
using EAD_project.Models.Interface;

namespace EAD_project.Controllers
{
    public class SignupController : Controller
    {
        private readonly ILogger<SignupController> _logger;
        private readonly IWebHostEnvironment Environment;
        private readonly ICustomer customer;

        public SignupController(ILogger<SignupController> logger, IWebHostEnvironment environment, ICustomer c)
        {
            _logger = logger;
            Environment = environment;
            customer = c;
        }

        [HttpGet]
        public ViewResult registerForm()
        {
            return View();
        }
        //string name, string email, string password, string cnic, string phoneNumber
        [HttpPost]
        public IActionResult registerForm(CDatum l, List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            Console.WriteLine("pathh",path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            customer.saveData(l);
            return RedirectToAction("signin", "Login");
        }
        
    }
}










/*  if (ModelState.IsValid)
              {
                  //DBClass.saveData(l);

                  return View("Thanks");

              }
              else
              {
                  ModelState.AddModelError(String.Empty, "Please enter correct data");//generic msg show 
                  return View();
              }*/