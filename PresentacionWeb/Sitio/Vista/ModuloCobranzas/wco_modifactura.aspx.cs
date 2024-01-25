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
    public partial class wco_modifactura : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        ConsumoCobranza conCobranza = new ConsumoCobranza();
        protected void Page_Load(object sender, EventArgs e)
        {
            var objTablaCompania = _objValidarProd.ObtenerTablaCompania("");
            if (!IsPostBack)
            {


                id_spvs.DataSource = objTablaCompania;
                id_spvs.TextField = "nomraz";
                id_spvs.ValueField = "id_spvs";
                id_spvs.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Grilla();
            pnlGrid.Visible = true;
            return;

        }
        private void Grilla()
        {
            var sId_spvs = id_spvs.Value.ToString();
            var sNro_factura = Convert.ToDouble(nro_factura.Text);
            var data = conCobranza.RecuFacMod(sNro_factura, sId_spvs);
            ViewState["cuotas"] = data;
            this.gridcuotas.DataSource = data;
            this.gridcuotas.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = "";
            int num = 0;
            if (this.id_spvs.Value.ToString() == "0")
            {
               
                lblMensaje.Text = "Seleccione una compañía de Seguros!";
                imagenFail.Visible = false;
                imagenOk.Visible = true;
                pnlMensaje.ShowOnPageLoad = true;
                return;
            }
            if (string.IsNullOrEmpty(this.nro_factura.Text))
            {
            
                lblMensaje.Text = "Registre un número de factura a buscar!";
                imagenFail.Visible = false;
                imagenOk.Visible = true;
                pnlMensaje.ShowOnPageLoad = true;
                return;
            }


            var nro_factura =Convert.ToDouble( this.nro_factura.Text);
            var nnro_factura = Convert.ToDouble(this.nnro_factura.Text);
            var fc_factura = this.fc_factura.Date;
            var id_spvs = this.id_spvs.Value.ToString();
           
           if(conCobranza.ModFacM(nro_factura,nnro_factura,fc_factura,id_spvs))
            {
                lblMensaje.Text = "Numero y Fecha de factura registrados correctamente!";
                imagenFail.Visible = false;
                imagenOk.Visible = true;
                pnlMensaje.ShowOnPageLoad = true;
            }
           else
            {
                imagenFail.Visible = true;
                imagenOk.Visible = false;
                lblMensaje.Text = "Hubo un error al registrar los datos!";
                pnlMensaje.ShowOnPageLoad = true;
            }
          

            this.Grilla();
        }

        protected void gridcuotas_DataBinding(object sender, EventArgs e)
        {

            this.gridcuotas.DataSource = ViewState["cuotas"];
        }

        protected void img2_Click(object sender, EventArgs e)
        {
            BootstrapButton button = sender as BootstrapButton;
            var container = button.NamingContainer as GridViewDataItemTemplateContainer;
            var id = Convert.ToInt64(gridcuotas.GetRowValues(container.VisibleIndex, gridcuotas.KeyFieldName));
            ASPxTextBox fact = gridcuotas.FindRowCellTemplateControl(container.VisibleIndex, null, "n_factura") as ASPxTextBox;
            ASPxDateEdit fechafact = gridcuotas.FindRowCellTemplateControl(container.VisibleIndex, null, "fecha_factura") as ASPxDateEdit;

            try
            {

                if (conCobranza.ModFac1(Convert.ToDouble(fact.Text), fechafact.Date, id))
                {
                    lblMensaje.Text = "Numero y Fecha de factura registrados correctamente!";
                    imagenFail.Visible = false;
                    imagenOk.Visible = true;
                    pnlMensaje.ShowOnPageLoad = true;
                }
                else
                {
                    imagenFail.Visible = true;
                    imagenOk.Visible = false;
                    lblMensaje.Text = "Hubo un error al registrar los datos!";
                    pnlMensaje.ShowOnPageLoad = true;
                }

                this.Grilla();
            }
            catch
            {
                imagenFail.Visible = true;
                imagenOk.Visible = false;
                lblMensaje.Text = "Hubo un error al registrar los datos!";
                pnlMensaje.ShowOnPageLoad = true;
            }
        }

    }
}