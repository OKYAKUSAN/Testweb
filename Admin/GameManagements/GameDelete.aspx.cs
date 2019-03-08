using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.BLL;

namespace TestWeb.Admin.GameManagements
{
    public partial class GameDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Request.QueryString["id"] != null ? Int32.Parse(Request.QueryString["id"]) : 0;
            GameBll gb = new GameBll();
            if (id > 0)
            {
                gb.DeleteGame(id);
            }
        }
    }
}