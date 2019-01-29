using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.DAL;
using TestWeb.Model;

namespace TestWeb.BLL
{
    public class PlayerBll
    {
        PlayerServer ps = new PlayerServer();
        List<Player> allPlayer = new List<Player>();

        public PlayerBll()
        {
            allPlayer = ps.GetAllPlayerList();
        }

        public List<Player> GetAllPlayer()
        {
            return allPlayer;
        }

        public Player GetPlayer(int id)
        {
            return ps.GetPlayer(id);
        }
    }
}