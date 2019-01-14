using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.Model;
using TestWeb.DAL;

namespace TestWeb.BLL
{
    public class GamesList
    {
        List<Game> allGameList = new List<Game>();

        public GamesList()
        {
            GameListXml _gameListXml = new GameListXml();
            allGameList = _gameListXml.GetGameList();
        }

        public List<Game> GetAllList()
        {
            return allGameList;
        }

        public List<Game> GetAllList(string team)
        {
            List<Game> _resultList = new List<Game>();
            foreach (Game _tempGame in allGameList)
            {
                if (_tempGame.AwayEName == team || _tempGame.HomeEName == team) _resultList.Add(_tempGame);
            }
            return _resultList;
        }

        public List<Game> GetTodayGames()
        {
            List<Game> _resultList = new List<Game>();
            DateTime _time = DateTime.Now;
            foreach (Game _tempGame in allGameList)
            {
                if (_time.Year == _tempGame.DateYear && _time.Month == _tempGame.DateMonth && _time.Day == _tempGame.DateDay) _resultList.Add(_tempGame);
            }
            return _resultList;
        }

        public List<Game> GetTodayGames(DateTime _time)
        {
            List<Game> _resultList = new List<Game>();
            foreach (Game _tempGame in allGameList)
            {
                if (_time.Year == _tempGame.DateYear && _time.Month == _tempGame.DateMonth && _time.Day == _tempGame.DateDay) _resultList.Add(_tempGame);
            }
            return _resultList;
        }
    }
}