using DevExpress.Web.Bootstrap;
using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PresentacionWeb.Sitio.Vista.ModuloCobranzas
{
    public partial class wpr_amortizacuota : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        ConsumoCobranza conCobranza = new ConsumoCobranza();
        bool sw = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Combos();
            }
        }
        private void Combos()
        {
            try

            {
                var sucursal = _objConsumoRegistroProd.ObtenerLista("id_tpago");
                id_tpago.DataSource = sucursal;
                id_tpago.TextField = "desc_param";
                id_tpago.ValueField = "id_par";
                id_tpago.DataBind();

            }
            catch
            {
            }
        }

        protected void btnserper1_Click(object sender, EventArgs e)
        {

            var dt = _objValidarProd.ObtenerTablaPersonasC(nomraz.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();

            pCPersona.ShowOnPageLoad = true;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BootstrapButton button = sender as BootstrapButton;
            var container = button.NamingContainer as GridViewDataItemTemplateContainer;
            string[] valores = container.KeyValue.ToString().Split('|');


            var idPer = valores[0];
            var nomRaz = valores[1];
            id_per.Value = idPer;
            nomraz.Text = nomRaz;
            Polizas();
            pCPersona.ShowOnPageLoad = false;
        }
        private void Polizas()
        {
            var lstPoliza = conCobranza.ObtenerPoliza(id_per.Value);
            num_poliza.DataSource = lstPoliza;
            num_poliza.TextField = "num_poliza";
            num_poliza.ValueField = "id_poliza";
            num_poliza.DataBind();


        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            pCPersona.ShowOnPageLoad = false;
        }


        protected void btnrec_Click(object sender, EventArgs e)
        {
            //if (this.id_tpago.Value.ToString() == "69")
            //{
            //    pr_amortizaciones prAmortizacione = new pr_amortizaciones();
            //    DataTable dataTable = prAmortizacione.ObtenerRD(this.id_tpago.SelectedValue, this.id_per.Value, this.id_gru.Value, 85);
            //    string str = "";
            //    str = "<div class=\"gridcontainer\" style=\"width: 350px\">";
            //    str = string.Concat(str, "<table class=\"grid\" width=\"350\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
            //    str = string.Concat(str, "<caption>Lista</caption>");
            //    str = string.Concat(str, "<tr><th scope='col'>N° de Recibo</th>");
            //    str = string.Concat(str, "<th scope='col'>Monto Resto</th>");
            //    str = string.Concat(str, "<th scope='col'>Año Recibo</th>");
            //    str = string.Concat(str, "<th>Liquida.</th></tr>");
            //    for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            //    {
            //        string str1 = str;
            //        string[] strArrays = new string[] { str1, "<tr OnMouseOut=\"this.className = this.orignalclassName;\" OnMouseOver=\"this.orignalclassName = this.className;this.className = 'altoverow';\" onclick=\"mClk('", dataTable.Rows[i][0].ToString(), "','", string.Format("{0:n}", double.Parse(dataTable.Rows[i][1].ToString())), "','", dataTable.Rows[i][2].ToString(), "','", dataTable.Rows[i][3].ToString(), "');\">" };
            //        str = string.Concat(strArrays);
            //        str = string.Concat(str, "<td>");
            //        str = string.Concat(str, dataTable.Rows[i][0].ToString());
            //        str = string.Concat(str, "</td>");
            //        str = string.Concat(str, "<td>");
            //        str = string.Concat(str, string.Format("{0:n}", double.Parse(dataTable.Rows[i][1].ToString())));
            //        str = string.Concat(str, "</td>");
            //        str = string.Concat(str, "<td>");
            //        str = string.Concat(str, dataTable.Rows[i][2].ToString());
            //        str = string.Concat(str, "</td>");
            //        str = string.Concat(str, "<td>");
            //        str = string.Concat(str, dataTable.Rows[i][3].ToString());
            //        str = string.Concat(str, "</td>");
            //        str = string.Concat(str, "</tr>");
            //    }
            //    str = string.Concat(str, "</table></div>");
            //    this.msgboxpanel.Visible = true;
            //    MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox.tpl"));
            //    messageBox.SetTitle("Busqueda de Montos de Recibos o Compensación");
            //    messageBox.SetIcon("search_user.png");
            //    messageBox.SetMessage(str);
            //    messageBox.SetOKButton("msg_button_class");
            //    this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
            //    return;
            //}
            //if (this.id_tpago.SelectedValue != "70")
            //{
            //    this.id_liq.Value = "0";
            //    this.msgboxpanel.Visible = true;
            //    MessageBox messageBox1 = new MessageBox(base.Server.MapPath("msgbox1.tpl"));
            //    messageBox1.SetTitle("Información");
            //    messageBox1.SetIcon("msg_icon_2.png");
            //    messageBox1.SetMessage("<p style='color:#990000; font-weight:bold'>Solo se Habilita si Selecciona Recibos o Compensación</p>");
            //    messageBox1.SetOKButton("msg_button_class1");
            //    this.msgboxpanel.InnerHtml = messageBox1.ReturnObject();
            //    return;
            //}
            //pr_amortizaciones prAmortizacione1 = new pr_amortizaciones();
            //DataTable dataTable1 = prAmortizacione1.ObtenerRD(this.id_tpago.SelectedValue, this.id_per.Value, "0", 85);
            //string str2 = "";
            //str2 = "<div class=\"gridcontainer\" style=\"width: 350px\">";
            //str2 = string.Concat(str2, "<table class=\"grid\" width=\"350\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
            //str2 = string.Concat(str2, "<caption>Lista</caption>");
            //str2 = string.Concat(str2, "<tr><th scope='col'>N° de Recibo</th>");
            //str2 = string.Concat(str2, "<th scope='col'>Monto Resto</th>");
            //str2 = string.Concat(str2, "<th scope='col'>Año Recibo</th></tr>");
            //for (int j = 0; j <= dataTable1.Rows.Count - 1; j++)
            //{
            //    string str3 = str2;
            //    string[] strArrays1 = new string[] { str3, "<tr OnMouseOut=\"this.className = this.orignalclassName;\" OnMouseOver=\"this.orignalclassName = this.className;this.className = 'altoverow';\" onclick=\"mClk('", dataTable1.Rows[j][0].ToString(), "','", string.Format("{0:n}", double.Parse(dataTable1.Rows[j][1].ToString())), "','", dataTable1.Rows[j][2].ToString(), "','0');\">" };
            //    str2 = string.Concat(strArrays1);
            //    str2 = string.Concat(str2, "<td>");
            //    str2 = string.Concat(str2, dataTable1.Rows[j][0].ToString());
            //    str2 = string.Concat(str2, "</td>");
            //    str2 = string.Concat(str2, "<td>");
            //    str2 = string.Concat(str2, string.Format("{0:n}", double.Parse(dataTable1.Rows[j][1].ToString())));
            //    str2 = string.Concat(str2, "</td>");
            //    str2 = string.Concat(str2, "<td>");
            //    str2 = string.Concat(str2, dataTable1.Rows[j][2].ToString());
            //    str2 = string.Concat(str2, "</td>");
            //    str2 = string.Concat(str2, "</tr>");
            //}
            //str2 = string.Concat(str2, "</table>");
            //this.msgboxpanel.Visible = true;
            //MessageBox messageBox2 = new MessageBox(base.Server.MapPath("msgbox.tpl"));
            //messageBox2.SetTitle("Busqueda de Montos de Recibos o Compensación");
            //messageBox2.SetIcon("search_user.png");
            //messageBox2.SetMessage(str2);
            //messageBox2.SetOKButton("msg_button_class");
            //this.msgboxpanel.InnerHtml = messageBox2.ReturnObject();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("wpr_amortizacuota.aspx");
        }

        protected void b1_Click(object sender, EventArgs e)
        {
           
            if (this.id_perclie.Value == "" || this.id_perclie.Value == null)
            {
                this.Polizas();
                return;
            }
            base.Response.Redirect("wpr_amortizacuota.aspx");
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
              
                if (string.IsNullOrEmpty(this.monto_pago.Text))
                {
                    str = string.Concat(str, "<br />Debe Ingresar un monto a pagar");
                    this.sw = true;
                }
                if (string.IsNullOrEmpty(this.pago_por.Text))
                {
                    str = string.Concat(str, "<br />Debe Ingresar un Concepto");
                    this.sw = true;
                }
                double num = double.Parse(this.monto_exclusion.Text.Replace(".", "").Replace(",", "")) / 100;
                double num1 = double.Parse(this.monto_pago.Text.Replace(".", "").Replace(",", "")) / 100;
                if (Math.Round(num1 + double.Parse(this.monto_devolucion.Text.Replace(".", "").Replace(",", "")) / 100 - num, 2) > 0)
                {
                    str = string.Concat(str, "<br /> La suma del monto pagado mas el monto a pagar no puede exceder el valor de la prima total ");
                    this.sw = true;
                }
                if (!this.sw)
                {
                    double num2 = double.Parse(this.cuota_neta.Value);
                    double num3 = double.Parse(this.cuota_total.Value);
                    double num4 = double.Parse(this.comision_cuota.Value);
                    if (this.monto_pago.Text.Length <= 6)
                    {
                        num1 = double.Parse(this.monto_pago.Text.Replace(".", ","));
                    }
                    else
                    {
                        num1 = double.Parse(this.monto_pago.Text.Replace(",", "").Replace(".", ""));
                        num1 /= 100;
                    }
                    double num5 = 0;
                    if (this.monto_resto.Text != "")
                    {
                        num5 = double.Parse(this.monto_resto.Text);
                        double num6 = num2 / num3 * num1;
                        double num7 = num4 / num3 * num1;
                        this.neta_pago.Value = num6.ToString();
                        this.comision_pago.Value = num7.ToString();
                    }
                    else
                    {
                        this.monto_resto.Text = "0";
                    }
                    if (this.id_tpago.Value.ToString() == "68")
                    {
                        this.anio_recibo.Value = "0";
                        this.recibo.Text = "0";
                        this.monto_resto.Text = "0";
                        //pr_amortizaciones prAmortizacione = new pr_amortizaciones()
                        //{
                        //    num_poliza = this.num_poliza,
                        //    no_liquida = this.no_liquida,
                        //    cuota = this.cuota,
                        //    recibo = this.recibo,
                        //    anio_recibo = this.anio_recibo,
                        //    monto_pago = this.monto_pago,
                        //    neta_pago = this.neta_pago,
                        //    comision_pago = this.comision_pago,
                        //    id_tpago = this.id_tpago,
                        //    pago_por = this.pago_por,
                        //    cuota_pago = this.monto_devolucion,
                        //    id_liq = this.id_liq,
                        //    lblmensaje = this.lblmensaje
                        //};
                       // prAmortizacione.Insertar();
                        this.Grilla();
                        this.Limpiar();
                        //this.polizasel();
                    }
                    else if (num1 > num5)
                    {
                        //this.lblmensaje.Text = "El monto a pagar tiene que ser menor al Monto total";
                        
                        //var messageBox = base.Server.MapPath("msgbox1.tpl");
                        //messageBox.SetTitle("Información");
                        //messageBox.SetIcon("msg_icon_2.png");
                        //messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>El monto a pagar tiene que ser menor al Monto total</p>");
                        //messageBox.SetOKButton("msg_button_class1");
                        //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                    }
                    else
                    {
                        //this.btnguardar.Enabled = false;
                        //pr_amortizaciones prAmortizacione1 = new pr_amortizaciones()
                        //{
                        //    num_poliza = this.num_poliza,
                        //    no_liquida = this.no_liquida,
                        //    cuota = this.cuota,
                        //    recibo = this.recibo,
                        //    anio_recibo = this.anio_recibo,
                        //    monto_pago = this.monto_pago,
                        //    neta_pago = this.neta_pago,
                        //    comision_pago = this.comision_pago,
                        //    id_tpago = this.id_tpago,
                        //    pago_por = this.pago_por,
                        //    cuota_pago = this.monto_devolucion,
                        //    id_liq = this.id_liq,
                        //    lblmensaje = this.lblmensaje
                        //};
                        //prAmortizacione1.Insertar();
                        this.Grilla();
                        this.Limpiar();
                    }
                }
                else
                {
                    //this.msgboxpanel.Visible = true;
                    //MessageBox messageBox1 = new MessageBox(base.Server.MapPath("msgbox1.tpl"));
                    //messageBox1.SetTitle("Validación de Datos");
                    //messageBox1.SetIcon("msg_icon_2.png");
                    //messageBox1.SetMessage(string.Concat("<span>Los siguientes valores deben ser verificados antes de proseguir<br /></span><p style='color:#990000; font-weight:bold'>", str, "</p>"));
                    //messageBox1.SetOKButton("msg_button_class1");
                    //this.msgboxpanel.InnerHtml = messageBox1.ReturnObject();
                    //this.sw = false;
                }
            }
            catch
            {
            }
        }
        private void Limpiar()
        {
            //pr_amortizaciones prAmortizacione = new pr_amortizaciones()
            //{
            //    cuota = this.cuota
            //};
            //prAmortizacione.Cuotas(int.Parse(this.num_poliza.SelectedValue), int.Parse(this.no_liquida.SelectedValue));
            this.cuota.SelectedIndex = -1;
            this.id_tpago.SelectedIndex = -1;
            this.recibo.Text = "";
            this.monto_resto.Text = "";
            this.monto_exclusion.Text = "";
            this.monto_devolucion.Text = "";
            this.monto_pago.Text = "";
            this.pago_por.Text = "";
        }
        protected void btnserper_Click(object sender, EventArgs e)
        {
            var dt = _objValidarProd.ObtenerTablaPersonasC(nomraz1.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();
        }
        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            grdPersonas.DataSource = Session["lstPersonas"];
        }

        protected void num_poliza_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                var lstLiq = conCobranza.ObtenerMovimiento(Convert.ToInt64(num_poliza.Value));

                this.no_liquida.DataSource = lstLiq;
                this.no_liquida.TextField = "no_liquida";
                this.no_liquida.ValueField = "id_movimiento";
                this.no_liquida.DataBind();


                var lstGrupo = conCobranza.ObtenerGrupoM(Convert.ToInt64(num_poliza.Value));
                id_gru.Value = lstGrupo.FirstOrDefault().id_gru.ToString();
                desc_grupo.Text = lstGrupo.FirstOrDefault().desc_grupo;
            }
            catch
            {
            }

        }

        protected void no_liquida_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {


                var lstCuotas = conCobranza.Cuotas(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value));

                this.cuota.DataSource = lstCuotas;
                this.cuota.TextField = "cuota";
                this.cuota.ValueField = "cuota";
                this.cuota.DataBind();
                this.Grilla();

            }
            catch
            {
            }
        }
        public void Grilla()
        {
            try
            {
                var lstCuotas = conCobranza.GridCuotas(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value));
                this.grdcuotas.DataSource = lstCuotas;
                this.grdcuotas.DataBind();
                grdcuotas.Visible = true;
            }
            catch
            {

            }
        }

        protected void cuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

               var vnum_poliza =Convert.ToInt64( num_poliza.Value);
               var vno_liquida = Convert.ToInt64(no_liquida.Value);
               var vcuota = Convert.ToInt64(cuota.Value);

                var datos = conCobranza.DatosCuota(vnum_poliza, vno_liquida, vcuota).FirstOrDefault();
                this.cuota_total.Value = datos.cuota_total.ToString();
                this.cuota_neta.Value = datos.cuota_neta.ToString();
                this.comision_cuota.Value = datos.cuota_comis.ToString();
                this.monto_exclusion.Text = datos.monto_exclusion.ToString();
                this.monto_devolucion.Text = datos.monto_devolucion.ToString();
            }
            catch
            {
            }

        }

        protected void id_tpago_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (this.id_tpago.Value.ToString() != "68")
            {
                this.recibo.Text = "";
                this.monto_resto.Text = "";
            }
            else
            {
                this.recibo.Text = "";
                this.monto_resto.Text = "0";
                this.id_liq.Value = "0";
                this.idliq.Text = "0";
                this.btnguardar.Enabled = true;
            }


            var vnum_poliza = Convert.ToInt64(num_poliza.Value);
            var vno_liquida = Convert.ToInt64(no_liquida.Value);
            var vcuota = Convert.ToInt64(cuota.Value);


            var datos = conCobranza.DatosCuota(vnum_poliza, vno_liquida, vcuota).FirstOrDefault();
            this.cuota_total.Value = datos.cuota_total.ToString();
            this.cuota_neta.Value = datos.cuota_neta.ToString();
            this.comision_cuota.Value = datos.cuota_comis.ToString();
            this.monto_exclusion.Text = datos.monto_exclusion.ToString();
            this.monto_devolucion.Text = datos.monto_devolucion.ToString();

        }
    }
}