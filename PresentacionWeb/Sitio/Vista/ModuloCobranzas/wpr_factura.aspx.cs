using DevExpress.ClipboardSource.SpreadsheetML;
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

namespace PresentacionWeb.Sitio.Vista.ModuloCobranzas
{
    public partial class wpr_factura : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        ConsumoCobranza conCobranza = new ConsumoCobranza();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Combo();
            }
        }
        private void Combo()
        {
            try
            {
                var objTablaCompania = _objValidarProd.ObtenerTablaCompania("");

                id_spvs.DataSource = objTablaCompania;
                id_spvs.TextField = "nomraz";
                id_spvs.ValueField = "id_spvs";
                id_spvs.DataBind();
            }
            catch
            {
            }
        }

        protected void id_spvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

              var lstFactura=  conCobranza.ObtenerListaF(this.id_spvs.Value.ToString());
                this.num_poliza1.DataSource = lstFactura;
                this.num_poliza1.TextField = "fanom";
                this.num_poliza1.ValueField = "num_poliza";
                this.num_poliza1.DataBind();
            }
            catch
            {

            }
        }

        protected void num_poliza1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var dataTable = conCobranza.ObtenerTablaFactura(this.id_spvs.Value.ToString(), this.num_poliza1.Value.ToString());
            if (dataTable.Count > 0)
            {
                this.grid_factura.DataSource = dataTable;
                this.grid_factura.DataBind();
                pnlGrid.Visible = true;
               //this.tr4.Visible = false;
               //  this.tr5.Visible = false;
            }
        }

       
        protected void Salir_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/Default.aspx");
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/wpr_factura.aspx");
        }

        protected void img2_Click(object sender, EventArgs e)
        {
            
                int num = Convert.ToInt32(e.CommandArgument);
                GridViewRow item = this.grid_factura.Rows[num];
                Label label = (Label)item.FindControl("num_poliza");
                Label label1 = (Label)item.FindControl("no_liquida");
                Label label2 = (Label)item.FindControl("id_perclie");
                Label label3 = (Label)item.FindControl("cuota");
                Label label4 = (Label)item.FindControl("monto_pago");
                TextBox textBox = (TextBox)item.FindControl("factura");
                TextBox textBox1 = (TextBox)item.FindControl("fecha_factura");
                HiddenField hiddenField = (HiddenField)item.FindControl("id_pago");
                pr_factura prFactura = new pr_factura()
                {
                    factura = textBox,
                    fecha_factura = textBox1
                };
                prFactura.ModificarPago(int.Parse(hiddenField.Value), label4.Text.Replace(".", "").Replace(",", "."));
                MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox.tpl"));
                messageBox.SetTitle("Información");
                messageBox.SetIcon("msg_icon_1.png");
                messageBox.SetMessage("Factura Modificada Satisfactoriamente");
                messageBox.SetOKButton("msg_button_class");
                this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                this.grid_factura.DataSource = prFactura.ObtenerTabla(this.id_spvs.SelectedValue, this.num_poliza1.SelectedValue);
                this.grid_factura.DataBind();
           
        }

    }
}