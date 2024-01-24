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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var objTablaCompania = _objValidarProd.ObtenerTablaCompania("");

                id_spvs.DataSource = objTablaCompania;
                id_spvs.TextField = "nomraz";
                id_spvs.ValueField = "id_spvs";
                id_spvs.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
                Grilla();
                return;
         
        }
        private void Grilla()
        {
            
            //var dataTable = prFactura.RecuFacMod(id_spvs, nro_factura);
            //this.gridcuotas.DataSource = dataTable;
            //this.gridcuotas.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}