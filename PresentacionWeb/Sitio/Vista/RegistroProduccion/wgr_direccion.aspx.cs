﻿using Common;
using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wgr_direccion : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            if (base.Request.QueryString["var"] == "")
            {
                CargaInicial(string.Empty);
                Limpiarform();
                this.btnGuardar.Visible = true;
                return;
            }
            string itemIdPer = base.Request.QueryString["var"];
            //this.id_per.Value = item;
            CargaInicial(itemIdPer);
            //this.DireccionPersona();
            ViewState["id_per"] = itemIdPer;
        }

        #region Metodos

        private void CargaInicial(string id_per)
        {
            var lstTipoDireccion = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tpdir);

            cmb_tpdir.DataSource = lstTipoDireccion;
            cmb_tpdir.ValueField = "id_par";
            cmb_tpdir.TextField = "desc_param";
            cmb_tpdir.DataBind();

            var itemTipoDireccion = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_tpdir.Items.Add(itemTipoDireccion);

            var lstLugarEmision = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstLugarEmision;
            cmb_id_emis.ValueField = "id_par";
            cmb_id_emis.TextField = "desc_param";
            cmb_id_emis.DataBind();

            var itemLugarEmision = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_id_emis.Items.Add(itemLugarEmision);

            var lstDireccionParametro = _objConsumoRegistroProd.ObtenerListaDireccion(id_per);
            grdDirecciones.DataSource = lstDireccionParametro;
            grdDirecciones.DataBind();
            Session["LST_DIRECCIONES"] = lstDireccionParametro;
        }

        private void Limpiarform()
        {
            direccion.Text = string.Empty;
            cmb_tpdir.SelectedItem = cmb_tpdir.Items.FindByValue(0);
            cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(0);
            telf_dir.Text = string.Empty;
            int_dire.Text = string.Empty;
            telf_cel.Text = string.Empty;
            telf_fax.Text = string.Empty;
            email.Text = string.Empty;
            casilla.Text = string.Empty;
            web.Text = string.Empty;
        }

        private void SetFormDireccion(long strIdDir)
        {
            var objDireccion = _objConsumoRegistroProd.ObtenerDireccion(strIdDir);
            direccion.Text = objDireccion.direccion;

            var itemTipoDir = cmb_tpdir.Items.FindByValue(objDireccion.id_tpdir);
            if (itemTipoDir != null)
            {
                cmb_tpdir.SelectedItem = itemTipoDir;
            }

            var itemLugar = cmb_id_emis.Items.FindByValue(objDireccion.id_emis);
            if (itemLugar != null)
            {
                cmb_id_emis.SelectedItem = itemLugar;
            }

            telf_dir.Text = objDireccion.telf_dir;
            int_dire.Text = objDireccion.int_dire;
            telf_cel.Text = objDireccion.telf_cel;
            telf_fax.Text = objDireccion.telf_fax;
            email.Text = objDireccion.email;
            casilla.Text = objDireccion.casilla;
            web.Text = objDireccion.web;

        }

        #endregion

        protected void btnPersona_Click(object sender, EventArgs e)
        {
            var itemIdPer = Convert.ToString(ViewState["id_per"]);
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_persona.aspx?var=" + itemIdPer);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiarform();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnContactos_Click(object sender, EventArgs e)
        {
            var itemIdPer = Convert.ToString(ViewState["id_per"]);
            var itemIdDir = Convert.ToString(ViewState["id_dir"]);
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_contactos.aspx?var=" + itemIdDir + "&val=" + itemIdPer);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

        }

        protected void grdDirecciones_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gr_direccion>)Session["LST_DIRECCIONES"];

            if (lstData != null)
            {
                grdDirecciones.DataSource = lstData;
            }
        }

        protected void grdDirecciones_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            object str_id_dir = e.KeyValue;
            ViewState["id_dir"] = Convert.ToInt64(str_id_dir);
            SetFormDireccion(Convert.ToInt64(str_id_dir));
        }
    }
}