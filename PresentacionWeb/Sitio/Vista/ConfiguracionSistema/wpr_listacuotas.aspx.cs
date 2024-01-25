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
            Session["LST_PER_COMPANIA"] = logicaConfiguracion.TablaPersona(e.Parameter);
            this.grdListaPersona.DataSource = Session["LST_PER_COMPANIA"];
            this.grdListaPersona.DataBind();
        }

        private void CargaGrillaProducto(string busqueda)
        {
            var listPersona = new List<gridCompania>();//logicaConfiguracion.TablaProductoL(busqueda.ToUpper());
            Session["LST_PERSONA"] = listPersona;
            grdListaPersona.DataSource = listPersona;
            grdListaPersona.DataBind();
        }

        protected void pnlCallBackBuscaProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }

        protected void grdListaProducto_DataBinding(object sender, EventArgs e)
        {

        }

        protected void grdListaProducto_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}