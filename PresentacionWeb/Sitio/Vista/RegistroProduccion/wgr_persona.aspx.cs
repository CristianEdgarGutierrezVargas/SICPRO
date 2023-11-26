using Common;
using DevExpress.Web.Rendering;
using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wgr_persona1 : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            CargaInicial();
        }

        #region Metodos

        private void CargaInicial()
        {
            btnDirecciones.Visible = false;
            btnNuevo.Visible = false;
            var lstSucursales = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_suc);

            cmb_id_suc.DataSource = lstSucursales;
            cmb_id_suc.ValueField = "id_par";
            cmb_id_suc.TextField = "desc_param";            
            cmb_id_suc.DataBind();
            var itemSeleccioneSucursal = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_id_suc.Items.Add(itemSeleccioneSucursal);

            var lstTipoPersona = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tper);

            cmb_tper.DataSource = lstTipoPersona;
            cmb_tper.ValueField = "id_par";
            cmb_tper.TextField = "desc_param";            
            cmb_tper.DataBind();
            var itemSeleccioneTipoPersona = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0};
            cmb_tper.Items.Add(itemSeleccioneTipoPersona);

            var lstSalutacionPersonal = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_sal);

            cmb_id_sal.DataSource = lstSalutacionPersonal;
            cmb_id_sal.ValueField = "id_par";
            cmb_id_sal.TextField = "desc_param";
            cmb_id_sal.DataBind();
            var itemSeleccioneSalPersonal = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_id_sal.Items.Add(itemSeleccioneSalPersonal);

            var lstTipoRol = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_rol);

            cmb_id_rol.DataSource = lstTipoRol;
            cmb_id_rol.ValueField = "id_par";
            cmb_id_rol.TextField = "desc_param";
            cmb_id_rol.DataBind();
            var itemSeleccioneTipoRol = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_id_rol.Items.Add(itemSeleccioneTipoRol);

            var lstTipoDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tdoc);

            cmb_tipodoc.DataSource = lstTipoDocumento;
            cmb_tipodoc.ValueField = "id_par";
            cmb_tipodoc.TextField = "desc_param";
            cmb_tipodoc.DataBind();
            var itemSeleccioneTipoDocumento = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_tipodoc.Items.Add(itemSeleccioneTipoDocumento);

            var lstEmisionDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstEmisionDocumento;
            cmb_id_emis.ValueField = "id_par";
            cmb_id_emis.TextField = "desc_param";
            cmb_id_emis.DataBind();
            var itemSeleccioneEmisionDocumento = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_id_emis.Items.Add(itemSeleccioneEmisionDocumento);

            var lstPersonas = _objConsumoRegistroProd.ObtenerListaPersona();
            grdPersonas.DataSource = lstPersonas;
            Session["LST_PERSONAS"] = lstPersonas;
            grdPersonas.DataBind();
           
        }

        private void LimpiarFormulario()
        {
            this.id_per.Text = string.Empty;
            this.nomraz.Text = string.Empty;
            this.fechaNacimiento.Text = string.Empty;
            this.nit_fac.Text = string.Empty;
            
            cmb_id_suc.SelectedItem = cmb_id_suc.Items.FindByValue(0);            
            cmb_id_sal.SelectedItem = cmb_id_sal.Items.FindByValue(Convert.ToInt64(0));
            cmb_tipodoc.SelectedItem = cmb_tipodoc.Items.FindByValue(Convert.ToInt64(0));
            cmb_tper.SelectedItem = cmb_tper.Items.FindByValue(Convert.ToInt64(0));
            cmb_id_rol.SelectedItem = cmb_id_rol.Items.FindByValue(Convert.ToInt64(0));
            cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(Convert.ToInt64(0));

            btnDirecciones.Visible = false;
            btnNuevo.Visible = false;
        }

        private void SetFormDatosPersona(string strIdPer)
        {
            var objPersona = _objConsumoRegistroProd.ObtenerPersona(strIdPer);

            id_per.Text = objPersona.id_per;
            nomraz.Text = objPersona.nomraz;

            var itemSucursal = cmb_id_suc.Items.FindByValue(objPersona.id_suc);
            if (itemSucursal != null)
            {
                cmb_id_suc.SelectedItem = itemSucursal;
            }

            var itemTipoPersona = cmb_tper.Items.FindByValue(objPersona.id_tper);
            if (itemTipoPersona != null)
            {
                cmb_tper.SelectedItem = itemTipoPersona;
            }

            fechaNacimiento.Date = objPersona.fechaaniv.Value;

            var itemSal = cmb_id_sal.Items.FindByValue(objPersona.id_sal);
            if (itemSal != null)
            {
                cmb_id_sal.SelectedItem = itemSal;
            }

            var itemTipoRol = cmb_id_rol.Items.FindByValue(objPersona.id_rol);
            if (itemTipoRol != null)
            {
                cmb_id_rol.SelectedItem = itemTipoRol;
            }

            var itemTipoDoc = cmb_tipodoc.Items.FindByValue(objPersona.id_tdoc);
            if (itemTipoDoc != null)
            {
                cmb_tipodoc.SelectedItem = itemTipoDoc;
            }

            var itemEmis = cmb_id_emis.Items.FindByValue(objPersona.id_emis);
            if (itemEmis != null)
            {
                cmb_id_emis.SelectedItem = itemEmis;
            }

            nit_fac.Text = objPersona.nit_fac;
        }
        #endregion

        protected void btnDirecciones_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_direccion.aspx", false); 
            //?var=2141515

            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_direccion.aspx?var=" + id_per.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var strIdPer = id_per.Text;
            if (string.IsNullOrEmpty(strIdPer))
            {
                lblmensaje.Text = "Por favor introduzca el numero de documento";
                return;
            }

            var objPersona = _objConsumoRegistroProd.ObtenerPersona(strIdPer);

            if (objPersona!= null)
            {
                this.id_per.Text = objPersona.id_per;
                this.nomraz.Text = objPersona.nomraz;
                this.fechaNacimiento.Date = objPersona.fechaaniv.Value;
                this.nit_fac.Text = objPersona.nit_fac;
                //this.RTipoPersona(this.id_per.Text);
                //this.RSalutacionPersona(this.id_per.Text);
                //this.id_rol.SelectedValue = dtgeneral.Rows[0]["id_rol"].ToString();
                //this.RTDocPersona(this.id_per.Text);
                //this.RSucPersona(this.id_per.Text);
                //this.REmisionPersona(this.id_per.Text);

                lblmensaje.Text = string.Empty;
                btnNuevo.Visible = true;
                btnDirecciones.Visible = true;
            }
            else
            {
                lblmensaje.Text = "Su busqueda no retorno resultados";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }

        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gr_persona>)Session["LST_PERSONAS"];

            if (lstData != null)
            {
                grdPersonas.DataSource = lstData;
            }
        }

        //protected void Select_Click(object sender, EventArgs e)
        //{
        //    //LinkButton link = sender as LinkButton;
        //    //if (link == null) return;
        //    //GridViewDataItemTemplateContainer container = link.Parent as GridViewDataItemTemplateContainer;
        //    //if (container == null) return;
        //    //GridViewTableDataCell dataCell = container.Parent as GridViewTableDataCell;
        //    //if (dataCell == null) return;
        //    //GridViewTableDataRow row = dataCell.Parent as GridViewTableDataRow;
        //    //if (row == null) return;
        //    //var gridview = (ASPxGridView)row.Parent.Parent.Parent.Parent.Parent.Parent;
        //    //gridview.Selection.UnselectAll();
        //    //gridview.Selection.SelectRow(row.VisibleIndex);
        //}

        protected void gv_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            object str_id_per = e.KeyValue;

            SetFormDatosPersona(Convert.ToString(str_id_per));            

            //https://supportcenter.devexpress.com/Ticket/Details/Q494995/fields-value-in-aspxgridview-on-row-command
            //https://docs.devexpress.com/AspNet/17651/components/grid-view/concepts/filter-data/search-panel
        }

        protected void Grid_SearchPanelEditorCreate(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorCreateEventArgs e)
        {
            //e.Value = "";
            var t = e.Value;
            //e.EditorProperties = new SpinEditProperties();
        }

        protected void grdPersonas_PageIndexChanged(object sender, EventArgs e)
        {
            int currentPage = grdPersonas.PageIndex + 1;
        }

    }
}