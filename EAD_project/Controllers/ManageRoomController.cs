using Microsoft.AspNetCore.Mvc;
using EAD_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*using System.Web.Mvc;
using WebApplication30.Models;*/


namespace EAD_project.Controllers
{

    public class ManageRoomController : Controller
    {
        private readonly ILogger<ManageRoomController> _logger;
        private readonly IWebHostEnvironment Environment;
        
        public ManageRoomController(ILogger<ManageRoomController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            Environment = environment;
        }

        //List<IFormFile> postedFiles
        [HttpGet]
        public ViewResult mRoom()
        {
            return View();
        }


        [HttpPost]
            public ViewResult mRoom(List<IFormFile> postedFiles,roomsdata rooms)
        {   
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "RoomPic");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string mypic="";
            foreach (var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                mypic = fileName;
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            string fullpicPath = "/RoomPic/" + mypic;
            roomsDataFunction r = new roomsDataFunction();
            r.addRoom(rooms.roomNum, rooms.description, fullpicPath,rooms.roomPrice,rooms.suite);
            return View();
        }

        public ViewResult adminRooms()
        {
            List<roomsdata> list = roomsDataFunction.getData();
            return View(list);
        }
      



    }
}
