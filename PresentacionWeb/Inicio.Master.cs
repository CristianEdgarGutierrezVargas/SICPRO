using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class Inicio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Page_Error(object sender, EventArgs e)
        {
            string mensajeError = string.Empty;
            Exception objErr = Server.GetLastError();
            if (objErr.InnerException == null)
                mensajeError = objErr.Message;
            else
                mensajeError = objErr.InnerException.Message;
            Response.Redirect("~/Sitio/Vista/Exceptions/Error.aspx?error=" + mensajeError.Replace("\r\n", ""));
        }
    }
}