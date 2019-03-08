using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TestWeb.Model;

namespace TestWeb.Helper
{
    public static class PackageHelper
    {
        public static PlayerGameStats PackagePlayerGameStats(DataRow dr)
        {
            PlayerGameStats packagePGS = new PlayerGameStats();
            packagePGS.StatsId = Int32.Parse(dr["ID_GPS"].ToString());
            packagePGS.PlayerId = Int32.Parse(dr["ID_P"].ToString());
            packagePGS.FirstName_E = dr["FirstName_E"].ToString();
            packagePGS.LastName_E = dr["LastName_E"].ToString();
            packagePGS.FirstName_C = dr["FirstName_C"].ToString();
            packagePGS.LastName_C = dr["LastName_C"].ToString();
            packagePGS.GameId = Int32.Parse(dr["ID_G"].ToString());
            packagePGS.Season = dr["Season"].ToString();
            packagePGS.Time = DateTime.Parse(dr["GameTime"].ToString());
            packagePGS.AwayTeamId = Int32.Parse(dr["Away"].ToString());
            packagePGS.AwayTeam = dr["AwayName"].ToString();
            packagePGS.HomeTeamId = Int32.Parse(dr["Home"].ToString());
            packagePGS.HomeTeam = dr["HomeName"].ToString();
            packagePGS.TeamId = Int32.Parse(dr["TeamId"].ToString());
            packagePGS.Team = dr["TeamName"].ToString();
            packagePGS.Starter = (bool)dr["Starter"];
            packagePGS.PlayingTime = Int32.Parse(dr["PlayingTime"].ToString());
            packagePGS.Points = Int32.Parse(dr["Points"].ToString());
            packagePGS.Shots = Int32.Parse(dr["Shots"].ToString());
            packagePGS.ShotsHit = Int32.Parse(dr["ShotsHit"].ToString());
            packagePGS.ShotsHitRate = Int32.Parse(dr["Shots"].ToString()) != 0 ? double.Parse(dr["ShotsHit"].ToString())/double.Parse(dr["Shots"].ToString())*100 : 0;
            packagePGS.ThreePoints = Int32.Parse(dr["ThreePoints"].ToString());
            packagePGS.ThreePointsHit = Int32.Parse(dr["ThreePointsHit"].ToString());
            packagePGS.ThreePointsHitRate = Int32.Parse(dr["ThreePoints"].ToString()) != 0 ? double.Parse(dr["ThreePointsHit"].ToString()) / double.Parse(dr["ThreePoints"].ToString()) * 100 : 0;
            packagePGS.FreeThrow = Int32.Parse(dr["FreeThrow"].ToString());
            packagePGS.FreeThrowHit = Int32.Parse(dr["FreeThrowHit"].ToString());
            packagePGS.FreeThrowHitRate = Int32.Parse(dr["FreeThrow"].ToString()) != 0 ? double.Parse(dr["FreeThrowHit"].ToString()) / double.Parse(dr["FreeThrow"].ToString()) * 100 : 0;
            packagePGS.Rebound = Int32.Parse(dr["OffensiveRebound"].ToString()) + Int32.Parse(dr["DefensiveRebound"].ToString());
            packagePGS.OffensiveRebound = Int32.Parse(dr["OffensiveRebound"].ToString());
            packagePGS.DefensiveRebound = Int32.Parse(dr["DefensiveRebound"].ToString());
            packagePGS.Block = Int32.Parse(dr["Block"].ToString());
            packagePGS.Assists = Int32.Parse(dr["Assists"].ToString());
            packagePGS.Steals = Int32.Parse(dr["Steals"].ToString());
            packagePGS.Foul = Int32.Parse(dr["Foul"].ToString());
            packagePGS.Faults = Int32.Parse(dr["Faults"].ToString());

            return packagePGS;
        }
    }
}