using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EntidadesClases.CustomModelEntities.OC_DATA_FORM;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizacobranzaea : System.Web.UI.Page
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
                btnMemo.Visible = false;   
                pnlDatosCobranza.Visible = false;
            }
            
        }

        #region Metodos

        private void Movimiento(string mov)
        {
            if (mov == "46")
            {
                this.titulo.Text = "Datos de Poliza Excluida (Módulo de Cobranzas)";
                this.id_clamov.Value = "46";
                return;
            }
            if (mov == "49")
            {
                this.titulo.Text = "Datos de Poliza Anulada (Módulo de Cobranzas)";
                this.id_clamov.Value = "49";
            }
        }
        private void NLiquidacion(long idMom, long idPoliza)
        {
            //pr_cuotapoliza prCuotapoliza = new pr_cuotapoliza()
            //{
            //    id_poliza = this.id_poliza,
            //    no_liquida = this.num_liquida
            //};
            var lstDatosPolizaEa = _objConsumoRegistroProd.DatosPolizaEA(idMom, idPoliza);
            cmbNroLiquidacion.DataSource = lstDatosPolizaEa;
            cmbNroLiquidacion.TextField = "no_liquida";
            cmbNroLiquidacion.ValueField = "id_movimiento";
            cmbNroLiquidacion.DataBind();
            var itemNumLiq = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbNroLiquidacion.Items.Add(itemNumLiq);
        }

        private void CargaInicial(long idPoliza, long idMov)
        {
            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            var objDataCompletaPoliza = _objConsumoRegistroProd.ObtenerDataCompletaPolizaEx(idPoliza, idMov);
            Session["DATA_POLIZA"] = objDataCompletaPoliza;
            if (objDataCompletaPoliza != null)
            {
                fc_emision.Date = objDataCompletaPoliza.objDataPoliza.fc_emision;
                fc_recepcion.Date = objDataCompletaPoliza.objDataPoliza.fc_recepcion;
                fc_inivig.Date = objDataCompletaPoliza.objDataPoliza.fc_inivig;
                lblfc_finvig.Text = objDataCompletaPoliza.objDataPoliza.fc_finvig.ToShortDateString();

                lblNroPoliza.Text = objDataCompletaPoliza.objDataPoliza.num_poliza;
                txtNroLiquidacion.Text = objDataCompletaPoliza.objDataPoliza.no_liquida;
                lblAsegurado.Text = objDataCompletaPoliza.objDataPoliza.nomraz;
                lblDireccion.Text = objDataCompletaPoliza.objDataPoliza.direccion;
                lblGrupo.Text = objDataCompletaPoliza.objGrupo == null ? "SIN GRUPO": objDataCompletaPoliza.objGrupo.desc_grupo;
                //lblCiaAseg.Text = ;

                lblProducto.Text = objDataCompletaPoliza.objProducto.desc_prod;

                var itemFuncionario = cmbEjecutivo.Items.FindByValue(objDataCompletaPoliza.objDataPoliza.id_perejec);
                if (itemFuncionario != null)
                {
                    cmbEjecutivo.SelectedItem = itemFuncionario;
                }
                lblAgente.Text = objDataCompletaPoliza.objPersonaAgente.nomraz;
                lblTipoPoliza.Text = objDataCompletaPoliza.objDataPoliza.clase_poliza == true ? "Normal" : "Flotante";
                txtPrimaBruta.Text = Convert.ToString(objDataCompletaPoliza.objDataPoliza.prima_bruta);
                //txtNumCuotas.Text = Convert.ToString(objDataCompletaPoliza.objDataPoliza.num_cuota);
                lblDivisa.Text = objDataCompletaPoliza.objParametroDivisa.desc_param;

                txtMatAseg.Text = objDataCompletaPoliza.objDataPoliza.mat_aseg;

                //grdCuotasPoliza.DataSource = lstCuotas;
                //grdCuotasPoliza.DataBind();
                NLiquidacion(objDataCompletaPoliza.objDataPoliza.id_mom, idPoliza);
            }
            //pr_poliza objPoliza = new pr_poliza();
            //var objPolmov = new pr_polmov();
            //if (objResponse == null)
            //{
            //    //    var objResponseData = _objConsumoRegistroProd.GetDataVeriPoliza(idPoliza, idMov);

            //    //    Session["vcb_veripoliza1"] = objResponseData;

            //    //    objPoliza.id_poliza = objResponseData.id_poliza;
            //    //    objPoliza.num_poliza = objResponseData.num_poliza;
            //    //    objPoliza.id_producto = objResponseData.id_producto;
            //    //    objPoliza.id_perclie = objResponseData.id_perclie;
            //    //    objPoliza.id_spvs = objResponseData.id_spvs;
            //    //    objPoliza.id_gru = objResponseData.id_gru;
            //    //    objPoliza.clase_poliza = objResponseData.clase_poliza;
            //    //    objPoliza.estado = objResponseData.estado;
            //    //    objPoliza.fc_reg = objResponseData.fc_recepcion;
            //    //    objPoliza.id_percart = objResponseData.id_percart;
            //    //    //objPoliza.id_suc = objResponse.id_suc;

            //    //    objPolmov.id_poliza = objResponseData.id_poliza;
            //    //    objPolmov.id_movimiento = objResponseData.id_movimiento;
            //    //    objPolmov.id_perejec = objResponseData.id_perejec;
            //    //    objPolmov.fc_emision = objResponseData.fc_emision;
            //    //    objPolmov.fc_inivig = objResponseData.fc_inivig;

            //    //    objPolmov.fc_finvig = objResponseData.fc_finvig;
            //    //    objPolmov.prima_bruta = objResponseData.prima_bruta;
            //    //    objPolmov.prima_neta = objResponseData.prima_neta;
            //    //    objPolmov.por_comision = objResponseData.por_comision;
            //    //    objPolmov.comision = objResponseData.comision;

            //    //    objPolmov.id_div = objResponseData.id_div;
            //    //    objPolmov.tipo_cuota = objResponseData.tipo_cuota;
            //    //    objPolmov.num_cuota = objResponseData.num_cuota;
            //    //    objPolmov.id_clamov = objResponseData.id_poliza;
            //    //    //objPolmov.estado = objResponse.estado;

            //    //    objPolmov.id_dir = objResponseData.id_dir;
            //    //    objPolmov.fc_recepcion = objResponseData.fc_recepcion;
            //    //    objPolmov.mat_aseg = objResponseData.mat_aseg;
            //    //    //objPolmov.fc_reg = objResponse.fc_reg;
            //    //    objPolmov.no_liquida = objResponseData.no_liquida;
            //    //    objPolmov.id_mom = objResponseData.id_mom;
            //}
            //else
            //{
            //    Session["vcb_veripoliza1"] = objResponse;

            //    objPoliza.id_poliza = objResponse.id_poliza;
            //    objPoliza.num_poliza = objResponse.num_poliza;
            //    objPoliza.id_producto = objResponse.id_producto;
            //    objPoliza.id_perclie = objResponse.id_perclie;
            //    objPoliza.id_spvs = objResponse.id_spvs;
            //    objPoliza.id_gru = objResponse.id_gru;
            //    objPoliza.clase_poliza = objResponse.clase_poliza;
            //    objPoliza.estado = objResponse.estado;
            //    objPoliza.fc_reg = objResponse.fc_recepcion;
            //    objPoliza.id_percart = objResponse.id_percart;
            //    //objPoliza.id_suc = objResponse.id_suc;

            //    objPolmov.id_poliza = objResponse.id_poliza;
            //    objPolmov.id_movimiento = objResponse.id_movimiento;
            //    objPolmov.id_perejec = objResponse.id_perejec;
            //    objPolmov.fc_emision = objResponse.fc_emision;
            //    objPolmov.fc_inivig = objResponse.fc_inivig;

            //    objPolmov.fc_finvig = objResponse.fc_finvig;
            //    objPolmov.prima_bruta = objResponse.prima_bruta;
            //    objPolmov.prima_neta = objResponse.prima_neta;
            //    objPolmov.por_comision = objResponse.por_comision;
            //    objPolmov.comision = objResponse.comision;

            //    objPolmov.id_div = objResponse.id_div;
            //    objPolmov.tipo_cuota = objResponse.tipo_cuota;
            //    objPolmov.num_cuota = objResponse.num_cuota;
            //    objPolmov.id_clamov = objResponse.id_poliza;
            //    //objPolmov.estado = objResponse.estado;

            //    objPolmov.id_dir = objResponse.id_dir;
            //    objPolmov.fc_recepcion = objResponse.fc_recepcion;
            //    objPolmov.mat_aseg = objResponse.mat_aseg;
            //    //objPolmov.fc_reg = objResponse.fc_reg;
            //    objPolmov.no_liquida = objResponse.no_liquida;
            //    objPolmov.id_mom = objResponse.id_mom;
            //}


            //var lstCuotas = _objConsumoRegistroProd.GridCuotasC(idPoliza, idMov);
            //Session["LST_CUOTAS"] = lstCuotas;
            //Session["POLIZA"] = objPoliza;
            //Session["POLIZA_MOVIMIENTO"] = objPolmov;

            //var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            //var objPoliza = (pr_poliza)Session["POLIZA"];
            //var objPolmov = (pr_polmov)Session["POLIZA_MOVIMIENTO"];

            //var objPersona = _objConsumoRegistroProd.ObtenerPersona(objPoliza.id_perclie);
            //var objPersonaAgente = _objConsumoRegistroProd.ObtenerPersona(objPoliza.id_percart);
            //var objDireccion = _objConsumoRegistroProd.ObtenerDireccion(objPolmov.id_dir);
            //var objGrupo = _objConsumoRegistroProd.ObtenerGrupo(objPoliza.id_gru);
            //var objProducto = _objConsumoRegistroProd.ObtenerProducto(objPoliza.id_producto);
            //var objParametroDivisa = _objConsumoRegistroProd.ObtenerParametro(objPolmov.id_div);



           

            

            
        }

        //private void CalculaGrilla()
        //{
        //    var objDataPoliza = (vcb_veripoliza1)Session["vcb_veripoliza1"];
        //    for (int i = 0; i < grdCuotasPoliza.Rows.Count; i++)
        //    {
        //        var txtCuotaTotal = (BootstrapSpinEdit)grdCuotasPoliza.Rows[i].Cells[2].FindControl("txtCuotaTotal");//cuota_total
        //        if (txtCuotaTotal == null)
        //        {
        //            return;
        //        }
        //        if (txtCuotaTotal.Text == "0,00")
        //        {

        //            grdCuotasPoliza.Rows[i].Cells[3].Text = "0.00";
        //            grdCuotasPoliza.Rows[i].Cells[4].Text = "0.00";
        //            //text.Text = "0,00";
        //            //str.Text = "0,00";
        //            //textBox1.Text = "0,00";
        //            return;
        //        }
        //        else
        //        {
        //            var decPrimaNeta = _objConsumoRegistroProd
        //                .Prima_Neta(objDataPoliza.id_spvs, objDataPoliza.id_poliza, objDataPoliza.id_movimiento, Convert.ToDecimal(txtNumCuotas.Text), Convert.ToDecimal(txtPrimaNeta.Text));//"0.00";
        //            //grdCuotasPoliza.Rows[i].Cells[3].Text = Convert.ToString(decPrimaNeta);
        //            var decComision = _objConsumoRegistroProd
        //                .Comision_Neta(objDataPoliza.id_spvs, objDataPoliza.id_poliza, objDataPoliza.id_movimiento, Convert.ToDecimal(txtPorcentaje.Text));//"0.00";

        //            grdCuotasPoliza.Rows[i].Cells[3].Text = Convert.ToString(decPrimaNeta);
        //            grdCuotasPoliza.Rows[i].Cells[4].Text = Convert.ToString(decComision);
        //        }
        //    }

        //    //int num = Convert.ToInt32(e.CommandArgument);
        //    //GridViewRow item = this.gridcuotas.Rows[num];
        //    //TextBox textBox = (TextBox)item.FindControl("fecha_pago");
        //    //TextBox textBox1 = (TextBox)item.FindControl("cuota_total");
        //    //TextBox text = (TextBox)item.FindControl("cuota_neta");
        //    //TextBox str = (TextBox)item.FindControl("cuota_comis");
        //    //TextBox textBox2 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_total");
        //    //TextBox textBox3 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_neta");
        //    //TextBox textBox4 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_comis");
        //    //Label label = (Label)item.FindControl("cuota");
        //    //if (e.CommandName == "Verificar")
        //    //{
        //    //    if (textBox1.Text == "0,00")
        //    //    {
        //    //        text.Text = "0,00";
        //    //        str.Text = "0,00";
        //    //        textBox1.Text = "0,00";
        //    //        return;
        //    //    }
        //    //    this.msgboxpanel.Visible = false;
        //    //    if (label.Text == "0" && this.id_spvs.Value == "109")
        //    //    {
        //    //        pr_cobranzas prCobranza = new pr_cobranzas()
        //    //        {
        //    //            id_spvs1 = this.id_spvs,
        //    //            prima_neta = this.prima_neta,
        //    //            por_comision = this.por_comision,
        //    //            num_cuota = this.num_cuota
        //    //        };
        //    //        string str1 = prCobranza.Prima_Neta1(int.Parse(this.id_poliza.Value), int.Parse(this.id_mov.Value));
        //    //        double num1 = Math.Round(double.Parse(str1), 2);
        //    //        str1 = num1.ToString();
        //    //        text.Text = string.Format("{0:n}", double.Parse(str1));
        //    //        prCobranza.comision = this.comision;
        //    //        string str2 = prCobranza.ComisionTotal1(int.Parse(this.id_poliza.Value), int.Parse(this.id_mov.Value), int.Parse(this.id_producto.Value));
        //    //        double num2 = Math.Round(double.Parse(str2), 2);
        //    //        str2 = num2.ToString();
        //    //        str.Text = string.Format("{0:n}", double.Parse(str2));
        //    //        return;
        //    //    }
        //    //    if (this.id_spvs.Value == "109")
        //    //    {
        //    //        text.Text = textBox1.Text;
        //    //        double num3 = double.Parse(text.Text.Replace(".", "").Replace(",", "")) / 100 * double.Parse(this.por_comision.Text.Replace(".", "").Replace(",", "")) / 100;
        //    //        str.Text = num3.ToString();
        //    //        double num4 = double.Parse(str.Text) / 100;
        //    //        str.Text = num4.ToString();
        //    //        str.Text = string.Format("{0:n}", double.Parse(str.Text));
        //    //        return;
        //    //    }
        //    //    double num5 = double.Parse(textBox1.Text.Replace(".", "").Replace(",", ""));
        //    //    num5 /= 100;
        //    //    double num6 = double.Parse(this.prima_bruta.Text.Replace(".", "").Replace(",", ""));
        //    //    num6 /= 100;
        //    //    double num7 = double.Parse(this.prima_neta.Text.Replace(".", "").Replace(",", ""));
        //    //    num7 /= 100;
        //    //    double num8 = num5 / num6 * num7;
        //    //    num8 = Math.Round(num8, 2);
        //    //    text.Text = string.Format("{0:n}", num8);
        //    //    double num9 = num8 * (double.Parse(this.por_comision.Text.Replace(".", ",")) / 100);
        //    //    num9 = Math.Round(num9, 2);
        //    //    str.Text = string.Format("{0:n}", num9);
        //    //    return;
        //    //}
        //}

        private void Calculos()
        {
            double num = double.Parse(this.txtCuotaTotal.Text.Replace(".", "").Replace(",", ".")) / 100;
            double num1 = double.Parse(this.txtCuotaTotal.Text.Replace(".", "").Replace(",", ".")) / 100;
            double num2 = 0;
            if (num > num1)
            {
                num2 = num - num1;
            }
            double num3 = 0;
            this.por_pagar.Value = num2.ToString();
            if (txtMontoExcluido.Text != "")
            {
                num3 = double.Parse(this.txtMontoExcluido.Text.Replace(".", "").Replace(",", ".")) / 100;
            }
            if (num3 > num)
            {
                this.lblmensaje.Text = "El monto excluido no debe ser mayor a Cuota Total";
                //this.msgboxpanel.Visible = true;
                //MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox1.tpl"));
                //messageBox.SetTitle("Validación de Valores");
                //messageBox.SetIcon("msg_icon_2.png");
                //messageBox.SetMessage(this.lblmensaje.Text);
                //messageBox.SetOKButton("msg_button_class1");
                //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                this.txtMontoExcluido.Text = "";
                this.txtMontoExcluido.Focus();
                return;
            }
            if (num3 == 0)
            {
                this.lblmensaje.Text = "El monto excluido debe ser distinto de cero";
                //this.msgboxpanel.Visible = true;
                //MessageBox messageBox1 = new MessageBox(base.Server.MapPath("msgbox1.tpl"));
                //messageBox1.SetTitle("Validación de Valores");
                //messageBox1.SetIcon("msg_icon_2.png");
                //messageBox1.SetMessage(this.lblmensaje.Text);
                //messageBox1.SetOKButton("msg_button_class1");
                //this.msgboxpanel.InnerHtml = messageBox1.ReturnObject();
                this.txtMontoExcluido.Text = "";
                this.txtMontoExcluido.Focus();
                return;
            }
            if (num2 < num3)
            {
                double num4 = num2 - num3;
                this.txtDevolucion.Text = string.Format("{0:n}", double.Parse(num4.ToString()));
                this.txtDevolucion.Text = this.txtDevolucion.Text.Replace("-", "");
            }
            else
            {
                this.txtDevolucion.Text = string.Format("{0:n}", double.Parse("0"));
            }
            this.btnCuotas.Visible = true;
            this.btnVerificar.Visible = false;
        }


        #endregion

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            //this.msgboxpanel.Visible = false;
            Calculos();
        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            //this.msgboxpanel.Visible = false;
            //pr_cuotapoliza prCuotapoliza = new pr_cuotapoliza();
            //double num = double.Parse(this.txtMontoExcluido.Text.Replace(".", "").Replace(",", ".")) / 100;
            //double num1 = double.Parse(this.cuota_neta.Value.Replace(".", "").Replace(",", ".")) / 100;
            //double num2 = double.Parse(this.txtCuotaTotal.Text.Replace(".", "").Replace(",", ".")) / 100;
            //double num3 = num * (num1 / num2);
            //num3 = Math.Round(num3, 2);
            //this.neta_exclusion.Value = num3.ToString();
            //double num4 = double.Parse(this.cuota_comis.Value.Replace(".", "").Replace(",", ".")) / 100;
            //double num5 = num * (num4 / num2);
            //num5 = Math.Round(num5, 2);
            //this.comision_exclusion.Value = num5.ToString();
            //double num6 = double.Parse(this.txtDevolucion.Text.Replace(".", "").Replace(",", ".")) / 100;
            //double num7 = num6 * (num1 / num2);
            //num7 = Math.Round(num7, 2);
            //this.neta_devolucion.Value = num7.ToString();
            //double num8 = num6 * (num4 / num2);
            //num8 = Math.Round(num8, 2);
            //this.comision_devolucion.Value = num8.ToString();
            //prCuotapoliza.monto_devolucion = this.monto_devolucion;
            //int num9 = int.Parse(this.cuota.SelectedValue);
            //prCuotapoliza.monto_exclusion = this.monto_exclusion;
            //prCuotapoliza.neta_exclusion = this.neta_exclusion;
            //prCuotapoliza.comision_exclusion = this.comision_exclusion;
            //prCuotapoliza.id_movimiento = this.id_mov;
            //if (this.monto_devolucion.Text == "0,00")
            //{
            //    prCuotapoliza.ModificarCuotaPolizaCEAEX(int.Parse(this.id_poliza.Value), int.Parse(this.num_liquida.SelectedValue), num9);
            //}
            //num9 = int.Parse(this.cuota.SelectedValue);
            //prCuotapoliza.monto_devolucion = this.monto_devolucion;
            //prCuotapoliza.neta_devolucion = this.neta_devolucion;
            //prCuotapoliza.comision_devolucion = this.comision_devolucion;
            //prCuotapoliza.lblmensaje = this.lblmensaje;
            //prCuotapoliza.cuota = this.cuota;
            //if (num6 != 0)
            //{
            //    prCuotapoliza.ModificarCuotaPolizaCEAEX(int.Parse(this.id_poliza.Value), int.Parse(this.num_liquida.SelectedValue), num9);
            //    prCuotapoliza.ModificarCuotaPolizaCEADE(int.Parse(this.id_poliza.Value), int.Parse(this.num_liquida.SelectedValue), num9);
            //}
            //this.Grilla();
            //this.Calcular(int.Parse(this.id_poliza.Value), int.Parse(this.id_mom.Value), int.Parse(this.id_mov.Value));
            //this.fecha_pago.Text = "";
            //this.cuota_total.Text = "";
            //this.cuota_pago.Text = "";
            //this.monto_exclusion.Text = "";
            //this.monto_devolucion.Text = "";
            //this.btnverificar.Visible = true;
            //this.lblmensaje.Text = "";




            // CalculaGrilla();
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
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            btnMemo.Visible = true;
            btnGuardar.Visible = false;
            pnlDatosCobranza.Visible = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarFormulario();
        }

        
        protected void btnSalir_Click(object sender, EventArgs e)
        {
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

        protected void btnMemo_Click(object sender, EventArgs e)
        {
            ////this.msgboxpanel.Visible = false;
            ////this.msgboxpanel.Visible = true;
            //MessageBoxButton messageBoxButton = new MessageBoxButton("Cerrar Reporte");
            ////MessageBoxButton messageBoxButton1 = new MessageBoxButton("Salir");
            //if (this.id_clamov.Value != "46")
            //{
            //    messageBoxButton.SetLocation("wpr_listaanu.aspx");
            //}
            //else
            //{
            //    messageBoxButton.SetLocation("wpr_listaexclu.aspx");
            //}
            ////messageBoxButton.SetClass("msg_button_class");
            ////messageBoxButton1.SetClass("msg_button_class");
            ////MessageBox messageBox = new MessageBox(base.Server.MapPath("msgboxrep.tpl"));
            ////messageBox.SetTitle("Visor de Reportes");
            ////string[] value = new string[] { "<iframe src='re_viewer.aspx?r=1&p=", this.id_poliza.Value, "&m=", this.id_mov.Value, "' runat='server' name='repo' width='100%' height='520' scrolling='auto' border='0' marginwidth='0' height='100%'></iframe>" };
            ////messageBox.SetMessage(string.Concat(value));
            ////messageBox.AddButton(messageBoxButton.ReturnObject());
            ////messageBox.AddButton(messageBoxButton1.ReturnObject());
            ////this.msgboxpanel.InnerHtml = messageBox.ReturnObject();

            


            var objVeriPoliza3 = (vcb_veripoliza3)Session["vcb_veripoliza3"];
            var idPoliza = objVeriPoliza3.id_poliza;
            var idMovimiento = objVeriPoliza3.id_movimiento;
            
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=1" +
                "&p=" + idPoliza +
                "&m=" + idMovimiento
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }

        protected void cmbNroLiquidacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objDataCompletaPoliza = (oc_data_vcb_veripoliza3)Session["DATA_POLIZA"];

            var lstCuotaPoliza =  _objConsumoRegistroProd.ListaC(objDataCompletaPoliza.objDataPoliza.id_poliza, Convert.ToInt64(cmbNroLiquidacion.SelectedItem.Value));
            cmbNroCuotas.DataSource = lstCuotaPoliza;
            cmbNroCuotas.TextField = "cuota";
            cmbNroCuotas.ValueField = "cuota";
            cmbNroCuotas.DataBind();
            var itemLstCuotas = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbNroCuotas.Items.Add(itemLstCuotas);
        }

        protected void cmbNroCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////this.msgboxpanel.Visible = false;
            ////pr_cuotapoliza prCuotapoliza = new pr_cuotapoliza()
            ////{
            ////    fecha_pago = this.fecha_pago,
            ////    cuota_total = this.cuota_total,
            ////    cuota_neta1 = this.cuota_neta,
            ////    cuota_comis1 = this.cuota_comis,
            ////    cuota_pago = this.cuota_pago
            ////};
            //var response = _objConsumoRegistroProd.BuscarCuotaPolizaC(int.Parse(this.id_poliza.Value), int.Parse(this.num_liquida.SelectedValue), int.Parse(this.cuota.SelectedValue));
            //this.txtFechaPago.Text = this.txtFechaPago.Text.Substring(0, 10);
            //this.btnverificar.Visible = true;
            //this.txtCuotaTotal.Text = string.Format("{0:n}", double.Parse(this.txtCuotaTotal.Text));
            //this.cuota_neta.Value = string.Format("{0:n}", double.Parse(this.cuota_neta.Value));
            //this.cuota_comis.Value = string.Format("{0:n}", double.Parse(this.cuota_comis.Value));
            //this.txtMontoPago.Text = string.Format("{0:n}", double.Parse(this.txtMontoPago.Text));
            //this.txtMontoExcluido.Text = "0,00";
            //this.txtDevolucion.Text = "0,00";
            //if (this.txtMontoExcluido.Text == "")
            //{
            //    this.txtMontoExcluido.Text = "0,00";
            //}
            //if (this.txtMontoExcluido.Text == "")
            //{
            //    this.txtMontoExcluido.Text = "0,00";
            //}
        }
    }
}