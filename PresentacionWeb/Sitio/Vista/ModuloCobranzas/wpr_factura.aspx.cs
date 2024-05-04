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

using DevExpress.XtraPrinting;
using DevExpress.XtraReports;

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

            BootstrapButton button = sender as BootstrapButton;
            var container = button.NamingContainer as GridViewDataItemTemplateContainer;
            string[] valores = container.KeyValue.ToString().Split('|');

            var numPoliza = valores[0];
            var noLiquida = valores[1];
            var idPerClie = valores[2];
            var cuota = valores[3];
            var montoPago = valores[4];
            var idPago= valores[5];

            int num = Convert.ToInt32(container.VisibleIndex);
            GridViewDataColumn CC = grid_factura.Columns[5] as GridViewDataColumn;
            BootstrapDateEdit fechaFactura = grid_factura.FindRowCellTemplateControl(num, CC, "fecha_factura") as BootstrapDateEdit;
            GridViewDataColumn CC1 = grid_factura.Columns[6] as GridViewDataColumn;
            BootstrapTextBox numFactura = grid_factura.FindRowCellTemplateControl(num, CC1, "n_factura") as BootstrapTextBox;

            //var label1 = (BootstrapDateEdit)grid_factura.Rows[num].Cells[1].FindControl("dtFechaPago");
            //Label label = (Label)grid_factura.FindDetailRowTemplateControl("num_poliza");
            //Label label1 = (Label)item.FindControl("no_liquida");
            //Label label2 = (Label)item.FindControl("id_perclie");
            //Label label3 = (Label)item.FindControl("cuota");
            //Label label4 = (Label)item.FindControl("monto_pago");
            //TextBox textBox = (TextBox)item.FindControl("factura");
            //TextBox textBox1 = (TextBox)item.FindControl("fecha_factura");
            //HiddenField hiddenField = (HiddenField)item.FindControl("id_pago");
            //pr_factura prFactura = new pr_factura()
            //{
            //    factura = textBox,
            //    fecha_factura = textBox1
            //};

            conCobranza.ModificarPago(Convert.ToDouble( numFactura.Text), fechaFactura.Date,Convert.ToInt64( idPago));
            lblMensaje.Text = "Factura Modificada Satisfactoriamente";
            imagenOk.Visible = true;
            imagenFail.Visible = false;
            pnlMensaje.ShowOnPageLoad = true;
        
          
            this.grid_factura.DataSource = conCobranza.ObtenerTablaFactura(this.id_spvs.Value.ToString(), numPoliza);
            this.grid_factura.DataBind();

        }

    }
}