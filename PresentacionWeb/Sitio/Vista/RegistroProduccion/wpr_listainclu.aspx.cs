using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.CustomModelEntities;
using Logica.Consumo;
using PresentacionWeb.Sitio.Vista.ValidacionProduccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_listainclu : System.Web.UI.Page
    {
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnserprod_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnsercom_Click(object sender, EventArgs e)
        {


        }

        protected void btnserper_Click(object sender, EventArgs e)
        {

        }

        protected void CallBPersona_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
           

        }

        protected void btnserper1_Click(object sender, EventArgs e)
        {
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
           
        }

        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void CallBCompania_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
           
        }

        protected void btnnomco_Click(object sender, EventArgs e)
        {
          
        }

        protected void grdCompania_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptarCompania_Click(object sender, EventArgs e)
        {
            
        }

        protected void CallBProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            
        }

        protected void btnProd_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptarProducto_Click(object sender, EventArgs e)
        {
            pCProducto.ShowOnPageLoad = false;
        }

        protected void grdProducto_DataBinding(object sender, EventArgs e)
        {
            grdProducto.DataSource = Session["lstProducto"];
        }

        protected void gridpoliza_DataBinding(object sender, EventArgs e)
        {
            gridpoliza.DataSource = Session["lstGridPoliza"];
        }


        protected void CallBGridPoliza_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            
        }

        public string Grupo(object num)
        {

            if (num == null)
                return "";

            string descGrupo = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idGrupo = Convert.ToInt64(num.ToString());
                descGrupo = _objConsumoValidarProd.objGrupoById(idGrupo).desc_grupo;
            }
            return descGrupo;
        }
        public string CompaniaAseg(object num)
        {
            if (num == null)
                return "";
            string descCompania = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {

                descCompania = _objConsumoValidarProd.GetDescCompaniaById(num.ToString());
            }
            return descCompania;
        }

        public string NombreProducto(object num)
        {
            if (num == null)
                return "";
            string descProducto = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idProducto = Convert.ToInt64(num.ToString());
                descProducto = _objConsumoValidarProd.GetProductoById(idProducto).desc_prod;
            }
            return descProducto;
        }
        public string TipoPoliza(object num)
        {
            if (num == null)
                return "";
            string descProducto = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idProducto = Convert.ToInt64(num.ToString());
                var tipo = _objConsumoValidarProd.GetPolizaByIdPoliza(idProducto).clase_poliza;
                if ((bool)tipo)
                    descProducto = "Normal";
                else descProducto = "Flotante";

            }
            return descProducto;
        }
        public string FormaPago(object num)
        {
            if (num == null)
                return "";
            string formaPago = "";
            if (Convert.ToBoolean(num.ToString()))

                formaPago = "Contado";
            else formaPago = "Crédito";


            return formaPago;
        }
        public string Ejecutivo(object num)
        {
            if (num == null)
                return "";
            string nomEjecutivo = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idEjecutivo = num.ToString();
                nomEjecutivo = _objConsumoValidarProd.GetPersonaById(idEjecutivo).nomraz;
            }
            return nomEjecutivo;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {           
            //var objTablaPolizaIn = new OC_ObtenerTablaPolizaIn();
            //objTablaPolizaIn.num_poliza = num_poliza.Text;
            ////objTablaPolizaIn.id_perclie = ;

            //var lstTablaPoliza = _objConsumoRegistroProd.ObtenerTablaPolizaR(objTablaPolizaIn);
            //this.gridpoliza.DataSource = lstTablaPoliza;
            //this.gridpoliza.DataBind();
            ////this.gridcontainer.Visible = true;
        }

        protected void gridpoliza_HtmlDataCellPrepared(object sender, BootstrapGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.Caption == "Opciones")
            //    e.Cell.Attributes.Add("onclick", "event.cancelBubble = true");
            ////if (e.DataColumn.FieldName == "UnitPrice")
            ////    e.Cell.Attributes.Add("onclick", "event.cancelBubble = true");

            ////https://supportcenter.devexpress.com/ticket/details/t189804/gridview-how-to-disable-row-click-in-particular-column
        }

    }
}