using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using PresentacionWeb.Parametros;
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
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();

        CParametros _cParametros = new CParametros();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Combos();
            }
        }

        #region 

        private void Combos()
        {
            try
            {
                //gr_parametro grParametro = new gr_parametro()
                //{
                //    ddlgeneral = this.id_suc
                //};
                //grParametro.Parametro("id_suc");
                //grParametro.ddlgeneral = this.id_suc1;
                //grParametro.Parametro("id_suc");
                //grParametro.ddlgeneral = this.id_suc2;
                //grParametro.Parametro("id_suc");
                //grParametro.ddlgeneral = this.id_suc3;
                //grParametro.Parametro("id_suc");
                //grParametro.ddlgeneral = this.id_suc4;
                //grParametro.Parametro("id_suc");
                //grParametro.ddlgeneral = this.id_suc5;
                //grParametro.Parametro("id_suc");
                //gr_compania grCompanium = new gr_compania()
                //{
                //    ddlgeneral = this.id_spvs
                //};
                //grCompanium.ObtenerListaCompania();
                //grCompanium.ddlgeneral = this.id_spvs1;
                //grCompanium.ObtenerListaCompania();
                //grCompanium.ddlgeneral = this.id_spvs2;
                //grCompanium.ObtenerListaCompania();
                //gr_persona grPersona = new gr_persona()
                //{
                //    id_rol = this.id_percart
                //};
                //grPersona.Persona(60);
                //grPersona.id_rol = this.id_percart1;
                //grPersona.Persona(60);
                //(new pr_grupo()
                //{
                //    ddlgeneral = this.id_gru
                //}).ObtenerGrupo();
            }
            catch
            {
            }
        }

        #endregion





        protected void CallBPersona_Callback(object sender, CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idPer = grdPersonas.GetRowValues(Convert.ToInt32(index), "id_per").ToString();
            var nombre = grdPersonas.GetRowValues(Convert.ToInt32(index), "nomraz").ToString();
            nomraz.Value = nombre;
            id_per.Value = idPer;
        }

        protected void btnserper_Click(object sender, EventArgs e)
        {
            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();

            pCPersona.ShowOnPageLoad = true;


        }

        protected void btnserper1_Click(object sender, EventArgs e)
        {
            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz1.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            pCPersona.ShowOnPageLoad = false;
        }

        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            grdPersonas.DataSource = Session["lstPersonas"];
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

        protected void btnGenerarReporteClientes_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteVcmto_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReportePagos_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteEstado_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteReimp_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteCobranzas_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporteRecibos_Click(object sender, EventArgs e)
        {

        }

    }
}