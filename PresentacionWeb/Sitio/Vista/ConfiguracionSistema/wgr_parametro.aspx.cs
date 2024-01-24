using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using PresentacionWeb.Sitio.Vista.Login;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wgr_parametro : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.Datos();
            this.btnmodificar.Visible = false;
        }
        protected void Datos()
        {
            try
            {
                this.icolumna.DataSource = logicaConfiguracion.ObtenerListaParametro();
                this.icolumna.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void grdparametro_DataBinding(object sender, EventArgs e)
        {
            List<gr_parametro> lstData = null;
            if (Session["LST_PARAMETRO"] != null)
            {
                lstData = (List<gr_parametro>)Session["LST_PARAMETRO"];
            }
            else
            {
                lstData = logicaConfiguracion.ObtenerLista(icolumna.SelectedValue);
            }

            this.grdparametro.DataSource = lstData;

        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("wgr_parametro.aspx");
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool sw = false;
                string str = "";
                if (string.IsNullOrEmpty(this.columna.Text))
                {
                    str += "<br /> Debe registrar una Columna";
                    sw = true;
                }
                if (string.IsNullOrEmpty(this.desc_param.Text))
                {
                    str += "<br /> Debe registrar una Descripción";
                    sw = true;
                }
                if (string.IsNullOrEmpty(this.abrev_param.Text))
                {
                    str += "<br /> Debe registrar una Abreviación de Descripción";
                    sw = true;
                }
                if (string.IsNullOrEmpty(this.valor_param.Text))
                {
                    str += "<br /> Debe seleccionar un Valor";
                    sw = true;
                }
                if (sw)
                {
                    lblerror.Text = str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    var item = new gr_parametro()
                    {
                        columna = this.columna.Text,
                        desc_param = this.desc_param.Text,
                        abrev_param = this.abrev_param.Text,
                        valor_param = decimal.Parse(this.valor_param.Text),
                        id_par = long.Parse(this.id_para.Value)
                    };

                    logicaConfiguracion.InsertarParametro(item);
                    lblMensajePop.Text = "Parámetro Agregado con éxito al Sistema";
                    popUpConfirmacion.ShowOnPageLoad = true;
                }
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }

        }
        protected void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                logicaConfiguracion.EliminarParametro(long.Parse(this.id_para.Value));
                lblMensajePop.Text = "Parámetro Eliminado";
                popUpConfirmacion.ShowOnPageLoad = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new gr_parametro()
                {
                    columna = this.columna.Text,
                    desc_param = this.desc_param.Text,
                    abrev_param = this.abrev_param.Text,
                    valor_param = decimal.Parse(this.valor_param.Text),
                    id_par = long.Parse(this.id_para.Value)
                };

                logicaConfiguracion.ModificarParametro(item);
                lblMensajePop.Text = "Parámetro Modificado";
                popUpConfirmacion.ShowOnPageLoad = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void icolumna_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<gr_parametro> lstData = null;
                if (Session["LST_PARAMETRO"] != null)
                {
                    lstData = (List<gr_parametro>)Session["LST_PARAMETRO"];
                }
                else
                {
                    lstData = logicaConfiguracion.ObtenerLista(icolumna.SelectedValue);
                }
                this.grdparametro.DataSource = lstData;
                this.grdparametro.DataBind();
                this.grdparametro.Visible = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var objSender = (ImageButton)sender;
                var parametro=logicaConfiguracion.ObtenerParametro(long.Parse(objSender.CommandArgument));

                id_para.Value = parametro.id_par.ToString();
                columna.Text = parametro.columna;
                desc_param.Text = parametro.desc_param;
                abrev_param.Text = parametro.abrev_param;
                valor_param.Text = parametro.valor_param.ToString() ;

                this.btnguardar.Visible = false;
                this.btnmodificar.Visible = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
    }
}