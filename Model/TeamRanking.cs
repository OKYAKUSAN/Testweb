using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class TeamRanking
    {
        public string EName { get; set; }
        public string CName { get; set; }
        public string Conference { get; set; }
        public string Zone { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int WinAway { get; set; }
        public int LoseAway { get; set; }
        public int WinHome { get; set; }
        public int LoseHome { get; set; }
        public float WinDifferential { get; set; }
    }
}