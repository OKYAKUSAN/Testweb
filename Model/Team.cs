using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string ECity { get; set; }
        public string CCity { get; set; }
        public string EName { get; set; }
        public string CName { get; set; }
        public string Conference { get; set; }
        public string Zone { get; set; }
    }
}