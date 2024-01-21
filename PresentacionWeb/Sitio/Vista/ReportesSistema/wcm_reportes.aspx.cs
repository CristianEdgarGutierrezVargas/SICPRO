using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ReportesSistema
{
    public partial class wcm_reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }





        protected void comisionesEje_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-comisionesEje-tab";
        }
        protected void spvs_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-spvs-tab";
        }
        protected void comisiones_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-comisiones-tab";
        }
        protected void contable_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-contable-tab";
        }
        protected void nota_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-nota-tab";
        }
        protected void comisionesFe_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-comisionesFe-tab";
        }


        protected void btnGenerarReporteComisionesEje_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteSpvs_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteComisiones_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteContable_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteNota_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteComisionesFe_Click(object sender, EventArgs e)
        {

        }

    }
}