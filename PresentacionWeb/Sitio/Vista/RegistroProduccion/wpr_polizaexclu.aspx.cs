﻿using DevExpress.Web.Bootstrap;
using EntidadesClases.CustomModelEntities;
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
    public partial class wpr_polizaexclu : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        internal void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && base.Request.QueryString["var"] != "")
            {
                int idPoliza = int.Parse(base.Request.QueryString["var"]);
                int idMovimiento = int.Parse(base.Request.QueryString["val"]);
                this.Buscar(idPoliza, idMovimiento);
                //this.fc_reg.Value = DateTime.Today.Date.ToShortDateString();
                pnlCuotas.Visible = false;
            }
        }

        #region Metodos

        private void Buscar(int par1, int par2)
        {
            try
            {
                var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
                cmbEjecutivo.DataSource = lstFuncionarios;
                cmbEjecutivo.TextField = "nomraz";
                cmbEjecutivo.ValueField = "id_per";
                cmbEjecutivo.DataBind();

                var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
                cmbEjecutivo.Items.Add(itemLstFuncionarios);
                var objDataCompletaPoliza = _objConsumoRegistroProd.ObtenerDataCompletaPolExcluvar(par1, par2);
                Session["DATA_POLIZA"] = objDataCompletaPoliza;
                if (objDataCompletaPoliza != null)
                {
                    lblNroPoliza.Text = objDataCompletaPoliza.objPoliza.num_poliza;

                    txtNroLiquidacion.Text = string.Empty;
                    lblAsegurado.Text = objDataCompletaPoliza.objPersona.nomraz;
                    lblDireccion.Text = objDataCompletaPoliza.objDireccion == null ? string.Empty : objDataCompletaPoliza.objDireccion.direccion;
                    lblGrupo.Text = objDataCompletaPoliza.objGrupo == null ? string.Empty : objDataCompletaPoliza.objGrupo.desc_grupo;

                    lblProducto.Text = objDataCompletaPoliza.objProducto.desc_prod;

                    var itemFuncionario = cmbEjecutivo.Items.FindByValue(objDataCompletaPoliza.objPoliza.id_perejec);
                    if (itemFuncionario != null)
                    {
                        cmbEjecutivo.SelectedItem = itemFuncionario;
                    }

                    lblAgente.Text = objDataCompletaPoliza.objPersonaAgente.nomraz;
                    lblTipoPoliza.Text = objDataCompletaPoliza.objPoliza.clase_poliza == true ? "Normal" : "Flotante";
                    lblPrimaTotal.Text = Convert.ToString(objDataCompletaPoliza.objPoliza.prima_bruta);
                    txtPrimaTotalExcluida.Text = "0.0";                    
                    lblDivisa.Text = objDataCompletaPoliza.objParametroDivisa.desc_param;
                    lblDivisaExcluida.Text = objDataCompletaPoliza.objParametroDivisa.desc_param;

                    txtMatAseg.Text = string.Empty;
                    lblFinVigencia.Text = objDataCompletaPoliza.objPoliza.fc_finvig.Value.ToShortDateString();
                }

            }
            catch
            {
            }
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
        }


        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_listaexclu.aspx", false);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }


        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            //lblmensaje.Text = string.Empty;
            //if (string.IsNullOrEmpty(txtNumCuotas.Text))
            //{
            //    lblmensaje.Text = "Las cuotas no deben estar vacio";
            //    return;
            //}
            //var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);
            //if (numeroCuotas <= 0)
            //{
            //    lblmensaje.Text = "Las cuotas no debe ser 0";
            //    return;
            //}

            //var lstCuotas = GetDataCuotas(numeroCuotas);
            //Session["LST_CUOTAS"] = lstCuotas;

            //grdCuotasPoliza.DataSource = lstCuotas;
            //grdCuotasPoliza.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var objData = (OC_DATA_FORM.oc_data_vpr_polexcluvar1)Session["DATA_POLIZA"];

            var objPolizaMovimiento = new pr_polmov();
            objPolizaMovimiento.id_poliza = objData.objPoliza.id_poliza;// id_poliza.Value;
            objPolizaMovimiento.id_perejec = Convert.ToString(cmbEjecutivo.SelectedItem.Value);
            objPolizaMovimiento.fc_emision = fc_emision.Date;
            objPolizaMovimiento.fc_inivig = fc_inivig.Date;
            objPolizaMovimiento.fc_finvig = objData.objPoliza.fc_finvig.Value;// fc_finvig.Date;
            objPolizaMovimiento.prima_bruta = Convert.ToDecimal(txtPrimaTotalExcluida.Text);// objData.objPoliza.prima_bruta.Value;// Convert.ToDecimal(txtPrimaBruta.Text);
            objPolizaMovimiento.prima_neta = 0;
            objPolizaMovimiento.por_comision = 0;
            objPolizaMovimiento.id_div = objData.objPoliza.id_div;
            //objPolizaMovimiento.num_cuota = Convert.ToDouble(txtNumCuotas.Text);
            objPolizaMovimiento.id_clamov = 46;// objData.objRenovar.id_clamov;
            objPolizaMovimiento.estado = "PRODUCCION";
            objPolizaMovimiento.id_dir = objData.objPoliza.id_dir;
            objPolizaMovimiento.fc_recepcion = fc_recepcion.Date;
            objPolizaMovimiento.mat_aseg = txtMatAseg.Text;
            objPolizaMovimiento.fc_reg = DateTime.Now;
            objPolizaMovimiento.no_liquida = txtNroLiquidacion.Text;
            //objPolizaMovimiento.tipo_cuota = Convert.ToBoolean(tipo_cuota.SelectedItem.Value);
            //objPolizaMovimiento.id_mom = objData.;

            //var lstCuotas = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];

            var response = _objConsumoRegistroProd.InsertarPolizaMovEx(objPolizaMovimiento);

            if (response == null)
            {
                lblmensaje.Text = "Ocurrio un error";
                return;
            }
            var idPoliza = objPolizaMovimiento.id_poliza;
            var idMovimiento = objPolizaMovimiento.id_movimiento;
            var idClaMov = objPolizaMovimiento.id_clamov;
            Response.Redirect("../RegistroProduccion/wpr_polizacobranzaea.aspx?var=" + idPoliza + "&val=" + idMovimiento + "&ver=" + idClaMov);
        }
    }
}