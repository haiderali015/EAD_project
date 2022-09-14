using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EAD_project.Models
{
    public partial class CDatum
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
