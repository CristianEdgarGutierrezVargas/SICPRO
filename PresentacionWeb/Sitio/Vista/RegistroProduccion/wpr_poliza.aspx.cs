using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Reflection.Emit;
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
            cmbGrupo.DataSource = lstGrupo;
            cmbGrupo.TextField = "desc_grupo";
            cmbGrupo.ValueField = "id_gru";
            cmbGrupo.DataBind();

            var itemLstGrupo = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbGrupo.Items.Add(itemLstGrupo);

            var lstTipoCartera = _objConsumoRegistroProd.listas1();
            cmbTipoCartera.DataSource = lstTipoCartera;
            cmbTipoCartera.TextField = "desc_param";
            cmbTipoCartera.ValueField = "id_par";
            cmbTipoCartera.DataBind();

            var itemTipoCartera = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbTipoCartera.Items.Add(itemTipoCartera);

            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerListaCompania();
            cmbCiaAseg.DataSource = lstCiaAseguradora;
            cmbCiaAseg.TextField = "nomraz";
            cmbCiaAseg.ValueField = "id_spvs";
            cmbCiaAseg.DataBind();

            var itemLstCiaAseguradora = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbCiaAseg.Items.Add(itemLstCiaAseguradora);


            var lstAgenteCartera = _objConsumoRegistroProd.Persona(60);
            cmbAgente.DataSource = lstAgenteCartera;
            cmbAgente.TextField = "nomraz";
            cmbAgente.ValueField = "id_per";
            cmbAgente.DataBind();

            var itemLstAgenteCartera = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbAgente.Items.Add(itemLstAgenteCartera);

            var lstDivisa = _objConsumoRegistroProd.ParametroA("id_div");
            cmbDivisa.DataSource = lstDivisa;
            cmbDivisa.TextField = "abrev_param";
            cmbDivisa.ValueField = "id_par";
            cmbDivisa.DataBind();

            var itemLstDivisa = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbDivisa.Items.Add(itemLstDivisa);


            var lstPersonas = _objConsumoRegistroProd.ObtenerListaPersona();
            cmbAsegurado.DataSource = lstPersonas;
            cmbAsegurado.TextField = "nomraz";
            cmbAsegurado.ValueField = "id_per";
            cmbAsegurado.DataBind();

            var itemLstPersonas = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbAsegurado.Items.Add(itemLstPersonas);
        }

        private List<pr_cuotapoliza> GetDataCuotas(double numeroCuotas)
        {
            var lstCuotas = new List<pr_cuotapoliza>();
            for (int i = 0; i < numeroCuotas; i++)
            {
                var objCuotasPoliza = new pr_cuotapoliza();
                objCuotasPoliza.cuota = i;
                objCuotasPoliza.fecha_pago = DateTime.Now;
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
            txtNroPoliza.Text = string.Empty;
            txtNroLiquidacion.Text = string.Empty;

            cmbAsegurado.Text = string.Empty;
            cmbDireccion.Text = string.Empty;
            cmbGrupo.SelectedItem = cmbGrupo.Items.FindByValue("");

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

        private bool ActualizarCuota(long poliza, long movimiento, int cuota)
        {
            var objActualizaCuota = new pr_cuotapoliza();
            objActualizaCuota.id_poliza = poliza;
            objActualizaCuota.id_movimiento = movimiento;
            objActualizaCuota.cuota = cuota;
            return _objConsumoRegistroProd.ActualizarCuotaPoliza(objActualizaCuota);
        }
        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            int id = 0;
            var lstCoutasTest = GetDataCuotas(2);
            lstCoutasTest.ForEach(s =>
            {
                s.id_movimiento = 3;                
                s.cuota = id++;
            });
            grdCuotasPoliza.DataSource = lstCoutasTest;
            grdCuotasPoliza.DataBind();

            return;
            if (_objConsumoRegistroProd.ExistePol(txtNroPoliza.Text, txtNroLiquidacion.Text))
            {

            }
            else
            {
                var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);

                var objPoliza = new pr_poliza();
                objPoliza.num_poliza = txtNroPoliza.Text;
                objPoliza.id_producto = Convert.ToInt64(cmbProducto.SelectedItem.Value);
                objPoliza.id_perclie = Convert.ToString(cmbAsegurado.SelectedItem.Value);
                objPoliza.id_spvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);
                objPoliza.id_gru = Convert.ToInt64(cmbGrupo.SelectedItem.Value);
                objPoliza.clase_poliza = Convert.ToBoolean(rbTipoPoliza.SelectedItem.Value);
                objPoliza.estado = true;
                objPoliza.fc_reg = DateTime.Now;
                objPoliza.id_percart = Convert.ToString(cmbTipoCartera.SelectedItem.Value);

                objPoliza.id_suc = Convert.ToInt64(Session["suc"]);

                var objResponse = _objConsumoRegistroProd.InsertarPoliza(objPoliza);

                pr_polmov prPolmov = new pr_polmov()
                {
                    id_poliza = objResponse.id_poliza,
                    id_perejec = Convert.ToString(cmbEjecutivo.SelectedItem.Value),
                    fc_emision = fc_emision.Date,
                    fc_inivig = fc_inivig.Date,
                    fc_finvig = fc_finvig.Date,
                    prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text),
                    //prima_neta =  this.prima_neta,
                    //por_comision = this.por_comision,
                    //comision = this.comision,
                    id_div = Convert.ToInt64(cmbDivisa.SelectedItem.Value),
                    //num_cuota = intNumeroCuotas,
                    id_clamov = Convert.ToInt64(cmbTipoCartera.SelectedItem.Value),
                    //estado = this.estado,
                    id_dir = Convert.ToInt64(cmbDireccion.SelectedItem.Value),
                    fc_recepcion = fc_recepcion.Date,
                    mat_aseg = txtMatAseg.Text,
                    fc_reg = DateTime.Now,
                    no_liquida = txtNroLiquidacion.Text,
                    //id_mom = this.id_mom
                };

                var responsePolMov = _objConsumoRegistroProd.InsertarPolizaMovimiento(prPolmov);

                int idx = 0;
                var lstCoutas = GetDataCuotas(numeroCuotas);
                lstCoutas.ForEach(s =>
                {
                    s.id_movimiento = responsePolMov.id_movimiento;
                    s.cuota = idx ++;                    
                });

                var responseSaveCuotas = _objConsumoRegistroProd.InsertarLstCuotasPoliza(lstCoutas);
            }



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

            throw new Exception("The Qty Required must be greater than 0 to update.");



            grdCuotas.Settings.ShowTitlePanel = true;
            grdCuotas.SettingsText.Title = "CHANGES ARE DONE";

            UpdateItem(e.Keys, e.NewValues);
            CancelEditing(e);
            //throw new CustomExceptions.MyException("Editing is disabled. Please log in as administrator.");

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('There was an error');", true);

            //grdCuotas.CancelEdit();

            //RowUpdating batch mode


            //UpdateItem(e.Keys, e.NewValues);
            //CancelEditing(e);
        }

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    //if there is an error
        //    if (errorFound == true)
        //    {
        //        //cancel the edit by setting editindex to -1 and rebind the grid
        //        GridView1.EditIndex = -1;
        //        BindData();

        //        //display the error in a label placed outside the grid
        //        Label1.Text = "There was an error";
        //        Label1.Visible = true;

        //        //or display javascript error message
        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('There was an error');", true);

        //        //or do not set the editindex back to -1, but show an error in the edititem template itself
        //        GridViewRow row = GridView1.Rows[e.RowIndex];
        //        Label label = row.FindControl("Label2") as Label;
        //        label.Text = "There was an error in the textbox";
        //        label.Visible = true;
        //    }
        //}
        protected pr_cuotapoliza UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            var id = Convert.ToInt32(keys["cuota"]);
            var lstCuotas = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            var item = lstCuotas.First(i => i.cuota == id);
            LoadNewValues(item, newValues);
            return item;
        }
        
        protected void LoadNewValues(pr_cuotapoliza item, OrderedDictionary values)
        {
            item.id_poliza = Convert.ToInt64(values["id_poliza"]);
            item.id_movimiento = Convert.ToInt64(values["id_movimiento"]);
            item.cuota = Convert.ToDecimal(values["cuota"]);
            item.fecha_pago = Convert.ToDateTime(values["fecha_pago"]);
            item.cuota_total = Convert.ToDecimal(values["cuota_total"]);

            item.cuota_neta = Convert.ToDecimal(values["cuota_neta"]);
            item.cuota_comis = Convert.ToDecimal(values["cuota_comis"]);
            item.cuota_pago = Convert.ToDecimal(values["cuota_pago"]);
            item.cuota_comicob = Convert.ToDecimal(values["cuota_comicob"]);
        }

        protected void CancelEditing(CancelEventArgs e)
        {
            e.Cancel = true;
            grdCuotas.CancelEdit();
        }

        protected void id_spvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strIdSpvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerTablaProducto(strIdSpvs);
            cmbProducto.DataSource = lstCiaAseguradora;
            cmbProducto.TextField = "desc_prod";
            cmbProducto.ValueField = "id_producto";
            cmbProducto.DataBind();

            var itemLstCiaAseguradora = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbProducto.Items.Add(itemLstCiaAseguradora);
        }

        protected void cmb_nomraz_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strIdPer = Convert.ToString(cmbAsegurado.SelectedItem.Value);

            var lstDirecciones = _objConsumoRegistroProd.ObtenerDireccionesPersona(strIdPer.TrimStart().TrimEnd());
            cmbDireccion.DataSource = lstDirecciones;
            cmbDireccion.TextField = "direccion";
            cmbDireccion.ValueField = "id_dir";
            cmbDireccion.DataBind();

            var itemLstDirecciones = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbDireccion.Items.Add(itemLstDirecciones);
        }

        protected void btnCuotasPoliza_Click(object sender, EventArgs e)
        {
            var lstCuotasSession = (List<pr_cuotapoliza>) Session["LST_CUOTAS"];
            foreach (GridViewRow item in grdCuotasPoliza.Rows)
            {
                var cuota = Convert.ToDecimal(item.Cells[0].Text);
                var fechaPago = item.Cells[1].FindControl("dtFechaPago") as ASPxDateEdit;
                var cuotaTotal = item.Cells[2].FindControl("txtCuotaTotal") as ASPxSpinEdit;
                var itemSession = lstCuotasSession.Where(w => w.cuota == cuota).FirstOrDefault();

                itemSession.fecha_pago = fechaPago.Date;
                itemSession.cuota_total = Convert.ToDecimal(cuotaTotal.Text);

            }
            Session["LST_CUOTAS"] = lstCuotasSession;
            grdCuotasPoliza.DataSource = lstCuotasSession;
            grdCuotasPoliza.DataBind();
        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{

        //    var objPoliza = new pr_poliza();
        //    objPoliza.num_poliza = txtNroPoliza.Text;
        //    objPoliza.id_perclie = Convert.ToString(cmbAsegurado.SelectedItem.Value);
        //    objPoliza.id_gru = Convert.ToInt64(cmbGrupo.SelectedItem.Value);
        //    objPoliza.id_spvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);
        //    objPoliza.id_producto = Convert.ToInt64(cmbProducto.SelectedItem.Value);
        //    objPoliza.id_percart = Convert.ToString(cmbTipoCartera.SelectedItem.Value);
        //    //objPoliza.clase_poliza = rbTipoPoliza.SelectedItem.Value;
        //    //objPoliza.fc_reg = DateTime.Now;
        //    //objPoliza.id_suc = "";

        //}


    }
}