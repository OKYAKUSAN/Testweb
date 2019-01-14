using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using TestWeb.Model;

namespace TestWeb.DAL
{
    public class TeamListXml
    {
        private XmlDocument teamListXml = new XmlDocument();

        public TeamListXml()
        {
            teamListXml.Load("F:/素材/自制/c_project/01_test/TestWeb/TestWeb/xml/teamList.xml");
        }

        public TeamListXml(string str)
        {
            teamListXml.Load(str);
        }

        public List<Team> GetTeamList()
        {
            List<Team> _list = new List<Team>();
            XmlNodeList _teamList = teamListXml.GetElementsByTagName("team");
            for (int i = 0; i < _teamList.Count; i++)
            {
                Team _tempTeam = new Team();
                _tempTeam.ECity = _teamList[i].ChildNodes[0].InnerText;
                _tempTeam.CCity = _teamList[i].ChildNodes[1].InnerText;
                _tempTeam.EName = _teamList[i].ChildNodes[2].InnerText;
                _tempTeam.CName = _teamList[i].ChildNodes[3].InnerText;
                _tempTeam.Conference = _teamList[i].ChildNodes[4].InnerText;
                _tempTeam.Zone = _teamList[i].ChildNodes[5].InnerText;
                _list.Add(_tempTeam);
            }
            return _list;
        }
    }
}