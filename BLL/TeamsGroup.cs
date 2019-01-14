using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.DAL;
using TestWeb.Model;

namespace TestWeb.BLL
{
    public class TeamsGroup
    {
        private List<Team> _teamList = new List<Team>();

        public TeamsGroup()
        {
            TeamListXml teamListData = new TeamListXml();
            _teamList = teamListData.GetTeamList();
        }

        public List<Team> GetGroup(string words)
        {
            List<Team> _resultList = new List<Team>();
            foreach (Team tempTeam in _teamList)
            {
                if (words == "西部联盟" || words == "东部联盟")
                {
                    if (tempTeam.Conference == words) _resultList.Add(tempTeam);
                }
                else
                {
                    if (tempTeam.Zone == words) _resultList.Add(tempTeam);
                }
            }

            return _resultList;
        }

        public Team GetTeam(string words)
        {
            Team _resultTeam = new Team();
            foreach (Team _tempTeam in _teamList)
            {
                if (_tempTeam.EName == words || _tempTeam.CName == words) _resultTeam = _tempTeam;
            }
            return _resultTeam;
        }
    }
}