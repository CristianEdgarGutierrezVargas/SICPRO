using Common;
using DevExpress.Web;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        #region Metodos

        private void CargaInicial(string id_per)
        {
            //var lstTipoDireccion = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tpdir);

            //cmb_tpdir.DataSource = lstTipoDireccion;
            //cmb_tpdir.ValueField = "id_par";
            //cmb_tpdir.TextField = "desc_param";
            //cmb_tpdir.DataBind();

            //var itemTipoDireccion = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            //cmb_tpdir.Items.Add(itemTipoDireccion);

            //var lstLugarEmision = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            //cmb_id_emis.DataSource = lstLugarEmision;
            //cmb_id_emis.ValueField = "id_par";
            //cmb_id_emis.TextField = "desc_param";
            //cmb_id_emis.DataBind();

            //var itemLugarEmision = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            //cmb_id_emis.Items.Add(itemLugarEmision);

            //var lstDireccionParametro = _objConsumoRegistroProd.ObtenerListaDireccion(id_per);
            //grdDirecciones.DataSource = lstDireccionParametro;
            //grdDirecciones.DataBind();
            //Session["LST_DIRECCIONES"] = lstDireccionParametro;
        }

        private void Limpiarform()
        {
            nomraz.Text = string.Empty;            
            cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(0);
            relacion.Text = string.Empty;            
        }

        private void SetFormDireccion(long strIdDir)
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
    }
}