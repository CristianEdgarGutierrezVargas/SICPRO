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

namespace PresentacionWeb.Sitio.Vista.ModuloCobranzas
{
    public partial class wpr_amortizaanexos : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        ConsumoCobranza conCobranza = new ConsumoCobranza();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
            bool isPostBack = this.Page.IsPostBack;
        }

        protected void btnserper_Click(object sender, EventArgs e)
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
           id_per.Value= idPer;
            nomraz.Text = nomRaz;
            Polizas();
            pCPersona.ShowOnPageLoad = false;




        }
        protected void btnrec_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {

        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            pCPersona.ShowOnPageLoad = false;
        }
        protected void btnserper1_Click(object sender, EventArgs e)
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

        protected void btnserper_Click1(object sender, EventArgs e)
        {

        }
        private void Polizas()
        {
            var lstPoliza= conCobranza.ObtenerPoliza1(id_per.Value);
            num_poliza.DataSource= lstPoliza;
            num_poliza.TextField = "num_poliza";
            num_poliza.ValueField = "id_poliza";
            num_poliza.DataBind();

        }

        protected void num_poliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var lstLiq = conCobranza.ObtenerMovimiento1(Convert.ToInt64( num_poliza.Value));

                this.no_liquida.DataSource = lstLiq;
                this.no_liquida.TextField = "no_liquida";
                this.no_liquida.ValueField = "id_movimiento";
                this.no_liquida.DataBind();
            }
            catch
            {
            }
        }

        protected void no_liquida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var lstCuotas = conCobranza.GetCuotasDev(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value));
             
                this.cuota_devolucion.DataSource = lstCuotas;
                this.cuota_devolucion.TextField = "cuota_devolucion1";
                this.cuota_devolucion.ValueField = "id_devolucion";
                this.cuota_devolucion.DataBind();
            }
            catch
            {
            }
        }

        protected void cuota_devolucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var lstCuotas = conCobranza.DatosDev(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value), Convert.ToInt64(cuota_devolucion.Value)).FirstOrDefault();
                if (lstCuotas!=null)
                {
                    monto_devolucion.Text = lstCuotas.monto_devolucion.ToString();
                    saldo_devolucion.Text = lstCuotas.saldo_devolucion.ToString();
                }
            }
            catch
            {
            }
        }
    }
}