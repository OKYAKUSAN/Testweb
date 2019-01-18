using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class PlayerSeasonStats
    {
        public string CName { get; set; }
        public string Season { get; set; }
        public int PlayingGames { get; set; }
        public float PlayingTime { get; set; }
        public float Points { get; set; }
        public float Shots { get; set; }
        public float ShotsHit { get; set; }
        public float ShotsHitRate { get; set; }
        public float ThreePoints { get; set; }
        public float ThreePointsHit { get; set; }
        public float ThreePointsHitRate { get; set; }
        public float FreeThrow { get; set; }
        public float FreeThrowHit { get; set; }
        public float FreeThrowHitRate { get; set; }
        public float Rebound { get; set; }
        public float OffensiveRebound { get; set; }
        public float DefensiveRebound { get; set; }
        public float Block { get; set; }
        public float Assists { get; set; }
        public float Steals { get; set; }
        public float Foul { get; set; }
    }
}