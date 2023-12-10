using Common;
using EntidadesClases.ModelSicPro;

using Logica.Consumo;
using PresentacionWeb.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ValidacionProduccion
{
    public partial class wpr_listacob1 : System.Web.UI.Page
    {
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        private long ll = 0;
        private long aa = 0;
        private long bb = 0;
        private long cc = 0;
        private long dd = 0;
        public static string valor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fc_finvig.Text = DateTime.Now.ToShortDateString();
                fc_inivig.Text = DateTime.Now.ToShortDateString();
                Limpiar();
                wpr_listacob1.valor = base.Request.QueryString["var"];
                id_clamov.Value = wpr_listacob1.valor;
                Datos();


            }
        }
        private void Limpiar()
        {
            id_per.Value = "";
            id_producto.Value = "0";
            id_spvs.Value = "";
        }

        private void Datos()
        {
            msgboxpanel.Visible = false;
            if (!vigencia.Checked & (num_poliza.Text == "") & (nomraz.Text == "") & (nomco.Text == "") & (desc_producto.Text == "") & !porvencer.Checked)
            {
                //msgboxpanel.Visible = true;
                //MessageBox messageBox = new MessageBox(base.Server.MapPath("../msgbox1.tpl"));
                //messageBox.SetTitle("Información");
                //messageBox.SetIcon("msg_icon_2.png");
                //messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>Introduzca Criterios de Búsqueda</p>");
                //messageBox.SetOKButton("msg_button_class1");
                //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                //this.lblmensaje.Text = "Introduzca Criterios de Búsqueda";
                return;
            }
            //Cpr_cobranzas prCobranza = new Cpr_cobranzas();

            string item = base.Request.QueryString["var"];
            //prCobranza.lblmensaje = this.lblmensaje;
            //prCobranza.num_poliza = this.num_poliza;
            //prCobranza.id_perclie = this.id_per;
            //prCobranza.fc_inivig = this.fc_inivig;
            //prCobranza.fc_finivig = this.fc_finvig;
            //prCobranza.fc_finvig = this.fc_polizavencida;
            //prCobranza.id_spvs1 = this.id_spvs;
            //prCobranza.id_producto = this.id_producto;
            //prCobranza.vigencia = this.vigencia;
            //prCobranza.porvencer = this.porvencer;
            //prCobranza.a = this.ap;
            //prCobranza.b = this.bp;
            //prCobranza.RecuperaTablaPolizaNRI(item);

            //RecuperaTablaPolizaNRI(item);
            var dataTable = _objConsumoValidarProd.ObtenerTablaPolizaNRI(item, num_poliza.Text, id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);
            gridpoliza.DataSource = dataTable;
            gridpoliza.DataBind();
            this.gridcontainer.Visible = true;
        }

        public string RecuperaTablaPolizaNRI(string id_clamov)
        {
            string npoliza = "";
            List<vcb_veripoliza1> dt = new List<vcb_veripoliza1>();
            if (num_poliza.Text != null & (num_poliza.Text != ""))
            {
                //dt = new DataTable();
                dt = _objConsumoValidarProd.ObtenerTablaPolizaNRI(id_clamov, num_poliza.Text, id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);

                // var dt = ObtenerTablaPolizaNRI(id_clamov);
                lblmensaje.Text = "";
            }
            if (id_per.Value != null & (id_per.Value != ""))
            {
                // dt = new DataTable();
                dt = _objConsumoValidarProd.ObtenerTablaPolizaNRI(id_clamov, num_poliza.Text, id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);

                //dt = this.ObtenerTablaPolizaNRI(id_clamov);
                lblmensaje.Text = "";
            }
            if (id_spvs.Value != null & (id_spvs.Value != ""))
            {
                //dt = new DataTable();
                dt = _objConsumoValidarProd.ObtenerTablaPolizaNRI(id_clamov, num_poliza.Text, id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);

                // dt = this.ObtenerTablaPolizaNRI(id_clamov);
                lblmensaje.Text = "";
            }
            if (id_producto.Value != "0")
            {
                // dt = new DataTable();
                dt = _objConsumoValidarProd.ObtenerTablaPolizaNRI(id_clamov, num_poliza.Text, id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);

                //dt = this.ObtenerTablaPolizaNRI(id_clamov);
                lblmensaje.Text = "";
            }
            if (vigencia.Checked & fc_inivig.Text != null & (fc_inivig.Text != "") & fc_finvig.Text != null & (fc_finvig.Text != ""))
            {
                // dt = new DataTable();
                dt = _objConsumoValidarProd.ObtenerTablaPolizaNRI(id_clamov, num_poliza.Text, id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);

                // dt = this.ObtenerTablaPolizaNRI(id_clamov);
                lblmensaje.Text = "";
            }
            if (porvencer.Checked & (fc_finvig.Text != "") & fc_finvig.Text != null)
            {
                //dt = new DataTable();
                dt = _objConsumoValidarProd.ObtenerTablaPolizaNRI(id_clamov, num_poliza.Text, id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);

                //dt = this.ObtenerTablaPolizaNRI(id_clamov);
                lblmensaje.Text = "";
            }
            decimal l2 = dt.Count / 10;
            npoliza = "<div class=\"gridcontainer\" style=\"width: 390px\">";
            npoliza = string.Concat(npoliza, "<table class=\"grid\" width=\"390\" cellpadding=\"0\" cellspacing=\"0\">");
            npoliza = string.Concat(npoliza, "<caption>Polizas Encontradas</caption>");
            npoliza = string.Concat(npoliza, "<tr><th scope=\"col\" style=\"width:75px;\">N° Poliza</th>");
            npoliza = string.Concat(npoliza, "<th style=\"width:165px;\">Cliente</th>");
            npoliza = string.Concat(npoliza, "<th style=\"width:75px;\">Ini. Vigencia</th>");
            npoliza = string.Concat(npoliza, "<th style=\"width:75px;\">Fin Vigencia</th></tr>");
            decimal num = Math.Floor(l2);
            ll = int.Parse(num.ToString()) * 10;
            if (dt.Count < 10)
            {
                b.Value = dt.Count.ToString();
                bb = dt.Count;
                aa = 0;
                cc = 0;
                dd = dt.Count;
            }
            else if (int.Parse(b.Value) < 10)
            {
                b.Value = "10";
                bb = 10;
                cc = -10;
                a.Value = "0";
                aa = 0;
                dd = 0;
            }
            var i = 0;
            // for (int i = int.Parse(a.Value); i <= int.Parse(b.Value) - 1; i++)
            foreach (var data in dt)
            {
                object obj = npoliza;
                object[] str = new object[] { obj, "<tr OnMouseOut=\"this.className = this.orignalclassName;\" OnMouseOver=\"this.orignalclassName = this.className;this.className = 'altoverow';\" onDblClick=\"AbrirPoliza('", data.id_poliza.ToString(), "', '", data.id_movimiento.ToString(), "', '", id_clamov, "');\" onclick=\"toggleDisplay('", i, "');\">" };
                npoliza = string.Concat(str);
                npoliza = string.Concat(npoliza, "<td><font color=\"#336699\" style=\" font-weight:bold ; size:10px\">");
                npoliza = string.Concat(npoliza, data.num_poliza.ToString());
                npoliza = string.Concat(npoliza, "</font></td>");
                npoliza = string.Concat(npoliza, "<td><font color=\"#336699\" size:10px\">");
                npoliza = string.Concat(npoliza, data.nomraz.ToString());
                npoliza = string.Concat(npoliza, "</font></td>");
                npoliza = string.Concat(npoliza, "<td><font color=\"#336699\" size:10px\">");
                npoliza = string.Concat(npoliza, data.fc_inivig.ToString().Substring(0, 10));
                npoliza = string.Concat(npoliza, "</font></td>");
                npoliza = string.Concat(npoliza, "<td><font color=\"#336699\" size:10px\">");
                npoliza = string.Concat(npoliza, data.fc_finvig.ToString().Substring(0, 10));
                npoliza = string.Concat(npoliza, "</font></td>");
                npoliza = string.Concat(npoliza, "</tr>");
                object obj1 = npoliza;
                object[] objArray = new object[] { obj1, "<tr><td colspan=\"6\" align=\"center\" valign=\"baseline\" style=\"display:none\" id=\"", i, "\"><iframe allowtransparency=\"true\" name=\"", i, "\" width=\"100%\" frameborder=\"0\" height=\"170\" scrolling=\"yes\" align=\"middle\" src = \"wpr_datospolizac.aspx?var=", data.id_poliza.ToString(), "&val=", data.id_movimiento.ToString(), "&ver=", id_clamov, "\"></iframe></td></tr>" };
                npoliza = string.Concat(objArray);
                i++;
            }
            npoliza = string.Concat(npoliza, "</table>");
            npoliza = string.Concat(npoliza, "</div>");
            aa = int.Parse(b.Value);
            if (aa + 10 <= dt.Count - 1)
            {
                bb = aa + 10;
            }
            else
            {
                bb = dt.Count - 1;
            }
            cc = aa - 20;
            dd = bb - 20;
            int l3 = dt.Count;
            if (dt.Count >= 10)
            {
                if (int.Parse(a.Value) == 0)
                {
                    npoliza = string.Concat(npoliza, "<div class=\"gridcontainer\" style=\"width: 390px\"><div style=\"width: 390px\" class=\"pagerstyle\"><center><a href='#' ><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página Desactivado' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                    npoliza = string.Concat(npoliza, "<a href='#' ><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página Desactivado' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                    object obj2 = npoliza;
                    object[] objArray1 = new object[] { obj2, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = ", aa, "; document.forms.aspnetForm.ctl00_cpmaster_bp.value = ", bb, ";fp(); '><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página'/></a>&nbsp;&nbsp;" };
                    npoliza = string.Concat(objArray1);
                    object obj3 = npoliza;
                    object[] objArray2 = new object[] { obj3, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = ", ll, "; document.forms.aspnetForm.ctl00_cpmaster_bp.value = ", l3, ";fp(); '><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página'/></a></center></div></div>" };
                    npoliza = string.Concat(objArray2);
                }
                else if (int.Parse(this.a.Value) != this.ll)
                {
                    npoliza = string.Concat(npoliza, "<div class=\"gridcontainer\" style=\"width: 390px\"><div style=\"width: 390px\" class=\"pagerstyle\"><center><a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = 0; document.forms.aspnetForm.ctl00_cpmaster_bp.value = 10;fp(); '><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                    object obj4 = npoliza;
                    object[] objArray3 = new object[] { obj4, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = ", this.cc, "; document.forms.aspnetForm.ctl00_cpmaster_bp.value = ", this.dd, ";fp(); '><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;" };
                    npoliza = string.Concat(objArray3);
                    object obj5 = npoliza;
                    object[] objArray4 = new object[] { obj5, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = ", this.aa, "; document.forms.aspnetForm.ctl00_cpmaster_bp.value = ", this.bb, ";fp(); '><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página' /></a>&nbsp;&nbsp;" };
                    npoliza = string.Concat(objArray4);
                    object obj6 = npoliza;
                    object[] objArray5 = new object[] { obj6, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = ", this.ll, "; document.forms.aspnetForm.ctl00_cpmaster_bp.value = ", l3, ";fp(); '><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página' /></a></center></div></div>" };
                    npoliza = string.Concat(objArray5);
                }
                else
                {
                    npoliza = string.Concat(npoliza, "<div class=\"gridcontainer\" style=\"width: 390px\"><div style=\"width: 390px\" class=\"pagerstyle\"><center><a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = 0; document.forms.aspnetForm.ctl00_cpmaster_bp.value = 10;fp(); '><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                    object obj7 = npoliza;
                    object[] objArray6 = new object[] { obj7, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_ap.value = ", this.cc, "; document.forms.aspnetForm.ctl00_cpmaster_bp.value = ", this.dd, ";fp(); '><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;" };
                    npoliza = string.Concat(objArray6);
                    npoliza = string.Concat(npoliza, "<a href='#' ><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página Desactivado' /></a>&nbsp;&nbsp;");
                    npoliza = string.Concat(npoliza, "<a href='#' ><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página Desactivado' /></a></center></div></div>");
                }
            }
            return npoliza;
        }

        protected void btnserprod_Click(object sender, EventArgs e)
        {
            if (nomco.Text == "")
            {
                //this.msgboxpanel.Visible = true;
                //MessageBox messageBox = new MessageBox(base.Server.MapPath("../msgbox1.tpl"));
                //messageBox.SetTitle("Validación de Datos");
                //messageBox.SetIcon("msg_icon_2.png");
                //messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>Seleccione una Compañia Existente <br />Para realizar la Busqueda de un Producto</p>");
                //messageBox.SetOKButton("msg_button_class1");
                //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                //lblmensaje.Text = "Seleccione una Compañia Existente Para realizar la Busqueda de un Producto";
                return;
            }
            //pr_producto prProducto = new pr_producto()
            //{
            //    a = this.a,
            //    b = this.b
            //};
            string str = TablaProductoL(id_spvs.Value, desc_producto.Text.ToUpper());
            //this.msgboxpanel.Visible = true;
            //MessageBox messageBox1 = new MessageBox(base.Server.MapPath("../msgboxprod.tpl"));
            //messageBox1.SetTitle("Busqueda de Productos por Compañia");
            //messageBox1.SetIcon("search_user.png");
            //messageBox1.SetMessage(str);
            //messageBox1.SetOKButton("msg_button_class");
            //this.msgboxpanel.InnerHtml = messageBox1.ReturnObject();
            a.Value = "0";
            b.Value = "10";
        }
        public string TablaProductoL(string var1, string desc_prod)
        {
            string str;
            try
            {
                // DataTable dt = new DataTable();
                string var = "";
                var dt = _objConsumoValidarProd.ObtenerTablaProductoL(var1, desc_prod);
                decimal l2 = dt.Count / 10;
                var = "<div class=\"gridcontainer\" style=\"width: 350px\">";
                var = string.Concat(var, "<table class=\"grid\" width=\"350\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
                var = string.Concat(var, "<caption>Lista de Productos</caption>");
                decimal num = Math.Floor(l2);
                this.ll = int.Parse(num.ToString()) * 10;
                if (dt.Count < 10)
                {
                    this.b.Value = dt.Count.ToString();
                    this.bb = dt.Count;
                    this.aa = 0;
                    this.cc = 0;
                    this.dd = dt.Count;
                }
                else if (int.Parse(this.b.Value) < 10)
                {
                    this.b.Value = "10";
                    this.bb = 10;
                    this.cc = -10;
                    this.a.Value = "0";
                    this.aa = 0;
                    this.dd = 0;
                }
                //for (int i = int.Parse(this.a.Value); i <= int.Parse(this.b.Value) - 1; i++)
                foreach (var data in dt)
                {
                    string str1 = var;
                    string[] strArrays = new string[] { str1, "<tr OnMouseOut=\"this.className = this.orignalclassName;\" OnMouseOver=\"this.orignalclassName = this.className;this.className = 'altoverow';\" onclick=\"mClk1('", data.id_producto.ToString(), "','", data.desc_prod.ToString(), "');\"><td >" };
                    var = string.Concat(strArrays);
                    var = string.Concat(var, "<font color=\"#336699\" style=\" font-weight:bold ; size:12px\">");
                    var = string.Concat(var, data.desc_prod.ToString());
                    var = string.Concat(var, "</font></td></tr>");
                }
                var = string.Concat(var, "</table></div>");
                this.aa = int.Parse(this.b.Value);
                if (this.aa + 10 <= dt.Count - 1)
                {
                    this.bb = this.aa + 10;
                }
                else
                {
                    this.bb = dt.Count - 1;
                }
                this.cc = this.aa - 20;
                this.dd = this.bb - 20;
                int l3 = dt.Count;
                if (dt.Count >= 10)
                {
                    if (int.Parse(this.a.Value) == 0)
                    {
                        var = string.Concat(var, "<div class=\"gridcontainer\" style=\"width: 350px\"><div style=\"width: 350px\" class=\"pagerstyle\"><center><a href='#' ><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página Desactivado' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                        var = string.Concat(var, "<a href='#' ><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página Desactivado' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                        object obj = var;
                        object[] objArray = new object[] { obj, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.aa, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.bb, ";fpr(); '><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página'/></a>&nbsp;&nbsp;" };
                        var = string.Concat(objArray);
                        object obj1 = var;
                        object[] objArray1 = new object[] { obj1, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.ll, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", l3, ";fpr(); '><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página'/></a></center></div></div>" };
                        var = string.Concat(objArray1);
                    }
                    else if (int.Parse(this.a.Value) != this.ll)
                    {
                        var = string.Concat(var, "<div class=\"gridcontainer\" style=\"width: 350px\"><div style=\"width: 350px\" class=\"pagerstyle\"><center><a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = 0; document.forms.aspnetForm.ctl00_cpmaster_b.value = 10;fpr(); '><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                        object obj2 = var;
                        object[] objArray2 = new object[] { obj2, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.cc, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.dd, ";fpr(); '><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;" };
                        var = string.Concat(objArray2);
                        object obj3 = var;
                        object[] objArray3 = new object[] { obj3, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.aa, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.bb, ";fpr(); '><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página' /></a>&nbsp;&nbsp;" };
                        var = string.Concat(objArray3);
                        object obj4 = var;
                        object[] objArray4 = new object[] { obj4, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.ll, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", l3, ";fpr(); '><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página' /></a></center></div></div>" };
                        var = string.Concat(objArray4);
                    }
                    else
                    {
                        var = string.Concat(var, "<div class=\"gridcontainer\" style=\"width: 350px\"><div style=\"width: 350px\" class=\"pagerstyle\"><center><a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = 0; document.forms.aspnetForm.ctl00_cpmaster_b.value = 10;fpr(); '><input type=\"submit\" class=\"pagfirst\" value=\"\" title='Primera Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;");
                        object obj5 = var;
                        object[] objArray5 = new object[] { obj5, "<a href='#' onclick='document.forms.aspnetForm.ctl00_cpmaster_a.value = ", this.cc, "; document.forms.aspnetForm.ctl00_cpmaster_b.value = ", this.dd, ";fpr(); '><input type=\"submit\" class=\"pagprev\" value=\"\" title='Anterior Página' style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" /></a>&nbsp;&nbsp;" };
                        var = string.Concat(objArray5);
                        var = string.Concat(var, "<a href='#' ><input type=\"submit\" value=\"\" class=\"pagnext\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Siguiente Página Desactivado' /></a>&nbsp;&nbsp;");
                        var = string.Concat(var, "<a href='#' ><input type=\"submit\" value=\"\" class=\"paglast\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;\" title='Última Página Desactivado' /></a></center></div></div>");
                    }
                }
                str = var;
            }
            catch (SecureExceptions secureException)
            {
                throw new SecureExceptions("Error", secureException);
            }
            return str;
        }
        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            Datos();
        }
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            this.msgboxpanel.Visible = false;
            base.Response.Redirect(string.Concat("~/wpr_listacob1.aspx?var=", wpr_listacob1.valor));
        }

        protected void btnsercom_Click(object sender, EventArgs e)
        {
            gr_compania grCompanium = new gr_compania();
            //DataTable dataTable = new DataTable();
            //dataTable = grCompanium.ObtenerTablaCompania(this.nomco.Text.ToUpper());
            //string str = "";
            //str = "<div class=\"gridcontainer\" style=\"width: 350px\">";
            //str = string.Concat(str, "<table class=\"grid\" width=\"350\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
            //str = string.Concat(str, "<caption>Lista de Compañias</caption>");
            //for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            //{
            //    string str1 = str;
            //    string[] strArrays = new string[] { str1, "<tr OnMouseOut=\"this.className = this.orignalclassName;\" OnMouseOver=\"this.orignalclassName = this.className;this.className = 'altoverow';\" onclick=\"mClk('", dataTable.Rows[i][0].ToString(), "','", dataTable.Rows[i][1].ToString(), "');\"><td >" };
            //    str = string.Concat(strArrays);
            //    str = string.Concat(str, "<font color=\"#336699\" style=\" font-weight:bold ; size:12px\">");
            //    str = string.Concat(str, dataTable.Rows[i][1].ToString());
            //    str = string.Concat(str, "</font></td></tr>");
            //}
            //str = string.Concat(str, "</table>");
            //str = string.Concat(str, "</div>");
            //this.msgboxpanel.Visible = true;
            //MessageBox messageBox = new MessageBox(base.Server.MapPath("msgboxco.tpl"));
            //messageBox.SetTitle("Busqueda de Compañias por Nombre o Razón Social");
            //messageBox.SetIcon("search_user.png");
            //messageBox.SetMessage(str);
            //messageBox.SetOKButton("msg_button_class");
            //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
        }

        protected void btnserper_Click(object sender, EventArgs e)
        {

            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz.Text.ToUpper());
            Session["lstPersonas"]= dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();
          
            pCPersona.ShowOnPageLoad = true;
           

        }





        protected void CallBPersona_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
                var idPer = grdPersonas.GetRowValues(Convert.ToInt32(index), "id_per").ToString();
                var nombre = grdPersonas.GetRowValues(Convert.ToInt32(index), "nomraz").ToString();
                nomraz.Value = nombre;
                id_per.Value = idPer;
            
        }

        protected void btnserper1_Click(object sender, EventArgs e)
        {
            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz1.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();
            grdPersonas.FocusedRowIndex = -1;


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            pCPersona.ShowOnPageLoad = false;
        }

        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            grdPersonas.DataSource = Session["lstPersonas"];
        }
    }
}