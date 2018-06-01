using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["user"];
            myCookie.Value = null;
            myCookie.Expires = DateTime.Now;
            Response.Redirect("login.aspx");
        }
    }
}