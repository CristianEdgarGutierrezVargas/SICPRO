using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizaapli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && base.Request.QueryString["var"] != "")
            {
                int num = int.Parse(base.Request.QueryString["var"]);
                int num1 = int.Parse(base.Request.QueryString["val"]);
                //this.Buscar(num, num1);
                //this.fc_reg.Value = DateTime.Today.Date.ToShortDateString();
            }
        }
    }
}