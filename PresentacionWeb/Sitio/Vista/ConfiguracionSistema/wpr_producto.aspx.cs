using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wpr_producto : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.Combos();

        }
        protected void Combos()
        {
            try
            {
                //this.id_riesgo.DataSource = (object)new pr_producto().ObtenerRiesgo();
                //this.id_riesgo.DataTextField = "desc_riesgo";
                //this.id_riesgo.DataValueField = "id_riesgo";
                //this.id_riesgo.DataBind();

                //new gr_compania() { ddlgeneral = this.id_spvs }.ObtenerListaCompania();
                PopupBuscadorCompania(string.Empty);
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void Buscar()
        {
            try 
            {
                pr_producto item = logicaConfiguracion.ObtenerProducto(long.Parse(id_producto.Value));
                this.id_producto.Value = item.id_producto.ToString();
                this.desc_producto.Text = item.desc_prod;
                this.abrev_prod.Text = item.abrev_prod;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool sw = false;
                string str = "";
                if (this.desc_producto.Text.Trim().Length == 0)
                {
                    str += "<br /> Debe Registrar un Nombre de Producto";
                    sw = true;
                }
                if (this.abrev_prod.Text.Trim().Length == 0)
                {
                    str += "<br /> Debe Registrar una Abreviación de Producto";
                    sw = true;
                }
                if (sw)
                {
                    lblerror.Text = str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    bool resp = logicaConfiguracion.ExisteProducto(this.desc_producto.Text, this.abrev_prod.Text);
                    if (resp)
                    {
                        lblerror.Text = "Debe Verificar el Nombre del Producto y la Abreviación del Mismo\nEl Producto ya Esta Registrado";
                        popUpValidacion.ShowOnPageLoad = true;
                    }
                    else
                    {
                        logicaConfiguracion.InsertarProducto(this.desc_producto.Text, this.abrev_prod.Text);
                    }
                }
            }
            catch
            {
                this.lblmensajeA.Text = "Error al Generar la Transacción";
            }
        }

        

        protected void grdListaProducto_SelectionChanged(object sender, EventArgs e)
        {
            //var grilla = (DevExpress.Web.ASPxGridView)sender;
            //var lista = grilla.GetSelectedFieldValues("id_spvs");
            //var objeto = (string)lista[0];
            //this.id_per.Value = objeto.ToString();

            //lista = grilla.GetSelectedFieldValues("nomraz");
            //objeto = (string)lista[0];
            //this.nomraz.Text = objeto.ToString();

            //this.btnguardar.Visible = true;
            //this.btnmodificar.Visible = false;

            //popupBusquedaPersona.ShowOnPageLoad = false;



            pr_producto item = logicaConfiguracion.ObtenerProducto(long.Parse(id_producto.Value));
            this.id_producto.Value = item.id_producto.ToString();
            this.desc_producto.Text = item.desc_prod;
            this.abrev_prod.Text = item.abrev_prod;
        }

        protected void pnlCallBackBuscaProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            PopupBuscadorCompania(e.Parameter.ToString());
        }
        protected void PopupBuscadorCompania(string valorBusqueda)
        {
            try
            {
                logicaConfiguracion = new ConsumoConfiguracionSistema();
                List<gr_compania> listCompania;
                List<gr_persona> listPer = logicaConfiguracion.ObtenerListaCompania(valorBusqueda, out listCompania);

                List<gridCompania> listGrilla = new List<gridCompania>();
                for (int i = 0; i < listPer.Count; i++)
                {
                    listGrilla.Add(new gridCompania
                    {
                        nomraz = listPer[i].nomraz,
                        id_spvs = listCompania[i].id_spvs,
                        abrev= listCompania[i].abrev_cia
                    });
                }

                Session["LST_PER_COMPANIA"] = listGrilla;
                this.grdListaProducto.DataSource = listGrilla;
                this.grdListaProducto.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void grdListaProducto_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gridCompania>)Session["LST_PER_COMPANIA"];
            if (lstData != null)
            {
                this.grdListaProducto.DataSource = lstData;
            }
        }
    }

    public class gridCompania
    {
        public string id_spvs { get; set; }
        public string nomraz { get; set; }
        public string abrev { get; set; }
    }
}