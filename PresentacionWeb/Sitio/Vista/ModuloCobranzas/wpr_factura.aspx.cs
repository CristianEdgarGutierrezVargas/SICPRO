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
            
            //var dataTable = prFactura.ObtenerTabla(this.id_spvs.SelectedValue, this.num_poliza1.SelectedValue);
            //if (dataTable.Rows.Count > 0)
            //{
            //    this.grid_factura.DataSource = dataTable;
            //    this.grid_factura.DataBind();
            //    this.tr4.Visible = false;
            //    this.tr5.Visible = false;
            //}
        }








        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    Grilla();
        //    pnlGrid.Visible = true;
        //    return;

        //}
        //private void Grilla()
        //{
        //    var sId_spvs = id_spvs.Value.ToString();
        //    var sNro_factura = Convert.ToDouble(nro_factura.Text);
        //    var data = conCobranza.RecuFacMod(sNro_factura, sId_spvs);
        //    ViewState["cuotas"] = data;
        //    this.gridcuotas.DataSource = data;
        //    this.gridcuotas.DataBind();
        //}
        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    string str = "";
        //    int num = 0;
        //    if (this.id_spvs.Value.ToString() == "0")
        //    {

        //        lblMensaje.Text = "Seleccione una compañía de Seguros!";
        //        imagenFail.Visible = false;
        //        imagenOk.Visible = true;
        //        pnlMensaje.ShowOnPageLoad = true;
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(this.nro_factura.Text))
        //    {

        //        lblMensaje.Text = "Registre un número de factura a buscar!";
        //        imagenFail.Visible = false;
        //        imagenOk.Visible = true;
        //        pnlMensaje.ShowOnPageLoad = true;
        //        return;
        //    }


        //    var nro_factura = Convert.ToDouble(this.nro_factura.Text);
        //    var nnro_factura = Convert.ToDouble(this.nnro_factura.Text);
        //    var fc_factura = this.fc_factura.Date;
        //    var id_spvs = this.id_spvs.Value.ToString();

        //    if (conCobranza.ModFacM(nro_factura, nnro_factura, fc_factura, id_spvs))
        //    {
        //        lblMensaje.Text = "Numero y Fecha de factura registrados correctamente!";
        //        imagenFail.Visible = false;
        //        imagenOk.Visible = true;
        //        pnlMensaje.ShowOnPageLoad = true;
        //    }
        //    else
        //    {
        //        imagenFail.Visible = true;
        //        imagenOk.Visible = false;
        //        lblMensaje.Text = "Hubo un error al registrar los datos!";
        //        pnlMensaje.ShowOnPageLoad = true;
        //    }


        //    this.Grilla();
        //}

        //protected void gridcuotas_DataBinding(object sender, EventArgs e)
        //{

        //    this.gridcuotas.DataSource = ViewState["cuotas"];
        //}

        //protected void img2_Click(object sender, EventArgs e)
        //{
        //    BootstrapButton button = sender as BootstrapButton;
        //    var container = button.NamingContainer as GridViewDataItemTemplateContainer;
        //    var id = Convert.ToInt64(gridcuotas.GetRowValues(container.VisibleIndex, gridcuotas.KeyFieldName));
        //    ASPxTextBox fact = gridcuotas.FindRowCellTemplateControl(container.VisibleIndex, null, "n_factura") as ASPxTextBox;
        //    ASPxDateEdit fechafact = gridcuotas.FindRowCellTemplateControl(container.VisibleIndex, null, "fecha_factura") as ASPxDateEdit;

        //    try
        //    {

        //        if (conCobranza.ModFac1(Convert.ToDouble(fact.Text), fechafact.Date, id))
        //        {
        //            lblMensaje.Text = "Numero y Fecha de factura registrados correctamente!";
        //            imagenFail.Visible = false;
        //            imagenOk.Visible = true;
        //            pnlMensaje.ShowOnPageLoad = true;
        //        }
        //        else
        //        {
        //            imagenFail.Visible = true;
        //            imagenOk.Visible = false;
        //            lblMensaje.Text = "Hubo un error al registrar los datos!";
        //            pnlMensaje.ShowOnPageLoad = true;
        //        }

        //        this.Grilla();
        //    }
        //    catch
        //    {
        //        imagenFail.Visible = true;
        //        imagenOk.Visible = false;
        //        lblMensaje.Text = "Hubo un error al registrar los datos!";
        //        pnlMensaje.ShowOnPageLoad = true;
        //    }
        //}

       
    }
}