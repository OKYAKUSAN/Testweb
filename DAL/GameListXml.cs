using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using TestWeb.Model;

namespace TestWeb.DAL
{
    public class GameListXml
    {
        private XmlDocument gameListXml = new XmlDocument();

        public GameListXml()
        {
            gameListXml.Load("F:/素材/自制/c_project/01_test/TestWeb/TestWeb/xml/gameList.xml");
        }

        public GameListXml(string str)
        {
            gameListXml.Load(str);
        }

        public List<Game> GetGameList()
        {
            XmlNodeList _gameList = gameListXml.GetElementsByTagName("game");
            //ArrayList _list = new ArrayList();
            List<Game> _list = new List<Game>();
            for (int i = 0; i < _gameList.Count; i++)
            {
                Game _tempGame = new Game();
                _tempGame.DateYear = Int32.Parse(_gameList[i].Attributes[0].Value);
                _tempGame.DateMonth = Int32.Parse(_gameList[i].Attributes[1].Value);
                _tempGame.DateDay = Int32.Parse(_gameList[i].Attributes[2].Value);
                _tempGame.Time = _gameList[i].ChildNodes[0].InnerText;
                _tempGame.Away = _gameList[i].ChildNodes[1].InnerText;
                _tempGame.AwayEName = _gameList[i].ChildNodes[1].Attributes["eName"].Value;
                _tempGame.Home = _gameList[i].ChildNodes[2].InnerText;
                _tempGame.HomeEName = _gameList[i].ChildNodes[2].Attributes["eName"].Value;
                _tempGame.Result = _gameList[i].ChildNodes[3].InnerText;
                _list.Add(_tempGame);
            }
            return _list;
        }
    }
}