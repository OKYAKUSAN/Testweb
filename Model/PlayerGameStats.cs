﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Model
{
    public class PlayerGameStats
    {
        public int StatsId { get; set; }
        public int PlayerId { get; set; }
        public string FirstName_E { get; set; }
        public string LastName_E { get; set; }
        public string FirstName_C { get; set; }
        public string LastName_C { get; set; }
        public int GameId { get; set; }
        public string Season { get; set; }
        public DateTime Time { get; set; }
        public int AwayTeamId { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeam { get; set; }
        public int TeamId { get; set; }
        public string Team { get; set; }
        public bool Starter { get; set; }
        public int PlayingTime { get; set; }
        public int Points { get; set; }
        public int Shots { get; set; }
        public int ShotsHit { get; set; }
        public double ShotsHitRate { get; set; }
        public int ThreePoints { get; set; }
        public int ThreePointsHit { get; set; }
        public double ThreePointsHitRate { get; set; }
        public int FreeThrow { get; set; }
        public int FreeThrowHit { get; set; }
        public double FreeThrowHitRate { get; set; }
        public int Rebound { get; set; }
        public int OffensiveRebound { get; set; }
        public int DefensiveRebound { get; set; }
        public int Block { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Foul { get; set; }
        public int Faults { get; set; }
    }
}