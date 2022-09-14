using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Model Validation
namespace EAD_project.Models
{
    public class adminClass
    {
        [Required(ErrorMessage = "please enter your name")]

        public string email { get; set; }



        [StringLength(15)]
        [Required(ErrorMessage = "please enter password")]

        public string password { get; set; }
    }
}
