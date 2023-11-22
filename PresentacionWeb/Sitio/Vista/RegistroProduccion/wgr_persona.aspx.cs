using Common;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            cmb_id_suc.DataValueField = "id_par";
            cmb_id_suc.DataValueField = "desc_param";
            cmb_id_suc.DataBind();
            var itemSeleccioneSucursal = new ListItem { Text = "Seleccione...", Value = string.Empty, Selected = true };
            cmb_id_suc.Items.Add(itemSeleccioneSucursal);

            var lstTipoPersona = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tper);

            cmb_tper.DataSource = lstTipoPersona;
            cmb_tper.DataValueField = "id_par";
            cmb_tper.DataValueField = "desc_param";
            cmb_tper.DataBind();

            var lstSalutacionPersonal = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_sal);

            cmb_id_sal.DataSource = lstSalutacionPersonal;
            cmb_id_sal.DataValueField = "id_par";
            cmb_id_sal.DataValueField = "desc_param";
            cmb_id_sal.DataBind();

            var lstTipoRol = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_rol);

            cmb_id_rol.DataSource = lstTipoRol;
            cmb_id_rol.DataValueField = "id_par";
            cmb_id_rol.DataValueField = "desc_param";
            cmb_id_rol.DataBind();

            var lstTipoDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tdoc);

            cmb_tipodoc.DataSource = lstTipoDocumento;
            cmb_tipodoc.DataValueField = "id_par";
            cmb_tipodoc.DataValueField = "desc_param";
            cmb_tipodoc.DataBind();

            var lstEmisionDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstEmisionDocumento;
            cmb_id_emis.DataValueField = "id_par";
            cmb_id_emis.DataValueField = "desc_param";
            cmb_id_emis.DataBind();
        }

        private void LimpiarFormulario()
        {
            this.id_per.Text = string.Empty;
            this.nomraz.Text = string.Empty;
            this.fechaNacimiento.Text = string.Empty;
            this.nit_fac.Text = string.Empty;

            btnDirecciones.Visible = false;
            btnNuevo.Visible = false;
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
    }
}