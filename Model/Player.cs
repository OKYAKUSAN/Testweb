using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class Player
    {
        public string EName { get; set; }
        public string CName { get; set; }
        public DateTime Birthday { get; set; }
        public string Position { get; set; }
        public int FirstSeason { get; set; }
        public int PlayAge { get; set; }
        public DateTime Retire { get; set; }
        public string Photo { get; set; }
    }
}