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

                #region tabClientes

                cmbOficina.DataSource = lstParametroRe;
                cmbOficina.ValueField = "id_par";
                cmbOficina.TextField = "desc_param";
                cmbOficina.DataBind();

                cmbAniv.DataSource = lstMeses;
                cmbAniv.TextField = "value";
                cmbAniv.ValueField = "key";
                cmbAniv.DataBind();

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

        protected void btnGenerarReporteClientes_Click(object sender, EventArgs e)
        {
            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "https://localhost:44347/Sitio/Vista/Reportes/re_viewer.aspx?r=13");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#exampleModal').modal('show');</script>", false);
            //string[] str = new string[] { "<iframe src='re_viewer.aspx?r=13&fc=", this.mes_aniv.SelectedValue.ToString(), "&nc=", this.nomclie.Text, "&sc=", this.id_suc1.SelectedValue.ToString(), "' runat='server' name='repo' width='100%' scrolling='auto' border='0' marginwidth='0' height='100%'></iframe>" };
        }
    }
}