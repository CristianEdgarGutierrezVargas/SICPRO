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
    public partial class wre_reportes : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();

        CParametros _cParametros = new CParametros();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Combos();
            }
        }

        private void Combos()
        {
            var lstParametroSuc = _objConsumoRegistroProd.ParametroA("id_suc");
            var lstParametroEst = _objConsumoRegistroProd.ParametroA("id_estca");

            var lstCompanias = _objConsumoRegistroProd.ObtenerListaCompania();
            var lstPersona60 = _objConsumoRegistroProd.Persona(60);


        }




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




        protected void cmbCompaniaProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            var response = _objConsumoRegistroProd.ObtenerTablaProducto(Convert.ToString(cmbCompaniaProd.SelectedItem.Value));
            cmbProductoProd.DataSource = response;
            cmbProductoProd.TextField = "desc_prod";
            cmbProductoProd.ValueField = "id_producto";
            cmbProductoProd.DataBind();
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