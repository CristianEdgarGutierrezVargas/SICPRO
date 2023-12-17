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
    public partial class wco_comicart : System.Web.UI.Page
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
                this.id_percart.DataSource = logicaConfiguracion.Persona(60);
                this.id_percart.DataTextField = "nomraz";
                this.id_percart.DataValueField = "id_per";
                this.id_percart.DataBind();
                this.id_percart.SelectedValue = "0";
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }



        protected void btnguardar_Click(object sender, EventArgs e)
        {

        }

        protected void id_percart_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listado = logicaConfiguracion.ObtPorcart(id_percart.SelectedValue);
            if (listado.Count <= 0)
            {
                
                this.porcentaje.Value = 0;
                this.factura.Checked = false;
                this.btn_guardar.Enabled = true;
                this.btn_modificar.Enabled = false;
                this.lblmensaje.Text = "La Solicitud no devolvio registros ";
            }
            else
            {
                var item= listado.FirstOrDefault();
                this.porcentaje.Value = item.porcentaje;//dt.Rows[0]["porcentaje"].ToString();
                this.factura.Checked = item.factura;//bool.Parse(dt.Rows[0]["factura"].ToString());
                this.btn_guardar.Enabled = false;
                this.btn_modificar.Enabled = true;
                this.lblmensaje.Text = "Datos Recuperados";
            }
        }
    }
}