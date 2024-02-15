using DevExpress.Web.Bootstrap;
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
    public partial class wcm_reportes : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        ConsumoReportes _objConsumoReportes = new ConsumoReportes();
        CParametros _objCParametros = new CParametros();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var lstPersona60 = _objConsumoRegistroProd.Persona(60);
                var lstPersona30 = _objConsumoRegistroProd.Persona(30);
                var lstCompanias = _objConsumoRegistroProd.ObtenerListaCompania();
                var lstParametroSuc = _objConsumoRegistroProd.ParametroA("id_suc");

                var lstAnios = _objCParametros.GetListSAnio();
                var lstMeses = _objCParametros.GetListSMeses();

                var lstReporteComisiones = _objCParametros.GetListReporteComisiones();

                #region Comisiones Eje

                cmbCarteraEje.DataSource = lstPersona60;
                cmbCarteraEje.ValueField = "id_per";
                cmbCarteraEje.TextField = "nomraz";
                cmbCarteraEje.DataBind();
                var itemSelecCarteraEje = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCarteraEje.Items.Add(itemSelecCarteraEje);
                //cmbCarteraEje.SelectedIndex = 0;

                cmbSucursalEje.DataSource = lstParametroSuc;
                cmbSucursalEje.ValueField = "id_par";
                cmbSucursalEje.TextField = "desc_param";
                cmbSucursalEje.DataBind();
                var itemSelecSucursalEje = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalEje.Items.Add(itemSelecSucursalEje);
                //cmbSucursalEje.SelectedIndex = 0;

                cmbEjecutivoEje.DataSource = lstPersona30;
                cmbEjecutivoEje.ValueField = "id_per";
                cmbEjecutivoEje.TextField = "nomraz";
                cmbEjecutivoEje.DataBind();
                var itemSelecEjeEje = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbEjecutivoEje.Items.Add(itemSelecEjeEje);
                // cmbEjecutivoEje.SelectedIndex = 0;

                #endregion

                #region spvs

                cmbMesSpvs.DataSource = lstMeses;
                cmbMesSpvs.ValueField = "key";
                cmbMesSpvs.TextField = "value";
                cmbMesSpvs.DataBind();
                cmbMesSpvs.SelectedIndex = 0;

                cmbAnioSpvs.DataSource = lstAnios;
                cmbAnioSpvs.ValueField = "key";
                cmbAnioSpvs.TextField = "value";
                cmbAnioSpvs.DataBind();
                cmbAnioSpvs.SelectedIndex = 0;
                #endregion

                #region Comisiones

                cmbMesCom.DataSource = lstMeses;
                cmbMesCom.ValueField = "key";
                cmbMesCom.TextField = "value";
                cmbMesCom.DataBind();
                cmbMesCom.SelectedIndex = 0;

                cmbAnioCom.DataSource = lstAnios;
                cmbAnioCom.ValueField = "key";
                cmbAnioCom.TextField = "value";
                cmbAnioCom.DataBind();
                cmbAnioCom.SelectedIndex = 0;

                cmbReporteCom.DataSource = lstReporteComisiones;
                cmbReporteCom.ValueField = "key";
                cmbReporteCom.TextField = "value";
                cmbReporteCom.DataBind();
                cmbReporteCom.SelectedIndex = 0;

                #endregion

                #region Contable

                cmbMesCont.DataSource = lstMeses;
                cmbMesCont.ValueField = "key";
                cmbMesCont.TextField = "value";
                cmbMesCont.DataBind();
                cmbMesCont.SelectedIndex = 0;

                cmbAnioCont.DataSource = lstAnios;
                cmbAnioCont.ValueField = "key";
                cmbAnioCont.TextField = "value";
                cmbAnioCont.DataBind();
                cmbAnioCont.SelectedIndex = 0;

                cmbCompaniaCont.DataSource = lstCompanias;
                cmbCompaniaCont.ValueField = "id_spvs";
                cmbCompaniaCont.TextField = "nomraz";
                cmbCompaniaCont.DataBind();
                var itemSelecCompCont = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCompaniaCont.Items.Add(itemSelecCompCont);
                //cmbCompaniaCont.SelectedIndex = 0;
                #endregion

                #region Nota

                cmbCompaniaNota.DataSource = lstCompanias;
                cmbCompaniaNota.ValueField = "id_spvs";
                cmbCompaniaNota.TextField = "nomraz";
                cmbCompaniaNota.DataBind();
                var itemSelecCompNota = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCompaniaNota.Items.Add(itemSelecCompNota);
                //cmbCompaniaNota.SelectedIndex = 0;

                cmbSucursalNota.DataSource = lstParametroSuc;
                cmbSucursalNota.ValueField = "id_par";
                cmbSucursalNota.TextField = "desc_param";
                cmbSucursalNota.DataBind();
                var itemSelecSucNota = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalNota.Items.Add(itemSelecSucNota);
                //cmbSucursalNota.SelectedIndex = 0;

                #endregion

                #region Comisiones Fe

                #endregion

                divMensajeError.Visible = false;
                lblMensaje.Text = string.Empty;
            }
        }





        protected void comisionesEje_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-comisionesEje-tab";
        }
        protected void spvs_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-spvs-tab";
        }
        protected void comisiones_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-comisiones-tab";
        }
        protected void contable_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-contable-tab";
        }
        protected void nota_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-nota-tab";
        }
        protected void comisionesFe_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-comisionesFe-tab";
        }


        protected void btnGenerarReporteComisionesEje_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var ife = fechaInicioEje.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaInicioEje.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha inicial valida";
                return;
            }

            var ff = fechaFinEje.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaFinEje.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha inicial valida";
                return;
            }
            var ipc = Convert.ToString(cmbCarteraEje.SelectedItem.Value);

            if (string.IsNullOrEmpty(ipc) || ipc == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una sucursal";
                return;
            }
            var isuc = Convert.ToString(cmbSucursalEje.SelectedItem.Value);
            var ipe = Convert.ToString(cmbEjecutivoEje.SelectedItem.Value);

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=14" +   
                "&ipc=" +  ipc + 
                "&ipe=" +  ipe + 
                "&if=" +  ife + 
                "&ff=" +  ff + 
                "&is=" +  isuc
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteSpvs_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var m = Convert.ToString(cmbMesSpvs.SelectedItem.Value);
            var a = Convert.ToString(cmbAnioSpvs.SelectedItem.Value);

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=8" +
                "&m=" + m +
                "&a=" + a 
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteComisiones_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var r = Convert.ToString(cmbReporteCom.SelectedItem.Value);
            if (string.IsNullOrEmpty(r) || r == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione un tipo de reporte";
                return;
            }
            var m = Convert.ToString(cmbMesCom.SelectedItem.Value);
            var a = Convert.ToString(cmbAnioCom.SelectedItem.Value);

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=" + r + 
                "&m=" + m +
                "&a=" + a
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteContable_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var s = Convert.ToString(cmbCompaniaCont.SelectedItem.Value);
            //if (string.IsNullOrEmpty(s) || s == "0")
            //{
            //    divMensajeError.Visible = true;
            //    lblMensaje.Text = "Seleccione una compania";
            //    return;
            //}

            var m = Convert.ToString(cmbMesCont.SelectedItem.Value);
            var a = Convert.ToString(cmbAnioCont.SelectedItem.Value);

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=21"+
                "&s=" + s +
                "&m=" + m +
                "&a=" + a
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteNota_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var ife = fechaInicioNota.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaInicioNota.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha inicial valida";
                return;
            }
            var ff = fechaFinNota.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaFinNota.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha final valida";
                return;
            }
            var ipc = Convert.ToString(cmbCompaniaNota.SelectedItem.Value);
            var isuc = Convert.ToString(cmbSucursalEje.SelectedItem.Value);
           
            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=23" +
                "&if=" + ife +
                "&ff=" + ff +
                "&s=" + ipc +    
                "&is=" + isuc
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteComisionesFe_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var ife = fechaInicioComFe.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaInicioComFe.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha inicial valida";
                return;
            }
            var ff = fechaFinComfe.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaFinComfe.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha final valida";
                return;
            }
            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=26" +
                "&if=" + ife +
                "&ff=" + ff                 
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

    }
}