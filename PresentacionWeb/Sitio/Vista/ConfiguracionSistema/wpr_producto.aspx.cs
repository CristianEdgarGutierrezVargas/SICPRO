using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            this.ListProducto();
        }
        protected void ListProducto()
        {
            try
            {
                PopupBuscadorProducto(string.Empty);
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void grdListaProducto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var grilla = (DevExpress.Web.ASPxGridView)sender;
                var lista = grilla.GetSelectedFieldValues("id_producto");
                var objeto = lista[0].ToString();
                id_producto.Value = objeto.ToString();

                pr_producto item = logicaConfiguracion.ObtenerProducto(long.Parse(id_producto.Value));
                this.id_producto.Value = item.id_producto.ToString();
                this.desc_producto.Text = item.desc_prod;
                this.abrev_prod.Text = item.abrev_prod;

                popupBusquedaProducto.ShowOnPageLoad = false;

                panelControles();
            }
            catch(Exception ex)
            {
                this.lblmensajeA.Text = "Error al Generar la Transacción";
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void pnlCallBackBuscaProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            PopupBuscadorProducto(e.Parameter.ToString());
        }
        protected void PopupBuscadorProducto(string valorBusqueda)
        {
            try
            {
                var listProducto = logicaConfiguracion.TablaProductoP(valorBusqueda);
                Session["LST_PRODUCTO"] = listProducto;
                this.grdListaProducto.DataSource = listProducto;
                this.grdListaProducto.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void grdListaProducto_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<pr_producto>)Session["LST_PRODUCTO"];
            if (lstData != null)
            {
                this.grdListaProducto.DataSource = lstData;
            }
        }
        private void panelControles()
        {
            pnlControles.Visible = true;

            logicaConfiguracion = new ConsumoConfiguracionSistema();
            this.id_riesgo.DataSource = logicaConfiguracion.ObtenerRiesgo();
            this.id_riesgo.DataTextField = "desc_riesgo";
            this.id_riesgo.DataValueField = "id_riesgo";
            this.id_riesgo.DataBind();

            List<v_pr_cias_resum> listPer = logicaConfiguracion.ObtenerListaCompania();
            this.id_spvs.DataSource = listPer;
            this.id_spvs.DataTextField = "nomraz";
            this.id_spvs.DataValueField = "id_spvs";
            this.id_spvs.DataBind();

            //List<gr_compania> listCompania;
            //List<v_pr_cias_resum> listPer = logicaConfiguracion.ObtenerListaCompania();

            //List<gridCompania> listGrilla = new List<gridCompania>();
            //for (int i = 0; i < listPer.Count; i++)
            //{
            //    listGrilla.Add(new gridCompania
            //    {
            //        nomraz = listPer[i].nomraz,
            //        id_spvs = listCompania[i].id_spvs,
            //        abrev = listCompania[i].abrev_cia
            //    });
            //}

            //this.id_riesgo.DataSource = (object)new pr_producto().ObtenerRiesgo();
            //this.id_riesgo.DataTextField = "desc_riesgo";
            //this.id_riesgo.DataValueField = "id_riesgo";
            //this.id_riesgo.DataBind();

            //new gr_compania() { ddlgeneral = this.id_spvs }.ObtenerListaCompania();

            //this.id_producto.Value = "";
            //string msg_message = new pr_producto()
            //{
            //    a = this.a,
            //    b = this.b
            //}.TablaProductoP(this.desc_producto.Text.ToUpper());
            //this.msgboxpanel.Visible = true;
            //MessageBox messageBox = new MessageBox(this.Server.MapPath("msgboxprod.tpl"));
            //messageBox.SetTitle("Busqueda de Productos por Compañia");
            //messageBox.SetIcon("search_user.png");
            //messageBox.SetMessage(msg_message);
            //messageBox.SetOKButton("msg_button_class");
            //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
            //this.a.Value = "0";
            //this.b.Value = "10";
            //this.id_producto.Value = "";
            //logicaConfiguracion.ta
            //string msg_message = new pr_producto()
            //{
            //    a = this.a,
            //    b = this.b
            //}.TablaProductoP(this.desc_producto.Text.ToUpper());


            //var listProducto = logicaConfiguracion.TablaProductoP(this.desc_producto.Text.ToUpper());
            //Session["LST_PRODUCTO"] = listProducto;
            //this.grdListaProducto.DataSource = listProducto;
            //this.grdListaProducto.DataBind();




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
    }

    public class gridCompania
    {
        public string id_spvs { get; set; }
        public string nomraz { get; set; }
        public string abrev { get; set; }
    }
}