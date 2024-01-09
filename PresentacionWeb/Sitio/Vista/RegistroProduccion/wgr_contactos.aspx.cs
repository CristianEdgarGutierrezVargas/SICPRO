using Common;
using DevExpress.Web;
using EntidadesClases.CustomModelEntities;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wgr_contactos : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            string idDireccion = base.Request.QueryString["var"];
            string idPersona = base.Request.QueryString["val"];

            ViewState["id_dir"] = idDireccion;
            ViewState["id_per"] = idPersona;

            if (base.Request.QueryString["var"] == "")
            {
                CargaInicial();
                //this.btnmodificar.Visible = false;
                //this.btnnuevo.Visible = false;
                return;
            }
            CargaInicial();
            

            

            //this.id_dir.Value = item;
            //this.id_perclie.Value = str;
            //this.DatosPersona(int.Parse(this.id_dir.Value));
            //this.Combos();
            //this.btnmodificar.Visible = false;
            //this.btnnuevo.Visible = false;

        }

        #region Metodos

        private void CargaInicial()
        {
            var lstLugarContactos = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstLugarContactos;
            cmb_id_emis.ValueField = "id_par";
            cmb_id_emis.TextField = "desc_param";
            cmb_id_emis.DataBind();

            var itemLugarContactos = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_id_emis.Items.Add(itemLugarContactos);

            var idPersona = (string)ViewState["id_per"];
            var lstDireccionParametro = _objConsumoRegistroProd.ObtenerListaContactosByIdPer(idPersona);
            //grdContactos.DataSource = lstDireccionParametro;
            grdContactos.DataBind();
            Session["LST_CONTACTOS"] = lstDireccionParametro;
        }

        private void Limpiarform()
        {
            nomraz.Text = string.Empty;            
            cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(0);
            relacion.Text = string.Empty;            
        }

        private void SetFormContactos(long strIdDir)
        {
            //var objDireccion = _objConsumoRegistroProd.ObtenerDireccion(strIdDir);
            //direccion.Text = objDireccion.direccion;

            //var itemTipoDir = cmb_tpdir.Items.FindByValue(objDireccion.id_tpdir);
            //if (itemTipoDir != null)
            //{
            //    cmb_tpdir.SelectedItem = itemTipoDir;
            //}

            //var itemLugar = cmb_id_emis.Items.FindByValue(objDireccion.id_emis);
            //if (itemLugar != null)
            //{
            //    cmb_id_emis.SelectedItem = itemLugar;
            //}

            //telf_dir.Text = objDireccion.telf_dir;
            //int_dire.Text = objDireccion.int_dire;
            //telf_cel.Text = objDireccion.telf_cel;
            //telf_fax.Text = objDireccion.telf_fax;
            //email.Text = objDireccion.email;
            //casilla.Text = objDireccion.casilla;
            //web.Text = objDireccion.web;

        }

        #endregion

        protected void btnDirecciones_Click(object sender, EventArgs e)
        {
            var idPersona = Convert.ToString(ViewState["id_per"]);
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_direccion.aspx?var=" + idPersona.TrimStart().TrimEnd());
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

        }

        protected void grdContactos_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<OC_DIRECCION_PARAMETRO>)Session["LST_CONTACTOS"];

            if (lstData != null)
            {
                grdContactos.DataSource = lstData;
            }
        }

        protected void grdContactos_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            object str_id_dir = e.KeyValue;
            ViewState["id_dir"] = Convert.ToInt64(str_id_dir);
            SetFormContactos(Convert.ToInt64(str_id_dir));
        }
    }
}