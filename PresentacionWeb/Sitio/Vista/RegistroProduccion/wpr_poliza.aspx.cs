using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_poliza : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridViewFeaturesHelper.SetupGlobalGridViewBehavior(Grid);
            //DemoHelper.Instance.PrepareControlOptions(OptionsFormLayout, new ControlOptionsSettings
            //{
            //    ColumnMinWidth = 380,
            //    RightBlockWidth = 410,
            //    ColumnCountMode = RecalculateColumnCountMode.RootGroup
            //});

            //Grid.SettingsPager.Mode = (GridViewPagerMode)Enum.Parse(typeof(GridViewPagerMode), PagerModeCombo.Text, true);
            //grdCuotas.SettingsEditing.BatchEditSettings.EditMode = (GridViewBatchEditMode)Enum.Parse(typeof(GridViewBatchEditMode), "Row", true);
            //grdCuotas.SettingsEditing.BatchEditSettings.StartEditAction = (GridViewBatchStartEditAction)Enum.Parse(typeof(GridViewBatchStartEditAction), "Click", true);
            //grdCuotas.SettingsEditing.BatchEditSettings.HighlightDeletedRows = true;
            //grdCuotas.SettingsEditing.BatchEditSettings.KeepChangesOnCallbacks = false;

            if (IsPostBack)
            {
                return;
            }
            CargaInicial();
        }

        #region Metodos

        private void CargaInicial()
        {
            var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();
            id_gru.DataSource = lstGrupo;
            id_gru.TextField = "desc_grupo";
            id_gru.ValueField = "id_gru";
            id_gru.DataBind();

            var itemLstGrupo = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_gru.Items.Add(itemLstGrupo);

            var lstTipoCartera = _objConsumoRegistroProd.listas1();
            id_clamov1.DataSource = lstTipoCartera;
            id_clamov1.TextField = "desc_param";
            id_clamov1.ValueField = "id_par";
            id_clamov1.DataBind();

            var itemTipoCartera = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_clamov1.Items.Add(itemTipoCartera);

            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            id_perejec.DataSource = lstFuncionarios;
            id_perejec.TextField = "nomraz";
            id_perejec.ValueField = "id_per";
            id_perejec.DataBind();

            var itemLstFuncionarios = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_perejec.Items.Add(itemLstFuncionarios);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerListaCompania();
            id_spvs.DataSource = lstCiaAseguradora;
            id_spvs.TextField = "nomraz";
            id_spvs.ValueField = "id_spvs";
            id_spvs.DataBind();

            var itemLstCiaAseguradora = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_spvs.Items.Add(itemLstCiaAseguradora);


            var lstAgenteCartera = _objConsumoRegistroProd.Persona(60);
            id_percart.DataSource = lstAgenteCartera;
            id_percart.TextField = "nomraz";
            id_percart.ValueField = "id_per";
            id_percart.DataBind();

            var itemLstAgenteCartera = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_percart.Items.Add(itemLstAgenteCartera);

            var lstDivisa = _objConsumoRegistroProd.ParametroA("id_div");
            id_div.DataSource = lstDivisa;
            id_div.TextField = "abrev_param";
            id_div.ValueField = "id_par";
            id_div.DataBind();

            var itemLstDivisa = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_div.Items.Add(itemLstDivisa);
        }

        private List<pr_cuotapoliza> GetDataCuotas(int numeroCuotas)
        {
            var lstCuotas = new List<pr_cuotapoliza>();
            for (int i = 0; i < numeroCuotas; i++)
            {
                var objCuotasPoliza = new pr_cuotapoliza();
                objCuotasPoliza.cuota = i;
                objCuotasPoliza.fecha_pago = null;
                objCuotasPoliza.cuota_total = null;

                lstCuotas.Add(objCuotasPoliza);
            }
            Session["LST_CUOTAS"] = lstCuotas;

            grdCuotas.DataBind();

            return lstCuotas;
        }

        private void LimpiarFormulario()
        {
            fc_emision.Text = string.Empty;
            fc_recepcion.Text = string.Empty;
            fc_inivig.Text = string.Empty;
            fc_finvig.Text = string.Empty;
            num_poliza.Text = string.Empty;
            no_liquida.Text = string.Empty;

            nomraz.Text = string.Empty;
            direccion.Text = string.Empty;
            id_gru.SelectedItem = id_gru.Items.FindByValue("");

            //this.id_per.Text = string.Empty;
            //this.nomraz.Text = string.Empty;
            //this.fechaNacimiento.Text = string.Empty;
            //this.nit_fac.Text = string.Empty;

            //cmb_id_suc.SelectedItem = cmb_id_suc.Items.FindByValue(0);
            //cmb_id_sal.SelectedItem = cmb_id_sal.Items.FindByValue(Convert.ToInt64(0));
            //cmb_tipodoc.SelectedItem = cmb_tipodoc.Items.FindByValue(Convert.ToInt64(0));
            //cmb_tper.SelectedItem = cmb_tper.Items.FindByValue(Convert.ToInt64(0));
            //cmb_id_rol.SelectedItem = cmb_id_rol.Items.FindByValue(Convert.ToInt64(0));
            //cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(Convert.ToInt64(0));

            //btnDirecciones.Visible = false;
            //btnNuevo.Visible = false;
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            var intNumeroCuotas = Convert.ToInt32(num_cuota.Text);
            GetDataCuotas(intNumeroCuotas);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }

        protected void grdCuotas_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];

            if (lstData != null)
            {
                grdCuotas.DataSource = lstData;
            }
        }

        protected void grdCuotas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //RowUpdating batch mode
        }

        protected void id_spvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strIdSpvs = Convert.ToString(id_spvs.SelectedItem.Value);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerTablaProducto(strIdSpvs);
            id_producto.DataSource = lstCiaAseguradora;
            id_producto.TextField = "desc_prod";
            id_producto.ValueField = "id_producto";
            id_producto.DataBind();

            var itemLstCiaAseguradora = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_producto.Items.Add(itemLstCiaAseguradora);
        }
    }
}