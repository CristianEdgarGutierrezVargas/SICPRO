using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ReportesSistema
{
    public partial class wre_reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void hist_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-hist-tab";
        }
        protected void gen_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-gen-tab";
        }


        protected void btnGenerarReporteHist_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteGen_Click(object sender, EventArgs e)
        {

        }
    }
}