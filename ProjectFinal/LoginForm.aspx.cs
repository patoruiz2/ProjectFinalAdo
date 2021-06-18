using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectFinal
{
    public partial class LoginForm : System.Web.UI.Page
    {
        private BL.UserBL peticion = new BL.UserBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Login();
            

        }

        private void Login()
        {
            var validate = peticion.Login(TextBox1.Text, TextBox2.Text);

            if (validate == true)
            {
                Response.Redirect("AdminForm.aspx");
            }


        }
    }
}