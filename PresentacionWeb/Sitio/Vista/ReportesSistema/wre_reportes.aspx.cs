using DevExpress.Web;
using DevExpress.XtraReports;
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
            divMensajeError.Visible = false;
            var lstParametroSuc = _objConsumoRegistroProd.ParametroA("id_suc");
            var lstParametroEst = _objConsumoRegistroProd.ParametroA("id_estca");

            var lstCompanias = _objConsumoRegistroProd.ObtenerListaCompania();
            var lstPersona60 = _objConsumoRegistroProd.Persona(60);

            #region Historico

            #endregion
            #region General

            cmbOficina.DataSource = lstParametroSuc;
            cmbOficina.ValueField = "id_par";
            cmbOficina.TextField = "desc_param";
            cmbOficina.DataBind();
            cmbOficina.SelectedIndex = 0;

            cmbCartera.DataSource = lstPersona60;
            cmbCartera.ValueField = "id_per";
            cmbCartera.TextField = "nomraz";
            cmbCartera.DataBind();

            cmbCartera.SelectedIndex = 0;

            cmbCompaniaProd.DataSource = lstCompanias;
            cmbCompaniaProd.ValueField = "id_spvs";
            cmbCompaniaProd.TextField = "nomraz";
            cmbCompaniaProd.DataBind();

            cmbCompaniaProd.SelectedIndex = 0;

            cmbEstadoCaso.DataSource = lstParametroEst;
            cmbEstadoCaso.ValueField = "id_par";
            cmbEstadoCaso.TextField = "desc_param";
            cmbEstadoCaso.DataBind();

            cmbEstadoCaso.SelectedIndex = 0;
            #endregion
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
            divMensajeError.Visible = false;
        }
        protected void gen_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-gen-tab";
            divMensajeError.Visible = false;
        }


        protected void btnGenerarReporteHist_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            if (string.IsNullOrEmpty(txtNroCasoHist.Text.Trim()) && string.IsNullOrEmpty(txtAnioRegHist.Text.Trim()))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "El número de Caso o el año debe ser completado <br /> verifiquelo antes de proseguir";
               
                return;
            }

            var ic = txtNroCasoHist.Text;
            var ac = txtAnioRegHist.Text;

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=3" +
                "&ic=" + ic +
                "&ac=" + ac
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteGen_Click(object sender, EventArgs e)
        {
            var s = Convert.ToString(cmbOficina.SelectedItem.Value);
            var ipc = id_per.Value;
            var np = txtNumPolizaProd.Text;
            var sp = Convert.ToString(cmbCompaniaProd.SelectedItem.Value);
            var ip = Convert.ToString(cmbProductoProd.SelectedItem.Value);
            var ca = Convert.ToString(cmbCartera.SelectedItem.Value);
            var iv1 = fechaDelProd.Date.ToShortDateString();
            var iv2 = fechaAlProd.Date.ToShortDateString();
            var ec = Convert.ToString(cmbEstadoCaso.SelectedItem.Value);

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=4" +
                "&s=" +  s + 
                "&ipc=" +  ipc + 
                "&np=" +  np + 
                "&sp=" +  sp + 
                "&ip=" +  ip + 
                "&ca=" +  ca + 
                "&iv1=" +  iv1 + 
                "&iv2=" +  iv2 + 
                "&ec=" +  ec
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}