using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Logica;
using Logica.Consumo;
using EntidadesClases.ModelSicPro;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wgr_respass : System.Web.UI.Page
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
                this.id_per.DataSource = logicaConfiguracion.ListaPersonaConPass();
                this.id_per.DataTextField = "nomraz";
                this.id_per.DataValueField = "id_per";
                this.id_per.DataBind();
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
                logicaConfiguracion.ResetPassword(this.id_per.SelectedValue);
                this.lblmensaje.Text = "Cambio de Clave realizado con éxito";
                msgboxpanel.Visible = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
    }
}