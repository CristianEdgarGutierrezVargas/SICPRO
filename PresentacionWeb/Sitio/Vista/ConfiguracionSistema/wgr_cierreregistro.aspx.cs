using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wgr_cierreregistro : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            int year = DateTime.Now.Year;
            Anio();
            anio.SelectedValue = year.ToString();
            Datos();
        }

        private void Anio()
        {
            int year = DateTime.Now.Year;
            anio.Items.Add("SEL. UNA OPCIÓN");
            anio.Items.Add((year - 1).ToString());
            anio.Items.Add(year.ToString());
            anio.Items.Add((year + 1).ToString());
        }

        private void Datos()
        {
            var lista = logicaConfiguracion.TablaCierre(anio.SelectedValue);
            if (lista.Count > 0)
            {
                gridcierre.DataSource = lista;
                gridcierre.DataBind();
            }
            else
            {
                popUpValidacion.HeaderText = "Información";
                lblerror.Text = "Debe Registrar una Fecha para apertura de Registro";
                popUpValidacion.ShowOnPageLoad = true;
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool sw = false;
                string str = string.Empty;
                if (mes.SelectedIndex == -1)
                {
                    str += "Debe registrar un Mes Válido\n";
                    sw = true;
                }
                if (this.anio.SelectedIndex == -1)
                {
                    str += "Debe seleccionar un Año Válido\n";
                    sw = true;
                }
                if (string.IsNullOrEmpty(ini_reg.Text) || ini_reg.Text.Length < 10)
                {
                    str += "Debe seleccionar una Fecha de Inicio\n";
                    sw = true;
                }
                if (sw)
                {
                    popUpValidacion.HeaderText = "Validación de Datos";
                    lblerror.Text = "Los siguientes valores deben ser verificados antes de proseguir\n" + str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    logicaConfiguracion.InsertarCierre(mes.SelectedValue, anio.SelectedValue, (DateTime)ini_reg.Value, (DateTime)fin_reg.Value, (decimal)porcentaje.Value);
                    popUpConfirmacion.HeaderText = "Confirmacion";
                    lblMensaje.Text = "Cierre de Registro Agregado Satisfactoriamente";
                    popUpConfirmacion.ShowOnPageLoad = true;
                }
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
                logicaConfiguracion.ModificarCierre(mes.SelectedValue, anio.SelectedValue, (DateTime)ini_reg.Value, (DateTime)fin_reg.Value, (decimal)porcentaje.Value);
                popUpConfirmacion.HeaderText = "Confirmacion";
                lblMensaje.Text = "Cierre de Registro Modificado Satisfactoriamente";
                popUpConfirmacion.ShowOnPageLoad = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void pnlCallBackCierreRegistro_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            try
            {
                //var datos e.Parameter

                //GridViewRow row = this.gridcierre.Rows[Convert.ToInt32(e.CommandArgument)];
                //if (!(e.CommandName == "Seleccion"))
                //    return;
                //this.msgboxpanel.Visible = false;
                //Label control1 = (Label)row.FindControl("mes");
                //Label control2 = (Label)row.FindControl("anio");
                //Label control3 = (Label)row.FindControl("ini_reg");
                //Label control4 = (Label)row.FindControl("fin_reg");
                //Label control5 = (Label)row.FindControl("tcambio");
                //this.anio.SelectedValue = control2.Text;
                //this.mes.SelectedValue = control1.Text;
                //this.ini_reg.Text = control3.Text;
                //this.fin_reg.Text = control4.Text;
                //this.tcambio.Text = control5.Text;
                //this.btnguardar.Visible = false;
                //this.btnmodificar.Visible = true;
                //popUpConfirmacion.ShowOnPageLoad = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
    }
}