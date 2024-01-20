using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ReportesSistema
{
    public partial class wco_reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region botones tab

        protected void clientes_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "v-pills-clientes-tab";
        }
        protected void vcmto_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "v-pills-vcmto-tab";
        }
        protected void pagos_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "v-pills-pagos-tab";
        }
        protected void estado_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "v-pills-estado-tab";
        }
        protected void reimp_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "v-pills-reimp-tab";
        }
        protected void cobranzas_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "v-pills-cobranzas-tab";
        }
        protected void recibos_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "v-pills-recibos-tab";
        }

        #endregion
    }
}