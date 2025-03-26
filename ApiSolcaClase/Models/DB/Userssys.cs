using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiSolcaClase.Models.DB
{
    public partial class Userssys
    {
        public decimal Iduser { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Nameperson { get; set; }
        public string Email { get; set; }
        public decimal Idrol { get; set; }
    }
}
