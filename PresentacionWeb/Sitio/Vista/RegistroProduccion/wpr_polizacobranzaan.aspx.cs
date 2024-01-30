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
    public partial class wpr_polizacobranzaan : System.Web.UI.Page
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
            re_memo_report.Visible = false;
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
        
        private void CargaInicial(long idPoliza, long idMov)
        {
            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            //para exclusion y anulacion la consulta es la misma
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
                lblGrupo.Text = objDataCompletaPoliza.objGrupo == null ? "SIN GRUPO" : objDataCompletaPoliza.objGrupo.desc_grupo;
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

                txtObservaciones.Text = objDataCompletaPoliza.objDataPoliza.mat_aseg;

                var dataPorcentual = _objConsumoRegistroProd.Porcentuales(objDataCompletaPoliza.objDataPoliza.id_mom);
                txtPrimaNeta.Text = string.Format("{0:n}", Convert.ToDecimal(txtPrimaBruta.Text.Replace(".", "").Replace(".", ",")) * dataPorcentual.por_neta);
                txtPorcentaje.Text = Convert.ToString(dataPorcentual.por_comision);
                txtComision.Text = string.Format("{0:n}", Convert.ToDecimal(txtPrimaBruta.Text.Replace(".", "").Replace(".", ",")) * dataPorcentual.por_neta * (dataPorcentual.por_comision) / 100);


                //grdCuotasPoliza.DataSource = lstCuotas;
                //grdCuotasPoliza.DataBind();

            }

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
        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarFormulario();
        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            //CalculaGrilla();
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

        protected void btnSalir_Click(object sender, EventArgs e)
        {
        }

        protected void btnMemo_Click(object sender, EventArgs e)
        {
            re_memo_report.Visible = true;
            re_memo_report.Attributes.Add("src", "https://localhost:44347/Sitio/Vista/Reportes/re_viewer.aspx?r=1");
        }
    }
}