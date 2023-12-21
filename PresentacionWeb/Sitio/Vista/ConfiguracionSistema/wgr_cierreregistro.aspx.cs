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
            var lista=logicaConfiguracion.TablaCierre(anio.SelectedValue);
            if (lista.Count>0)
            {
                gridcierre.DataSource = lista;
                gridcierre.DataBind();
            }
            else{
                popUpValidacion.HeaderText = "Información";
                lblerror.Text= "Debe Registrar una Fecha para apertura de Registro";
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
                    lblerror.Text = "Los siguientes valores deben ser verificados antes de proseguir\n"+str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    //    new gr_cierreregistro()
                    //    {
                    //        mes = this.mes,
                    //        anio = this.anio,
                    //        inireg = this.ini_reg,
                    //        finreg = this.fin_reg,
                    //        tcambio = this.tcambio
                    //    }.InsertarCierre();
                    //    this.lblmensaje.Text = "Cierre de Registro Agregado Satisfactoriamente";
                    //    this.msgboxpanel.Visible = true;
                    //    MessageBoxButton messageBoxButton = new MessageBoxButton("Aceptar");
                    //    messageBoxButton.SetLocation("wgr_cierreregistro.aspx");
                    //    messageBoxButton.SetClass("msg_button_class");
                    //    MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox.tpl"));
                    //    messageBox.SetTitle("Confirmacion");
                    //    messageBox.SetIcon("msg_icon_1.png");
                    //    messageBox.SetMessage("Cierre de Registro Agregado Satisfactoriamente");
                    //    messageBox.AddButton(messageBoxButton.ReturnObject());
                    //    this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                }
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            } 
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    new gr_cierreregistro()
            //    {
            //        finreg = this.fin_reg,
            //        mes = this.mes,
            //        anio = this.anio,
            //        inireg = this.ini_reg,
            //        tcambio = this.tcambio
            //    }.ModificarCierre();
            //    this.lblmensaje.Text = "Cierre de Registro Modificado Satisfactoriamente";
            //    this.msgboxpanel.Visible = true;
            //    MessageBoxButton messageBoxButton = new MessageBoxButton("Aceptar");
            //    messageBoxButton.SetLocation("wgr_cierreregistro.aspx");
            //    messageBoxButton.SetClass("msg_button_class");
            //    MessageBox messageBox = new MessageBox(this.Server.MapPath("msgbox.tpl"));
            //    messageBox.SetTitle("Confirmación");
            //    messageBox.SetIcon("msg_icon_1.png");
            //    messageBox.SetMessage("Cierre de Registro Modificado Satisfactoriamente");
            //    messageBox.AddButton(messageBoxButton.ReturnObject());
            //    this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
            //}
            //catch
            //{
            //}
        }
    }
}