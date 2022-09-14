using Microsoft.AspNetCore.Mvc;
using EAD_project.Models;

namespace EAD_project.Controllers
{
    public class BookingController : Controller
    {
        public ViewResult rooms()
        {
            List<roomsdata> list = roomsDataFunction.getData();
            return View(list);
        }
        
        public ViewResult price()
        {
            return View();
        }

       
    }
}
