using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logeo_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Sistema.Instancia.ValidarUsuario(Logeo.UserName.Trim(), Logeo.Password.Trim()))
            {
                Session["usu"] = Logeo.UserName;
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}