using Common;
using DevExpress.XtraPrinting;
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
    public partial class wgr_acceso : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.Datos();
        }
        protected void Datos()
        {
            try
            {
                var list= logicaConfiguracion.ListaRoles().OrderBy(x => x.id_par).ToList();
                this.id_rol.DataSource = list;//logicaConfiguracion.ListaRoles().OrderBy(x => x.id_par).ToList();
                this.id_rol.DataTextField = "desc_param";
                this.id_rol.DataValueField = "id_par";
                this.id_rol.DataBind();
                this.id_rol.SelectedValue = "0";

                this.id_com.DataSource = logicaConfiguracion.Componente();
                this.id_com.DataTextField = "desc_comp";
                this.id_com.DataValueField = "id_com";
                this.id_com.DataBind();
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void id_rol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long idRol = long.Parse(this.id_rol.SelectedValue);

                this.lstcomp.DataSource = logicaConfiguracion.ListaComponentesNoAsig(idRol);// (object)grPass.ListaComponentesNoAsig();
                this.lstcomp.DataTextField = "desc_comp";
                this.lstcomp.DataValueField = "id_com";
                this.lstcomp.DataBind();
                this.lstcompo.DataSource = logicaConfiguracion.ListaComponentesAsig(idRol); //(object)grPass.ListaComponentesAsig();
                this.lstcompo.DataTextField = "desc_comp";
                this.lstcompo.DataValueField = "id_com";
                this.lstcompo.DataBind();
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void id_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long idRol = long.Parse(this.id_rol.SelectedValue);
                int idCom = int.Parse(this.id_com.SelectedValue);
                var lisAcceso = logicaConfiguracion.VerificarComponente(idRol, idCom);

                if (lisAcceso.Count > 0)
                    return;

                logicaConfiguracion.InsertarAcceso(idRol, idCom);
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void btnid_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstcomp.SelectedIndex == -1)
                {
                    lblerror.Text = "Seleccione un Elemento de la Lista";
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    long idRol = long.Parse(this.id_rol.SelectedValue);
                    int idCom = int.Parse(this.lstcomp.SelectedValue);
                    logicaConfiguracion.AsignarAccesos(idRol, idCom);
                    Accesos();
                    this.lstcomp.Items.Remove(this.lstcomp.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        private void Accesos()
        {
            try
            {
                long idRol = long.Parse(this.id_rol.SelectedValue);
                this.lstcompo.DataSource = logicaConfiguracion.ListaComponentes(idRol);
                this.lstcompo.DataTextField = "desc_comp";
                this.lstcompo.DataValueField = "id_com";
                this.lstcompo.DataBind();
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void btnti_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = 0; index <= this.lstcomp.Items.Count - 1; ++index)
                {
                    long idRol = long.Parse(this.id_rol.SelectedValue);
                    int idCom = int.Parse(this.lstcomp.Items[index].Value);
                    logicaConfiguracion.AsignarAccesos(idRol, idCom);

                    this.Accesos();
                    this.lstcomp.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void btndi_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstcompo.SelectedIndex == -1)
                {
                    lblerror.Text = "Seleccione un Elemento de la Lista";
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    long idRol = long.Parse(this.id_rol.SelectedValue);
                    long idCom = long.Parse(this.lstcompo.SelectedValue);
                    logicaConfiguracion.QuitarAccesos(idCom, idRol);
                    Accesos();
                }
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void btntd_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = 0; index <= this.lstcompo.Items.Count - 1; ++index)
                {
                    long idRol = long.Parse(this.id_rol.SelectedValue);
                    long idCom = long.Parse(this.lstcompo.Items[index].Value);

                    logicaConfiguracion.QuitarAccesos(idCom, idRol);
                    Accesos();
                }
            }
            catch (Exception ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
    }
}