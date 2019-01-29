using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName_E { get; set; }
        public string LastName_E { get; set; }
        public string FirstName_C { get; set; }
        public string LastName_C { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public int PlayingAge { get; set; }
        public DateTime Retire { get; set; }
        public string Photo { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
    }
}