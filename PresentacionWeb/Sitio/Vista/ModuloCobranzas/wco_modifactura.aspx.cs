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
            var sNro_factura =Convert.ToDouble(nro_factura.Text);
            var data = conCobranza.RecuFacMod(sNro_factura,sId_spvs );
            this.gridcuotas.DataSource = data;
            this.gridcuotas.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void gridcuotas_DataBinding(object sender, EventArgs e)
        {

        }

        protected void img2_Click(object sender, EventArgs e)
        {

        }
    }
}