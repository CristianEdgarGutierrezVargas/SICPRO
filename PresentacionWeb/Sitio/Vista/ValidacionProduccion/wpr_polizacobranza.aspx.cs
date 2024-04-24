﻿using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using DevExpress.XtraReports;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizacobranza : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack && base.Request.QueryString["var"] != "")
            {
                int num = int.Parse(base.Request.QueryString["var"]);
                int num1 = int.Parse(base.Request.QueryString["val"]);
                Movimiento(base.Request.QueryString["ver"]);
                CargaInicial(num, num1);

                id_poliza.Value = num.ToString();
                id_mov.Value = num1.ToString();
                //id_mom=
                btnCuotas.Visible = false;
                btnMemo.Visible = false;
                btnSalir.Visible = false;
                divCuotasPoliza.Visible = false;

                pnlMensaje.Visible = false;
                lblmensaje.Visible = false;
            }            
        }
        private void Movimiento(string mov)
        {
            if (mov == "42")
            {
                titulo.Text = "Datos de Poliza Nueva (Módulo de Cobranzas)";
                id_clamov.Value = "42";
                return;
            }
            if (mov == "43")
            {
                titulo.Text = "Datos de Poliza Renovada (Módulo de Cobranzas)";
                id_clamov.Value = "43";
            }
        }

        private void CalculaBtnCalcular()
        {
            var objPoliza = (pr_poliza)Session["POLIZA"];
            var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

            var id_spvs = objPoliza.id_spvs;
            var prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text);
            var id_producto = objPoliza.id_producto;
            var tipo_cuota = objPolmov.tipo_cuota;// true = contado, false=credito
            var ocCalcFrmCred = new OcCalFrmCred() {
                IdProducto = id_producto,
                IdSpvs= id_spvs,
                PrimaTotal = prima_bruta,
                TipoCuota  = tipo_cuota
            };

           // txtPrimaNeta.Text = _objConsumoValidarProd.CalcularPrimaNeta(ocCalcFrmCred).ToString();
            txtPrimaNeta.Text =Math.Round(_objConsumoRegistroProd.Calculo2(prima_bruta, id_producto, id_spvs, tipo_cuota),2).ToString();
            txtPorcentaje.Text = _objConsumoRegistroProd.Porco1(id_producto, id_spvs).ToString();
            txtComision.Text = _objConsumoRegistroProd.Com(prima_bruta, id_producto, id_spvs).ToString();
        }

        #region Metodos

        private void CargaInicial(long idPoliza, long idMov)
        {
            var objResponseData = _objConsumoRegistroProd.ObtenerDataCompletaPolizaNRI(idPoliza, idMov);

            pr_poliza objPoliza = new pr_poliza();
            var objPolmov = new pr_polmov();
            var objResponse = objResponseData.objDataPoliza;
            if (objResponse == null)
            {
                   //var objResponseData = _objConsumoRegistroProd.GetDataVeriPoliza(idPoliza, idMov);

                //    Session["vcb_veripoliza1"] = objResponseData;

                //    objPoliza.id_poliza = objResponseData.id_poliza;
                //    objPoliza.num_poliza = objResponseData.num_poliza;
                //    objPoliza.id_producto = objResponseData.id_producto;
                //    objPoliza.id_perclie = objResponseData.id_perclie;
                //    objPoliza.id_spvs = objResponseData.id_spvs;
                //    objPoliza.id_gru = objResponseData.id_gru;
                //    objPoliza.clase_poliza = objResponseData.clase_poliza;
                //    objPoliza.estado = objResponseData.estado;
                //    objPoliza.fc_reg = objResponseData.fc_recepcion;
                //    objPoliza.id_percart = objResponseData.id_percart;
                //    //objPoliza.id_suc = objResponse.id_suc;

                //    objPolmov.id_poliza = objResponseData.id_poliza;
                //    objPolmov.id_movimiento = objResponseData.id_movimiento;
                //    objPolmov.id_perejec = objResponseData.id_perejec;
                //    objPolmov.fc_emision = objResponseData.fc_emision;
                //    objPolmov.fc_inivig = objResponseData.fc_inivig;

                //    objPolmov.fc_finvig = objResponseData.fc_finvig;
                //    objPolmov.prima_bruta = objResponseData.prima_bruta;
                //    objPolmov.prima_neta = objResponseData.prima_neta;
                //    objPolmov.por_comision = objResponseData.por_comision;
                //    objPolmov.comision = objResponseData.comision;

                //    objPolmov.id_div = objResponseData.id_div;
                //    objPolmov.tipo_cuota = objResponseData.tipo_cuota;
                //    objPolmov.num_cuota = objResponseData.num_cuota;
                //    objPolmov.id_clamov = objResponseData.id_poliza;
                //    //objPolmov.estado = objResponse.estado;

                //    objPolmov.id_dir = objResponseData.id_dir;
                //    objPolmov.fc_recepcion = objResponseData.fc_recepcion;
                //    objPolmov.mat_aseg = objResponseData.mat_aseg;
                //    //objPolmov.fc_reg = objResponse.fc_reg;
                //    objPolmov.no_liquida = objResponseData.no_liquida;
                //    objPolmov.id_mom = objResponseData.id_mom;
            }
            else
            {
                Session["vcb_veripoliza1"] = objResponse;

                objPoliza.id_poliza = objResponse.id_poliza;
                objPoliza.num_poliza = objResponse.num_poliza;
                objPoliza.id_producto = objResponse.id_producto;
                objPoliza.id_perclie = objResponse.id_perclie;
                objPoliza.id_spvs = objResponse.id_spvs;
                objPoliza.id_gru = objResponse.id_gru;
                objPoliza.clase_poliza = objResponse.clase_poliza;
                objPoliza.estado = objResponse.estado;
                objPoliza.fc_reg = objResponse.fc_recepcion;
                objPoliza.id_percart = objResponse.id_percart;
                //objPoliza.id_suc = objResponse.id_suc;

                objPolmov.id_poliza = objResponse.id_poliza;
                objPolmov.id_movimiento = objResponse.id_movimiento;
                objPolmov.id_perejec = objResponse.id_perejec;
                objPolmov.fc_emision = objResponse.fc_emision;
                objPolmov.fc_inivig = objResponse.fc_inivig;

                objPolmov.fc_finvig = objResponse.fc_finvig;
                objPolmov.prima_bruta = objResponse.prima_bruta;
                objPolmov.prima_neta = objResponse.prima_neta;
                objPolmov.por_comision = objResponse.por_comision;
                objPolmov.comision = objResponse.comision;

                objPolmov.id_div = objResponse.id_div;
                objPolmov.tipo_cuota = objResponse.tipo_cuota;
                objPolmov.num_cuota = objResponse.num_cuota;
                objPolmov.id_clamov = objResponse.id_poliza;
                //objPolmov.estado = objResponse.estado;

                objPolmov.id_dir = objResponse.id_dir;
                objPolmov.fc_recepcion = objResponse.fc_recepcion;
                objPolmov.mat_aseg = objResponse.mat_aseg;
                //objPolmov.fc_reg = objResponse.fc_reg;
                objPolmov.no_liquida = objResponse.no_liquida;
                objPolmov.id_mom = objResponse.id_mom;

                //var consumoValidar= _objConsumoValidarProd.ObtenerPolizaNRI(num, num1);
                //if (consumoValidar != null)
                //{                
                fc_emision.Value = objResponse.fc_emision;
                fc_recepcion.Value = objResponse.fc_recepcion;
                fc_inivig.Value = objResponse.fc_inivig;
                fc_finvig.Value = objResponse.fc_finvig;
                txtNroPoliza.Text = objResponse.num_poliza;
                txtNroLiquidacion.Text = objResponse.no_liquida;
                nomraz.Text = objResponse.nomraz;
                id_per.Value = objResponse.id_perclie;
                desc_direccion.Text = objResponse.direccion;
                id_direccion.Value = objResponse.id_dir.ToString();
                cmbGrupo.Value = objResponse.id_gru.ToString();
                cmbCiaAseg.Value = objResponse.id_spvs;

                cmbEjecutivo.Value = objResponse.id_perejec;
                cmbAgente.Value = objResponse.id_percart.ToString();
                rbTipoPoliza.Value = objResponse.clase_poliza;
                txtPrimaBruta.Value = objResponse.prima_bruta;
                txtNumCuotas.Value = objResponse.num_cuota;
                cmbDivisa.Value = objResponse.id_div.ToString();
                tipo_cuota.Value = objResponse.tipo_cuota;
                txtMatAseg.Value = objResponse.mat_aseg;
                cmbProducto.Value = objResponse.id_producto.ToString();
                txtPrimaNeta.Value = objResponse.prima_neta.ToString();
                txtPorcentaje.Value = objResponse.por_comision.ToString();
                txtComision.Value = objResponse.comision.ToString();

                //}
            }


            var lstCuotas = _objConsumoRegistroProd.GridCuotasC(idPoliza, idMov);
            Session["LST_CUOTAS"] = lstCuotas;
            Session["POLIZA"] = objPoliza;
            Session["POLIZA_MOVIMIENTO"] = objPolmov;

            //var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            //var objPoliza = (pr_poliza)Session["POLIZA"];
            //var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

            var objPersona = _objConsumoRegistroProd.ObtenerPersona(objPoliza.id_perclie);
            var objPersonaAgente = _objConsumoRegistroProd.ObtenerPersona(objPoliza.id_percart);
            var objDireccion = _objConsumoRegistroProd.ObtenerDireccion(objPolmov.id_dir);
            var objGrupo = _objConsumoRegistroProd.ObtenerGrupo(objPoliza.id_gru);
            var objProducto = _objConsumoRegistroProd.ObtenerProducto(objPoliza.id_producto);
            var objParametroDivisa = _objConsumoRegistroProd.ObtenerParametro(objPolmov.id_div);

            var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();
            cmbGrupo.DataSource = lstGrupo;
            cmbGrupo.TextField = "desc_grupo";
            cmbGrupo.ValueField = "id_gru";
            cmbGrupo.DataBind();

            var itemLstGrupo = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbGrupo.Items.Add(itemLstGrupo);

            var itemGrupo = cmbGrupo.Items.FindByValue(Convert.ToString(objPoliza.id_gru));
            if (itemGrupo != null)
            {
                cmbGrupo.SelectedItem = itemGrupo;
            }            

            var lstProducto = _objConsumoRegistroProd.ObtenerTablaProducto(cmbCiaAseg.Value.ToString());
            cmbProducto.DataSource = lstProducto;
            cmbProducto.TextField = "desc_prod";
            cmbProducto.ValueField = "id_producto";
            cmbProducto.DataBind();

            //var lstTipoCartera = _objConsumoRegistroProd.listas1();
            //cmbTipoCartera.DataSource = lstTipoCartera;
            //cmbTipoCartera.TextField = "desc_param";
            //cmbTipoCartera.ValueField = "id_par";
            //cmbTipoCartera.DataBind();

            //var itemTipoCartera = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            //cmbTipoCartera.Items.Add(itemTipoCartera);

            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            var itemFuncionario = cmbEjecutivo.Items.FindByValue(objPolmov.id_perejec);
            if (itemFuncionario != null)
            {
                cmbEjecutivo.SelectedItem = itemFuncionario;
            }

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerListaCompania();
            cmbCiaAseg.DataSource = lstCiaAseguradora;
            cmbCiaAseg.TextField = "nomraz";
            cmbCiaAseg.ValueField = "id_spvs";
            cmbCiaAseg.DataBind();

            var itemLstCiaAseguradora = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbCiaAseg.Items.Add(itemLstCiaAseguradora);

            var itemCompañia = cmbCiaAseg.Items.FindByValue(Convert.ToString(objResponse.id_spvs));
            if (itemCompañia != null)
            {
                cmbCiaAseg.SelectedItem = itemCompañia;
            }

            var lstAgenteCartera = _objConsumoRegistroProd.Persona(60);
            cmbAgente.DataSource = lstAgenteCartera;
            cmbAgente.TextField = "nomraz";
            cmbAgente.ValueField = "id_per";
            cmbAgente.DataBind();

            var itemLstAgenteCartera = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbAgente.Items.Add(itemLstAgenteCartera);

            var itemAgente = cmbAgente.Items.FindByValue(Convert.ToString(objResponse.id_percart));
            if (itemAgente != null)
            {
                cmbAgente.SelectedItem = itemAgente;
            }

            var lstDivisa = _objConsumoRegistroProd.ParametroA("id_div");
            cmbDivisa.DataSource = lstDivisa;
            cmbDivisa.TextField = "abrev_param";
            cmbDivisa.ValueField = "id_par";
            cmbDivisa.DataBind();

            var itemLstDivisa = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbDivisa.Items.Add(itemLstDivisa);

            var itemDivisa = cmbDivisa.Items.FindByValue(Convert.ToString(objPolmov.id_div));
            if (itemDivisa != null)
            {
                cmbDivisa.SelectedItem = itemDivisa;
            }

            //var lstPersonas = _objConsumoRegistroProd.ObtenerListaPersona();
            //cmbAsegurado.DataSource = lstPersonas;
            //cmbAsegurado.TextField = "nomraz";
            //cmbAsegurado.ValueField = "id_per";
            //cmbAsegurado.DataBind();

            //var itemLstPersonas = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            //cmbAsegurado.Items.Add(itemLstPersonas);

            grdCuotasPoliza.DataSource = lstCuotas;
            grdCuotasPoliza.DataBind();
        }

        private List<pr_cuotapoliza> GetDataCuotas(double numeroCuotas)
        {
            var lstCuotas = new List<pr_cuotapoliza>();
            for (int i = 0; i < numeroCuotas; i++)
            {
                var objCuotasPoliza = new pr_cuotapoliza();
                objCuotasPoliza.cuota = i;
                objCuotasPoliza.fecha_pago = DateTime.Now;
                objCuotasPoliza.cuota_total = 0;

                lstCuotas.Add(objCuotasPoliza);
            }
            return lstCuotas;


            //var lstActual = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            //if (lstActual == null)
            //{
            //    var lstCuotas = new List<pr_cuotapoliza>();
            //    for (int i = 0; i < numeroCuotas; i++)
            //    {
            //        var objCuotasPoliza = new pr_cuotapoliza();
            //        objCuotasPoliza.cuota = i;
            //        objCuotasPoliza.fecha_pago = DateTime.Now;
            //        objCuotasPoliza.cuota_total = 0;

            //        lstCuotas.Add(objCuotasPoliza);
            //    }
            //    return lstCuotas;
            //}
            //else
            //{
            //    ActualizaSessionCuotas();
            //    if (lstActual.Count == numeroCuotas)
            //    {
            //        return lstActual;
            //    }
            //    if (lstActual.Count < numeroCuotas)
            //    {
            //        var diferencia = numeroCuotas - lstActual.Count;

            //        for (int i = 1;i < diferencia; i++)
            //        {
            //            var objCuotasPoliza = new pr_cuotapoliza();
            //            objCuotasPoliza.cuota = i + lstActual.Count;
            //            objCuotasPoliza.fecha_pago = DateTime.Now;
            //            objCuotasPoliza.cuota_total = 0;

            //            lstActual.Add(objCuotasPoliza);
            //        }
            //    }
            //    if (lstActual.Count > numeroCuotas)
            //    {
            //        var diferencia = lstActual.Count - numeroCuotas;
            //        for (int i = 0; i < diferencia; i++)
            //        {
            //            lstActual.RemoveAt(lstActual.Count - 1);
            //        }
            //        return lstActual;
            //    }
            //}
            ////Session["LST_CUOTAS"] = lstCuotas;

            ////grdCuotas.DataBind();

            //return null;
        }

        private void LimpiarFormulario()
        {
            fc_emision.Text = string.Empty;
            fc_recepcion.Text = string.Empty;
            fc_inivig.Text = string.Empty;
            fc_finvig.Text = string.Empty;
            txtNroPoliza.Text = string.Empty;
            txtNroLiquidacion.Text = string.Empty;

            //cmbAsegurado.Text = string.Empty;
            //cmbDireccion.Text = string.Empty;
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

        //private bool ActualizarCuota(long poliza, long movimiento, int cuota)
        //{
        //    var objActualizaCuota = new pr_cuotapoliza();
        //    objActualizaCuota.id_poliza = poliza;
        //    objActualizaCuota.id_movimiento = movimiento;
        //    objActualizaCuota.cuota = cuota;
        //    return _objConsumoRegistroProd.ActualizarCuotaPoliza(objActualizaCuota);
        //}

        private decimal ActualizaSessionCuotas()
        {
            var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            decimal montoTotalSuma = 0;
            foreach (GridViewRow item in grdCuotasPoliza.Rows)
            {
                var cuota = Convert.ToDecimal(item.Cells[0].Text);
                var fechaPago = item.Cells[1].FindControl("dtFechaPago") as BootstrapDateEdit;
                var cuotaTotal = item.Cells[2].FindControl("txtCuotaTotal") as BootstrapSpinEdit;
                var cuotaNeta = item.Cells[3].FindControl("txtCuotaNeta") as BootstrapSpinEdit;
                var cuotaComis = item.Cells[4].FindControl("txtComision") as BootstrapSpinEdit;
                var itemSession = lstCuotasSession.Where(w => w.cuota == cuota).FirstOrDefault();

                itemSession.fecha_pago = fechaPago.Date;
                itemSession.cuota_total = Convert.ToDecimal(cuotaTotal == null ? "0" : cuotaTotal.Text);
                itemSession.cuota_neta = Convert.ToDecimal(cuotaNeta == null ? "0" : cuotaNeta.Text);
                itemSession.cuota_comis = Convert.ToDecimal(cuotaComis == null ? "0" : cuotaComis.Text);

                montoTotalSuma += Convert.ToDecimal(cuotaTotal.Text);
            }
            Session["LST_CUOTAS"] = lstCuotasSession;
            return montoTotalSuma;
        }

        #endregion

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            CalculaBtnCalcular();
            btnCuotas.Visible = true;
            btnMemo.Visible = true;
            btnSalir.Visible = true;
            divCuotasPoliza.Visible = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("../RegistroProduccion/wpr_poliza.aspx");

        }



        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }

        protected void btnMemo_Click(object sender, EventArgs e)
        {
            var objVeriPoliza1 = (vcb_veripoliza1)Session["vcb_veripoliza1"];
            var idPoliza = objVeriPoliza1.id_poliza;
            var idMovimiento = objVeriPoliza1.id_movimiento;

            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=1" +
                "&p=" + idPoliza +
                "&m=" + idMovimiento
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
        //protected pr_cuotapoliza UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        //{
        //    var id = Convert.ToInt32(keys["cuota"]);
        //    var lstCuotas = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
        //    var item = lstCuotas.First(i => i.cuota == id);
        //    LoadNewValues(item, newValues);
        //    return item;
        //}

        //protected void LoadNewValues(pr_cuotapoliza item, OrderedDictionary values)
        //{
        //    item.id_poliza = Convert.ToInt64(values["id_poliza"]);
        //    item.id_movimiento = Convert.ToInt64(values["id_movimiento"]);
        //    item.cuota = Convert.ToDecimal(values["cuota"]);
        //    item.fecha_pago = Convert.ToDateTime(values["fecha_pago"]);
        //    item.cuota_total = Convert.ToDecimal(values["cuota_total"]);

        //    item.cuota_neta = Convert.ToDecimal(values["cuota_neta"]);
        //    item.cuota_comis = Convert.ToDecimal(values["cuota_comis"]);
        //    item.cuota_pago = Convert.ToDecimal(values["cuota_pago"]);
        //    item.cuota_comicob = Convert.ToDecimal(values["cuota_comicob"]);
        //}


        protected void id_spvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strIdSpvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerTablaProducto(strIdSpvs);
            cmbProducto.DataSource = lstCiaAseguradora;
            cmbProducto.TextField = "desc_prod";
            cmbProducto.ValueField = "id_producto";
            cmbProducto.DataBind();

            var itemLstCiaAseguradora = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbProducto.Items.Add(itemLstCiaAseguradora);
        }

        //protected void cmb_nomraz_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var strIdPer = Convert.ToString(cmbAsegurado.SelectedItem.Value);

        //    var lstDirecciones = _objConsumoRegistroProd.ObtenerDireccionesPersona(strIdPer.TrimStart().TrimEnd());
        //    cmbDireccion.DataSource = lstDirecciones;
        //    cmbDireccion.TextField = "direccion";
        //    cmbDireccion.ValueField = "id_dir";
        //    cmbDireccion.DataBind();

        //    var itemLstDirecciones = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
        //    cmbDireccion.Items.Add(itemLstDirecciones);
        //}

        //protected void btnCuotas_Click(object sender, EventArgs e)
        //{
        //    var sumaTotal = ActualizaSessionCuotas();
        //    if (sumaTotal != Convert.ToDecimal(txtPrimaBruta.Text))
        //    {
        //        lblmensaje.Text = "La suma de las Cuotas debe ser igual a la prima Total";
        //        return;
        //    }

        //    foreach (var itemCuotaPoliza in (List<pr_cuotapoliza>)Session["LST_CUOTAS"])
        //    {
        //        var response = _objConsumoRegistroProd.ModificarCuotaPolizaC(itemCuotaPoliza);
        //    }







        //    popUpConfirmacion.ShowOnPageLoad = true;
        //    lblMensajePopUpConfirmacion.Text = "Se han registrado correctamente todos los valores para la póliza ahora puede proceder a la verificación de la misma en el módulo de comisiones";

        //}
        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumCuotas.Text) || Convert.ToDecimal(txtNumCuotas.Text) == 0)
            {
                lblmensaje.Text = "El Numero de Cuotas no es valido";
                return;
            }

            var montoTotalSuma = ActualizaSessionCuotas();
            var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            if (montoTotalSuma != Convert.ToDecimal(txtPrimaBruta.Text))
            {
                grdCuotasPoliza.DataSource = lstCuotasSession;
                grdCuotasPoliza.DataBind();
                lblmensaje.Text = "La Prima total es diferente de la suma de las cuotas por favor verifique este dato";
                return;
            }
            else
            {
                //ActualizaSessionCuotas();
                //if (_objConsumoRegistroProd.ExistePol(txtNroPoliza.Text, txtNroLiquidacion.Text))
                //{
                //    lblmensaje.Text = "Datos existentes, Debe Verificar el Número de Póliza y Liquidación";
                //    return;
                //}
                //else
                //{
                //    var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);

                var objPoliza = new pr_poliza();
                objPoliza.num_poliza = txtNroPoliza.Text;
                objPoliza.id_producto = Convert.ToInt64(cmbProducto.SelectedItem.Value);
                objPoliza.id_perclie = id_per.Value;//Convert.ToString(cmbAsegurado.SelectedItem.Value);

                objPoliza.id_spvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);
                objPoliza.id_gru = Convert.ToInt64(cmbGrupo.SelectedItem.Value);
                objPoliza.clase_poliza = Convert.ToBoolean(rbTipoPoliza.SelectedItem.Value);
                objPoliza.estado = true;
                objPoliza.fc_reg = DateTime.Now;
                objPoliza.id_percart = Convert.ToString(cmbAgente.SelectedItem.Value);// Convert.ToString(cmbTipoCartera.SelectedItem.Value);

                objPoliza.id_suc = Convert.ToInt64(Session["suc"]);
                objPoliza.id_poliza = Convert.ToInt64(id_poliza.Value);

                var objResponse = _objConsumoRegistroProd.UpdatePoliza(objPoliza);

                pr_polmov prPolmov = new pr_polmov();

                prPolmov.id_poliza = Convert.ToInt64(id_poliza.Value);// objResponse.id_poliza;
                prPolmov.id_perejec = Convert.ToString(cmbEjecutivo.SelectedItem.Value);
                prPolmov.fc_emision = fc_emision.Date;
                prPolmov.fc_inivig = fc_inivig.Date;
                prPolmov.fc_finvig = fc_finvig.Date;
                prPolmov.prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text);
                prPolmov.prima_neta = Convert.ToDecimal(txtPrimaNeta.Text);
                prPolmov.por_comision = Convert.ToDecimal(txtPorcentaje.Text);
                prPolmov.comision = Convert.ToDecimal(txtComision.Text);
                prPolmov.id_div = Convert.ToInt64(cmbDivisa.SelectedItem.Value);
                //num_cuota = intNumeroCuotas,
                //prPolmov.id_clamov = Convert.ToInt64(cmbTipoCartera.SelectedItem.Value);
                prPolmov.estado = "PRODUCCION"; //this.estado,
                prPolmov.id_dir = Convert.ToInt64(id_direccion.Value);// Convert.ToInt64(cmbDireccion.SelectedItem.Value);
                prPolmov.fc_recepcion = fc_recepcion.Date;
                prPolmov.mat_aseg = txtMatAseg.Text;
                prPolmov.fc_reg = DateTime.Now;
                prPolmov.no_liquida = txtNroLiquidacion.Text;
                prPolmov.num_cuota = Convert.ToDouble(txtNumCuotas.Text);

               // prPolmov.id_mom = this.id_mom
                prPolmov.id_movimiento = Convert.ToInt64(id_mov.Value);
                //65364
                var responsePolMov = _objConsumoRegistroProd.UpdatePolizaMovimiento(prPolmov);

                //    int idx = 0;
                //    var lstCoutas = GetDataCuotas(numeroCuotas);
                lstCuotasSession.ForEach(s =>
                {
                    s.id_movimiento = Convert.ToInt64(id_mov.Value);//responsePolMov.id_movimiento;
                    s.id_poliza = objPoliza.id_poliza;
                });

                var responseSaveCuotas = _objConsumoRegistroProd.InsertarLstCuotasPoliza(lstCuotasSession);
                //}
                Session["POLIZA"] = objPoliza;
                Session["POLIZA_MOVIMIENTO"] = prPolmov;
                //Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_polizacobranzain.aspx?var=" + objPoliza.id_poliza + "&val=" + responsePolMov.id_movimiento + "&ver=0");
            }
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

        #region direccion

        protected void btnserdireccion_Click(object sender, EventArgs e)
        {
            if (nomraz.Text.Trim() == "")
            {
                //    //this.msgboxpanel.Visible = true;
                //    //MessageBox messageBox = new MessageBox(base.Server.MapPath("../msgbox1.tpl"));
                //    //messageBox.SetTitle("Validación de Datos");
                //    //messageBox.SetIcon("msg_icon_2.png");
                //    //messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>Seleccione una Compañia Existente <br />Para realizar la Busqueda de un Producto</p>");
                //    //messageBox.SetOKButton("msg_button_class1");
                //    //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                lblmensaje.Text = "Seleccione una Compañia Existente Para realizar la Busqueda de un Producto";
                return;
            }
            var lstDirecciones = _objConsumoRegistroProd.ObtenerDireccionesPersona(id_per.Value.ToUpper().TrimStart().TrimEnd())
                .Where(w => w.direccion.Contains(desc_direccion.Text.ToUpper()))
                .ToList();
            //var dt = _objConsumoValidarProd.ObtenerTablaProductoL(id_per.Value, desc_direccion.Text.ToUpper());
            Session["lstDireccion"] = lstDirecciones;
            grdDireccion.DataSource = lstDirecciones;
            grdDireccion.DataBind();

            pCDireccion.ShowOnPageLoad = true;
            ////this.msgboxpanel.Visible = true;
            ////MessageBox messageBox1 = new MessageBox(base.Server.MapPath("../msgboxprod.tpl"));
            ////messageBox1.SetTitle("Busqueda de Productos por Compañia");
            ////messageBox1.SetIcon("search_user.png");
            ////messageBox1.SetMessage(str);
            ////messageBox1.SetOKButton("msg_button_class");
            ////this.msgboxpanel.InnerHtml = messageBox1.ReturnObject();
            //a.Value = "0";
            //b.Value = "10";
        }
        protected void CallBDireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idProducto = grdDireccion.GetRowValues(Convert.ToInt32(index), "id_dir").ToString();
            var nombreProducto = grdDireccion.GetRowValues(Convert.ToInt32(index), "direccion").ToString();
            desc_direccion.Value = nombreProducto;
            id_direccion.Value = idProducto;

        }

        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            var lstDirecciones = _objConsumoRegistroProd.ObtenerDireccionesPersona(id_per.Value.ToUpper().TrimStart().TrimEnd())
                .Where(w=>w.direccion.Contains(desc_direccion.Text.ToUpper()))
                .ToList() ;
            //var dt = _objConsumoValidarProd.ObtenerTablaProductoL(id_per.Value.ToUpper(), desc_direccion1.Text.ToUpper());
            Session["lstDireccion"] = lstDirecciones;
            grdDireccion.DataSource = lstDirecciones;
            grdDireccion.DataBind();
        }

        protected void btnAceptarDireccion_Click(object sender, EventArgs e)
        {
            pCDireccion.ShowOnPageLoad = false;
        }

        protected void grdDireccion_DataBinding(object sender, EventArgs e)
        {
            grdDireccion.DataSource = Session["lstDireccion"];
        }
        #endregion

        protected void grdCuotasPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = grdCuotasPoliza.SelectedIndex;
            var intNroCuota = grdCuotasPoliza.Rows[index].Cells[0].Text;
            var dtFechaPago = (BootstrapDateEdit)grdCuotasPoliza.Rows[index].Cells[1].FindControl("dtFechaPago");
            var txtCuotaTotal = (BootstrapSpinEdit)grdCuotasPoliza.Rows[index].Cells[2].FindControl("txtCuotaTotal");
            var txtCuotaNeta = (BootstrapSpinEdit)grdCuotasPoliza.Rows[index].Cells[3].FindControl("txtCuotaNeta");
            var txtComision = (BootstrapSpinEdit)grdCuotasPoliza.Rows[index].Cells[4].FindControl("txtComision");


            var objPoliza = (pr_poliza)Session["POLIZA"];
            var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

            var id_spvs = objPoliza.id_spvs;
            var prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text);
            var prima_neta = Convert.ToDecimal(txtPrimaNeta.Text);
            var id_producto = objPoliza.id_producto;
            var tipo_cuota = objPolmov.tipo_cuota;// true = contado, false=credito

            //txtPrimaNeta.Text = Math.Round(_objConsumoRegistroProd.Calculo2(prima_bruta, id_producto, id_spvs, tipo_cuota), 2).ToString();
            //txtPorcentaje.Text = _objConsumoRegistroProd.Porco1(id_producto, id_spvs).ToString();
            //txtComision.Text = _objConsumoRegistroProd.Com(prima_bruta, id_producto, id_spvs).ToString();

            if (intNroCuota == "0" && cmbCiaAseg.SelectedItem.Value == "109" && cmbProducto.SelectedItem.Value != "64" && cmbProducto.SelectedItem.Value != "76")
            {
                //    pr_cobranzas prCobranza = new pr_cobranzas()
                //    {
                //        id_spvs = this.id_spvs,
                //        prima_neta = this.prima_neta,
                //        por_comision = this.por_comision,
                //        num_cuota = this.num_cuota
                //    };
                var str1 = _objConsumoRegistroProd.Prima_Neta(id_spvs,objPoliza.id_poliza, objPolmov.id_movimiento, Convert.ToDecimal(intNroCuota), prima_neta);
                var num1 = Math.Round(str1, 2);

                //    str1 = num1.ToString();
                txtCuotaNeta.Text = string.Format("{0:n}", num1);
                //    prCobranza.comision = this.comision;
                var str2 = _objConsumoRegistroProd.ComisionTotal(id_spvs, id_producto, objPoliza.id_poliza, objPolmov.id_movimiento, Convert.ToDecimal(intNroCuota), prima_neta, Convert.ToDecimal(txtPorcentaje.Text));                   
                var num2 = Math.Round(double.Parse(str2), 2);

                //    str2 = num2.ToString();
                txtComision.Text = string.Format("{0:n}", num2);
                return;
            }

            if (cmbCiaAseg.SelectedItem.Value == "109" && cmbProducto.SelectedItem.Value != "64" && cmbProducto.SelectedItem.Value != "76")
            {
                //    pr_cobranzas prCobranza1 = new pr_cobranzas();
                txtCuotaNeta.Text = txtCuotaTotal.Text;
                var num3 = double.Parse(txtCuotaNeta.Text) / 100 * double.Parse(txtPorcentaje.Text) / 100;
                txtComision.Text = num3.ToString();
                var num4 = num3 / 100;
                //txtComision.Text = num4.ToString();
                txtComision.Text = string.Format("{0:n}", num4);
                return;
            }

            var num8 = (Convert.ToDecimal(txtCuotaTotal.Text) / prima_bruta) * prima_neta;
            txtCuotaNeta.Text = string.Format("{0:n}", num8);
            var num9 = num8 * (decimal.Parse(txtPorcentaje.Text) / 100);
            txtComision.Text = string.Format("{0:n}", num9);

            var sumaTotal = ActualizaSessionCuotas();
            if (sumaTotal != Convert.ToDecimal(txtPrimaBruta.Text))
            {
                lblmensaje.Text = "La suma de las Cuotas debe ser igual a la prima Total";
                return;
            }

            pr_cuotapoliza itemCuotaPoliza = new pr_cuotapoliza()
            {
                fecha_pago = dtFechaPago.Date,
                cuota_total =Convert.ToDecimal( txtCuotaTotal.Text),
                cuota_neta = Convert.ToDecimal(txtCuotaNeta.Text),
                cuota_comis = Convert.ToDecimal(txtComision.Text),
                id_poliza= objPoliza.id_poliza,
                id_movimiento= objPolmov.id_movimiento,
                cuota=Convert.ToDecimal( intNroCuota)

            };
            var response = _objConsumoRegistroProd.ModificarCuotaPolizaC(itemCuotaPoliza);
           
        }
    }
}