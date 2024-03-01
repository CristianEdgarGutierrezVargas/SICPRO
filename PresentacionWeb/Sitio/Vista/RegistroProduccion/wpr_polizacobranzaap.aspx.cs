using DevExpress.Web.Bootstrap;
using DevExpress.XtraExport.Helpers;
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
    public partial class wpr_polizacobranzaap : System.Web.UI.Page
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
            if (mov == "47")
            {
                this.titulo.Text = "Datos de Poliza Aplicada (Módulo de Cobranzas)";
                //this.id_clamov.Value = "47";
            }
        }
        private void CargaInicial(long idPoliza, long idMov)
        {
            var objResponseData = _objConsumoRegistroProd.ObtenerDataCompletaPolizaAp(idPoliza, idMov);
            pr_poliza objPoliza = new pr_poliza();
            var objPolmov = new pr_polmov();
            var objResponse = objResponseData.objDataPoliza;
            if (objResponse == null)
            {
                //    var objResponseData = _objConsumoRegistroProd.GetDataVeriPoliza(idPoliza, idMov);

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
                Session["vcb_veripoliza2"] = objResponse;

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
            lblDireccion.Text = objDireccion == null? string.Empty: objDireccion.direccion;
            lblGrupo.Text = objGrupo == null? string.Empty: objGrupo.desc_grupo;
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

        private void CalculaGrilla()
        {

            //var objDataPoliza = (vcb_veripoliza2)Session["vcb_veripoliza2"];
            //for (int i = 0; i < grdCuotasPoliza.Rows.Count; i++)
            //{
            //    var txtCuotaTotal = (BootstrapSpinEdit)grdCuotasPoliza.Rows[i].Cells[2].FindControl("txtCuotaTotal");//cuota_total
            //    if (txtCuotaTotal == null)
            //    {
            //        return;
            //    }
            //    if (txtCuotaTotal.Text == "0,00")
            //    {

            //        grdCuotasPoliza.Rows[i].Cells[3].Text = "0.00";
            //        grdCuotasPoliza.Rows[i].Cells[4].Text = "0.00";
            //        //text.Text = "0,00";
            //        //str.Text = "0,00";
            //        //textBox1.Text = "0,00";
            //        return;
            //    }
            //    else
            //    {
            //        var decPrimaNeta = _objConsumoRegistroProd
            //            .Prima_Neta(objDataPoliza.id_spvs, objDataPoliza.id_poliza, objDataPoliza.id_movimiento, Convert.ToDecimal(txtNumCuotas.Text), Convert.ToDecimal(txtPrimaNeta.Text));//"0.00";
            //        //grdCuotasPoliza.Rows[i].Cells[3].Text = Convert.ToString(decPrimaNeta);
            //        var decComision = _objConsumoRegistroProd
            //            .Comision_Neta(objDataPoliza.id_spvs, objDataPoliza.id_poliza, objDataPoliza.id_movimiento, Convert.ToDecimal(txtPorcentaje.Text));//"0.00";

            //        grdCuotasPoliza.Rows[i].Cells[3].Text = Convert.ToString(decPrimaNeta);
            //        grdCuotasPoliza.Rows[i].Cells[4].Text = Convert.ToString(decComision);
            //    }
            //}

            var sumaTotal = ActualizaSessionCuotas();
            if (sumaTotal != Convert.ToDecimal(txtPrimaBruta.Text))
            {
                lblmensaje.Text = "La suma de las Cuotas debe ser igual a la prima Total";
                return;
            }

            foreach (var itemCuotaPoliza in (List<pr_cuotapoliza>)Session["LST_CUOTAS"])
            {
                var response = _objConsumoRegistroProd.ModificarCuotaPolizaC(itemCuotaPoliza);
            }
            lblmensaje.Text = "Se han registrado correctamente todos los valores para la póliza ahora puede proceder a la verificación de la misma en el módulo de comisiones";
            //int num = Convert.ToInt32(e.CommandArgument);
            //GridViewRow item = this.gridcuotas.Rows[num];
            //TextBox textBox = (TextBox)item.FindControl("fecha_pago");
            //TextBox textBox1 = (TextBox)item.FindControl("cuota_total");
            //TextBox text = (TextBox)item.FindControl("cuota_neta");
            //TextBox str = (TextBox)item.FindControl("cuota_comis");
            //TextBox textBox2 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_total");
            //TextBox textBox3 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_neta");
            //TextBox textBox4 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_comis");
            //Label label = (Label)item.FindControl("cuota");
            //if (e.CommandName == "Verificar")
            //{
            //    if (textBox1.Text == "0,00")
            //    {
            //        text.Text = "0,00";
            //        str.Text = "0,00";
            //        textBox1.Text = "0,00";
            //        return;
            //    }
            //    this.msgboxpanel.Visible = false;
            //    if (label.Text == "0" && this.id_spvs.Value == "109")
            //    {
            //        pr_cobranzas prCobranza = new pr_cobranzas()
            //        {
            //            id_spvs1 = this.id_spvs,
            //            prima_neta = this.prima_neta,
            //            por_comision = this.por_comision,
            //            num_cuota = this.num_cuota
            //        };
            //        string str1 = prCobranza.Prima_Neta1(int.Parse(this.id_poliza.Value), int.Parse(this.id_mov.Value));
            //        double num1 = Math.Round(double.Parse(str1), 2);
            //        str1 = num1.ToString();
            //        text.Text = string.Format("{0:n}", double.Parse(str1));
            //        prCobranza.comision = this.comision;
            //        string str2 = prCobranza.ComisionTotal1(int.Parse(this.id_poliza.Value), int.Parse(this.id_mov.Value), int.Parse(this.id_producto.Value));
            //        double num2 = Math.Round(double.Parse(str2), 2);
            //        str2 = num2.ToString();
            //        str.Text = string.Format("{0:n}", double.Parse(str2));
            //        return;
            //    }
            //    if (this.id_spvs.Value == "109")
            //    {
            //        text.Text = textBox1.Text;
            //        double num3 = double.Parse(text.Text.Replace(".", "").Replace(",", "")) / 100 * double.Parse(this.por_comision.Text.Replace(".", "").Replace(",", "")) / 100;
            //        str.Text = num3.ToString();
            //        double num4 = double.Parse(str.Text) / 100;
            //        str.Text = num4.ToString();
            //        str.Text = string.Format("{0:n}", double.Parse(str.Text));
            //        return;
            //    }
            //    double num5 = double.Parse(textBox1.Text.Replace(".", "").Replace(",", ""));
            //    num5 /= 100;
            //    double num6 = double.Parse(this.prima_bruta.Text.Replace(".", "").Replace(",", ""));
            //    num6 /= 100;
            //    double num7 = double.Parse(this.prima_neta.Text.Replace(".", "").Replace(",", ""));
            //    num7 /= 100;
            //    double num8 = num5 / num6 * num7;
            //    num8 = Math.Round(num8, 2);
            //    text.Text = string.Format("{0:n}", num8);
            //    double num9 = num8 * (double.Parse(this.por_comision.Text.Replace(".", ",")) / 100);
            //    num9 = Math.Round(num9, 2);
            //    str.Text = string.Format("{0:n}", num9);
            //    return;
            //}
        }
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
                itemSession.cuota_total = Convert.ToDecimal(cuotaTotal == null? "0" : cuotaTotal.Text);
                itemSession.cuota_neta = Convert.ToDecimal(cuotaNeta == null ? "0" : cuotaNeta.Text);
                itemSession.cuota_comis = Convert.ToDecimal(cuotaComis == null ? "0" : cuotaComis.Text);

                montoTotalSuma += Convert.ToDecimal(cuotaTotal.Text);
            }
            Session["LST_CUOTAS"] = lstCuotasSession;
            return montoTotalSuma;
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarFormulario();
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_listaapli.aspx", false);
        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            CalculaGrilla();                   
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
            var objVeriPoliza2 = (vcb_veripoliza2)Session["vcb_veripoliza2"];
            var idPoliza = objVeriPoliza2.id_poliza;
            var idMovimiento = objVeriPoliza2.id_movimiento;
            //re_memo_report.Visible = true;
            //re_memo_report.Attributes.Add("src", "https://localhost:44347/Sitio/Vista/Reportes/re_viewer.aspx?r=1");
            //ifrReport.Visible = true;

            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=1" +
                "&p=" + idPoliza +
                "&m=" + idMovimiento
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void grdCuotasPoliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = grdCuotasPoliza.SelectedIndex;
            var dtFechaPago = (BootstrapDateEdit)grdCuotasPoliza.Rows[index].Cells[1].FindControl("dtFechaPago");
            var txtCuotaTotal = (BootstrapSpinEdit)grdCuotasPoliza.Rows[index].Cells[2].FindControl("txtCuotaTotal");
            var txtCuotaNeta = (BootstrapSpinEdit)grdCuotasPoliza.Rows[index].Cells[3].FindControl("txtCuotaNeta");
            var txtComision = (BootstrapSpinEdit)grdCuotasPoliza.Rows[index].Cells[4].FindControl("txtComision");


        }


    }
}