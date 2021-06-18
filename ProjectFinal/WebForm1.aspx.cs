using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectFinal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private UserBL user = new UserBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }

        public void Render()
        {
            GridView1.DataSource = user.List();
            GridView1.DataBind();
        }
    }
}