using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using PresentacionWeb.Parametros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ReportesSistema
{
    public partial class wpr_reportes : System.Web.UI.Page
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

        #region metodos

        private void Combos()
        {
            try
            {
                var lstParametroRe = _objConsumoRegistroProd.ParametroRE("id_suc");
                var lstParametroA = _objConsumoRegistroProd.ParametroA("id_div");
                var lstParametro = _objConsumoRegistroProd.ParametroA("id_clamov");

                var lstPersona60 = _objConsumoRegistroProd.Persona(60);
                var lstPersona30 = _objConsumoRegistroProd.Persona(30);

                var lstCompanias = _objConsumoRegistroProd.ObtenerListaCompania();

                var lstRiesgo = _objConsumoRegistroProd.ObtenerRiesgo();

                var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();

                var lstMeses = _cParametros.GetListMeses();

                var lstRangoFechas = _cParametros.GetListRangoFechas();

                var lstComparaPrima = _cParametros.GetListComparaPrima();

                #region Clientes

                cmbOficina.DataSource = lstParametroRe;
                cmbOficina.ValueField = "id_par";
                cmbOficina.TextField = "desc_param";
                cmbOficina.DataBind();

                cmbOficina.SelectedIndex = 0;

                cmbAniv.DataSource = lstMeses;
                cmbAniv.TextField = "value";
                cmbAniv.ValueField = "key";
                cmbAniv.DataBind();
                cmbAniv.SelectedIndex = 0;
                #endregion

                #region Grupos

                cmbGrupoGrupos.DataSource = lstGrupo;
                cmbGrupoGrupos.ValueField = "id_gru";
                cmbGrupoGrupos.TextField = "desc_grupo";
                cmbGrupoGrupos.DataBind();

                cmbGrupoGrupos.SelectedIndex = 0;

                cmbSucursalGrupos.DataSource = lstParametroRe;
                cmbSucursalGrupos.ValueField = "id_par";
                cmbSucursalGrupos.TextField = "desc_param";
                cmbSucursalGrupos.DataBind();

                cmbSucursalGrupos.SelectedIndex = 0;

                #endregion

                #region Proy Cartera

                cmbSucursalCartera.DataSource = lstParametroRe;
                cmbSucursalCartera.ValueField = "id_par";
                cmbSucursalCartera.TextField = "desc_param";
                cmbSucursalCartera.DataBind();

                cmbSucursalCartera.SelectedIndex = 0;

                #endregion

                #region Produccion general

                cmbSucursalProd.DataSource = lstParametroRe;
                cmbSucursalProd.ValueField = "id_par";
                cmbSucursalProd.TextField = "desc_param";
                cmbSucursalProd.DataBind();

                cmbSucursalProd.SelectedIndex = 0;

                cmbDivisaProd.DataSource = lstParametroA;
                cmbDivisaProd.ValueField = "id_par";
                cmbDivisaProd.TextField = "desc_param";
                cmbDivisaProd.DataBind();

                cmbDivisaProd.SelectedIndex = 0;

                cmbCarteraProd.DataSource = lstPersona60;
                cmbCarteraProd.ValueField = "id_per";
                cmbCarteraProd.TextField = "nomraz";
                cmbCarteraProd.DataBind();

                cmbCarteraProd.SelectedIndex = 0;

                cmbEjecutivoProd.DataSource = lstPersona30;
                cmbEjecutivoProd.ValueField = "id_per";
                cmbEjecutivoProd.TextField = "nomraz";
                cmbEjecutivoProd.DataBind();

                cmbEjecutivoProd.SelectedIndex = 0;

                cmbCompaniaProd.DataSource = lstCompanias;
                cmbCompaniaProd.ValueField = "id_spvs";
                cmbCompaniaProd.TextField = "nomraz";
                cmbCompaniaProd.DataBind();

                cmbCompaniaProd.SelectedIndex = 0;

                cmbRamoProd.DataSource = lstRiesgo;
                cmbRamoProd.ValueField = "id_riesgo";
                cmbRamoProd.TextField = "desc_riesgo";
                cmbRamoProd.DataBind();

                cmbRamoProd.SelectedIndex = 0;

                cmbGrupoProd.DataSource = lstGrupo;
                cmbGrupoProd.ValueField = "id_gru";
                cmbGrupoProd.TextField = "desc_grupo";
                cmbGrupoProd.DataBind();
                cmbGrupoProd.SelectedIndex = 0;

                cmbMovimientoProd.DataSource = lstParametro;
                cmbMovimientoProd.ValueField = "id_par";
                cmbMovimientoProd.TextField = "desc_param";
                cmbMovimientoProd.DataBind();
                cmbMovimientoProd.SelectedIndex = 0;

                cmbRangosFechasProd.DataSource = lstRangoFechas;
                cmbRangosFechasProd.ValueField = "key";
                cmbRangosFechasProd.TextField = "value";
                cmbRangosFechasProd.DataBind();
                cmbRangosFechasProd.SelectedIndex = 0;


                cmbPrimaTotal.DataSource = lstComparaPrima;
                cmbPrimaTotal.ValueField = "key";
                cmbPrimaTotal.TextField = "value";
                cmbPrimaTotal.DataBind();

                cmbPrimaTotal.SelectedIndex = 0;

                cmbPrimaNeta.DataSource = lstComparaPrima;
                cmbPrimaNeta.ValueField = "key";
                cmbPrimaNeta.TextField = "value";
                cmbPrimaNeta.DataBind();

                cmbPrimaNeta.SelectedIndex = 0;

                #endregion

                #region Memos

                cmbCarteraMemo.DataSource = lstPersona60;
                cmbCarteraMemo.ValueField = "id_per";
                cmbCarteraMemo.TextField = "nomraz";
                cmbCarteraMemo.DataBind();

                cmbCarteraMemo.SelectedIndex = 0;

                cmbFechasMemo.DataSource = lstRangoFechas;
                cmbFechasMemo.ValueField = "key";
                cmbFechasMemo.TextField = "value";
                cmbFechasMemo.DataBind();
                cmbFechasMemo.SelectedIndex = 0;

                #endregion

                //gr_parametro grParametro = new gr_parametro()
                //{
                //    ddlgeneral = this.id_suc
                //};
                //grParametro.ParametroRE("id_suc");
                //grParametro.ddlgeneral = this.id_suc1;
                //grParametro.ParametroRE("id_suc");
                //grParametro.ddlgeneral = this.id_suc2;
                //grParametro.ParametroRE("id_suc");
                //grParametro.ddlgeneral = this.id_suc3;
                //grParametro.ParametroRE("id_suc"); 
                //grParametro.ddlgeneral = this.id_div;
                //grParametro.ParametroA("id_div");
                //grParametro.ddlgeneral = this.id_clamov;
                //grParametro.Parametro("id_clamov");


                //gr_persona grPersona = new gr_persona()
                //{
                //    id_rol = this.id_percart
                //};
                //grPersona.Persona(60);
                //grPersona.id_rol = this.id_percart1;
                //grPersona.Persona(60);
                //grPersona.id_rol = this.id_perejec;
                //grPersona.Persona(30);
                //(new gr_compania()
                //{
                //    ddlgeneral = this.id_spvs
                //}).ObtenerListaCompania();
                //DataTable dataTable = (new pr_producto()).ObtenerRiesgo();
                //this.id_riesgo.DataSource = dataTable;
                //this.id_riesgo.DataTextField = "desc_riesgo";
                //this.id_riesgo.DataValueField = "id_riesgo";
                //this.id_riesgo.DataBind();
                //pr_grupo prGrupo = new pr_grupo()
                //{
                //    ddlgeneral = this.id_gru
                //};
                //prGrupo.ObtenerGrupo();
                //prGrupo.ddlgeneral = this.id_gru1;
                //prGrupo.ObtenerGrupo();
            }
            catch
            {
                //gr_parametro idSuc1 = new gr_parametro()
                //{
                //    ddlgeneral = this.id_suc
                //};
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_suc1;
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_suc2;
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_suc3;
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_div;
                //idSuc1.ParametroA("id_div");
                //idSuc1.ddlgeneral = this.id_clamov;
                //idSuc1.Parametro("id_clamov");
                //gr_persona idPercart1 = new gr_persona()
                //{
                //    id_rol = this.id_percart
                //};
                //idPercart1.Persona(60);
                //idPercart1.id_rol = this.id_percart1;
                //idPercart1.Persona(60);
                //idPercart1.id_rol = this.id_perejec;
                //idPercart1.Persona(30);
                //(new gr_compania()
                //{
                //    ddlgeneral = this.id_spvs
                //}).ObtenerListaCompania();
                //DataTable dataTable1 = (new pr_producto()).ObtenerRiesgo();
                //this.id_riesgo.DataSource = dataTable1;
                //this.id_riesgo.DataTextField = "desc_riesgo";
                //this.id_riesgo.DataValueField = "id_riesgo";
                //this.id_riesgo.DataBind();
                //pr_grupo idGru1 = new pr_grupo()
                //{
                //    ddlgeneral = this.id_gru
                //};
                //idGru1.ObtenerGrupo();
                //idGru1.ddlgeneral = this.id_gru1;
                //idGru1.ObtenerGrupo();
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


        protected void clientes_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-clientes-tab";
        }
        protected void grupos_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-grupos-tab";
        }
        protected void cartera_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-cartera-tab";
        }
        protected void produccion_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-produccion-tab";
        }
        protected void memo_tab_Click(object sender, EventArgs e)
        {
            hidtab.Value = "nav-memo-tab";
        }


        protected void cmbCompaniaProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            var response = _objConsumoRegistroProd.ObtenerTablaProducto(Convert.ToString(cmbCompaniaProd.SelectedItem.Value));
            cmbProductoProd.DataSource = response;
            cmbProductoProd.TextField = "desc_prod";
            cmbProductoProd.ValueField = "id_producto";
            cmbProductoProd.DataBind();
        }



        protected void btnGenerarReporteClientes_Click(object sender, EventArgs e)
        {
            var mesAniv = Convert.ToString(cmbAniv.SelectedItem.Value);
            var nomcli = txtNomclie.Text;
            var suc = cmbOficina.SelectedItem.Value;

            reportTabClientes.Visible = true;
            //reportTabClientes.Attributes.Add("src", "https://localhost:44347/Sitio/Vista/Reportes/re_viewer.aspx?r=13&fc=");
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=13&fc=" + mesAniv + "&nc=" + nomcli + "&sc=" + suc);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#exampleModal').modal('show');</script>", false);
            //string[] str = new string[] { "<iframe src='re_viewer.aspx?r=13&fc=", this.mes_aniv.SelectedValue.ToString(), "&nc=", this.nomclie.Text, "&sc=", this.id_suc1.SelectedValue.ToString(), "' runat='server' name='repo' width='100%' scrolling='auto' border='0' marginwidth='0' height='100%'></iframe>" };
        }

        protected void btnGenerarReporteGrupos_Click(object sender, EventArgs e)
        {
            var idGrupo = Convert.ToString(cmbGrupoGrupos.SelectedItem.Value);
            var suc = Convert.ToString(cmbSucursalGrupos.SelectedItem.Value);
            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=15&ig=" + idGrupo + "&sc=" + suc);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteCartera_Click(object sender, EventArgs e)
        {
            var suc = Convert.ToString(cmbSucursalCartera.SelectedItem.Value);
            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=16&sc=" + suc);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteProduccion_Click(object sender, EventArgs e)
        {
            var s = "";
            var ca = "";
            var ej = "";
            var sp = "";
            var ip = "";

            var iv1 = "";
            var iv2 = "";
            var ipc = "";
            var nup = "";
            var pt = "";

            var pn = "";
            var fc = "";
            var nl = "";
            var de1 = "";
            var de2 = "";

            var idi = "";
            var idr = "";
            var ve = "";
            var ve0 = "";
            var mv = "";
            var g = "";

            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=2" +
            "&s=" + s + 
			"&ca=" + ca +
			"&ej=" + ej + 
			"&sp=" + sp + 
			"&ip=" + ip + 

			"&iv1=" + iv1 + 
			"&iv2=" + iv2 + 
			"&ipc=" + ipc + 
			"&nup=" + nup + 
			"&pt=" + pt + 

			"&pn=" + pn + 
			"&fc=" + fc + 
			"&nl=" + nl + 
			"&de1=" + de1 + 
			"&de2=" + de2 + 

			"&idi=" + idi +  
			"&idr=" + idr +  
			"&ve=" + ve +  
			"&ve0=" +  ve0 +  
			"&mv=" +  mv +  
			"&g=" +  g
                );
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteMemo_Click(object sender, EventArgs e)
        {
            var numPoliza = txtNumPolizaMemo.Text;
            var numLiquidacion = txtNumLiquidacionMemo.Text;
            var cartera = Convert.ToString(cmbCarteraMemo.SelectedItem.Value);
            var fechaMemo = Convert.ToString(cmbFechasMemo.SelectedItem.Value);
            var fechaDe = fechaDel.Date.ToShortDateString();
            var fechaA = fechaAl.Date.ToShortDateString();
            string str = "";
            str = (this.cmbCopiasMemo.SelectedItem.Value.ToString() != "1" ? "10" : "9");

            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=" + str + "&np=" + numPoliza + 
                "&nl=" + numLiquidacion +
                "&fc=" + fechaDe +
                "&fc2=" + fechaA +
                "&fb=" + fechaMemo +
                "&ca=" + cartera
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        
    }
}