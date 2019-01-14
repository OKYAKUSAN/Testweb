using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class Game
    {
        public int DateYear { get; set; }
        public int DateMonth { get; set; }
        public int DateDay { get; set; }
        public string Time { get; set; }
        public string Away { get; set; }
        public string AwayEName { get; set; }
        public string Home { get; set; }
        public string HomeEName { get; set; }
        public string Result { get; set; }
    }
}