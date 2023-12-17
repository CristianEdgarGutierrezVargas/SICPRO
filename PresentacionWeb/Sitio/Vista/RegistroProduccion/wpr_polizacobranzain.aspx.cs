using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizacobranzain : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.IsPostBack && base.Request.QueryString["var"] != "")
            {
                long idPoliza = Convert.ToInt64(base.Request.QueryString["var"]);
                long idMov = Convert.ToInt64(base.Request.QueryString["val"]);
                string mov = Convert.ToString(base.Request.QueryString["ver"]);
                Movimiento(mov);
                //this.Buscar(num, num1);
                //this.id_poliza.Value = num.ToString();
                //this.id_mov.Value = num1.ToString();

                CargaInicial(idPoliza, idMov);
            }
            
        }

        #region Metodos

        private void Movimiento(string mov)
        {
            if (mov == "44")
            {
                titulo.Text = "Datos de Poliza Incluida (Módulo de Cobranzas)";
                //this.id_clamov.Value = "44";
            }
        }
        private void CargaInicial(long idPoliza, long idMov)
        {
            var objResponse = _objConsumoRegistroProd.ObtenerPolizaI(idPoliza, idMov);
            pr_poliza objPoliza = new pr_poliza();
            var objPolmov = new pr_polmov();
            if (objResponse == null)
            {
                var objResponseData = _objConsumoRegistroProd.GetDataVeriPoliza(idPoliza, idMov);

                Session["vcb_veripoliza1"] = objResponseData;

                objPoliza.id_poliza = objResponseData.id_poliza;
                objPoliza.num_poliza = objResponseData.num_poliza;
                objPoliza.id_producto = objResponseData.id_producto;
                objPoliza.id_perclie = objResponseData.id_perclie;
                objPoliza.id_spvs = objResponseData.id_spvs;
                objPoliza.id_gru = objResponseData.id_gru;
                objPoliza.clase_poliza = objResponseData.clase_poliza;
                objPoliza.estado = objResponseData.estado;
                objPoliza.fc_reg = objResponseData.fc_recepcion;
                objPoliza.id_percart = objResponseData.id_percart;
                //objPoliza.id_suc = objResponse.id_suc;

                objPolmov.id_poliza = objResponseData.id_poliza;
                objPolmov.id_movimiento = objResponseData.id_movimiento;
                objPolmov.id_perejec = objResponseData.id_perejec;
                objPolmov.fc_emision = objResponseData.fc_emision;
                objPolmov.fc_inivig = objResponseData.fc_inivig;

                objPolmov.fc_finvig = objResponseData.fc_finvig;
                objPolmov.prima_bruta = objResponseData.prima_bruta;
                objPolmov.prima_neta = objResponseData.prima_neta;
                objPolmov.por_comision = objResponseData.por_comision;
                objPolmov.comision = objResponseData.comision;

                objPolmov.id_div = objResponseData.id_div;
                objPolmov.tipo_cuota = objResponseData.tipo_cuota;
                objPolmov.num_cuota = objResponseData.num_cuota;
                objPolmov.id_clamov = objResponseData.id_poliza;
                //objPolmov.estado = objResponse.estado;

                objPolmov.id_dir = objResponseData.id_dir;
                objPolmov.fc_recepcion = objResponseData.fc_recepcion;
                objPolmov.mat_aseg = objResponseData.mat_aseg;
                //objPolmov.fc_reg = objResponse.fc_reg;
                objPolmov.no_liquida = objResponseData.no_liquida;
                objPolmov.id_mom = objResponseData.id_mom;
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

                var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
                cmbEjecutivo.DataSource = lstFuncionarios;
                cmbEjecutivo.TextField = "nomraz";
                cmbEjecutivo.ValueField = "id_per";
                cmbEjecutivo.DataBind();

                var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
                cmbEjecutivo.Items.Add(itemLstFuncionarios);

                fc_emision.Date = objPolmov.fc_emision;
                fc_recepcion.Date = objPolmov.fc_recepcion;
                fc_inivig.Date = objPolmov.fc_inivig;
                lblfc_finvig.Text = objPolmov.fc_finvig.ToShortDateString();

                lblNroPoliza.Text = objPoliza.num_poliza;
                txtNroLiquidacion.Text = objPolmov.no_liquida;
                lblAsegurado.Text = objPersona.nomraz;
                lblDireccion.Text = objDireccion.direccion;
                lblGrupo.Text = objGrupo.desc_grupo;
                //lblCiaAseg.Text = ;

                lblProducto.Text = objProducto.desc_prod;

                var itemFuncionario = cmbEjecutivo.Items.FindByValue(objPolmov.id_perejec);
                if (itemFuncionario != null)
                {
                    cmbEjecutivo.SelectedItem = itemFuncionario;
                }
                lblAgente.Text = objPersonaAgente.nomraz;
                lblTipoPoliza.Text = objPoliza.clase_poliza == true ? "Normal" : "Flotante";
                txtPrimaBruta.Text = Convert.ToString(objPolmov.prima_bruta);
                txtNumCuotas.Text = Convert.ToString(objPolmov.num_cuota);
                lblDivisa.Text = objParametroDivisa.desc_param;

                txtMatAseg.Text = objPolmov.mat_aseg;

                grdCuotasPoliza.DataSource = lstCuotas;
                grdCuotasPoliza.DataBind();
            
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarFormulario();
        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            //var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);
            //var lstCuotas = GetDataCuotas(numeroCuotas);
            //Session["LST_CUOTAS"] = lstCuotas;

            //grdCuotasPoliza.DataSource = lstCuotas;
            //grdCuotasPoliza.DataBind();

            ////int id = 0;
            ////lstCoutasTest.ForEach(s =>
            ////{
            ////    s.id_movimiento = 3;                
            ////    s.cuota = id++;
            ////});           
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            //pr_cobranzas prCobranza = new pr_cobranzas()
            //{
            //    id_spvs1 = this.id_spvs,
            //    prima_bruta = this.prima_bruta,
            //    id_producto = this.id_producto,
            //    tipo_cuota = this.tipo_cuota
            //};
            var objPoliza = (pr_poliza)Session["POLIZA"];
            var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

            var id_spvs = objPoliza.id_spvs;
            var prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text);
            var id_producto = objPoliza.id_producto;
            var tipo_cuota = objPolmov.tipo_cuota;// true = contado, false=credito

            txtPrimaNeta.Text = _objConsumoRegistroProd.Calculo2(prima_bruta, id_producto, id_spvs, tipo_cuota).ToString();
            txtPorcentaje.Text = _objConsumoRegistroProd.Porco1(id_producto, id_spvs).ToString();
            txtComision.Text = _objConsumoRegistroProd.Com3(prima_bruta, id_producto, id_spvs, tipo_cuota).ToString();
            //double.Parse(this.prima_neta.Text);
            //this.prima_neta.Text = string.Format("{0:n}", double.Parse(this.prima_neta.Text));
            //this.por_comision.Text = string.Format("{0:n}", double.Parse(this.por_comision.Text));
            //this.comision.Text = string.Format("{0:n}", double.Parse(this.comision.Text));
        }
    }
}