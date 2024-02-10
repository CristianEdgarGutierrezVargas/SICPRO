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

namespace PresentacionWeb.Sitio.Vista.ModuloComisiones
{
    public partial class wpr_amortizacomis1 : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        public bool sw;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }
        private void CargaInicial()
        {
            var objTablaCompania = _objValidarProd.ObtenerTablaCompania("");

            id_spvs.DataSource = objTablaCompania;
            id_spvs.TextField = "nomraz";
            id_spvs.ValueField = "id_spvs";
            id_spvs.DataBind();
        }








       

        protected void id_spvs_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //var dataTable = prComisione.ObtenerTablaCheque(this.id_spvs.Value);
            //this.cheque.DataSource = dataTable;
            //this.cheque.TextFormatString = "cheque";
            //this.cheque.ValueField = "cheque";
            //this.cheque.DataBind();

            //dataTable = prComisione.PagoCheque2(this.id_spvs.Value.ToString(), this.RadComboBox1.Value.ToString());
            //this.RadComboBox1.DataSource = dataTable;
            //this.RadComboBox1.DataBind();
        }

        protected void btncuotas_Click(object sender, EventArgs e)
        {

        }
    }
}