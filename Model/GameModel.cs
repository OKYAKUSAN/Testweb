using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Season { get; set; }
        public DateTime Time { get; set; }
        public int Away_ID { get; set; }
        public string Away { get; set; }
        public string Away_E { get; set; }
        public int Home_ID { get; set; }
        public string Home { get; set; }
        public string Home_E { get; set; }
        public string AwayPoints { get; set; }
        public string HomePoints { get; set; }
    }
}