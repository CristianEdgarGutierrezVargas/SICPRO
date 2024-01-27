using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wpr_listacuotas : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.fc_finvig.Text = DateTime.Now.ToShortDateString();
            this.fc_inivig.Text = DateTime.Now.ToShortDateString();
            this.Limpiar();
            //this.gridcontainer.Visible = false;
            IniciarGrillas();
        }

        private void IniciarGrillas()
        {
            CargaGrillaPersona(string.Empty);
            CargaGrillaCompania(string.Empty);
        }

        private void CargaGrillaPersona(string busqueda)
        {
            var listPersona = logicaConfiguracion.TablaPersona(busqueda.ToUpper());
            Session["LST_PERSONA"] = listPersona;
            grdListaPersona.DataSource = listPersona;
            grdListaPersona.DataBind();
        }
        protected void grdListaPersona_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gr_persona>)Session["LST_PERSONAS"];
            if (lstData != null)
            {
                this.grdListaPersona.DataSource = lstData;
            }
        }
        protected void grdListaPersona_SelectionChanged(object sender, EventArgs e)
        {
            var grilla = (DevExpress.Web.ASPxGridView)sender;
            var lista = grilla.GetSelectedFieldValues("id_per");
            var objeto = (string)lista[0];
            this.id_per.Value = objeto.ToString();

            lista = grilla.GetSelectedFieldValues("nomraz");
            objeto = (string)lista[0];
            this.nomraz.Text = objeto.ToString();
            popupBusquedaPersona.ShowOnPageLoad = false;
        }
        protected void pnlCallBackBuscaPersona_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            logicaConfiguracion = new ConsumoConfiguracionSistema();
            Session["LST_PERSONAS"] = logicaConfiguracion.TablaPersona(e.Parameter);
            this.grdListaPersona.DataSource = Session["LST_PERSONAS"];
            this.grdListaPersona.DataBind();
        }
        private void Limpiar()
        {
            this.id_per.Value = "";
            this.id_producto.Value = "0";
            this.id_spvs.Value = "";
        }
        private void CargaGrillaCompania(string busqueda)
        {
            logicaConfiguracion = new ConsumoConfiguracionSistema();
            List<gr_compania> listCompania;
            List<gr_persona> listPer = logicaConfiguracion.ObtenerListaCompania(busqueda, out listCompania);

            List<gridCompania> listGrilla = new List<gridCompania>();
            for (int i = 0; i < listPer.Count; i++)
            {
                listGrilla.Add(new gridCompania
                {
                    nomraz = listPer[i].nomraz,
                    id_spvs = listCompania[i].id_spvs,
                    abrev = listCompania[i].abrev_cia
                });
            }

            Session["LST_PER_COMPANIA"] = listGrilla;
            this.grdListaCompania.DataSource = listGrilla;
            this.grdListaCompania.DataBind();
        }
        protected void grdListaCompania_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gridCompania>)Session["LST_PER_COMPANIA"];
            if (lstData != null)
            {
                this.grdListaCompania.DataSource = lstData;
            }
        }
        protected void grdListaCompania_SelectionChanged(object sender, EventArgs e)
        {
            var grilla = (DevExpress.Web.ASPxGridView)sender;
            var lista = grilla.GetSelectedFieldValues("id_spvs");
            var objeto = (string)lista[0];
            this.id_spvs.Value = objeto.ToString();

            lista = grilla.GetSelectedFieldValues("nomraz");
            objeto = (string)lista[0];
            this.nomco.Text = objeto.ToString();
            popupBusquedaCompania.ShowOnPageLoad = false;
        }
        protected void pnlCallBackBuscaCompania_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            logicaConfiguracion = new ConsumoConfiguracionSistema();
            List<gr_compania> listCompania;
            List<gr_persona> listPer = logicaConfiguracion.ObtenerListaCompania(e.Parameter, out listCompania);

            List<gridCompania> listGrilla = new List<gridCompania>();
            for (int i = 0; i < listPer.Count; i++)
            {
                listGrilla.Add(new gridCompania
                {
                    nomraz = listPer[i].nomraz,
                    id_spvs = listCompania[i].id_spvs,
                    abrev = listCompania[i].abrev_cia
                });
            }
            Session["LST_PER_COMPANIA"] = listGrilla;
            this.grdListaCompania.DataSource = listGrilla;
            this.grdListaCompania.DataBind();
        }
        protected void pnlCallBackBuscaProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            logicaConfiguracion = new ConsumoConfiguracionSistema();
            Session["LST_PRODUCTO"] = logicaConfiguracion.TablaProductoL(id_spvs.Value.ToString(), e.Parameter.ToUpper());
            this.grdListaProducto.DataSource = Session["LST_PRODUCTO"];
            this.grdListaProducto.DataBind();
        }
        protected void grdListaProducto_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<pr_producto>)Session["LST_PRODUCTO"];
            if (lstData != null)
            {
                this.grdListaProducto.DataSource = lstData;
            }
        }
        protected void grdListaProducto_SelectionChanged(object sender, EventArgs e)
        {
            var grilla = (DevExpress.Web.ASPxGridView)sender;
            var lista = grilla.GetSelectedFieldValues("id_producto");
            var objeto = (string)lista[0];
            this.id_producto.Value = objeto.ToString();

            lista = grilla.GetSelectedFieldValues("desc_prod");
            objeto = (string)lista[0];
            this.desc_producto.Text = objeto.ToString();

            popupBusquedaProducto.ShowOnPageLoad = false;
        }
        protected void btnserprod_Click(object sender, EventArgs e)
        {
            if (this.nomco.Text == "")
            {
                lblerror.Text = "Seleccione una Compañia Existente";
                popUpValidacion.ShowOnPageLoad = true;
            }
            else
            {
                var listProducto = logicaConfiguracion.TablaProductoL(id_spvs.Value.ToString(), this.desc_producto.Text.ToUpper());
                Session["LST_PRODUCTO"] = listProducto;
                grdListaProducto.DataSource = listProducto;
                grdListaProducto.DataBind();
                popupBusquedaProducto.ShowOnPageLoad = true;
            }
        }
        protected void Datos()
        {
            if (!this.vigencia.Checked & this.num_poliza.Text == "" & this.nomraz.Text == "" & this.nomco.Text == "" & this.desc_producto.Text == "" & !this.porvencer.Checked)
            {
                lblerror.Text = "Introduzca Criterios de Búsqueda";
                popUpValidacion.ShowOnPageLoad = true;
            }
            else
            {
                //pr_cuotas prCuotas = new pr_cuotas();
                //string str = this.Request.QueryString["var"];
                //prCuotas.vigencia = this.vigencia;
                //prCuotas.vigencia.Checked = this.vigencia.Checked;
                //prCuotas.porvencer = this.porvencer;
                //prCuotas.porvencer.Checked = this.porvencer.Checked;
                //prCuotas.num_poliza = this.num_poliza;
                //prCuotas.id_perclie = this.id_per;
                //prCuotas.id_spvs = this.id_spvs;
                //prCuotas.id_producto = this.id_producto;
                //prCuotas.fc_inivig = this.fc_inivig;
                //prCuotas.fc_finivig = this.fc_finvig;
                //prCuotas.fc_finvig = this.fc_polizavencida;
                //prCuotas.lblmensaje = this.lblmensaje;
                //prCuotas.a = this.ap;
                //prCuotas.b = this.bp;
                //prCuotas.RecuperaTabla();
                //this.gridpoliza.DataSource = (object)prCuotas.ObtenerTablaPoliza();
                //this.gridpoliza.DataBind();
                //this.gridcontainer.Visible = true;
            }
        }


        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("wpr_listacuotas.aspx");
        }
    }
}